using NewPlat.BLL;
using NewPlat.Model;
using NewPlat.MyDataSetTableAdapters;
using NewPlat.MySuperSocket;
using SuperSocket.SocketBase.Command;
using System;
using System.Data;
using System.Threading;

namespace NewPlat.MyCommand
{
    /// <summary>
    /// 恢复出厂设置
    /// </summary>
  public class MyCommand8E : CommandBase<MySession, MyRequestInfo>
    {
        private DT_ResultTableAdapter Myadapter_r;
        public static object obj3 = new object();
        public override string Name
        {
            get
            {
                return "8E";
            }
        }
        /// <summary>
        /// 从成功和失败的表中查询表
        /// 判断表的总结果是否为成功，表的测试状态为准备下发81命令
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(MySession session, MyRequestInfo requestInfo)
        {
            lock (obj3)
            {
                Myadapter_r = new DT_ResultTableAdapter();
                DataTable dt = new DataTable();
                MeterInfo tempmeter = new MeterInfo();
                bool f = true;
                Thread.Sleep(1000);
                var info = requestInfo;
                dt = Myadapter_r.GetDataBy_r(info.EquipmentID,"合格","初始","失败");
                if (dt != null && dt.Rows.Count > 0)
                    tempmeter = DataHelper.Dt2Ob(dt);
                else
                {
                    f = false;
                }

                if (tempmeter != null && f)
                {
                    DateTime dtime = DateTime.Now;
                    tempmeter.MeterTime = dtime;
                    //成功的下发81修改网络参数，失败的不处理
                    if ((tempmeter.MeterState.Equals("合格") || tempmeter.MeterCancel.Equals("合格")) && tempmeter.MeterTest.Equals("准备"))
                    {
                        string ip = CommonFunction.dicBooks["strJituanHostIP"];
                        string port = CommonFunction.dicBooks["strJituanHostPort"];
                        string domain = CommonFunction.dicBooks["strJituanHostDomain"];
                        string send81 = DownCommond.GenerateSendFrame(DownCommond.GenerateCore81(ip, port, true, domain, tempmeter.MeterRand_num), info, false, true);
                        ArraySegment<byte> f2 = new ArraySegment<byte>(DataHelper.Str2Byte(send81));
                        session.Send(f2);
                        tempmeter.MeterTest = "就绪";
                        //更新测试状态和修改时间
                        Myadapter_r.Update_wait(tempmeter.MeterTest,tempmeter.MeterRand_num ,tempmeter.MeterTime, tempmeter.MeterState,tempmeter.MeterId);
                    }
                    else
                    {
                        LogHelper.Info("燃气表错误发送恢复出厂设置");
                    }
                }
                else
                {
                    LogHelper.Info("表不在检测列表中");
                }
            }
        }
    }
}