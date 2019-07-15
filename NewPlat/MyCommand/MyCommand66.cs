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
    public class MyCommand66 : CommandBase<MySession, MyRequestInfo>
    {
        private DT_WaringPlatTableAdapter myadapter_w;
        private Dt_PlateInfoTableAdapter Myadapter_p;
        private DataTable dt;
        private PlatInfo pl;
        private HeartInfo heart;

        public override string Name {
            get
            {
                return "66";
            }
        }

        /// <summary>
        /// id+ip+port+type+入网/出网（1+4+2+1+1）
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(MySession session, MyRequestInfo requestInfo)
        {
            lock (CommonFunction.obj_66)
            {
                string re = "00";
                bool f;
                bool isallowexit;
                Myadapter_p = new Dt_PlateInfoTableAdapter();
                myadapter_w = new DT_WaringPlatTableAdapter();
                var info = requestInfo;
                int id = Convert.ToInt32(info.Data.Substring(2, 2), 16);
                string ip = DataHelper.Str2IP(info.Data.Substring(4, 8));
                string port = Convert.ToInt32(info.Data.Substring(12, 4), 16).ToString();
                string type = info.Data.Substring(16, 2);
                string cmd = info.Data.Substring(18, 2);
                //入网 根据id查询数据库（有，更新数据）（没有，插入数据）
                //出网 根据id查询数据库（有，更新数据） （没有，不做操作） 检查其状态是否可以立即出网，并回复。若不可以标记状态为待出网，通知其下次上传。
                //更新platinfo 和 heart 入网成功加入heart，出网成功移除heart，dictionary存储heartinfo
                //加锁，当执行01操作时不能执行出网操作，避免
                if (cmd.Equals("AA"))
                {
                    //入网
                    try
                    {
                        pl = Replat(id);
                        if (pl == null)
                        {
                            pl = new PlatInfo();
                            f = false;
                        }
                        else f = true;
                        switch (type)
                        {
                            case "01":
                                heart = new HeartInfo(id, "命令检测", ip, port, 00 ,"正常");
                                pl.PlatComs = "空闲";
                                pl.PlatComp = port;
                                break;
                            case "02":
                                heart = new HeartInfo(id, "IC卡卡控", ip, port, 00, "正常");
                                pl.PlatIcs = "空闲";
                                pl.PlatIcp = port;
                                break;
                            case "03":
                                heart = new HeartInfo(id, "膜式表初检", ip, port, 00, "正常");
                                pl.PlatChus_msb = "空闲";
                                pl.PlatChup_msb = port;
                                break;
                            case "04":
                                heart = new HeartInfo(id, "修正仪初检", ip, port, 00, "正常");
                                pl.PlatChus_xzy = "空闲";
                                pl.PlatChup_xzy = port;
                                break;
                            case "05":
                                heart = new HeartInfo(id, "超声波初检", ip, port, 00, "正常");
                                pl.PlatChus_csb = "空闲";
                                pl.PlatChup_csb = port;
                                break;
                            case "06":
                                heart = new HeartInfo(id, "终检", ip, port, 00, "正常");
                                pl.PlatZhos = "空闲";
                                pl.PlatZhop = port;
                                break;
                        }
                        pl.IP = ip;
                        pl.id = id;
                        if (f)
                        {
                            Myadapter_p.UpdatePlat(
                                pl.IP,
                                pl.PlatComs,
                                pl.PlatIcs,
                                pl.PlatChus_msb,
                                pl.PlatChus_xzy,
                                pl.PlatChus_csb,
                                pl.PlatZhos,
                                pl.PlatComp,
                                pl.PlatIcp,
                                pl.PlatChup_msb,
                                pl.PlatChup_xzy,
                                pl.PlatChup_csb,
                                pl.PlatZhop,
                                pl.id);
                        }
                        else
                        {
                            Myadapter_p.InsertPlat(
                                pl.id,
                                pl.IP,
                                pl.PlatComs,
                                pl.PlatIcs,
                                pl.PlatChus_msb,
                                pl.PlatChus_xzy,
                                pl.PlatChus_csb,
                                pl.PlatZhos,
                                pl.PlatComp,
                                pl.PlatIcp,
                                pl.PlatChup_msb,
                                pl.PlatChup_xzy,
                                pl.PlatChup_csb,
                                pl.PlatZhop);
                        }
                        //入网成功
                        CommonFunction.platInfos[id] = pl;
                        CommonFunction.hearts[id+type] = heart;
                        re = "AA";
                        //此检测平台是否为异常的平台，修改数据库
                        DataTable dtw = myadapter_w.GetDataBy_it(id.ToString(),heart.Type,0);
                        if (dtw.Rows.Count != 0)
                        {
                            myadapter_w.UpdateMP(1, DateTime.Now,heart.Type , id.ToString(),0);
                            PostLl(id.ToString(), heart.Type, "正常");
                        }
                        LogHelper.Info(id+" "+type+" 入网成功");
                    }
                    catch (Exception e)
                    {
                        LogHelper.Error("入网失败" + e);
                        re = "55";
                    }
                }
                else if (cmd.Equals("55"))
                {
                    //出网
                    lock (CommonFunction.obj_44)
                    {
                        try
                        {
                            pl = Replat(id);
                            if (pl != null)
                            {
                                switch (type)
                                {
                                    case "01":
                                        if (pl.PlatComs.Equals("空闲") || pl.PlatComs.Equals("待出网"))
                                        {
                                            pl.PlatComs = "未启用";
                                            isallowexit = true;
                                        }
                                        else
                                        {
                                            pl.PlatComs = "待出网";
                                            isallowexit = false;
                                        }
                                        break;
                                    case "02":
                                        if (pl.PlatIcs.Equals("空闲") || pl.PlatIcs.Equals("待出网"))
                                        {
                                            pl.PlatIcs = "未启用";
                                            isallowexit = true;
                                        }
                                        else
                                        {
                                            pl.PlatIcs = "待出网";
                                            isallowexit = false;
                                        }
                                        break;
                                    case "03":
                                        if (pl.PlatChus_msb.Equals("空闲") || pl.PlatChus_msb.Equals("待出网"))
                                        {
                                            pl.PlatChus_msb = "未启用";
                                            isallowexit = true;
                                        }
                                        else
                                        {
                                            pl.PlatChus_msb = "待出网";
                                            isallowexit = false;
                                        }
                                        break;
                                    case "04":
                                        if (pl.PlatChus_xzy.Equals("空闲") || pl.PlatChus_xzy.Equals("待出网"))
                                        {
                                            pl.PlatChus_xzy = "未启用";
                                            isallowexit = true;
                                        }
                                        else
                                        {
                                            pl.PlatChus_xzy = "待出网";
                                            isallowexit = false;
                                        }
                                        break;
                                    case "05":
                                        if (pl.PlatChus_csb.Equals("空闲") || pl.PlatChus_csb.Equals("待出网"))
                                        {
                                            pl.PlatChus_csb = "未启用";
                                            isallowexit = true;
                                        }
                                        else
                                        {
                                            pl.PlatChus_csb = "待出网";
                                            isallowexit = false;
                                        }
                                        break;
                                    case "06":
                                        if (pl.PlatZhos.Equals("空闲") || pl.PlatZhos.Equals("待出网"))
                                        {
                                            pl.PlatZhos = "未启用";
                                            isallowexit = true;
                                        }
                                        else
                                        {
                                            pl.PlatZhos = "待出网";
                                            isallowexit = false;
                                        }
                                        break;
                                    default:
                                        isallowexit = false;
                                        break;
                                }
                                Myadapter_p.UpdatePlat(
                                    pl.IP,
                                    pl.PlatComs,
                                    pl.PlatIcs,
                                    pl.PlatChus_msb,
                                    pl.PlatChus_xzy,
                                    pl.PlatChus_csb,
                                    pl.PlatZhos,
                                    pl.PlatComp,
                                    pl.PlatIcp,
                                    pl.PlatChup_msb,
                                    pl.PlatChup_xzy,
                                    pl.PlatChup_csb,
                                    pl.PlatZhop,
                                    pl.id);
                                CommonFunction.platInfos[id] = pl;
                                if (isallowexit)
                                {
                                    CommonFunction.hearts.Remove(id + type);
                                    re = "AA";
                                    LogHelper.Info(id + " " + type + " 出网成功");
                                }
                                else re = "BB";
                            }
                        }
                        catch (Exception e)
                        {
                            LogHelper.Error("出网失败" + e);
                            re = "55";
                        }
                    }                    
                }
                try
                {
                    //回复检测平台，入网成功或失败，出网成功或失败或等一次检测
                    IPAddress Ip = IPAddress.Parse(ip);
                    int Port = Convert.ToInt32(port);
                    string send_66 = DownCommond.GenerateSendFrame("66" + re, info, true, false);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(Ip, Port);
                    socket.Send(DataHelper.Str2Byte(send_66));
                    socket.Close();
                    LogHelper.Info("回复66：" + send_66);
                }
                catch (Exception e)
                {
                    LogHelper.Error("无法连接入网检测平台" + e);
                }
               
            }
        }
        private PlatInfo Replat (int id)
        {
            try
            {
                dt = Myadapter_p.GetDataBy1(id);
                return DataHelper.Dt2pl(dt);
                
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        private async void PostLl(string id, string type, string cmd)
        {
            try
            {
                List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>>();
                param.Add(new KeyValuePair<string, string>("waring", cmd));
                param.Add(new KeyValuePair<string, string>("wid", id));
                param.Add(new KeyValuePair<string, string>("wtype", type));
                string x = await CommonFunction.hs.PostSend("http://192.168.3.137:8000/rtr/", param);
                LogHelper.Info(x);
                // Debug.Print(x);
            }
            catch (Exception we)
            {
                LogHelper.Error("66命令推送入网" + we);
            }

        }
    }
}
