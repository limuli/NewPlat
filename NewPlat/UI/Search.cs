using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewPlat.BLL;
using NewPlat.Model;

namespace NewPlat.UI
{
    public partial class Search : Form
    {
        Dictionary<string, string> manufacture = new Dictionary<string, string>();
        public Search()
        {
            InitializeComponent();
        }

        private void Serach_Click(object sender, EventArgs e)
        {
            string sql = "Select * From mygas_meter_test WHERE 1=1";
            string sql2 = "Select * From mygas_meterplat WHERE 1=1";
            if (CB_MeterId.Checked == true)
            {
                sql += string.Format(@" AND MeterId = '{0}'",TB_MeterId.Text);
                sql += string.Format(@" AND MeterId = '{0}'", TB_MeterId.Text);
            }
            if (CB_Time.Checked == true)
            {
                sql += string.Format(@" AND MeterTime > '{0}' AND MeterTime < '{1}'", DTP_Start.Value.ToString(), DTP_End.Value.ToString());
            }
            DataTable dt = MysqlHepler.SqlReturnDs(sql).Tables[0];
            DataTable dt2 = MysqlHepler.SqlReturnDs(sql2).Tables[0];
            IList<MeterInfo> li = Dt2serch(Dt2listmeter(dt), Dt2distmeterplat(dt2));
            DGV_MeterInfo.DataSource = li;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            if (!MysqlHepler.SqlOpen())
                MessageBox.Show("数据库连接失败！");
            string sql = "Select * From mygas_manufacture";
            DataTable dt = MysqlHepler.SqlReturnDs(sql).Tables[0];
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                CLB_changjia.Items.Add(dt.Rows[i]["ManufactureName"].ToString());
                manufacture[dt.Rows[i]["id"].ToString()] = dt.Rows[i]["ManufactureName"].ToString();
            }
            DGV_MeterInfo.Visible = true;
            DGV_result.Visible = false;
            DGV_MeterInfo.ClearSelection();
            DGV_result.ClearSelection();
        }

        private List<MeterInfo> Dt2listmeter(DataTable DT)
        {
            List<MeterInfo> result = new List<MeterInfo>();
            for(int i = 0; i<DT.Rows.Count; i++)
            {
                MeterInfo temp = (MeterInfo)Activator.CreateInstance(typeof(MeterInfo));
                PropertyInfo[] pi = temp.GetType().GetProperties();
                foreach(PropertyInfo p in pi)
                {
                    for(int j = 0; j<DT.Columns.Count; j++)
                    {
                        if (p.Name.Equals(DT.Columns[j].ColumnName))
                        {
                            if (DT.Rows[i][j] != DBNull.Value)
                                p.SetValue(temp, DT.Rows[i][j], null);
                            else
                                p.SetValue(temp, null, null);
                            break;
                        }                            
                    }
                }
                result.Add(temp);
            }

            return result;
        }
        private List<MeterSearch> Dt2listmetersearch(DataTable DT)
        {
            List<MeterSearch> result = new List<MeterSearch>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                MeterSearch temp = (MeterSearch)Activator.CreateInstance(typeof(MeterSearch));
                PropertyInfo[] pi = temp.GetType().GetProperties();
                foreach (PropertyInfo p in pi)
                {
                    for (int j = 0; j < DT.Columns.Count; j++)
                    {
                        if (p.Name.Equals(DT.Columns[j].ColumnName))
                        {
                            if (DT.Rows[i][j] != DBNull.Value)
                                p.SetValue(temp, DT.Rows[i][j], null);
                            else
                                p.SetValue(temp, null, null);
                            break;
                        }
                    }
                }
                result.Add(temp);
            }

