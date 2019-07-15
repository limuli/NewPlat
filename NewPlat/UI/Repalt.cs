using NewPlat.BLL;
using NewPlat.Model;
using NewPlat.MyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NewPlat.UI
{
    public partial class Repalt : Form
    {
        private Dt_PlateInfoTableAdapter Myadapter_p;
        public Repalt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in DGV_replat.Rows)
            {

                //    if (Convert.ToBoolean(dr.Cells["ischeck"].Value))
                //    {
                //        //根据IP与port寻找检测平台
                //        //因此同一IP的检测平台不能有相同的port
                //        HeartInfo temp = new HeartInfo
                //        {
                //            IP = dr.Cells["IP"].Value.ToString(),
                //            Port = dr.Cells["Port"].Value.ToString()
                //        };
                //        if(CommonFunction.hearts.ContainsKey())
                //           CommonFunction.heart[tempi].State = "正常";
                //       // CommonFunction.platm.ShowListener("第" + CommonFunction.heart[tempi].Id + "台电脑的" + CommonFunction.heart[tempi].Type + "平台通信异常");
                //        switch (dr.Cells["Type"].Value.ToString())
                //        {
                //            case "命令检测":
                //                Myadapter_p.UpdatePlatCom("空闲", (int)dr.Cells["Id"].Value);
                //                break;
                //            case "Ic检测":
                //                Myadapter_p.UpdatePlatIc("空闲", (int)dr.Cells["Id"].Value);
                //                break;
                //            case "初检模式表":
                //                Myadapter_p.UpdatePlatChu_msb("空闲", (int)dr.Cells["Id"].Value);
                //                break;
                //            case "初检修正仪":
                //                Myadapter_p.UpdatePlatChu_xzy("空闲", (int)dr.Cells["Id"].Value);
                //                break;
                //            case "初检超声波":
                //                Myadapter_p.UpdatePlatChu_csb("空闲", (int)dr.Cells["Id"].Value);
                //                break;
                //            case "终检":
                //                Myadapter_p.UpdatePlatZho("空闲", (int)dr.Cells["Id"].Value);
                //                break;
                //        }                   
                //    }
            }
            //CommonFunction.platm.ChangePlat();
            this.Close();
        }

        private void Repalt_Load(object sender, EventArgs e)
        {
            //    Myadapter_p = new Dt_PlateInfoTableAdapter();
            //    //HeartInfo temp = new HeartInfo();
            //    List<HeartInfo> hli = new List<HeartInfo>();
            //    for (int i = 0; i < CommonFunction.heart.Count; i++)
            //    {
            //        HeartInfo temp = new HeartInfo();
            //        temp = CommonFunction.heart[i];
            //        if (temp.State.Equals("禁用"))
            //            hli.Add(temp);                
            //    }
            //    DGV_replat.DataSource = hli;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
