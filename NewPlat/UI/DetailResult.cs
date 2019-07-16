using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPlat.UI
{
    public partial class DetailResult : Form
    {
        string id;
        int type;
        string every;
        string fla;
        public DetailResult()
        {
            InitializeComponent();
        }
        public DetailResult(String MeterId, int type, string every,string fla)
        {
            InitializeComponent();
            this.id = MeterId;
            this.type = type;
            this.every = every;
            this.fla = fla;
        }

        private void DetailResult_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            switch (type)
            {
                case 2:
                    dic["IC卡卡控"] = Reresult(every.Substring(0, 2));
                    break;
                case 3:
                    dic["常规数据"] = Reresult(every.Substring(0, 2));
                    dic["修改秘钥"] = Reresult(every.Substring(2, 2));
                    dic["修改网络参数"] = Reresult(every.Substring(4, 2));
                    dic["远程升级"] = Reresult(every.Substring(6, 2));
                    break;
                case 4:
                    dic["常规检测"] = Reresult(every.Substring(0, 2));
                    dic["错误命令"] = Reresult(every.Substring(2, 2));
                    break;
                case 5:
                    dic["常规数据"] = Reresult(every.Substring(0, 2));
                    dic["修改秘钥"] = Reresult(every.Substring(2, 2));
                    dic["修改网络参数"] = Reresult(every.Substring(4, 2));
                    dic["远程升级"] = Reresult(every.Substring(6, 2));
                    break;
                case 6:
                    if (fla.Substring(0, 1) == "A")
                    {
                        dic["常规数据"] = Reresult(every.Substring(0, 2));
                        dic["修改秘钥"] = Reresult(every.Substring(2, 2));
                        dic["修改网络参数"] = Reresult(every.Substring(4, 2));
                        dic["远程升级"] = Reresult(every.Substring(6, 2));
                    }
                    else
                    {
                        dic["常规数据"] = "不测";
                        dic["修改秘钥"] = "不测";
                        dic["修改网络参数"] = "不测";
                        dic["远程升级"] = "不测";
                    }
                    if(fla.Substring(1,1) == "A")
                    {
                        dic["IC卡卡控"] = Reresult(every.Substring(10, 2));
                    }
                    else
                    {
                        dic["IC卡卡控"] = "不测";
                    }
                    if (fla.Substring(2, 1) == "A")
                    {
                        dic["常规检测"] = Reresult(every.Substring(14, 2));
                        dic["错误命令"] = Reresult(every.Substring(16, 2));
                    }
                    else
                    {
                        dic["常规检测"] = "不测";
                        dic["错误命令"] = "不测";
                    }
                    if (fla.Substring(3, 1) == "A")
                    {
                        dic["1"] = Reresult(every.Substring(20, 2));
                        dic["2"] = Reresult(every.Substring(22, 2));
                        dic["3"] = Reresult(every.Substring(24, 2));
                        dic["4"] = Reresult(every.Substring(26, 2));
                    }
                    else
                    {
                        dic["1"] = "不测";
                        dic["2"] = "不测";
                        dic["3"] = "不测";
                        dic["4"] = "不测";
                    }                   
                    break;
            }
            this.DGV_Every.Rows.Clear();
            label1.Text = "表号：" + id;
            foreach (string k in dic.Keys)
            {
                int i = this.DGV_Every.Rows.Add();
                this.DGV_Every.Rows[i].Cells[0].Value = k;
                this.DGV_Every.Rows[i].Cells[1].Value = dic[k];
            }
        }

        private string Reresult(string s)
        {
            string re = "";
            if (s.Equals("00"))
                re = "待测";
            if (s.Equals("AA"))
                re = "合格";
            if (s.Equals("55"))
                re = "不合格";
            return re;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
