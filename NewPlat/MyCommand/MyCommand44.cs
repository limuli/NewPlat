using NewPlat.BLL;
using NewPlat.Model;
using NewPlat.MyDataSetTableAdapters;
using NewPlat.MySuperSocket;
using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.MyCommand
{
   public class MyCommand44 : CommandBase<MySession, MyRequestInfo>
    {
        private Dt_PlateInfoTableAdapter Myadapter_p;
        public override string Name
        {
            get
            {
                return "44";
            }
        }
        /// <summary>
        /// 检测平台回复的alive(44)命令
        /// ip + port
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(MySession session, MyRequestInfo requestInfo)
        {
            lock (CommonFunction.obj_44)
            {
                Myadapter_p = new Dt_PlateInfoTableAdapter();
                var info = requestInfo;
                int id = Convert.ToInt32(info.Data.Substring(2, 2), 16);
                string ip = DataHelper.Str2IP(info.Data.Substring(4, 8));
                string port = Convert.ToInt32(info.Data.Substring(12, 4), 16).ToString();
                string type = info.Data.Substring(16, 2);
                if (CommonFunction.hearts.ContainsKey(id+type))
                {
                    CommonFunction.hearts[id + type].Ke_al = 00;
                    if (CommonFunction.hearts[id + type].State.Equals("异常"))
                    {
                        CommonFunction.hearts[id + type].State = "正常";
                        switch (CommonFunction.hearts[id + type].Type)
                        {
                            case "命令检测":
                                Myadapter_p.UpdatePlatCom("空闲", CommonFunction.hearts[id + type].Id);
                                break;
                            case "Ic检测":
                                Myadapter_p.UpdatePlatIc("空闲", CommonFunction.hearts[id + type].Id);
                                break;
                            case "初检模式表":
                                Myadapter_p.UpdatePlatChu_msb("空闲", CommonFunction.hearts[id + type].Id);
                                break;
                            case "初检修正仪":
                                Myadapter_p.UpdatePlatChu_xzy("空闲", CommonFunction.hearts[id + type].Id);
                                break;
                            case "初检超声波":
                                Myadapter_p.UpdatePlatChu_csb("空闲", CommonFunction.hearts[id + type].Id);
                                break;
                            case "终检":
                                Myadapter_p.UpdatePlatZho("空闲", CommonFunction.hearts[id + type].Id);
                                break;
                        }
                        CommonFunction.platm.ChangePlat();
                    }
                    LogHelper.Info("心跳包");
                }
            }
        }
    }
}
