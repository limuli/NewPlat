using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.MySuperSocket
{
    [MyCommandFilter]
    public class MyServer : AppServer<MySession, MyRequestInfo>
    {
        public MyServer()
            :base(new MyReceiveFilterFactory())
        {
        }
    }
}
