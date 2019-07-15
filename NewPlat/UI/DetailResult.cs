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
        public DetailResult()
        {
            InitializeComponent();
        }
        public DetailResult(String MeterId, int type, string every)
        {
            InitializeComponent();
            this.id = MeterId;
            this.type = type;
            this.every = every;
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
    }
}
