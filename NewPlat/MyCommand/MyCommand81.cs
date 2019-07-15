using NewPlat.BLL;
using NewPlat.Model;
using NewPlat.MyDataSetTableAdapters;
using NewPlat.MySuperSocket;
using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPlat.MyCommand
{
    public class MyCommand81 : CommandBase<MySession, MyRequestInfo>
    {
        private Dt_MeterInfoTableAdapter Myadapter;
        private DT_ResultTableAdapter Myadapter_r;
        public static Object obj2 = new object();
        public override string Name
        {
            get
            {
                return "81";
            }
        }
        /// <summary>
        /// 上行81命令
        /// 测试完成，修改正式域名（此时表state为成功,Test为就绪）从metersuccess中查找
        /// 准备去检测平台测试（此时表的state为初始，test状态为准备）从meterinfo中查找
        /// 判断表的修改网络参数是否成功？（这里要考虑数据库更新的IP port是否在+81之前
        /// 不在这里判断修改网络参数若检测平台没有回复，就不能排除是表的问题了）
        /// 让这个线程休眠500ms来等待数据库操作
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(MySession session, MyRequestInfo requestInfo)
        {
            lock (obj2)
            {
                Myadapter = new Dt_MeterInfoTableAdapter();
                Myadapter_r = new DT_ResultTableAdapter();
                DataTable dt = new DataTable();
                MeterInfo tempmeter = new MeterInfo();
                bool issuccess = false;
                Thread.Sleep(1000);
                var info = requestInfo;
                try
                {
                    dt = Myadapter.GetDataBy1(info.EquipmentID);
                    if (dt != null && dt.Rows.Count > 0)
                        tempmeter = DataHelper.Dt2Ob(dt);
                    else
                    {
                        dt = Myadapter_r.GetDataBy_r(info.EquipmentID,"合格","初始","初始");
                        tempmeter = DataHelper.Dt2Ob(dt);
                        issuccess = true;
                    }
                }
                catch (Exception e)
                {
                    LogHelper.Error("数据库连接异常" +e);
                }                
                if (tempmeter != null)
                {
                    DateTime dtime = DateTime.Now;
                    tempmeter.MeterTime = dtime;
                    string IP = DataHelper.Str2IP(info.Data.Substring(4, 8));
                    string port = Convert.ToInt32(info.Data.Substring(12, 4), 16).ToString();
                    string domain = Encoding.ASCII.GetString(DataHelper.SplitArray(DataHelper.Str2Byte(info.Data), 8, 32));
                    //修改到正式服务器的表，不需检测网络修改功能
                    if (issuccess)
                    {
                        if ((tempmeter.MeterState.Equals("合格") || (tempmeter.MeterCancel.Equals("合格") && tempmeter.MeterState.Equals("初始"))) && tempmeter.MeterTest.Equals("就绪"))
                        {
                            string send0F = S0f(info.EquipmentType, info);
                            if (send0F.Equals("0"))
                            {
                                LogHelper.Info("设备类型不是标准值");
                            }
                            else
                            {
                                //of不需要发送
                                ArraySegment<byte> f0 = new ArraySegment<byte>(DataHelper.Str2Byte(send0F));
                                session.Send(f0);
                                LogHelper.Info("发送命令" + send0F);
                                tempmeter.MeterState = "完成";
                                tempmeter.MeterTest = "空闲";
                                Myadapter_r.Update_wait(tempmeter.MeterTest, tempmeter.MeterRand_num, tempmeter.MeterTime, tempmeter.MeterState,tempmeter.MeterId);
                            }
                        }
                        else if (tempmeter.MeterCancel.Equals("合格")&& tempmeter.MeterState.Equals("初始") && tempmeter.MeterTest.Equals("准备"))
                        {
                            tempmeter.MeterTest = "特殊";
                            string ip = CommonFunction.dicBooks["strMainHostIP"];
                            string port2 = CommonFunction.dicBooks["strMainHostPort"];
                            //下发81，修改回来，修改状态为就绪，下次上传81时再修改正式域     
                            string send813 = DownCommond.GenerateSendFrame(DownCommond.GenerateCore81(ip, port2, false, "", tempmeter.MeterRand_num), info, false, true);
                            ArraySegment<byte> f23 = new ArraySegment<byte>(DataHelper.Str2Byte(send813));
                            session.Send(f23);
                            LogHelper.Info("发送命令81" + send813);
                            Myadapter_r.Update_wait(tempmeter.MeterTest,tempmeter.MeterRand_num ,tempmeter.MeterTime, tempmeter.MeterState,tempmeter.MeterId);
                        }
                        else if (tempmeter.MeterState.Equals("初始") && tempmeter.MeterTest.Equals("特殊"))
                        {
                            tempmeter.MeterTest = "准备";                            
                            string send8E = DownCommond.GenerateSendFrame(DownCommond.GenerateCore8E(tempmeter.MeterRand_num), info, false, false);
                            ArraySegment<byte> f2 = new ArraySegment<byte>(DataHelper.Str2Byte(send8E));
                            session.Send(f2);
                            LogHelper.Info("发送命令" + send8E);
                            Myadapter_r.Update_wait(tempmeter.MeterTest, tempmeter.MeterRand_num, tempmeter.MeterTime, tempmeter.MeterState, tempmeter.MeterId);
                        }                                
                    }
                    else if (tempmeter.MeterState.Equals("初始") && tempmeter.MeterTest.Equals("准备") && !issuccess)
                    {
                        string re = tempmeter.Meteriport;
                        string[] tip = re.Split('@');
                        //修改网络参数成功
                        if (tip[1].Equals(IP) && tip[2].Equals(port))
                        {
                            string send0F = S0f(info.EquipmentType, info);
                            if (send0F.Equals("0"))
                            {
                                LogHelper.Info("设备类型不是标准值");
                            }
                            else
                            {
                                ArraySegment<byte> f0 = new ArraySegment<byte>(DataHelper.Str2Byte(send0F));
                                session.Send(f0);
                                LogHelper.Info("发送命令" + send0F);
                                tempmeter.MeterTest = "就绪";
                                Myadapter.UpdateMeterTest2(tempmeter.MeterTime, tempmeter.MeterTest, tempmeter.MeterId);
                            }
                        }
                        else
                        {
                            //修改网络参数失败
                            //下发8e休眠，并将其移到测试失败的表中
                            //检测平台将收不到表，会回复33没有连上的命令，需要在33哪里修改检测平台的状态为空闲
                            tempmeter.MeterState = "失败";
                            tempmeter.MeterTest = "空闲";
                            LogHelper.Info("网络参数未正确修改到检测平台");
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
                            CommonFunction.platm.ChangeSB();                            
                        }
                    }
                    else
                    {
                        LogHelper.Info("分配逻辑出错");
                    }
                    //更新界面
                    CommonFunction.platm.ChangeMeter();
                    CommonFunction.platm.ChangePlat();
                    CommonFunction.platm.ChangeHG();
                }
                else
                {
                    LogHelper.Info("表不再检测列表中");
                }
            }
        }
        private string S0f(string EquipmentType, MyRequestInfo info)
        {
            string send0F = "0";
            if (EquipmentType.Equals("00") || EquipmentType.Equals("20"))
            {
                send0F = DownCommond.GenerateSendFrame(DownCommond.GenerateCore0F("0F",3 , 2), info, true, true);
            }
            else if (EquipmentType.Equals("01") || EquipmentType.Equals("21"))
            {
                send0F = DownCommond.GenerateSendFrame(DownCommond.GenerateCore0F("1F",3,2), info, true, true);;
            }
            else if (EquipmentType.Equals("51"))
            {
                send0F = DownCommond.GenerateSendFrame(DownCommond.GenerateCore0F("5F",3,2), info, true, true);
            }
            return send0F;
        }
    }
}
