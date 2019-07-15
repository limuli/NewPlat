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
    public partial class Cancel_Test : Form
    {
        private Dt_MeterInfoTableAdapter Myadapter;
        private DT_ResultTableAdapter Myadapter_r;
        public Cancel_Test()
        {
            InitializeComponent();
        }

        private void Cancel_Test_Load(object sender, EventArgs e)
        {
            Myadapter = new Dt_MeterInfoTableAdapter();
            Myadapter_r = new DT_ResultTableAdapter();
            foreach (string key in CommonFunction.dic_cancel.Keys) {
                int index = DGV_CANCEL.Rows.Add();
                DGV_CANCEL.Rows[index].Cells[0].Value = key;
                DGV_CANCEL.Rows[index].Cells[1].Value = CommonFunction.dic_cancel[key];
                if (CommonFunction.dic_cancel[key].Equals("合格"))
                    DGV_CANCEL.Rows[index].Cells[1].Style.ForeColor = Color.Green;
                else DGV_CANCEL.Rows[index].Cells[1].Style.ForeColor = Color.Red;
            }
            DGV_CANCEL.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            CommonFunction.dic_cancel.Clear();
            CommonFunction.platm.ChangeMeter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string key in CommonFunction.dic_cancel.Keys)
                {
                    MeterInfo tempmeter = new MeterInfo();
                    tempmeter = DataHelper.Dt2Ob(Myadapter.GetDataBy1(key));
                    if (tempmeter != null)
                    {                        
                            Myadapter_r.InsertMeter(tempmeter.MeterId,
                                                                   tempmeter.MeterType,
                                                                   tempmeter.MeterComState,
                                                                   tempmeter.MeterIcState,
                                                                   tempmeter.MeterChuState,
                                                                   tempmeter.MeterZhongState,
                                                                   CommonFunction.dic_cancel[key],
                                                                   tempmeter.MeterTest,
                                                                   tempmeter.MeterRand_num,
                                                                   tempmeter.Meteriport,
                                                                   tempmeter.MeterTime,
                                                                   CommonFunction.dic_cancel[key],
                                                                   tempmeter.MeterEvery,
                                                                   tempmeter.MeterPrivilege,
                                                                   tempmeter.CheckTime,
                                                                   tempmeter.ManufactureName_id,
                                                                   tempmeter.Subtime);
                        Myadapter.DeleteMeter(key);
                    }                    
                }
            }
            catch (Exception)
            {
                LogHelper.Error("取消测试失败");
                MessageBox.Show("取消测试失败");
            }
            CommonFunction.platm.ChangeMeter();
            CommonFunction.platm.ChangeHG();
            CommonFunction.platm.ChangeBHG();
            CommonFunction.platm.ChangeSB();
            CommonFunction.dic_cancel.Clear();
            this.Close();
        }

        private void Cancel_Test_MouseDown(object sender, MouseEventArgs e)
        {
            DGV_CANCEL.ClearSelection();
        }
    }
}
