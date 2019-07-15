using NewPlat.MySuperSocket;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace NewPlat.UI
{
    public partial class FormSecurity : Form
    {
        string SerialNumber = Welcome.SerialNumber;
        string KeyNow = Welcome.KeyNow;
        int LifeTime = int.Parse(ConfigurationManager.AppSettings["LifeTime"].ToString());
        public FormSecurity()
        {
            InitializeComponent();
        }
        private void FormSecurity_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "ZNCS" + SerialNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LifeTime > 0 && LifeTime <= 10)
            {

                if (KeyNow != this.textBox2.Text)
                {
                    LifeTime--;
                    MessageBox.Show("密钥错误，还剩" + (LifeTime) + "次机会");
                }
                else
                {
                    Configuration cfgg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    cfgg.AppSettings.Settings["strkey"].Value = KeyNow;
                    cfgg.Save();
                    this.Hide();
                    this.Close();
                }
            }
            else
            {
                LifeTime = 0;
                MessageBox.Show("产品未授权，请联系产品开发商");
                string strPath = System.IO.Directory.GetCurrentDirectory();
                FileAttributes attr = File.GetAttributes(strPath);
                try
                {
                    if (attr == FileAttributes.Directory)
                    {
                        strPath += "\\test\\";
                        Directory.Delete(strPath, true);
                    }
                    else
                    {
                        File.Delete(strPath);
                    }
                }
                catch (Exception ee)
                {
                    LogHelper.Error(ee.ToString());
                }

            }
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfg.AppSettings.Settings["LifeTime"].Value = LifeTime.ToString();
            cfg.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show("确认退出?", "退出程序", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dresult == DialogResult.OK)
            {
                Application.ExitThread(); //注意不是EXIT()
            }
        }
        private void FormSecurity_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
