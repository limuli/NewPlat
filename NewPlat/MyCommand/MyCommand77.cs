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
using System.Threading.Tasks;

namespace NewPlat.MyCommand
{
    public class MyCommand77 : CommandBase<MySession, MyRequestInfo>
    {
        private DT_ResultTableAdapter Myadapter_r;
        private Dt_MeterInfoTableAdapter Myadapter;
        public override string Name
        {
            get
            {
                return "77";
            }
        }
        /// <summary>
        /// 取消测试的命令（若表没在测试怎么办，在ll哪处理吗）
        /// 将表的cancel字段改为是，将表的总状态改为失败。等到22命令的时候将表以失败移到meter_result中，可以发送8e命令，让其休眠。
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(MySession session, MyRequestInfo requestInfo)
        {
            string send = "00";
            Myadapter = new Dt_MeterInfoTableAdapter();
            Myadapter_r = new DT_ResultTableAdapter();
            DataTable dt = null;
            MeterInfo tempmeter = null;
            var info = requestInfo;
            int id = Convert.ToInt32(info.Data.Substring(2, 2), 16);
            string ip = DataHelper.Str2IP(info.Data.Substring(4, 8));
            string port = Convert.ToInt32(info.Data.Substring(12, 4), 16).ToString();
            string type = info.Data.Substring(16, 2);
            string meterid = info.Data.Substring(18, 12);
            try
            {
                dt = Myadapter.GetDataBy1(meterid);
                tempmeter = DataHelper.Dt2Ob(dt);
            }
            catch (Exception e)
            {
                send = "55";
                LogHelper.Error("77命令：" + e);
            }
            if (tempmeter != null)
            {
                string[] re = tempmeter.Meteriport.Split('@');
                tempmeter.MeterCancel = "是";
                tempmeter.MeterState = "失败";
                try
                {
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
                        tempmeter.Subtime
                        );
                    Myadapter.DeleteMeter(meterid);
                    send = "AA";
                }
                catch (Exception e)
                {
                    send = "55";
                    LogHelper.Info("取消测试失败：" + meterid);
                }
            }
            else
            {
                LogHelper.Info("检测平台不存在需要取消测试表" + meterid);
                send = send.Equals("55") ? "55" : "BB";
            }
            //回复检测平台，是否取消测试成功
            IPAddress Ip = IPAddress.Parse(ip);
            int Port = Convert.ToInt32(port);
            string send_77 = DownCommond.GenerateSendFrame("77" + send, info, true, false);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(Ip, Port);
            socket.Send(DataHelper.Str2Byte(send_77));
            socket.Close();
            LogHelper.Info("回复77：" + send_77);
        }
    }
}
