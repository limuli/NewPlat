using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.MySuperSocket
{
    class MyReceiveFilterFactory : IReceiveFilterFactory<MyRequestInfo>
    {
        public IReceiveFilter<MyRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint)
        {
            return new MyReceiveFilter();
        }
    }
}
