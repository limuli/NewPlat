using NewPlat.BLL;
using NewPlat.Model;
using NewPlat.MyDataSetTableAdapters;
using NewPlat.MySuperSocket;
using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace NewPlat.MyCommand
{
    /// <summary>
    /// 检测平台恢复准备命令
    /// </summary>
   public class MyCommand33 : CommandBase<MySession, MyRequestInfo>
    {
        private Dt_MeterInfoTableAdapter Myadapter;
        private DT_ResultTableAdapter Myadapter_r;
        private Dt_PlateInfoTableAdapter Myadapter_p;
        private static readonly object obj_33 = new object();
        private DataTable dt = new DataTable();
        private MeterInfo tempmeter = new MeterInfo();
        public override string Name
        {
            get
            {
                return "33";
            }
        }
        /// <summary>
        /// 检测平台连接表后回复命令
        /// (id ，IP，port)+结果（AA/55/66）
        /// 表没有正确修改，检测平台要回复没有修改成功
        /// 修改成功（表在meterinfo中），表test=正测，检测平台 = 正忙
        /// 修改失败（表在meterinfo中（表移入到meterfail中，State=失败），表在meterfail中（不用管））检测平台=空闲
        /// 解析失败（表在meterinfo中，后把表的测试状态改为空闲，延迟15s检测平台的状态改为空闲）
        ///
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(MySession session, MyRequestInfo requestInfo)
        {
            lock (obj_33)
            {
                Myadapter = new Dt_MeterInfoTableAdapter();
                Myadapter_r = new DT_ResultTableAdapter();
                Myadapter_p = new Dt_PlateInfoTableAdapter();
                var info = requestInfo;
                string result = info.Data.Substring(26, 2);
                try
                {
                    dt = Myadapter.GetDataBy1(info.EquipmentID);
                    tempmeter = DataHelper.Dt2Ob(dt);
                    if (tempmeter == null)
                    {
                        dt = Myadapter_r.GetDataBy_r(info.EquipmentID, "合格", "初始","初始");
                        tempmeter = DataHelper.Dt2Ob(dt);
                    }
                }
                catch (Exception)
                {
                    LogHelper.Error("数据库连接异常");
                }
                switch (result)
                {
                    case "AA":
                        if (tempmeter != null)
                        {
                            DateTime dtime2 = DateTime.Now;
                            tempmeter.MeterTime = dtime2;
                            tempmeter.MeterTest = "正测";
                            if (tempmeter.MeterCancel.Equals("合格"))
                                Myadapter_r.Update_wait(tempmeter.MeterTest, tempmeter.MeterRand_num, tempmeter.MeterTime, tempmeter.MeterState, tempmeter.MeterId);
                            else Myadapter.UpdateMeterTest2(tempmeter.MeterTime, tempmeter.MeterTest, tempmeter.MeterId);
                            //修改检测平台=正忙     
                            Thread.Sleep(100);
                            Xiugai(tempmeter, "正忙");
                        }
                        else
                        {
                            LogHelper.Info("错误的33命令1");
                        }
                        break;
                    case "55":
                        if (tempmeter != null)
                        {

                            if (tempmeter.MeterCancel.Equals("否"))
                            {
                                tempmeter.MeterState = "失败";
                                tempmeter.MeterComState = tempmeter.MeterComState.Equals("待测") ? "失败" : tempmeter.MeterComState;
                                tempmeter.MeterIcState = tempmeter.MeterIcState.Equals("待测") ? "失败" : tempmeter.MeterIcState;
                                tempmeter.MeterChuState = tempmeter.MeterChuState.Equals("待测") ? "失败" : tempmeter.MeterChuState;
                                tempmeter.MeterZhongState = tempmeter.MeterComState.Equals("待测") ? "失败" : tempmeter.MeterZhongState;
                                Myadapter_r.InsertMeter(tempmeter.MeterId,
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
                            CommonFunction.platm.ChangeBHG();
                            Xiugai(tempmeter, "空闲");
                        }
                        else
                        {
                            dt = Myadapter_r.GetDataBy_r(info.EquipmentID, "失败", "失败","失败");
                            tempmeter = DataHelper.Dt2Ob(dt);
                            if (tempmeter != null)
                            {
                                Thread.Sleep(3 * 1000);
                                Xiugai(tempmeter, "空闲");
                            }
                            else
                            {
                                LogHelper.Info("此表具不再任何检测表中");
                            }
                        }
                        break;
                    case "66":
                        if (tempmeter.MeterCancel.Equals("否"))
                        {
                            DateTime dtime = DateTime.Now;
                            tempmeter.MeterTime = dtime;
                            tempmeter.MeterTest = "空闲";
                            Myadapter.UpdateMeterTest2(tempmeter.MeterTime, tempmeter.MeterTest, tempmeter.MeterId);
                            Thread.Sleep(15 * 1000);
                            string s = "空闲";
                            Xiugai(tempmeter, s);
                        }
                        break;
                    default:
                        LogHelper.Info("错误的33命令");
                        break;
                }
                //更新界面
                CommonFunction.platm.ChangeMeter();
                CommonFunction.platm.ChangePlat();
            }                  
        }
        private void Xiugai(MeterInfo temp,string state) {
            string re = temp.Meteriport;
            string[] tip = re.Split('@');
            switch (tip[3])
            {
                case "PlatComs":
                    Myadapter_p.UpdatePlatCom(state, int.Parse(tip[0]));
                    break;
                case "PlatIcs":
                    Myadapter_p.UpdatePlatIc(state, int.Parse(tip[0]));
                    break;
                case "PlatChus_msb":
                    Myadapter_p.UpdatePlatChu_msb(state, int.Parse(tip[0]));
                    break;
                case "PlatComs_xzy":
                    Myadapter_p.UpdatePlatChu_xzy(state, int.Parse(tip[0]));
                    break;
                case "PlatComs_csb":
                    Myadapter_p.UpdatePlatChu_csb(state, int.Parse(tip[0]));
                    break;
                case "PlatZhos":
                    Myadapter_p.UpdatePlatZho(state, int.Parse(tip[0]));
                    break;
            }
        }
        /// <summary>
        /// 给ll发消息，正测？
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
                LogHelper.Error("33命令推送进度" + we);
            }
           
        }
    }
}