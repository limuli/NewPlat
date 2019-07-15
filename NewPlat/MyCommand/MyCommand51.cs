using NewPlat.BLL;
using NewPlat.Model;
using NewPlat.MyDataSetTableAdapters;
using NewPlat.MySuperSocket;
using SuperSocket.SocketBase.Command;
using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace NewPlat.MyCommand
{
    public class MyCommand51 : CommandBase<MySession, MyRequestInfo>
    {
        private Dt_MeterInfoTableAdapter Myadapter;
        private DT_ResultTableAdapter Myadapter_r;
        private Dt_Chu_csbTableAdapter Myadapter_csb;
        private Dt_Chu_xzyTableAdapter Myadapter_xzy;
        private Dt_Chu_msbTableAdapter Myadapter_msb;
        private Dt_IcTableAdapter Myadapter_Ic;
        private Dt_MPTableAdapter Myadapter_Mp;
        private Dt_PlateInfoTableAdapter Myadapter_p;
        private DataTable dt = new DataTable();
        private DataTable dt_temp = new DataTable();
        private MeterInfo tempmeter = new MeterInfo();
        public static Object obj = new object();
        public override string Name
        {
            get
            {
                return "51";
            }
        }
        /// <summary>
        /// tempi为表具在meterinfos的索引号
        /// tempmeter为收到请求的表具
        /// 调用logical中的函数来安排
        /// 将成功或失败的表移到成功和失败的表中，8E的时候从这两个表中查询
        /// 判断表具恢复出厂设置功能是否成功（8E）()
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(MySession session, MyRequestInfo requestInfo)
        {
            lock (obj)
            {
                Myadapter = new Dt_MeterInfoTableAdapter();
                Myadapter_r = new DT_ResultTableAdapter();
                Myadapter_csb = new Dt_Chu_csbTableAdapter();
                Myadapter_xzy = new Dt_Chu_xzyTableAdapter();
                Myadapter_msb = new Dt_Chu_msbTableAdapter();
                Myadapter_Ic = new Dt_IcTableAdapter();
                Myadapter_Mp = new Dt_MPTableAdapter();
                Myadapter_p = new Dt_PlateInfoTableAdapter();                
                bool ishavepri = false;
                Boolean flag_sen = true;
                Boolean flag_xiu = true;
                Boolean flag_xinx = true;
                var info = requestInfo;
                DateTime dtime2 = DateTime.Now;
                //LogHelper.Error(dtime2 + "  " + info.EquipmentID + "  " + info.Key + "获取锁");
                try
                {
                    dt = Myadapter.GetDataBy1(info.EquipmentID);
                    if (Myadapter.SQ_Privilege("1") != 0)
                        ishavepri = true;
                }
                catch (Exception e)
                {
                    LogHelper.Info("数据库连接异常90" + e);
                }
                tempmeter = DataHelper.Dt2Ob(dt);
                if (tempmeter != null)
                {
                    //随机数与datetime
                    tempmeter.MeterRand_num = info.Data.Substring(52, 8);
                    DateTime dtime = DateTime.Now;
                    tempmeter.MeterTime = dtime;
                    switch (tempmeter.MeterState)
                    {
                        case "完成":
                            //如果表上传，说明恢复出厂设置不成功
                            XiugaiSF(tempmeter, session, info);
                            break;
                        case "失败":
                            //不可能一旦失败表就会移入到meterfail表中
                            break;
                        case "不合格":
                            //不可能一旦失败表就会移入到meterfail表中
                            break;
                        case "合格":
                            //免检产品
                            Xiugaisuc(tempmeter, session, info);
                            break;
                        case "初始":
                            //查询测量标志位
                            if (tempmeter.MeterTest.Equals("正测") || tempmeter.MeterTest.Equals("准备") || tempmeter.MeterTest.Equals("就绪"))
                            {
                                //更新随机数
                                //下发5F
                                string send0F = DownCommond.GenerateSendFrame(DownCommond.GenerateCore0F("5F", 2, 1), info, true, true);
                                ArraySegment<byte> f0 = new ArraySegment<byte>(DataHelper.Str2Byte(send0F));
                                session.Send(f0);
                                LogHelper.Info("发送命令4" + send0F);
                                Myadapter.UpdateRand_num(tempmeter.MeterRand_num, tempmeter.MeterId);
                            }
                            else if (tempmeter.MeterTest.Equals("空闲"))
                            {
                                //安排分                       
                                string[] re = Logical.Meter_AnPai(tempmeter,ishavepri);
                                //LogHelper.Error(tempmeter.MeterId + re[1]);
                                //返回2222代表此表合格，其需要回复出厂设置并修改到正式服务器
                                if (re[1].Equals("成功"))
                                {
                                    Xiugaisuc(tempmeter, session, info);
                                }
                                //返回3333代表此表的所有测试都失败
                                else if (re[1].Equals("失败"))
                                {
                                    //Xiugaifai(tempmeter, session, info);
                                }
                                //返回安排的结果
                                else if (!re[1].Equals("空"))
                                {
                                    //获取对应的IP与port                                                          
                                    //下发8f与81命令
                                    //并向检测平台下发33命令                                   
                                    //修改表的测试状态为准备2
                                    //修改检测平台的测试状态为就绪
                                    //保存表对应检测平台的IP与port                                                                        
                                    try
                                    {
                                        IPAddress ip = IPAddress.Parse(re[1]);
                                        int port = Convert.ToInt32(re[2]);
                                        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                        socket.Connect(ip, port);
                                        string send34 = null;
                                        try
                                        {
                                            switch (re[3])
                                            {
                                                case "PlatComs":
                                                    string typee = "";
                                                    if (tempmeter.MeterType.Equals("膜式表"))
                                                    {
                                                        dt_temp = Myadapter_msb.GetData(tempmeter.MeterId);
                                                        typee = "msb";
                                                    }
                                                    else if (tempmeter.MeterType.Equals("修正仪"))
                                                    {
                                                        dt_temp = Myadapter_xzy.GetData(tempmeter.MeterId);
                                                        typee = "xzy";
                                                    }
                                                    else if (tempmeter.MeterType.Equals("超声波"))
                                                    {
                                                        dt_temp = Myadapter_csb.GetData(tempmeter.MeterId);
                                                        typee = "csb";
                                                    }
                                                    send34 = DownCommond.GenerateSendFrame(DownCommond.GenerateCore33(tempmeter.MeterId) + DownCommond.GenerateCore34_Com(dt_temp, typee), info, false, false);
                                                    if (Convert.ToInt64(Myadapter_Mp.SQ_MP(tempmeter.MeterId)) == 0)
                                                        Myadapter_Mp.Insert_MP(tempmeter.MeterId, re[0], "-1", "-1", "-1");
                                                    else Myadapter_Mp.Update_MP_Com(re[0], tempmeter.MeterId);
                                                    Myadapter_p.UpdatePlatCom("就绪", int.Parse(re[0]));
                                                    break;
                                                case "PlatIcs":
                                                    dt_temp = Myadapter_Ic.GetData(tempmeter.MeterId);
                                                    send34 = DownCommond.GenerateSendFrame(DownCommond.GenerateCore33(tempmeter.MeterId) + DownCommond.GenerateCore34_Ic(dt_temp), info, false, false);
                                                    if (Convert.ToInt64(Myadapter_Mp.SQ_MP(tempmeter.MeterId)) == 0)
                                                        Myadapter_Mp.Insert_MP(tempmeter.MeterId, "-1", re[0], "-1", "-1");
                                                    else Myadapter_Mp.Update_MP_IC(re[0], tempmeter.MeterId);
                                                    Myadapter_p.UpdatePlatIc("就绪", int.Parse(re[0]));
                                                    break;
                                                case "PlatChus_msb":
                                                    dt_temp = Myadapter_msb.GetData(tempmeter.MeterId);
                                                    send34 = DownCommond.GenerateSendFrame(DownCommond.GenerateCore33(tempmeter.MeterId) + DownCommond.GenerateCore34_Chu_msb(dt_temp), info, false, false);
                                                    if (Convert.ToInt64(Myadapter_Mp.SQ_MP(tempmeter.MeterId)) == 0)
                                                        Myadapter_Mp.Insert_MP(tempmeter.MeterId, "-1", "-1", re[0], "-1");
                                                    else Myadapter_Mp.Update_MP_Chu(re[0], tempmeter.MeterId);
                                                    Myadapter_p.UpdatePlatChu_msb("就绪", int.Parse(re[0]));
                                                    break;
                                                case "PlatChus_xzy":
                                                    dt_temp = Myadapter_xzy.GetData(tempmeter.MeterId);
                                                    send34 = DownCommond.GenerateSendFrame(DownCommond.GenerateCore33(tempmeter.MeterId) + DownCommond.GenerateCore34_Chu_xzy(dt_temp), info, false, false);
                                                    if (Convert.ToInt64(Myadapter_Mp.SQ_MP(tempmeter.MeterId)) == 0)
                                                        Myadapter_Mp.Insert_MP(tempmeter.MeterId, "-1", "-1", re[0], "-1");
                                                    else Myadapter_Mp.Update_MP_Chu(re[0], tempmeter.MeterId);
                                                    Myadapter_p.UpdatePlatChu_xzy("就绪", int.Parse(re[0]));
                                                    break;
                                                case "PlatChus_csb":
                                                    dt_temp = Myadapter_csb.GetData(tempmeter.MeterId);
                                                    send34 = DownCommond.GenerateSendFrame(DownCommond.GenerateCore33(tempmeter.MeterId) + DownCommond.GenerateCore34_Chu_csb(dt_temp), info, false, false);
                                                    if (Convert.ToInt64(Myadapter_Mp.SQ_MP(tempmeter.MeterId)) == 0)
                                                        Myadapter_Mp.Insert_MP(tempmeter.MeterId, "-1", "-1", re[0], "-1");
                                                    else Myadapter_p.UpdatePlatChu_csb("就绪", int.Parse(re[0]));
                                                    break;
                                                case "PlatZhos":
                                                    //dt_temp =
                                                    //send34 = DownCommond.GenerateSendFrame(DownCommond.GenerateCore33(tempmeter.MeterId) + DownCommond.GenerateCore34_Zho(dt_temp), info, false, false);
                                                    //socket.Send(DataHelper.Str2Byte(send34));
                                                    socket.Close();
                                                    Myadapter_p.UpdatePlatZho("就绪", int.Parse(re[0]));
                                                    //有问题
                                                    if (Convert.ToInt64(Myadapter_Mp.SQ_MP(tempmeter.MeterId)) == 0)
                                                        Myadapter_Mp.Insert_MP(tempmeter.MeterId, "-1", "-1", "-1", re[0]);
                                                    else Myadapter_Mp.Update_MP_Zho(re[0], tempmeter.MeterId);
                                                    break;
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            flag_xinx = false;
                                            flag_sen = false;
                                            flag_xiu = false;
                                            LogHelper.Error("检测平台修改数据库或读取燃气表测试信息异常" + e);
                                        }
                                        if (flag_xinx)
                                        {
                                            socket.Send(DataHelper.Str2Byte(send34));
                                            socket.Close();
                                            LogHelper.Info("发送命令33" + send34);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        flag_sen = false;
                                        flag_xiu = false;
                                        LogHelper.Error("检测平台异常或数据异常" + e);
                                    }
                                    if (flag_sen)
                                    {
                                        try
                                        {
                                            string send8F3 = DownCommond.GenerateSendFrame(DownCommond.GenerateCore8F(tempmeter.MeterRand_num), info, true, false);
                                            string send813 = DownCommond.GenerateSendFrame(DownCommond.GenerateCore81(re[1], re[2], false, "", tempmeter.MeterRand_num), info, false, true);
                                            ArraySegment<byte> f3 = new ArraySegment<byte>(DataHelper.Str2Byte(send8F3));
                                            ArraySegment<byte> f23 = new ArraySegment<byte>(DataHelper.Str2Byte(send813));
                                            session.Send(f3);
                                            Thread.Sleep(1000);
                                            session.Send(f23);
                                            LogHelper.Info("发送命令8F" + send8F3);
                                            LogHelper.Info("发送命令81" + send813);
                                        }
                                        catch (Exception e)
                                        {
                                            flag_xiu = false;
                                            LogHelper.Error("修改网络参数下发失败" + e);
                                        }
                                    }
                                    else
                                    {
                                        //更新随机数
                                        //下发5F
                                        string send0F = DownCommond.GenerateSendFrame(DownCommond.GenerateCore0F("5F", 2, 1), info, true, true);
                                        ArraySegment<byte> f0 = new ArraySegment<byte>(DataHelper.Str2Byte(send0F));
                                        session.Send(f0);
                                        LogHelper.Info("发送命令3" + send0F);
                                        Myadapter.UpdateRand_num(tempmeter.MeterRand_num, tempmeter.MeterId);
                                    }
                                    if (flag_xiu)
                                    {
                                        tempmeter.MeterTest = "准备";
                                        tempmeter.Meteriport = re[0] + "@" + re[1] + "@" + re[2] + "@" + re[3];
                                        Myadapter.UpdateMeterTest(tempmeter.MeterRand_num, tempmeter.Meteriport, tempmeter.MeterTime, tempmeter.MeterTest, tempmeter.MeterId);
                                    }
                                }
                                else if (re[1].Equals("空"))
                                {
                                    LogHelper.Info("无空闲检测平台");
                                    Random rd = new Random();
                                    int uplod_time = rd.Next(10, 20);
                                    string send0F = DownCommond.GenerateSendFrame(DownCommond.GenerateCore0F("5F", uplod_time, 5), info, true, true);
                                    ArraySegment<byte> f0 = new ArraySegment<byte>(DataHelper.Str2Byte(send0F));
                                    session.Send(f0);
                                    LogHelper.Info("发送命令2" + send0F);
                                    Myadapter.UpdateRand_num(tempmeter.MeterRand_num, tempmeter.MeterId);
                                }
                                else
                                {
                                    LogHelper.Info("安排出错，大于检测平台数");
                                }
                            }
                            else
                            {
                                LogHelper.Info("非规定测量标志位");
                            }
                            break;
                        default:
                            LogHelper.Info("未知状态");
                            break;
                    }
                    CommonFunction.platm.ChangeMeter();
                    CommonFunction.platm.ChangePlat();
                }
                else
                {
                    try
                    {
                        dt = Myadapter_r.GetDataBy_r(info.EquipmentID, "合格", "初始","失败");
                    }
                    catch (Exception e)
                    {
                        LogHelper.Info("数据库连接异常90" + e);
                    }
                    tempmeter = DataHelper.Dt2Ob(dt);
                    if (tempmeter != null)
                    {
                        //随机数与datetime
                        //在51之前修改为合格，表在metersuccess中，metertest=空闲，metercancel=合格
                        //如果测试状态为正测
                        tempmeter.MeterRand_num = info.Data.Substring(52, 8);
                        DateTime dtime = DateTime.Now;
                        tempmeter.MeterTime = dtime;
                        if ((tempmeter.MeterCancel.Equals("合格") && tempmeter.MeterTest.Equals("空闲")) || (tempmeter.MeterCancel.Equals("是") && tempmeter.MeterState.Equals("失败")))
                            Cancel_meter(tempmeter, session, info);
                        else if (tempmeter.MeterCancel.Equals("合格") && tempmeter.MeterTest.Equals("正测"))
                        {
                            //更新随机数
                            //下发5F
                            string send0F = DownCommond.GenerateSendFrame(DownCommond.GenerateCore0F("5F", 2, 1), info, true, true);
                            ArraySegment<byte> f0 = new ArraySegment<byte>(DataHelper.Str2Byte(send0F));
                            session.Send(f0);
                            LogHelper.Info("发送命令1" + send0F);
                            Myadapter_r.Update_wait(tempmeter.MeterTest, tempmeter.MeterRand_num, tempmeter.MeterTime, tempmeter.MeterState, tempmeter.MeterId);
                        }

                    }
                }
            }
        }
        /// <summary>
        /// 总状态为成功的表
        /// </summary>
        /// <param name="tempmeter"></param>
        /// <param name="session"></param>
        private void Xiugaisuc(MeterInfo tempmeter, MySession session, MyRequestInfo info)
        {
            try
            {
                //修改总结果为成功
                tempmeter.MeterState = "合格";
                //下发8f，8E, 改变测试状态为准备,正准备修改到正式服务器
                string send8F = DownCommond.GenerateSendFrame(DownCommond.GenerateCore8F(tempmeter.MeterRand_num), info, true, false);
                string send8E = DownCommond.GenerateSendFrame(DownCommond.GenerateCore8E(tempmeter.MeterRand_num), info, false, false);
                ArraySegment<byte> f = new ArraySegment<byte>(DataHelper.Str2Byte(send8F));
                ArraySegment<byte> f2 = new ArraySegment<byte>(DataHelper.Str2Byte(send8E));
                session.Send(f);
                Thread.Sleep(1000);
                session.Send(f2);
                LogHelper.Info("发送命令" + send8F);
                LogHelper.Info("发送命令" + send8E);
                //修改测试状态为准备 +++++++++++++++++++++++++++++++
                tempmeter.MeterTest = "准备";
                //Myadapter.UpdateMeterState(tempmeter.MeterRand_num, tempmeter.MeterTime, tempmeter.MeterState, tempmeter.MeterTest, tempmeter.MeterId);
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
                //CommonFunction.platm.ChangeSuc();
            }
            catch (Exception e)
            {
                LogHelper.Info(tempmeter.MeterId + e);
            }
        }
        /// <summary>
        /// 总状态为失败的表
        /// </summary>
        /// <param name="tempmeter"></param>
        /// <param name="session"></param>
        private void Xiugaifai(MeterInfo tempmeter, MySession session, MyRequestInfo info)
        {
            try
            {
                //修改测试总结果为失败，将其从检测列表中转移到检测失败的表中
                tempmeter.MeterState = "失败";
                //下发8f 8e回复出厂设置  （5F?）+++++++++++++++++++++++++++++++
                string send8F = DownCommond.GenerateSendFrame(DownCommond.GenerateCore8F(tempmeter.MeterRand_num), info, true, false);
                string send8E = DownCommond.GenerateSendFrame(DownCommond.GenerateCore8E(tempmeter.MeterRand_num), info, false, false);
                ArraySegment<byte> f = new ArraySegment<byte>(DataHelper.Str2Byte(send8F));
                ArraySegment<byte> f2 = new ArraySegment<byte>(DataHelper.Str2Byte(send8E));
                session.Send(f);
                session.Send(f2);
                LogHelper.Info("发送命令" + send8F);
                LogHelper.Info("发送命令" + send8E);
                tempmeter.MeterTest = "准备";
                //Myadapter.UpdateMeterState(tempmeter.MeterRand_num, tempmeter.MeterTime, tempmeter.MeterState, tempmeter.MeterTest, tempmeter.MeterId);
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
            catch (Exception e)
            {
                LogHelper.Info(tempmeter.MeterId + e);
            }
        }
        /// <summary>
        /// 取消测试的表
        /// </summary>
        /// <param name="tempmeter"></param>
        /// <param name="session"></param>
        /// <param name="info"></param>
        private void Cancel_meter(MeterInfo tempmeter, MySession session, MyRequestInfo info)
        {
            try
            {
                //下发8f 8e回复出厂设置
                string send8F = DownCommond.GenerateSendFrame(DownCommond.GenerateCore8F(tempmeter.MeterRand_num), info, true, false);
                string send8E = DownCommond.GenerateSendFrame(DownCommond.GenerateCore8E(tempmeter.MeterRand_num), info, false, false);
                ArraySegment<byte> f = new ArraySegment<byte>(DataHelper.Str2Byte(send8F));
                ArraySegment<byte> f2 = new ArraySegment<byte>(DataHelper.Str2Byte(send8E));
                session.Send(f);
                session.Send(f2);
                LogHelper.Info("发送命令" + send8F);
                LogHelper.Info("发送命令" + send8E);
                tempmeter.MeterTest = "准备";
                Myadapter_r.Update_wait(tempmeter.MeterTest, tempmeter.MeterRand_num, tempmeter.MeterTime, tempmeter.MeterState, tempmeter.MeterId);
            }
            catch (Exception e)
            {
                LogHelper.Info(tempmeter.MeterId + e);
            }
        }

        private void XiugaiSF(MeterInfo tempmeter, MySession session, MyRequestInfo info)
        {
            try
            {
                tempmeter.MeterState = "不合格";
                Myadapter_r.Update_wait(
                    tempmeter.MeterTest,
                    tempmeter.MeterRand_num,
                    tempmeter.MeterTime,
                    tempmeter.MeterState,
                    tempmeter.MeterId);
                CommonFunction.platm.ChangeBHG();
                CommonFunction.platm.ChangeHG();
            }
            catch (Exception e)
            {
                LogHelper.Error("从成功移到失败失败!" + e);
            }
        }
    }
}
