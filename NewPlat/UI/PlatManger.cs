using NewPlat.BLL;
using NewPlat.MySuperSocket;
using SuperSocket.SocketBase;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Data;
using NewPlat.MyDataSetTableAdapters;
using System.Diagnostics;
using NewPlat.Model;
using System.Collections.Generic;

namespace NewPlat.UI
{
    public partial class PlatManger : Form
    {
        DetailResult der;
        private Dt_PlateInfoTableAdapter Myadapter_p;
        private Dt_MeterInfoTableAdapter Myadapter;
        MyServer Server;
        private delegate void MyDelegate(string data, Color color,bool f);
        private delegate void MyDelegate_plat();
        private delegate void MyDelegate_meter();
        private delegate void MyDelegate_sh(object data);
        private delegate void MyDelegate_bt(object data,Color c);
        SpeechSynthesizer speech = new SpeechSynthesizer();
        private int formStartX = 0;
        private int formStartY = 0;
        FormControl fc = null;

        public PlatManger()
        {
            CommonFunction.flag_listener = true;
            InitializeComponent();
            Server = CommonFunction.myServer;
            Myadapter_p = new Dt_PlateInfoTableAdapter();
            Myadapter = new Dt_MeterInfoTableAdapter();
            CommonFunction.platm = this;
            if(CommonFunction.flag_listener)
            SetTB_lister("通信异常监听未开启", Color.Red,false);
        }

        private void PlatManger_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: 这行代码将数据加载到表“myDataSet.Dt_success”中。您可以根据需要移动或删除它。
                this.dt_PlateInfoTableAdapter.Fill(this.myDataSet.Dt_PlateInfo);
                ChangeMeter();
                // TODO: 这行代码将数据加载到表“myDataSet.Dt_MeterInfo”中。您可以根据需要移动或删除它。
                //  this.dt_MeterInfoTableAdapter.Fill(this.myDataSet.Dt_MeterInfo);
                //  this.dT_ResultTableAdapter.Fill(this.myDataSet.DT_Result,"完成");
                // this.dT_BHGTableAdapter.Fill_BHG(this.myDataSet.DT_BHG, "不合格");
                // this.dT_SBTableAdapter.Fill_SB(this.myDataSet.DT_SB, "失败");
            }
            catch (Exception)
            {
                MessageBox.Show("数据库连接异常");
            }
            
            DGV_MeterInfo.AllowUserToAddRows = false;
            DGV_plat.AllowUserToAddRows = false;

            DGV_MeterInfo.ClearSelection();
            DGV_plat.ClearSelection();
            DGV_HG.ClearSelection();
            DGV_BHG.ClearSelection();
            DGV_SB.ClearSelection();
            fc = new FormControl(this);
            fc.GetInit(this, fc);

            this.formStartX = this.Width;
            this.formStartY = this.Height;

            Change_st(DGV_MeterInfo);
            Change_pl(DGV_plat);

            if (OpenServer()) {
                SetBtsetext("关闭服务", Color.Black);
                Lisenter();
            }

            Dictionary<string, HeartInfo> h =  CommonFunction.hearts;
            Dictionary<int, PlatInfo> he = CommonFunction.platInfos;
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="strMsg"></param>
        public void Showmsg(object strMsg) {
            if (TB_show.InvokeRequired)
            {
                MyDelegate_sh md = new MyDelegate_sh(Showmsg);
                Invoke(md, new object[] { strMsg });
            }
            else {
                string info = DateTime.Now.ToString("hh:mm:ss   ")+ strMsg + Environment.NewLine;
                TB_show.AppendText(info);
            }

        }

        private void test_Click(object sender, EventArgs e)
        {
            //DateTime DT = DateTime.Now;
            //Showmsg("test");
            //Myadapter.UpdateMeterChu("准备","2",DT,"000000000001");
            // ChangeMeter();
            //Change_row(DGV_MeterInfo,"000000000001",Color.LightPink);
            Thread t = new Thread(ts);
            t.Start();

        }
        private void ts()
        {
            ChangePlat();
        }

        /// <summary>
        /// 改变待测表的界面datagridview
        /// </summary>
        public void ChangePlat() {

            if (DGV_plat.InvokeRequired)
            {
                MyDelegate_meter Mdm = new MyDelegate_meter(ChangePlat);
                this.Invoke(Mdm);
            }
            else {
                // TODO: 这行代码将数据加载到表“myDataSet.Dt_PlateInfo”中。您可以根据需要移动或删除它。
                this.dt_PlateInfoTableAdapter.Fill(this.myDataSet.Dt_PlateInfo);
                DGV_plat.ClearSelection();
                Change_pl(DGV_plat);
            }
        }

