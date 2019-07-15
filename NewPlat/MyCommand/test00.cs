using NewPlat.BLL;
using NewPlat.MySuperSocket;
using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.MyCommand
{
    public class Test00 : CommandBase<MySession, MyRequestInfo>
    {
        
        public override string Name
        {
            get
            {
                return "00";
            }
        }
        public override void ExecuteCommand(MySession session, MyRequestInfo requestInfo)
        {
            //CommonFunction.platm.ChangePState(1,"准备");
        }
        private void Log(string p)
        {
            LogHelper.Info(p);
        }
    }
}
