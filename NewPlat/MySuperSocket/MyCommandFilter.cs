using NewPlat.BLL;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.MySuperSocket
{
   public class MyCommandFilter : CommandFilterAttribute
    {
        public override void OnCommandExecuted(CommandExecutingContext commandContext)
        {
            
            string strMsg = "";
            string l = Environment.NewLine;
            MyRequestInfo info = (MyRequestInfo)commandContext.RequestInfo;
            DateTime dt = DateTime.Now;            
            strMsg += ("命令 "+ info.Key+ " 执行完时间为：" + dt +l);
            Log(strMsg);
            //LogHelper.Error(dt + "  " + info.EquipmentID + "  " + info.Key + "结束");
        }
        private void Log(string p)
        {
            LogHelper.Info(p);
        }
        public override void OnCommandExecuting(CommandExecutingContext commandContext)
        {
            string strMsg = "";
            string l = Environment.NewLine;
            MySession session = ((MySession)(commandContext.Session));
            session.dateCommandReceive = DateTime.Now;
            DateTime dt = DateTime.Now;
            string strEntireFrame = ((MyRequestInfo)commandContext.RequestInfo).EntireFrame;
            MyRequestInfo info = (MyRequestInfo)commandContext.RequestInfo;
            strMsg += ("receive from: " + session.RemoteEndPoint.ToString()) + l;
            strMsg += ("接收到数据：" + strEntireFrame) + l;
            strMsg += ("设备类型:" + info.EquipmentType) + l;
            strMsg += ("设备号:" + info.EquipmentID) + l;
            strMsg += ("控制码:" + info.CtrlCodeBin);
            Log(strMsg);
            //LogHelper.Error(dt + "  " + info.EquipmentID + "  " + info.Key+"开始");
        }
    }
}