            return result;
        }
        private Dictionary<string,MeterPlat> Dt2distmeterplat(DataTable DT)
        {
            Dictionary<string, MeterPlat> result = new Dictionary<string, MeterPlat>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                MeterPlat temp = (MeterPlat)Activator.CreateInstance(typeof(MeterPlat));
                PropertyInfo[] pi = temp.GetType().GetProperties();
                foreach (PropertyInfo p in pi)
                {
                    for (int j = 0; j < DT.Columns.Count; j++)
                    {
                        if (p.Name.Equals(DT.Columns[j].ColumnName))
                        {
                            if (DT.Rows[i][j] != DBNull.Value)
                                p.SetValue(temp, DT.Rows[i][j], null);
                            else
                                p.SetValue(temp, null, null);
                            break;
                        }
                    }
                }
                result[temp.MeterId] = temp;
            }

            return result;
        }
        private IList<MeterInfo> Dt2serch(List<MeterInfo> li, Dictionary<string,MeterPlat> mp)
        {
            for(int i =0; i< li.Count; i++)
            {
                //直接在meterplat中查找，然后结果加平台号输出
                if (mp.ContainsKey(li[i].MeterId))
                {
                    if (!(mp[li[i].MeterId].Meterip_Chu.Equals("-1")))
                        li[i].MeterChuState = li[i].MeterChuState + "( " + mp[li[i].MeterId].Meterip_Chu + " )";
                    if (!(mp[li[i].MeterId].Meterip_Com.Equals("-1")))
                        li[i].MeterComState = li[i].MeterComState + "( " + mp[li[i].MeterId].Meterip_Com + " )";
                    if (!(mp[li[i].MeterId].Meterip_IC.Equals("-1")))
                        li[i].MeterIcState = li[i].MeterIcState + "( " + mp[li[i].MeterId].Meterip_IC + " )";
                    if (!(mp[li[i].MeterId].Meterip_Zhong.Equals("-1")))
                        li[i].MeterZhongState = li[i].MeterZhongState + "( " + mp[li[i].MeterId].Meterip_Zhong + " )";

                }
                if (li[i].MeterTest != "空闲")
                {
                    string[] ipport = li[i].Meteriport.Split('@');
                    switch (ipport[3])
                    {
                        case "PlatComs":
                            li[i].MeterComState ="正测( "+ ipport[0]+" )";
                            break;
                        case "PlatIcs":
                            li[i].MeterIcState = "正测( " + ipport[0] + " )";
                            break;
                        case "PlatChus_msb":
                            li[i].MeterChuState = "正测( " + ipport[0] + " )";
                            break;
                        case "PlatChus_xzy":
                            li[i].MeterChuState = "正测( " + ipport[0] + " )";
                            break;
                        case "PlatChus_csb":
                            li[i].MeterChuState = "正测( " + ipport[0] + " )";
                            break;
                        case "PlatZhos":
                            li[i].MeterZhongState = "正测( " + ipport[0] + " )";
                            break;
                    }
                }
            }
            return li;
        }
        private IList<MeterSearch> Dt2serch_result(List<MeterSearch> li, Dictionary<string, MeterPlat> mp)
        {
            for (int i = 0; i < li.Count; i++)
            {
                li[i].MeterPrivilege = li[i].MeterPrivilege.Equals("0") ? "否" : "是";
                //直接在meterplat中查找，然后结果加平台号输出
                if (mp.ContainsKey(li[i].MeterId))
                {
                    if (!(mp[li[i].MeterId].Meterip_Chu.Equals("-1")))
                        li[i].MeterChuState = li[i].MeterChuState + "( " + mp[li[i].MeterId].Meterip_Chu + " )";
                    if (!(mp[li[i].MeterId].Meterip_Com.Equals("-1")))
                        li[i].MeterComState = li[i].MeterComState + "( " + mp[li[i].MeterId].Meterip_Com + " )";
                    if (!(mp[li[i].MeterId].Meterip_IC.Equals("-1")))
                        li[i].MeterIcState = li[i].MeterIcState + "( " + mp[li[i].MeterId].Meterip_IC + " )";
                    if (!(mp[li[i].MeterId].Meterip_Zhong.Equals("-1")))
                        li[i].MeterZhongState = li[i].MeterZhongState + "( " + mp[li[i].MeterId].Meterip_Zhong + " )";

                }
            }
            return li;
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    DGV_MeterInfo.Visible = true;
                    DGV_result.Visible = false;
                    break;
                case 1:
                    DGV_MeterInfo.Visible = false;
                    DGV_result.Visible = true;
                    break;
            }
        }

        private void BT_result_Click(object sender, EventArgs e)
        {
            string sql = "select * From mygas_meter_result INNER JOIN mygas_manufacture on ManufactureName_id = id WHERE 1=1";
            string sql2 = "Select * From mygas_meterplat WHERE 1=1";
            if(CB_id.Checked == true)
            {
                sql += string.Format(@" AND MeterId = '{0}'", TB_ID.Text);
                sql += string.Format(@" AND MeterId = '{0}'", TB_ID.Text);
            }
            if(CB_checktime.Checked == true)
            {
                sql += string.Format(@" AND CheckTime>'{0}' AND CheckTime<'{1}'", dtp_checktime_start, dtp_chencktime_end);
            }
            int f = 0;
            sql += " AND(1=1";
            for(int i =0; i<CLB_changjia.Items.Count; i++)
            {
                if (CLB_changjia.GetItemChecked(i))
                {
                    if(f==0)
                        sql += string.Format(@" AND ManufactureName='{0}'",CLB_changjia.GetItemText(CLB_changjia.Items[i]));
                    else sql += string.Format(@" OR ManufactureName='{0}'", CLB_changjia.GetItemText(CLB_changjia.Items[i]));
                    f++;
                }               
            }
            sql += " )";
            f = 0;
            DataTable dt = MysqlHepler.SqlReturnDs(sql).Tables[0];
            DataTable dt2 = MysqlHepler.SqlReturnDs(sql2).Tables[0];
            IList<MeterSearch> li = Dt2serch_result(Dt2listmetersearch(dt), Dt2distmeterplat(dt2));
            DGV_result.DataSource = li;
        }

        private void BT_all_Click(object sender, EventArgs e)
        {
            for(int i =0; i < CLB_changjia.Items.Count; i++)
            {
                CLB_changjia.SetItemChecked(i,true);
            }
        }

        private void BT_over_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CLB_changjia.Items.Count; i++)
            {
                if(CLB_changjia.GetItemChecked(i))
                    CLB_changjia.SetItemChecked(i, false);
                else CLB_changjia.SetItemChecked(i, true);
            }
        }

        private void DGV_result_Leave(object sender, EventArgs e)
        {
            DGV_result.ClearSelection();
        }

        private void DGV_MeterInfo_Leave(object sender, EventArgs e)
        {
            DGV_MeterInfo.ClearSelection();
        }

        private void Search_MouseDown(object sender, MouseEventArgs e)
        {
            DGV_MeterInfo.ClearSelection();
            DGV_result.ClearSelection();
            CLB_changjia.SelectedItems.Clear();
        }

        private void TabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            DGV_MeterInfo.ClearSelection();
            DGV_result.ClearSelection();
            CLB_changjia.SelectedItems.Clear();
        }

        private void TB_jindu_MouseDown(object sender, MouseEventArgs e)
        {
            DGV_MeterInfo.ClearSelection();
            DGV_result.ClearSelection();
            CLB_changjia.SelectedItems.Clear();
        }

        private void TP_result_MouseDown(object sender, MouseEventArgs e)
        {
            DGV_MeterInfo.ClearSelection();
            DGV_result.ClearSelection();
            CLB_changjia.SelectedItems.Clear();
        }
    }
}
