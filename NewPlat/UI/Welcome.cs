using NewPlat.BLL;
using NewPlat.Model;
using NewPlat.MyDataSetTableAdapters;
using NewPlat.MySuperSocket;
using NewPlat.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static NewPlat.MyDataSet;

namespace NewPlat.UI
{
    public partial class Welcome : Form
    {        private Dt_PlateInfoTableAdapter Myadapter_p;
        public static string SerialNumber = "";
        public static string KeyNow = "";
        private delegate void MyDelegate(string data, Color color);
        private delegate void MyDelegate2(Boolean f);
        public Welcome()
        {
            InitializeComponent();
            
            if (!getPCInfo.IsValid(out SerialNumber, out KeyNow))
            {
                FormSecurity formSecurity = new FormSecurity();
                formSecurity.ShowDialog();
                //formSecurity.Dispose();
            }
            CommonFunction.dicAppConfig["strValid"] = ConfigurationManager.AppSettings["strValid"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (CommonFunction.dicAppConfig["strValid"] == "true")
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("请注册");
                LogHelper.Info("请注册");
            }

        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dresult = MessageBox.Show("确认退出?", "退出程序", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dresult == DialogResult.OK)
            {
                Application.ExitThread(); //注意不是EXIT()
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            Myadapter_p = new Dt_PlateInfoTableAdapter();
            
            SetSqllb("请检测数据库连接情况", Color.Red);
            pb_wait.Visible = false;
        }
        /// <summary>
        /// 设置数据库检测lable
        /// </summary>
        /// <param name="s"></param>
        private void SetSqllb(string s, Color color)
        {
            if (lb_sqltest.InvokeRequired)
            {
                MyDelegate md = new MyDelegate(SetSqllb);
                this.Invoke(md, new object[] { s, color });
            }
            else
            {
                lb_sqltest.Text = s;
                lb_sqltest.ForeColor = color;
            }
        }
        /// <summary>
        /// 设置wait显示问题
        /// </summary>
        /// <param name="s"></param>
        private void Setwait(bool f)
        {
            if (lb_sqltest.InvokeRequired)
            {
                MyDelegate2 md = new MyDelegate2(Setwait);
                this.Invoke(md, new object[] { f });
            }
            else
            {
                    pb_wait.Visible = f;
            }
        }

        private void bt_sqltest_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Wait)
            {
                IsBackground = true
            };
            t.Start();
            Setwait(true);
        }
        /// <summary>
        /// 测试数据库连接情况，通过查询platinfo中的PlatZhos字段
        /// </summary>
        private void Wait()
        {
            SetSqllb("数据库连接测试中", Color.Red);
            Thread.Sleep(2000);
            try
            {
                // string n = Myadapter_p.ScalarTest("未启用").ToString();
                // if (n != null)
                if (MysqlHepler.SqlOpen())
                {
                    SetSqllb("数据库测试通过", Color.Green);
                    MysqlHepler.SqlClose();
                }
                    
                else SetSqllb("数据库连接失败(1)", Color.Red);

            }
            catch (Exception)
            {
                SetSqllb("数据库连接失败(2)", Color.Red);
            }
            Thread.Sleep(200);
            Setwait(false);
        }

        private void pb_wait_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int a = Convert.ToInt32(Myadapter_Mp.SQ_MP("000000000001"));
            //Thread t1 = new Thread(test);
            //Thread t2 = new Thread(test2);
            //t1.Start();
            //t2.Start();
            //StringBuilder sb = new StringBuilder("1111111111");
            //sb.Replace("11", "22", 0, 2);
            //string s = sb.ToString();
            //try
            //{
            //    long n = Convert.ToInt64(Myadapter_Mp.SQ_MP("999999999999"));
            //    bool m = Myadapter.SQ_Privilege("1")!=0;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //DataTable dt = new DataTable();
            //MeterInfo tempmeter = new MeterInfo();
            //bool f = true;
            //dt = Myadapter_r.GetDataBy_r("0", "合格", "准备");
            //if (dt != null && dt.Rows.Count > 0)
            //    tempmeter = DataHelper.Dt2Ob(dt);
            //else
            //{
            //    f = false;
            //}

            //if (tempmeter != null && f)
            //{

            //}
            //else
            //{
            //    LogHelper.Info("表不在检测列表中");
            //}
            //string re = "";
            //string[] tip = re.Split('@');
            //string me = "00000000000000000000000000000000";
            //StringBuilder re_ev = new StringBuilder(me);
            //string oldchar = me.Substring(0, 10);
            //re_ev.Replace(oldchar, "AAAAAAAA0A", 0, 10);
            //string T = re_ev.ToString();

            //Dictionary<string, string> dtest = new Dictionary<string, string>();
            //dtest["1"] = "2";
            //dtest["2"] = "3";
            //dtest.Remove("1");
            //Dictionary<string, string> dtest2 = dtest;
            //test3Async();
            DT_WaringPlatTableAdapter myadapter_wp = new DT_WaringPlatTableAdapter();
            //DataTable dtw = myadapter_wp.GetDataBy_it("1", "1");

        }
        private void test() {
            StreamWriter sw = new StreamWriter(@"D:\\Info\\err_.txt", true, Encoding.Default);
            for (int i = 0; i < 10000; i++) {
                try
                {
                    Dt_MeterInfoTableAdapter Myadapter = new Dt_MeterInfoTableAdapter();
                    Myadapter.GetDataBy1("000000000001");
                    // MyDataSet.Dt_MeterInfoDataTable.GetAdapter().GetDataBy1("000000000001");
                    Debug.Print("1   " + i);
                }
                catch (Exception e)
                {
                    sw.Write("1   " + i + e + Environment.NewLine);
                }
                
            }
        }
        private void test2()
        {
            StreamWriter sw = new StreamWriter(@"D:\\Info\\eerr_.txt", true, Encoding.Default);
            for (int i = 0; i < 10000; i++)
            {
                try
                {
                    //if(Myadapter.Connection.State == ConnectionState.Open)
                    Dt_MeterInfoTableAdapter Myadapter = new Dt_MeterInfoTableAdapter();
                    Myadapter.GetDataBy1("000000000005");
                    Debug.Print("2   " + i);
                }
                catch (Exception e)
                {
                    sw.Write("2   " + i + e + Environment.NewLine);
                }
                Thread.Sleep(100);
            }
        }
        private async void test3Async()
        {
          
            List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("rtr", "你好"));
            string x = await CommonFunction.hs.PostSend("http://192.168.3.137:8000/rtr/", param);
            Debug.Print(x);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
