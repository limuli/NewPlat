using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.MySuperSocket
{
   public class MySession : AppSession<MySession, MyRequestInfo>
    {
        public string strRecord = "";
        public DateTime dateCommandReceive;
        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();
            //strRecord += "ID为： " + this.SessionID + " 接入时间为" +this.StartTime + Environment.NewLine;
            //LogHelper.Info(strRecord);
        }
        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
            //strRecord += "ID为： " + this.SessionID+ "接入时间为：" + this.StartTime +"关闭时间为：" + DateTime.Now+ Environment.NewLine;
            //strRecord += Environment.NewLine;
            //LogHelper.Info(strRecord);

        }
        protected override void HandleException(Exception e)
        {
            base.HandleException(e);
            LogHelper.Error(e.ToString());
        }

        protected override void HandleUnknownRequest(MyRequestInfo requestInfo)
        {
            base.HandleUnknownRequest(requestInfo);
            LogHelper.Info("未知请求");
        }
    }
}
