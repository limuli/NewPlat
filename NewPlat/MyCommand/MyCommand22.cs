using NewPlat.BLL;
using NewPlat.Model;
using NewPlat.MyDataSetTableAdapters;
using NewPlat.MySuperSocket;
using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NewPlat.MyCommand
{
    /// <summary>
    /// 检测平台发送测试结果命令
    ///  回复检测平台
    /// </summary>
    public class MyCommand22 : CommandBase<MySession, MyRequestInfo>
    {
        private Dt_MeterInfoTableAdapter Myadapter;
        private DT_ResultTableAdapter Myadapter_r;
        private Dt_PlateInfoTableAdapter Myadapter_p;
        private readonly object obj_22 = new object();
        private DataTable dt = null;
        private MeterInfo tempmeter = null;
        int len;
        int len_every;
        int starti;
        public override string Name
        {
            get
            {
                return "22";
            }
        }
        /// <summary>
        /// 收到检测平台的检测结果
        /// ip+port+cmd+num+(id+AA/55+单项+修改网络参数是否成功+是否是单机)*num
        /// 字节4+2+1+2+(6+1+单项)*n
        /// AA通过；55不合格但修改网络参数成功 
        /// 修改表测试状态为空闲，表对应的检测项结果，表在meterinfo表中
        /// 修改检测平台为空闲
        /// 
        /// 单机操作：1.temper对象，修改对象属性为测试结果 2.判断是否测完 3.未测完，更新meter_test的数据库 4.测完，表移到meter_result中
        /// 1.前提获取测试类型和表类型。
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(MySession session, MyRequestInfo requestInfo)
        {
            lock (obj_22)
            {
                Myadapter = new Dt_MeterInfoTableAdapter();
                Myadapter_r = new DT_ResultTableAdapter();
                Myadapter_p = new Dt_PlateInfoTableAdapter();
                var info = requestInfo;
                string ip = DataHelper.Str2IP(info.Data.Substring(2, 8));
                string port = Convert.ToInt32(info.Data.Substring(10, 4), 16).ToString();
                string cmd_isauto = info.Data.Substring(14, 1);
                string cmd_type = info.Data.Substring(15, 1);
                int num = Convert.ToInt32(info.Data.Substring(16, 4), 16);
                StringBuilder info_sb = new StringBuilder();
                info_sb.Append("22");
                info_sb.Append(info.Data.Substring(16, 4));
                switch (cmd_type)
                {
                    //膜式表
                    case "1":
                        len = 24;
                        len_every = 10;
                        starti = 0;
                        break;
                    //IC
                    case "2":
                        len = 18;
                        len_every = 4;
                        starti = 10;
                        break;
                        //命令
                    case "3":
                        len = 20;
                        len_every = 6;
                        starti = 14;
                        break;
                        //终检
                    case "4":
                        len = 26;
                        len_every = 12;
                        starti = 20;
                        break;
                }
                for (int i = 0; i < num; i++)
                {
                    string id = info.Data.Substring(20 + i * len, 12);
                    string result = info.Data.Substring(32 + i * len, 2);
                    string re_every = info.Data.Substring(34 + i * len, len_every);
                    info_sb.Append(id);
                    bool is_danji = re_every.Substring(len_every - 2, 1).Equals("1") ? true : false;                                        
                    bool isscu = re_every.Substring(re_every.Length - 1, 1).Equals("A") ? true : false;
                    try
                    {
                        dt = Myadapter.GetDataBy1(id);
                        tempmeter = DataHelper.Dt2Ob(dt);
                        if (tempmeter == null)
                        {
                            dt = Myadapter_r.GetDataBy_r(id, "合格", "初始","失败");
                            tempmeter = DataHelper.Dt2Ob(dt);
                        }
                    }
                    catch (Exception e)
                    {
                        info_sb.Append("55");
                        LogHelper.Error("数据库连接异常" + e);
                    }
                    if (tempmeter != null)
                    {
                        //更新单项测试结果
                        StringBuilder re_ev = new StringBuilder(tempmeter.MeterEvery);
                        string oldchar = tempmeter.MeterEvery.Substring(starti, len_every);
                        re_ev.Replace(oldchar, re_every, starti, len_every);
                        tempmeter.MeterEvery = re_ev.ToString();
                        DateTime dtime = DateTime.Now;
                        tempmeter.MeterTime = dtime;
                        if (!is_danji)
                        {
                            string re = tempmeter.Meteriport;
                            string[] tip = re.Split('@');
                            tempmeter.MeterTest = "空闲";
                            if (result.Equals("AA"))
                            {
                                string st = "合格";
                                if (Xiugai(tip, st, tempmeter.MeterCancel, true, isscu, is_danji))
                                    info_sb.Append("AA");
                                else info_sb.Append("55");
                            }
                            else if (result.Equals("55"))
                            {
                                string st = "不合格";
                                if (Xiugai(tip, st, tempmeter.MeterCancel, false, isscu, is_danji))
                                    info_sb.Append("AA");
                                else info_sb.Append("55");
                            }
                            else LogHelper.Info("错误的22命令");
                        }
                        else
                        {
                            string type = "";
                            switch (cmd_type)
                            {
                                case "1":
                                    tempmeter.MeterChuState = result.Equals("AA") ? "合格" : "不合格";
                                    type = "chu";
                                    break;
                                case "2":
                                    tempmeter.MeterIcState = result.Equals("AA") ? "合格" : "不合格";
                                    type = "ic";
                                    break;
                                case "3":
                                    tempmeter.MeterComState = result.Equals("AA") ? "合格" : "不合格";
                                    type = "com";
                                    break;
                                case "4":
                                    tempmeter.MeterZhongState = result.Equals("AA") ? "合格" : "不合格";
                                    type = "zho";
                                    break;
                            }
                            bool is_complete = tempmeter.MeterChuState.Equals("待测") || tempmeter.MeterIcState.Equals("待测") || tempmeter.MeterComState.Equals("待测") || tempmeter.MeterZhongState.Equals("待测") ? false : true;
                            if(Up_Dj(tempmeter, is_complete, type))
                                info_sb.Append("AA");
                            else info_sb.Append("55");
                        }                   
                    }
                    else {
                        info_sb.Append("55");
                        LogHelper.Info("表具不在检测列表中");
                    }                   
                    Thread.Sleep(100);
                }
                try
                {
                    IPAddress Ip = IPAddress.Parse(ip);
                    int Port = Convert.ToInt32(port);
                    string send22 = DownCommond.GenerateSendFrame(info_sb.ToString(), info, false, false);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(Ip, Port);
                    socket.Send(DataHelper.Str2Byte(send22));
                    socket.Close();
                    LogHelper.Info("回复22：" + send22);
                }
                catch (Exception e)
                {
                    LogHelper.Error("回复22命令连接检测平台异常"+e);
                    LogHelper.Info("检测平台通信异常");
                }

                //更新界面
                CommonFunction.platm.ChangeMeter();
                CommonFunction.platm.ChangePlat();
                CommonFunction.platm.ChangeBHG();
                Thread.Sleep(500);
            }           
        }

        private bool Up_Dj(MeterInfo tempmeter, bool is_complete,string type)
        {
            try
            {
                if (is_complete)
                {
                    tempmeter.MeterState = tempmeter.MeterChuState.Equals("不合格") || tempmeter.MeterIcState.Equals("不合格") || tempmeter.MeterComState.Equals("不合格") || tempmeter.MeterZhongState.Equals("不合格") ? "不合格" : "完成";
                    Myadapter_r.InsertMeter(
                                     tempmeter.MeterId,
                                     tempmeter.MeterType,
                                     tempmeter.MeterComState,
                                     tempmeter.MeterIcState,
                                     tempmeter.MeterChuState,
                                     tempmeter.MeterZhongState,
                                     tempmeter.MeterState,
                                     tempmeter.MeterTest,
                                     tempmeter.MeterRand_num,
                                     tempmeter.Meteriport,
                                     tempmeter.MeterTime,
                                     tempmeter.MeterCancel,
                                     tempmeter.MeterEvery,
                                     tempmeter.MeterPrivilege,
                                     tempmeter.CheckTime,
                                     tempmeter.ManufactureName_id,
                                     tempmeter.Subtime);
                    Myadapter.DeleteMeter(tempmeter.MeterId);
                }
                else
                {
                    Up_test(tempmeter, type);
                }
                return true;
            }
            catch (Exception )
            {
                LogHelper.Info("单机测试结果更新失败：" + tempmeter.MeterId);
                return false;
            }
            
        }

        /// <summary>
        /// 更新数据到meter_test中
        /// </summary>
        /// <param name="tempmeter"></param>
        /// <param name="type"></param>
        private void Up_test(MeterInfo tempmeter, string type)
        {
            try
            {
                switch (type)
                {
                    case "com":
                        Myadapter.UpdateMeterCom(
                               tempmeter.MeterComState,
                               tempmeter.MeterTest,
                               tempmeter.MeterTime,
                               tempmeter.MeterEvery,
                               tempmeter.MeterId);
                        break;
                    case "ic":
                        Myadapter.UpdateMeterIc(
                               tempmeter.MeterIcState,
                               tempmeter.MeterTest,
                               tempmeter.MeterTime,
                               tempmeter.MeterEvery,
                               tempmeter.MeterId);
                        break;
                    case "chu":
                        Myadapter.UpdateMeterChu(
                               tempmeter.MeterChuState,
                               tempmeter.MeterTest,
                               tempmeter.MeterTime,
                               tempmeter.MeterEvery,
                               tempmeter.MeterId);
                        break;
                    case "zho":
                        Myadapter.UpdateMeterZho(
                               tempmeter.MeterZhongState,
                               tempmeter.MeterTest,
                               tempmeter.MeterTime,
                               tempmeter.MeterEvery,
                               tempmeter.MeterId);
                        break;
                }
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        private Boolean Xiugai(string[] s, string state,string cancel,Boolean ishege,bool issuc,bool isdanji)
        {
            try
            {
                switch (s[3])
                {
                    case "PlatComs":
                        Myadapter_p.UpdatePlatCom("空闲", int.Parse(s[0]));
                        tempmeter.MeterComState = state;
                        Caozuo(cancel, ishege, issuc,"com");
                        break;
                    case "PlatIcs":
                        Myadapter_p.UpdatePlatIc("空闲", int.Parse(s[0]));
                        tempmeter.MeterIcState = state;
                        Caozuo(cancel, ishege, issuc,"ic");
                        break;
                    case "PlatChus_msb":
                        Myadapter_p.UpdatePlatChu_msb("空闲", int.Parse(s[0]));
                        tempmeter.MeterChuState = state;
                        Caozuo(cancel, ishege, issuc,"chu");
                        break;
                    case "PlatChus_xzy":
                        Myadapter_p.UpdatePlatChu_xzy("空闲", int.Parse(s[0]));
                        tempmeter.MeterChuState = state;
                        Caozuo(cancel, ishege, issuc,"chu");
                        break;
                    case "PlatChus_csb":
                        Myadapter_p.UpdatePlatChu_csb("空闲", int.Parse(s[0]));
                        tempmeter.MeterChuState = state;
                        Caozuo(cancel, ishege, issuc,"chu");
                        break;
                    case "PlatZhos":
                        Myadapter_p.UpdatePlatZho("空闲", int.Parse(s[0]));
                        tempmeter.MeterZhongState = state;
                        Caozuo(cancel, ishege, issuc,"zho");
                        break;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
        /// <summary>
        /// 不合格先按合格的更新然后判断是否成功修改网络参数
        /// 否的话再移入到result表中，后面待测的改为失败
        /// </summary>
        /// <param name="cancel"></param>
        /// <param name="ishege"></param>
        /// <param name="type"></param>
        private void Caozuo(string cancel,Boolean ishege,bool isscu, string type) {
            try
            {
                if (cancel.Equals("否"))
                {
                    tempmeter.MeterState = ishege ? "合格" : "不合格";
                    Up_test(tempmeter,type);
                    if (!ishege && !isscu)
                    {
                        tempmeter.MeterState = "不合格";
                        tempmeter.MeterComState = tempmeter.MeterComState.Equals("待测") ? "失败" : tempmeter.MeterComState;
                        tempmeter.MeterIcState = tempmeter.MeterIcState.Equals("待测") ? "失败" : tempmeter.MeterIcState;
                        tempmeter.MeterChuState = tempmeter.MeterChuState.Equals("待测") ? "失败" : tempmeter.MeterChuState;
                        tempmeter.MeterZhongState = tempmeter.MeterComState.Equals("待测") ? "失败" : tempmeter.MeterZhongState;
                        Myadapter_r.InsertMeter(
                                tempmeter.MeterId,
                                tempmeter.MeterType,
                                tempmeter.MeterComState,
                                tempmeter.MeterIcState,
                                tempmeter.MeterChuState,
                                tempmeter.MeterZhongState,
                                tempmeter.MeterState,
                                tempmeter.MeterTest,
                                tempmeter.MeterRand_num,
                                tempmeter.Meteriport,
                                tempmeter.MeterTime,
                                tempmeter.MeterCancel,
                                tempmeter.MeterEvery,
                                tempmeter.MeterPrivilege,
                                tempmeter.CheckTime,
                                tempmeter.ManufactureName_id,
                                tempmeter.Subtime);
                        Myadapter.DeleteMeter(tempmeter.MeterId);
                    }
                }                
                else
                {
                    Myadapter_r.Update_d_state(
                        tempmeter.MeterComState,
                        tempmeter.MeterIcState,
                        tempmeter.MeterChuState,
                        tempmeter.MeterZhongState,
                        tempmeter.MeterState,
                        tempmeter.MeterTime,
                        tempmeter.MeterTest,
                        tempmeter.MeterEvery,
                        tempmeter.MeterId);
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }

        /// <summary>
        /// 给ll发消息，单项测试完成？
        /// </summary>
        /// <param name="cmd"></param>
        private async void PostLl(string cmd)
        {
            try
            {
                List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>>();
                param.Add(new KeyValuePair<string, string>("rtr", cmd));
                string x = await CommonFunction.hs.PostSend("http://192.168.3.137:8000/rtr/", param);
                //Debug.Print(x);
            }
            catch (Exception we)
            {
                LogHelper.Error("22命令推送进度" + we);
            }
            
        }

    }
}