        /// <summary>
        /// 改变待测表的界面datagridview
        /// </summary>
        public void ChangeMeter()
        {

            if (DGV_MeterInfo.InvokeRequired)
            {
                MyDelegate_meter Mdm = new MyDelegate_meter(ChangeMeter);
                this.Invoke(Mdm);
            }
            else
            {
                // this.dt_MeterInfoTableAdapter.Fill(this.myDataSet.Dt_MeterInfo);
                DataTable dt = this.dt_MeterInfoTableAdapter.GetData();
                DGV_MeterInfo.AllowUserToAddRows = true;
                this.DGV_MeterInfo.Rows.Clear();
                for (int i =0; i<dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    this.DGV_MeterInfo.Rows.Add();
                    this.DGV_MeterInfo.Rows[i].Cells["MeterId"].Value = dr["MeterId"].ToString();
                    this.DGV_MeterInfo.Rows[i].Cells["MeterType"].Value = dr["MeterType"].ToString();
                    this.DGV_MeterInfo.Rows[i].Cells["MeterIcState"].Value = dr["MeterIcState"].ToString();
                    this.DGV_MeterInfo.Rows[i].Cells["MeterChuState"].Value = dr["MeterChuState"].ToString();
                    this.DGV_MeterInfo.Rows[i].Cells["MeterComState"].Value = dr["MeterComState"].ToString();
                    this.DGV_MeterInfo.Rows[i].Cells["MeterZhongState"].Value = dr["MeterZhongState"].ToString();
                    this.DGV_MeterInfo.Rows[i].Cells["MeterState"].Value = dr["MeterState"].ToString();
                    this.DGV_MeterInfo.Rows[i].Cells["MeterTest"].Value = dr["MeterTest"].ToString();
                    this.DGV_MeterInfo.Rows[i].Cells["MeterTime"].Value = ((DateTime)dr["MeterTime"]).ToString("MM-dd HH:mm");
                    this.DGV_MeterInfo.Rows[i].Cells["MeterCancel"].Value = dr["MeterCancel"].ToString().Equals("否") ? false : true;
                    this.DGV_MeterInfo.Rows[i].Cells["MeterPrivilege"].Value = dr["MeterPrivilege"].ToString().Equals("0") ? false : true;
                }
                DGV_MeterInfo.ClearSelection();
                Change_st(DGV_MeterInfo);
                DGV_MeterInfo.AllowUserToAddRows = false;
            }            
        }

        public void ChangeHG()
        {

            if (DGV_HG.InvokeRequired)
            {
                MyDelegate_meter Mdm = new MyDelegate_meter(ChangeHG);
                this.Invoke(Mdm);
            }
            else
            {
                this.dT_ResultTableAdapter.Fill(this.myDataSet.DT_Result, "完成");
                DGV_HG.ClearSelection();
            }
        }
        public void ChangeBHG()
        {

            if (DGV_BHG.InvokeRequired)
            {
                MyDelegate_meter Mdm = new MyDelegate_meter(ChangeBHG);
                this.Invoke(Mdm);
            }
            else
            {
                this.dT_BHGTableAdapter.Fill_BHG(this.myDataSet.DT_BHG, "不合格");
                DGV_BHG.ClearSelection();
            }
        }
        public void ChangeSB()
        {

            if (DGV_SB.InvokeRequired)
            {
                MyDelegate_meter Mdm = new MyDelegate_meter(ChangeSB);
                this.Invoke(Mdm);
            }
            else
            {
                this.dT_SBTableAdapter.Fill_SB(this.myDataSet.DT_SB, "失败");
                DGV_SB.ClearSelection();
            }
        }

        private void SetTB_lister(string s, Color color,bool f)
        {
            if (TB_Listener.InvokeRequired)
            {
                MyDelegate md = new MyDelegate(SetTB_lister);
                this.Invoke(md, new object[] { s, color ,f});
            }
            else
            {
                TB_Listener.Text = s;
                TB_Listener.ForeColor = color;
                PB_LIS.Visible = f;
            }
        }

        private void Log(string p)
        {
            LogHelper.Info(p);
        }

