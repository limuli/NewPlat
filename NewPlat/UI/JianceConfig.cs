using NewPlat.BLL;
using NewPlat.Model;
using NewPlat.MyDataSetTableAdapters;
using NewPlat.MySuperSocket;
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
    public partial class JianceConfig : Form
    {
        private Dt_PlateInfoTableAdapter Myadapter_p;
        bool flag;
        private int formStartX = 0;
        private int formStartY = 0;
        FormControl fc = null;
        public JianceConfig()
        {
            InitializeComponent();
        }

        private void JianceConfig_Load(object sender, EventArgs e)
        {
            Myadapter_p = new Dt_PlateInfoTableAdapter();
            try
            {
                this.dt_PlateInfoTableAdapter.Fill(this.myDataSet.Dt_PlateInfo);
                DGPlatConfig.ClearSelection();
            }
            catch (Exception)
            {
                MessageBox.Show("本地数据库连接异常");
            }
            // TODO: 这行代码将数据加载到表“myDataSet.Dt_PlateInfo”中。您可以根据需要移动或删除它。           
            flag = false;
            this.DGPlatConfig.AllowUserToAddRows = false;

            fc = new FormControl(this);
            fc.GetInit(this, fc);

            this.formStartX = this.Width;
            this.formStartY = this.Height;

            TB_IP.Text = CommonFunction.dicBooks["strMainHostIP"];
            TB_PORT.Text = CommonFunction.dicBooks["strMainHostPort"];
        }

        private void bt_configplatinfo_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable dt = this.dt_PlateInfoTableAdapter.GetData();
                //CommonFunction.heart = Dt2IList(dt);
                //CommonFunction.platInfos = DataHelper.DS2List(dt);
                //PlatManger platManger = new PlatManger();
                //platManger.Show();
                //flag = true;
                //this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("数据库异常");
            }                     
        }
        /// <summary>
        /// 添加平台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_add_Click(object sender, EventArgs e)
        {
            if (tb_add.Text != "")
            {
                this.DGPlatConfig.AllowUserToAddRows = true;
                try
                {
                    //if (Myadapter_p.InsertPlat(int.Parse(tb_add.Text),"212.64.12.60","空闲", "空闲", "空闲", "空闲", "空闲", "空闲") != 1)
                    //{
                    //    MessageBox.Show("添加失败");
                    //    // LogHelper.Info("添加平台失败");
                    //}
                    //else {
                    //    MessageBox.Show("添加成功");
                    //}
                }
                catch (Exception)
                {
                    MessageBox.Show("添加失败，请检查此ID是否已经存在");
                }
                this.dt_PlateInfoTableAdapter.Fill(this.myDataSet.Dt_PlateInfo);
                this.DGPlatConfig.AllowUserToAddRows = false;
                DGPlatConfig.ClearSelection();
            }
            else {
                MessageBox.Show("请输入要添加的主机ID");
            }
            
        }
        /// <summary>
        /// 检测平台关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JianceConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!flag)
                CommonFunction.frmWelcome.Show();
        }
        /// <summary>
        /// 删除平台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_delet_Click(object sender, EventArgs e)
        {
            if (tb_delet.Text != "")
            {
                this.DGPlatConfig.AllowUserToAddRows = true;
                try
                {
                    if (Myadapter_p.DeletePlat(int.Parse(tb_delet.Text)) != 1)
                    {
                        MessageBox.Show("删除失败，请检查此ID是否已经删除");
                        // LogHelper.Info("添加平台失败");
                    }
                    else
                    {
                        MessageBox.Show("删除成功");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("删除失败，请检查此ID是否已经删除");
                }
                this.dt_PlateInfoTableAdapter.Fill(this.myDataSet.Dt_PlateInfo);
                this.DGPlatConfig.AllowUserToAddRows = false;
                DGPlatConfig.ClearSelection();
            }
            else
            {
                MessageBox.Show("请输入要删除的主机ID");
            }
        }
        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_save_Click(object sender, EventArgs e)
        {
           DataTable Changedt = this.myDataSet.Dt_PlateInfo.GetChanges();
           bool flag2 = true;
            if (Changedt != null)
            {
                foreach (DataRow dr in Changedt.Rows)
                {
                    if (dr.RowState == System.Data.DataRowState.Modified)
                    {
                        try
                        {
                            if (Myadapter_p.UpdatePlat(dr["IP"].ToString(), dr["PlatComs"].ToString(), dr["PlatIcs"].ToString(), dr["PlatChus_msb"].ToString(), dr["PlatChus_xzy"].ToString(), dr["PlatChus_csb"].ToString(), dr["PlatZhos"].ToString(), dr["PlatComp"].ToString(), dr["PlatIcp"].ToString(), dr["PlatChup_msb"].ToString(), dr["PlatChup_xzy"].ToString(), dr["PlatChup_csb"].ToString(), dr["PlatZhop"].ToString(),Convert.ToInt32(dr["Id"].ToString())) > 0)
                                flag2 = true;
                            else flag2 = false;
                        }
                        catch (Exception se)
                        {
                            MessageBox.Show("配置信息修改失败" + se.ToString());
                        }

                    }
                }
                if (flag2 == true)
                    MessageBox.Show("配置信息修改成功");
                else MessageBox.Show("配置信息修改失败");
                this.dt_PlateInfoTableAdapter.Fill(this.myDataSet.Dt_PlateInfo);
                DGPlatConfig.ClearSelection();
            }
            else MessageBox.Show("配置信息修改成功");
        }
        /// <summary>
        /// datable转化为list,应用于心跳机制
        /// </summary>
        /// <param name="ds">dataset</param>
        /// <param name="index">datable的索引</param>
        /// <returns></returns>
        private List<HeartInfo> Dt2IList(DataTable dt)
        {
            List<HeartInfo> result = new List<HeartInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                HeartInfo temp = new HeartInfo();
                temp = Hti(dr, "PlatComs", "PlatComp", "命令检测");
                if (temp != null)
                    result.Add(temp);
                temp = Hti(dr, "PlatIcs", "PlatIcp", "Ic检测");
                if (temp != null)
                    result.Add(temp);
                temp = Hti(dr, "PlatChus_msb", "PlatChup_msb", "初检模式表");
                if (temp != null)
                    result.Add(temp);
                temp = Hti(dr, "PlatChus_xzy", "PlatChup_xzy", "初检修正仪");
                if (temp != null)
                    result.Add(temp);
                temp = Hti(dr, "PlatChus_csb", "PlatChup_csb", "初检超声波");
                if (temp != null)
                    result.Add(temp);
                temp = Hti(dr, "PlatZhos", "PlatZhop", "终检");
                if (temp!=null)
                    result.Add(temp);
            }
            return result;
        }
        /// <summary>
        /// 返回心跳类型
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="type1">PlatChus</param>
        /// <param name="type2">PlatChup</param>
        /// <returns></returns>
        private HeartInfo Hti(DataRow dr, string type1, string type2,string type3)
        {
            if (!dr[type1].ToString().Equals("空闲"))
                return null;
            else
            {
                HeartInfo temp = new HeartInfo
                {
                    Id = (int)dr["Id"],
                    IP = dr["IP"].ToString(),
                    Type = type3,
                    Port = dr[type2].ToString(),
                    Ke_al = 00,
                    State = "正常"
                };
                return temp;
            }
        }
        private void JianceConfig_MouseDown(object sender, MouseEventArgs e)
        {
            DGPlatConfig.ClearSelection();
        }

        private void BT_Save_host_Click(object sender, EventArgs e)
        {
            Boolean a = false, b = false;
            if (TB_IP.Text != "") {
                CommonFunction.dicBooks["strMainHostIP"] = TB_IP.Text;
                a = true;
            }                
            else MessageBox.Show("IP地址不能为空！");
            if (TB_PORT.Text != "")
            {
                CommonFunction.dicBooks["strMainHostPort"] = TB_PORT.Text;
                b = true;
            }                
            else MessageBox.Show("端口不能为空！");
            if( a & b)
                MessageBox.Show("修改成功！");
            else MessageBox.Show("修改失败！");
        }
    }
}
       