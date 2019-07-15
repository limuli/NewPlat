using NewPlat.BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace NewPlat.UI
{
    public partial class Login : Form
    {
        bool flag;
        public Login()
        {
            InitializeComponent();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            //读取book.xml
            //数字与端口名字一一对应
            XmlElement root = null;
            XmlDocument xmldoc = new XmlDocument();
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                //时间
                ["strMainHostIP"] = "62.234.134.161",
                ["strMainHostPort"] = "3001",
                ["strJituanHostIP"] = "212.64.12.60",
                ["strJituanHostPort"] = "3001",
                ["strJituanHostDomain"] = "baidu.com",
                ["AllowNum"] = "1"
            };
            string xmlPath = "";
            try
            {
                xmlPath = (System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "books.xml";
                //string xmlPath = @"D:\books.xml";
                xmldoc.Load(@xmlPath);
                root = xmldoc.DocumentElement;
            }
            catch
            {
                //没有books.xml
            }
            foreach (var item in dic)
            {
                try
                {
                    if (XmlReadStr(root, item.Key) != "default")
                        CommonFunction.dicBooks[item.Key] = XmlReadStr(root, item.Key);
                    else
                        CommonFunction.dicBooks[item.Key] = dic[item.Key];
                }
                catch
                {
                    MessageBox.Show("books.xml没有" + item.Key);
                    //LogHelper.Info("books.xml没有" + item.Key);
                }
            }
            //JianceConfig jianceConfig = new JianceConfig();
            //jianceConfig.Show();
            CommonFunction.platm = new PlatManger();
            CommonFunction.platm.Show();
            flag = true;
            this.Close();
        }

        private string XmlReadStr(XmlElement root, string p)
        {
            XmlElement theBook = (XmlElement)root.SelectSingleNode("/params/param[name='" + p + "']");
            return (theBook.GetElementsByTagName("value").Item(0).InnerText);
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!flag)
                CommonFunction.frmWelcome.Show();          
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