        private void PlatManger_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("关闭页面测试将会终止,是否关闭", 
                "系统提示！", 
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button1, 
                MessageBoxOptions.DefaultDesktopOnly);
            if (dr == DialogResult.OK)
            {
                CommonFunction.myServer.Stop();
                CommonFunction.flag_listener = false;
                CommonFunction.frmWelcome.Show();
                if (der != null)
                    der.Close();
                //未写完，需要考虑测试表的状态
            }
             else
            {
                 e.Cancel = true;
            }          
        }

        /// <summary>
        /// 心跳线程
        /// </summary>
        private void Heart() {
            while (CommonFunction.flag_listener)
            {
                lock (CommonFunction.obj_66)
                {
                    foreach (HeartInfo hi in CommonFunction.hearts.Values)
                    {

                        try
                        {
                            if (hi.Ke_al > 3)
                            {
                                hi.State = "异常";
                                hi.Ke_al = 00;
                                Showmsg(hi.Id + "/" + hi.Type);

                                //Thread me = new Thread(() => Message_f(hi))
                                //{
                                //    IsBackground = true
                                //};
                                //me.Start();
                                hi.State = "禁用";
                                //修改检测平台状态为异常
                                switch (hi.Type)
                                {
                                    case "命令检测":
                                        Myadapter_p.UpdatePlatCom("异常", hi.Id);
                                        break;
                                    case "IC卡卡控":
                                        Myadapter_p.UpdatePlatIc("异常", hi.Id);
                                        break;
                                    case "膜式表初检":
                                        Myadapter_p.UpdatePlatChu_msb("异常", hi.Id);
                                        break;
                                    case "修正仪初检":
                                        Myadapter_p.UpdatePlatChu_xzy("异常", hi.Id);
                                        break;
                                    case "超声波初检":
                                        Myadapter_p.UpdatePlatChu_csb("异常", hi.Id);
                                        break;
                                    case "终检":
                                        Myadapter_p.UpdatePlatZho("异常", hi.Id);
                                        break;
                                }
                                Thread.Sleep(50);
                                CommonFunction.platm.ChangePlat();
                                PostLl(hi.Id.ToString(), hi.Type, "异常");
                                DT_WaringPlatTableAdapter myadapter_wp = new DT_WaringPlatTableAdapter();
                                DataTable dtw = myadapter_wp.GetDataBy_it(hi.Id.ToString(), hi.Type, 0);
                                if (dtw.Rows.Count == 0)
                                {
                                    myadapter_wp.InsertWP(hi.Id.ToString(), hi.Type, DateTime.Now, 0, 0);
                                }
                                else
                                {
                                    myadapter_wp.UpdateMP(0, DateTime.Now, hi.Type, hi.Id.ToString(), 0);
                                }
                                //异常，给ll推送异常，修改检测平台状态为异常
                            }
                            if (hi.State.Equals("正常"))
                            {
                                try
                                {
                                    Debug.Print("2");
                                    if (CommonFunction.flag_listener)
                                    {
                                        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                        IPAddress ip = IPAddress.Parse(hi.IP);
                                        int port = Convert.ToInt32(hi.Port);
                                        socket.Connect(ip, port);
                                        string s = DownCommond.GenerateCorekeep();
                                        socket.Send(DataHelper.Str2Byte(s));
                                        socket.Close();
                                    }
                                }
                                catch (Exception)
                                {
                                    Debug.Print("3");
                                    LogHelper.Info("检测平台异常");
                                }
                                hi.Ke_al++;
                            }
                            Thread.Sleep(500);
                        }
                        catch (Exception)
                        {
                            hi.Ke_al++;
                            //此处应警报，没有办法发送心跳包
                        }

                    }
                }
                Debug.Print("1");                
            Thread.Sleep(10000);
            }
        }

        /// <summary>
        /// 通信异常处理
        /// </summary>
        /// <param name="i">CommonFunction.heart[i].Id和 CommonFunction.heart[i].Type </param>
        private void Message_f(HeartInfo hi) {
            speech.Speak("警告！" + Environment.NewLine + "第" + hi.Id + "台电脑的" + hi.Type + "平台通信异常");
            DialogResult dr = MessageBox.Show( "第" + hi.Id + "台电脑的" + hi.Type + "平台通信异常" + Environment.NewLine + "是否暂时禁用此检测平台", 
                "警告！", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);            
            if (dr == DialogResult.Yes && hi.State.Equals("异常"))
            {
                hi.State = "禁用";
                //修改检测平台状态为异常
                switch (hi.Type)
                {
                    case "命令检测":
                        Myadapter_p.UpdatePlatCom("异常", hi.Id);
                        break;
                    case "Ic检测":
                        Myadapter_p.UpdatePlatIc("异常", hi.Id);
                        break;
                    case "初检模式表":
                        Myadapter_p.UpdatePlatChu_msb("异常", hi.Id);
                        break;
                    case "初检修正仪":
                        Myadapter_p.UpdatePlatChu_xzy("异常", hi.Id);
                        break;
                    case "初检超声波":
                        Myadapter_p.UpdatePlatChu_csb("异常", hi.Id);
                        break;
                    case "终检":
                        Myadapter_p.UpdatePlatZho("异常", hi.Id);
                        break;
                }
                Thread.Sleep(50);
                CommonFunction.platm.ChangePlat();
            }
            else hi.State = "正常";

        }

        private void DGV_plat_Leave(object sender, EventArgs e)
        {
            DGV_plat.ClearSelection();
        }

        private void DGV_MeterInfo_Leave(object sender, EventArgs e)
        {
            DGV_MeterInfo.ClearSelection();
        }

        private void DGV_HG_Leave(object sender, EventArgs e)
        {
            DGV_HG.ClearSelection();
        }

        private void DGV_BHG_Leave(object sender, EventArgs e)
        {
            DGV_BHG.ClearSelection();
        }

        private void DGV_SB_Leave(object sender, EventArgs e)
        {
            DGV_SB.ClearSelection();
        }

        private void PlatManger_MouseDown(object sender, MouseEventArgs e)
        {
            DGV_MeterInfo.ClearSelection();
            DGV_plat.ClearSelection();
            if (der != null)
                der.Close();
            // Showmsg("pp");
        }

        private void BT_Canccel_Click(object sender, EventArgs e)
        {
            bool isnull = true;
            for(int i =0; i < this.DGV_MeterInfo.Rows.Count; i++)
            {
                DataGridViewRow dr = DGV_MeterInfo.Rows[i];
                if ((bool)dr.Cells["MeterCancel"].Value == true)
                {
                    CommonFunction.dic_cancel.Add(dr.Cells["MeterId"].Value.ToString(), "失败");
                    isnull = false;
                }                    
            }
            if(isnull) MessageBox.Show("没有要取消测试的燃气表！");
            else
            {
                Cancel_Test ct = new Cancel_Test();
                ct.Show();
            }             
        }

        private void BT_ST_SE_Click(object sender, EventArgs e)
        {
            if (BT_SE.Text == "开启服务") {
                if (OpenServer()) {
                    Lisenter();
                    SetBtsetext("关闭服务", Color.Black);
                }                   
            }              
            else if (BT_SE.Text == "关闭服务") {
                CommonFunction.myServer.Stop();
                LogHelper.Info("服务关闭！");
                CommonFunction.flag_listener = false;
                SetTB_lister("通信异常监听关闭", Color.Red, false);
                SetBtsetext("开启服务",Color.Green);
            }
        }
        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //界面还原的按钮
            this.Width = this.formStartX;
            this.Height = this.formStartY;

            fc.Reset(this, fc);
        }

        //private void DGV_MeterInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    Showmsg("123");
           
        //}
        /// <summary>
        ///不测正常，正测lightyellow,失败red,成功green
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="id"></param>
        /// <param name="c"></param>
        //private void Change_row(DataGridView dgv, string id,Color c) {
        //    for (int i = 0; i < dgv.Rows.Count; i++) {
        //        if (dgv.Rows[i].Cells["MeterId"].Value.Equals(id)) {
        //            dgv.Rows[i].DefaultCellStyle.BackColor = c;
        //        }
        //    }
        //}
        //private void Change_cell(DataGridView dgv, string id, string type, Color c) {
        //    foreach(DataGridViewRow dr in dgv.Rows)
        //    {
        //        if (dr.Cells["MeterId"].Equals(id)) {
        //            foreach (DataGridViewCell dc in dr.Cells) {
        //                if (dc.Value.Equals(type))
        //                    dc.Style.ForeColor = c;
        //            }
        //        }

        //    }
        //}
        private void Change_st(DataGridView dgv) {
            for (int i = 0; i < dgv.Rows.Count-1; i++)
            {
                DataGridViewRow dr = dgv.Rows[i];  
                //if(dr.Cells["MeterTest"].Value.Equals(""))
                if (dr.Cells["MeterState"].Value.Equals("失败"))
                    dr.DefaultCellStyle.BackColor = Color.LightPink;
                if (dr.Cells["MeterState"].Value.Equals("合格"))
                    dr.DefaultCellStyle.BackColor = Color.LightGreen;
                if (!dr.Cells["MeterTest"].Value.Equals("空闲"))
                    dr.DefaultCellStyle.BackColor = Color.LightYellow;
                foreach (DataGridViewCell dc in dr.Cells)
                {
                    if (dc.Value.Equals("失败"))
                        dc.Style.ForeColor = Color.Red;
                    if (dc.Value.Equals("成功"))
                        dc.Style.ForeColor = Color.Green;
                }
            }
        }
        private void Change_pl(DataGridView dgv)
        {
            foreach (DataGridViewRow dr in dgv.Rows)
            {                
                foreach (DataGridViewCell dc in dr.Cells)
                {
                    if (dc.Value.Equals("异常"))
                        dc.Style.ForeColor = Color.Red;
                    if (dc.Value.Equals("正忙")|| dc.Value.Equals("就绪"))
                        dc.Style.ForeColor = Color.DarkOrange;
                    if (dc.Value.Equals("空闲"))
                        dc.Style.ForeColor = Color.LimeGreen;
                }
            }
        }

        private void TB_Listener_Click(object sender, EventArgs e)
        {

        }

        private bool OpenServer() {
            if (Server.State == ServerState.NotInitialized)
            {
                if (!CommonFunction.myServer.Setup(Convert.ToInt16(CommonFunction.dicBooks["strMainHostPort"])))
                {
                    LogHelper.Info("3001端口被占用");
                    return false;
                }
            }
            if (!CommonFunction.myServer.Start())
            {
                LogHelper.Info("开启失败" + Server.State.ToString());
                return false;
            }
            else
            {
                LogHelper.Info("\n\n\nServer开启成功");
                return true;
            }
        }

        private void SetBtsetext(object s,Color c) {
            if (BT_SE.InvokeRequired)
            {
                MyDelegate_bt mb = new MyDelegate_bt(SetBtsetext);
                this.Invoke(mb, new object[] { s, c });
            }
            else {
                BT_SE.Text = s.ToString();
                BT_SE.ForeColor = c;
            }           
        }

        private void Lisenter()
        {
            CommonFunction.flag_listener = true;
            Thread t = new Thread(Heart)
            {
                IsBackground = true
            };
            t.Start();
            // ShowListener("通信异常监听开启！");
            SetTB_lister("通信异常监听开启", Color.Green, true);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ChangeMeter();
            ChangePlat();
            ChangeBHG();
            ChangeHG();
            ChangeSB();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Repalt re = new Repalt();
            re.Show();
        }

        private void DGV_MeterInfo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string type = "";
            string ever = "";
            string id = "";            
            if((e.ColumnIndex == 2 || e.ColumnIndex==3|| e.ColumnIndex == 4|| e.ColumnIndex == 5)&& !((this.DGV_MeterInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Equals("不测")))
            {
                switch (e.ColumnIndex)
                {
                    case 2:
                        id = this.DGV_MeterInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                        type = "IC卡卡控测试";
                        ever = (Myadapter.GetDataBy1(id).Rows[0]["MeterEvery"].ToString()).Substring(10, 2);
                        break;
                    case 3:
                        id = this.DGV_MeterInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                        type = "初检测试";
                        ever = (Myadapter.GetDataBy1(id).Rows[0]["MeterEvery"].ToString()).Substring(0, 8);
                        break;
                    case 4:
                        id = this.DGV_MeterInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                        ever = (Myadapter.GetDataBy1(id).Rows[0]["MeterEvery"].ToString()).Substring(14, 4);
                        type = "命令检测测试";
                        break;
                    case 5:
                        id = this.DGV_MeterInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                        ever = (Myadapter.GetDataBy1(id).Rows[0]["MeterEvery"].ToString()).Substring(20, 10);
                        type = "终检测试";
                        break;
                }
                DialogResult dr = MessageBox.Show("是否要查看表："+id+" "+type+"的详细测试信息",
                "提示！",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                if(dr == DialogResult.Yes)
                {
                    der = new DetailResult(id, e.ColumnIndex,ever,"AAAA");
                    der.Show();
                }
            }
        }

        private void DGV_MeterInfo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                if (der != null)
                    der.Close();
            }
        }

        private async void PostLl(string id, string type,string cmd)
        {
            try
            {
                List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>>();
                param.Add(new KeyValuePair<string, string>("waring", cmd));
                param.Add(new KeyValuePair<string, string>("wid", id));
                param.Add(new KeyValuePair<string, string>("wtype", type));
                string x = await CommonFunction.hs.PostSend("http://192.168.3.137:8000/rtr/", param);
                Debug.Print(x);
                LogHelper.Info(x);
            }
            catch (Exception we)
            {
                LogHelper.Error("向网站推送异常出错" + we);
            }
           
        }

        private void TSB_search_Click(object sender, EventArgs e)
        {
            Search se = new Search();
            se.Show();
        }
    }
}
