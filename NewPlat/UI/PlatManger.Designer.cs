using NewPlat.BLL;

namespace NewPlat.UI
{
    partial class PlatManger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlatManger));
            this.dtMeterInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataSet = new NewPlat.MyDataSet();
            this.test = new System.Windows.Forms.Button();
            this.TB_Listener = new System.Windows.Forms.Label();
            this.TB_show = new System.Windows.Forms.TextBox();
            this.DGV_plat = new System.Windows.Forms.DataGridView();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatComs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatIcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatChus_msb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatChus_xzy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatChus_csb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatZhos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtPlateInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DGV_MeterInfo = new System.Windows.Forms.DataGridView();
            this.MeterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterIcState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterChuState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterComState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterZhongState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterCancel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MeterPrivilege = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BT_Canccel = new System.Windows.Forms.Button();
            this.BT_SE = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DGV_SB = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTSBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DGV_BHG = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTBHGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DGV_HG = new System.Windows.Forms.DataGridView();
            this.meterIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dt_MeterInfoTableAdapter = new NewPlat.MyDataSetTableAdapters.Dt_MeterInfoTableAdapter();
            this.dt_PlateInfoTableAdapter = new NewPlat.MyDataSetTableAdapters.Dt_PlateInfoTableAdapter();
            this.dT_ResultTableAdapter = new NewPlat.MyDataSetTableAdapters.DT_ResultTableAdapter();
            this.dT_BHGTableAdapter = new NewPlat.MyDataSetTableAdapters.DT_BHGTableAdapter();
            this.dT_SBTableAdapter = new NewPlat.MyDataSetTableAdapters.DT_SBTableAdapter();
            this.界面刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PB_LIS = new System.Windows.Forms.PictureBox();
            this.TSB_search = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtMeterInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_plat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPlateInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MeterInfo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTSBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BHG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTBHGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_HG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LIS)).BeginInit();
            this.SuspendLayout();
            // 
            // dtMeterInfoBindingSource
            // 
            this.dtMeterInfoBindingSource.DataMember = "Dt_MeterInfo";
            this.dtMeterInfoBindingSource.DataSource = this.myDataSetBindingSource;
            // 
            // myDataSetBindingSource
            // 
            this.myDataSetBindingSource.DataSource = this.myDataSet;
            this.myDataSetBindingSource.Position = 0;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "MyDataSet";
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(1411, 94);
            this.test.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(75, 22);
            this.test.TabIndex = 4;
            this.test.Text = "test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // TB_Listener
            // 
            this.TB_Listener.AutoSize = true;
            this.TB_Listener.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Listener.Location = new System.Drawing.Point(1163, 55);
            this.TB_Listener.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TB_Listener.Name = "TB_Listener";
            this.TB_Listener.Size = new System.Drawing.Size(96, 27);
            this.TB_Listener.TabIndex = 9;
            this.TB_Listener.Text = "label1";
            this.TB_Listener.Click += new System.EventHandler(this.TB_Listener_Click);
            // 
            // TB_show
            // 
            this.TB_show.Location = new System.Drawing.Point(1508, 47);
            this.TB_show.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_show.Multiline = true;
            this.TB_show.Name = "TB_show";
            this.TB_show.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_show.Size = new System.Drawing.Size(372, 305);
            this.TB_show.TabIndex = 3;
            // 
            // DGV_plat
            // 
            this.DGV_plat.AllowUserToAddRows = false;
            this.DGV_plat.AllowUserToDeleteRows = false;
            this.DGV_plat.AllowUserToResizeColumns = false;
            this.DGV_plat.AllowUserToResizeRows = false;
            this.DGV_plat.AutoGenerateColumns = false;
            this.DGV_plat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_plat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_plat.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV_plat.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_plat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_plat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_plat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP,
            this.PlatComs,
            this.PlatIcs,
            this.PlatChus_msb,
            this.PlatChus_xzy,
            this.PlatChus_csb,
            this.PlatZhos});
            this.DGV_plat.DataSource = this.dtPlateInfoBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_plat.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_plat.EnableHeadersVisualStyles = false;
            this.DGV_plat.Location = new System.Drawing.Point(15, 22);
            this.DGV_plat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGV_plat.Name = "DGV_plat";
            this.DGV_plat.ReadOnly = true;
            this.DGV_plat.RowHeadersVisible = false;
            this.DGV_plat.RowHeadersWidth = 51;
            this.DGV_plat.RowTemplate.Height = 23;
            this.DGV_plat.Size = new System.Drawing.Size(1038, 330);
            this.DGV_plat.TabIndex = 2;
            this.DGV_plat.Leave += new System.EventHandler(this.DGV_plat_Leave);
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IP.DataPropertyName = "IP";
            this.IP.HeaderText = "IP";
            this.IP.MinimumWidth = 6;
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.Width = 63;
            // 
            // PlatComs
            // 
            this.PlatComs.DataPropertyName = "PlatComs";
            this.PlatComs.HeaderText = "命令平台";
            this.PlatComs.MinimumWidth = 6;
            this.PlatComs.Name = "PlatComs";
            this.PlatComs.ReadOnly = true;
            // 
            // PlatIcs
            // 
            this.PlatIcs.DataPropertyName = "PlatIcs";
            this.PlatIcs.HeaderText = "IC平台";
            this.PlatIcs.MinimumWidth = 6;
            this.PlatIcs.Name = "PlatIcs";
            this.PlatIcs.ReadOnly = true;
            // 
            // PlatChus_msb
            // 
            this.PlatChus_msb.DataPropertyName = "PlatChus_msb";
            this.PlatChus_msb.HeaderText = "膜式初检";
            this.PlatChus_msb.MinimumWidth = 6;
            this.PlatChus_msb.Name = "PlatChus_msb";
            this.PlatChus_msb.ReadOnly = true;
            // 
            // PlatChus_xzy
            // 
            this.PlatChus_xzy.DataPropertyName = "PlatChus_xzy";
            this.PlatChus_xzy.HeaderText = "修正初检";
            this.PlatChus_xzy.MinimumWidth = 6;
            this.PlatChus_xzy.Name = "PlatChus_xzy";
            this.PlatChus_xzy.ReadOnly = true;
            // 
            // PlatChus_csb
            // 
            this.PlatChus_csb.DataPropertyName = "PlatChus_csb";
            this.PlatChus_csb.HeaderText = "超声初检";
            this.PlatChus_csb.MinimumWidth = 6;
            this.PlatChus_csb.Name = "PlatChus_csb";
            this.PlatChus_csb.ReadOnly = true;
            // 
            // PlatZhos
            // 
            this.PlatZhos.DataPropertyName = "PlatZhos";
            this.PlatZhos.HeaderText = "终检平台";
            this.PlatZhos.MinimumWidth = 6;
            this.PlatZhos.Name = "PlatZhos";
            this.PlatZhos.ReadOnly = true;
            // 
            // dtPlateInfoBindingSource
            // 
            this.dtPlateInfoBindingSource.DataMember = "Dt_PlateInfo";
            this.dtPlateInfoBindingSource.DataSource = this.myDataSet;
            // 
            // DGV_MeterInfo
            // 
            this.DGV_MeterInfo.AllowUserToAddRows = false;
            this.DGV_MeterInfo.AllowUserToDeleteRows = false;
            this.DGV_MeterInfo.AllowUserToResizeColumns = false;
            this.DGV_MeterInfo.AllowUserToResizeRows = false;
            this.DGV_MeterInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_MeterInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_MeterInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_MeterInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_MeterInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MeterId,
            this.MeterType,
            this.MeterIcState,
            this.MeterChuState,
            this.MeterComState,
            this.MeterZhongState,
            this.MeterTest,
            this.MeterTime,
            this.MeterState,
            this.MeterCancel,
            this.MeterPrivilege});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_MeterInfo.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_MeterInfo.EnableHeadersVisualStyles = false;
            this.DGV_MeterInfo.Location = new System.Drawing.Point(15, 380);
            this.DGV_MeterInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGV_MeterInfo.Name = "DGV_MeterInfo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_MeterInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_MeterInfo.RowHeadersVisible = false;
            this.DGV_MeterInfo.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DGV_MeterInfo.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_MeterInfo.RowTemplate.Height = 23;
            this.DGV_MeterInfo.Size = new System.Drawing.Size(1865, 550);
            this.DGV_MeterInfo.TabIndex = 1;
            this.DGV_MeterInfo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_MeterInfo_CellEnter);
            this.DGV_MeterInfo.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_MeterInfo_CellLeave);
            this.DGV_MeterInfo.Leave += new System.EventHandler(this.DGV_MeterInfo_Leave);
            // 
            // MeterId
            // 
            this.MeterId.HeaderText = "表号";
            this.MeterId.MinimumWidth = 6;
            this.MeterId.Name = "MeterId";
            this.MeterId.ReadOnly = true;
            // 
            // MeterType
            // 
            this.MeterType.HeaderText = "表类型";
            this.MeterType.MinimumWidth = 6;
            this.MeterType.Name = "MeterType";
            this.MeterType.ReadOnly = true;
            // 
            // MeterIcState
            // 
            this.MeterIcState.HeaderText = "IC卡控";
            this.MeterIcState.MinimumWidth = 6;
            this.MeterIcState.Name = "MeterIcState";
            this.MeterIcState.ReadOnly = true;
            // 
            // MeterChuState
            // 
            this.MeterChuState.HeaderText = "初检";
            this.MeterChuState.MinimumWidth = 6;
            this.MeterChuState.Name = "MeterChuState";
            this.MeterChuState.ReadOnly = true;
            // 
            // MeterComState
            // 
            this.MeterComState.HeaderText = "命令检";
            this.MeterComState.MinimumWidth = 6;
            this.MeterComState.Name = "MeterComState";
            this.MeterComState.ReadOnly = true;
            // 
            // MeterZhongState
            // 
            this.MeterZhongState.HeaderText = "终检";
            this.MeterZhongState.MinimumWidth = 6;
            this.MeterZhongState.Name = "MeterZhongState";
            this.MeterZhongState.ReadOnly = true;
            // 
            // MeterTest
            // 
            this.MeterTest.HeaderText = "测试状态";
            this.MeterTest.MinimumWidth = 6;
            this.MeterTest.Name = "MeterTest";
            this.MeterTest.ReadOnly = true;
            // 
            // MeterTime
            // 
            this.MeterTime.HeaderText = "时间";
            this.MeterTime.MinimumWidth = 6;
            this.MeterTime.Name = "MeterTime";
            this.MeterTime.ReadOnly = true;
            this.MeterTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MeterTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MeterState
            // 
            this.MeterState.HeaderText = "总结果";
            this.MeterState.MinimumWidth = 6;
            this.MeterState.Name = "MeterState";
            this.MeterState.ReadOnly = true;
            // 
            // MeterCancel
            // 
            this.MeterCancel.HeaderText = "取消测试";
            this.MeterCancel.MinimumWidth = 6;
            this.MeterCancel.Name = "MeterCancel";
            this.MeterCancel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MeterPrivilege
            // 
            this.MeterPrivilege.HeaderText = "优先测试";
            this.MeterPrivilege.MinimumWidth = 6;
            this.MeterPrivilege.Name = "MeterPrivilege";
            this.MeterPrivilege.ReadOnly = true;
            this.MeterPrivilege.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // BT_Canccel
            // 
            this.BT_Canccel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Canccel.Location = new System.Drawing.Point(1325, 183);
            this.BT_Canccel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BT_Canccel.Name = "BT_Canccel";
            this.BT_Canccel.Size = new System.Drawing.Size(138, 56);
            this.BT_Canccel.TabIndex = 11;
            this.BT_Canccel.Text = "保存更改";
            this.BT_Canccel.UseVisualStyleBackColor = true;
            this.BT_Canccel.Click += new System.EventHandler(this.BT_Canccel_Click);
            // 
            // BT_SE
            // 
            this.BT_SE.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_SE.Location = new System.Drawing.Point(1096, 183);
            this.BT_SE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BT_SE.Name = "BT_SE";
            this.BT_SE.Size = new System.Drawing.Size(138, 56);
            this.BT_SE.TabIndex = 0;
            this.BT_SE.Text = "开启服务";
            this.BT_SE.UseVisualStyleBackColor = true;
            this.BT_SE.Click += new System.EventHandler(this.BT_ST_SE_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.TSB_search});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(1924, 31);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton1.Image = global::NewPlat.Properties.Resources.shuxin;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton1.Size = new System.Drawing.Size(130, 28);
            this.toolStripButton1.Text = "控件初始";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton2.Image = global::NewPlat.Properties.Resources.shuxin;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton2.Size = new System.Drawing.Size(130, 28);
            this.toolStripButton2.Text = "界面刷新";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton3.Image = global::NewPlat.Properties.Resources.timg;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton3.Size = new System.Drawing.Size(130, 28);
            this.toolStripButton3.Text = "平台恢复";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DGV_SB);
            this.groupBox4.Controls.Add(this.DGV_BHG);
            this.groupBox4.Controls.Add(this.DGV_HG);
            this.groupBox4.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(1079, 390);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(524, 469);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "测试结果汇总";
            this.groupBox4.Visible = false;
            // 
            // DGV_SB
            // 
            this.DGV_SB.AllowUserToAddRows = false;
            this.DGV_SB.AllowUserToDeleteRows = false;
            this.DGV_SB.AllowUserToResizeColumns = false;
            this.DGV_SB.AllowUserToResizeRows = false;
            this.DGV_SB.AutoGenerateColumns = false;
            this.DGV_SB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_SB.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGV_SB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.DGV_SB.DataSource = this.dTSBBindingSource;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SB.DefaultCellStyle = dataGridViewCellStyle9;
            this.DGV_SB.EnableHeadersVisualStyles = false;
            this.DGV_SB.Location = new System.Drawing.Point(356, 28);
            this.DGV_SB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGV_SB.Name = "DGV_SB";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SB.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGV_SB.RowHeadersVisible = false;
            this.DGV_SB.RowHeadersWidth = 51;
            this.DGV_SB.RowTemplate.Height = 23;
            this.DGV_SB.Size = new System.Drawing.Size(158, 434);
            this.DGV_SB.TabIndex = 2;
            this.DGV_SB.Leave += new System.EventHandler(this.DGV_SB_Leave);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MeterId";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn2.HeaderText = "失败表";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dTSBBindingSource
            // 
            this.dTSBBindingSource.DataMember = "DT_SB";
            this.dTSBBindingSource.DataSource = this.myDataSet;
            // 
            // DGV_BHG
            // 
            this.DGV_BHG.AllowUserToAddRows = false;
            this.DGV_BHG.AllowUserToDeleteRows = false;
            this.DGV_BHG.AllowUserToResizeColumns = false;
            this.DGV_BHG.AllowUserToResizeRows = false;
            this.DGV_BHG.AutoGenerateColumns = false;
            this.DGV_BHG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_BHG.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_BHG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DGV_BHG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_BHG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.DGV_BHG.DataSource = this.dTBHGBindingSource;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_BHG.DefaultCellStyle = dataGridViewCellStyle13;
            this.DGV_BHG.EnableHeadersVisualStyles = false;
            this.DGV_BHG.Location = new System.Drawing.Point(188, 28);
            this.DGV_BHG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGV_BHG.Name = "DGV_BHG";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_BHG.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.DGV_BHG.RowHeadersVisible = false;
            this.DGV_BHG.RowHeadersWidth = 51;
            this.DGV_BHG.RowTemplate.Height = 23;
            this.DGV_BHG.Size = new System.Drawing.Size(158, 434);
            this.DGV_BHG.TabIndex = 1;
            this.DGV_BHG.Leave += new System.EventHandler(this.DGV_BHG_Leave);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MeterId";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn1.HeaderText = "不合格表";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dTBHGBindingSource
            // 
            this.dTBHGBindingSource.DataMember = "DT_BHG";
            this.dTBHGBindingSource.DataSource = this.myDataSet;
            // 
            // DGV_HG
            // 
            this.DGV_HG.AllowUserToAddRows = false;
            this.DGV_HG.AllowUserToDeleteRows = false;
            this.DGV_HG.AllowUserToResizeColumns = false;
            this.DGV_HG.AllowUserToResizeRows = false;
            this.DGV_HG.AutoGenerateColumns = false;
            this.DGV_HG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_HG.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_HG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DGV_HG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_HG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.meterIdDataGridViewTextBoxColumn});
            this.DGV_HG.DataSource = this.dTResultBindingSource;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_HG.DefaultCellStyle = dataGridViewCellStyle17;
            this.DGV_HG.EnableHeadersVisualStyles = false;
            this.DGV_HG.Location = new System.Drawing.Point(19, 28);
            this.DGV_HG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGV_HG.Name = "DGV_HG";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_HG.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.DGV_HG.RowHeadersVisible = false;
            this.DGV_HG.RowHeadersWidth = 51;
            this.DGV_HG.RowTemplate.Height = 23;
            this.DGV_HG.Size = new System.Drawing.Size(158, 434);
            this.DGV_HG.TabIndex = 0;
            this.DGV_HG.Leave += new System.EventHandler(this.DGV_HG_Leave);
            // 
            // meterIdDataGridViewTextBoxColumn
            // 
            this.meterIdDataGridViewTextBoxColumn.DataPropertyName = "MeterId";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.meterIdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.meterIdDataGridViewTextBoxColumn.HeaderText = "合格表";
            this.meterIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.meterIdDataGridViewTextBoxColumn.Name = "meterIdDataGridViewTextBoxColumn";
            // 
            // dTResultBindingSource
            // 
            this.dTResultBindingSource.DataMember = "DT_Result";
            this.dTResultBindingSource.DataSource = this.myDataSet;
            // 
            // dt_MeterInfoTableAdapter
            // 
            this.dt_MeterInfoTableAdapter.ClearBeforeFill = true;
            // 
            // dt_PlateInfoTableAdapter
            // 
            this.dt_PlateInfoTableAdapter.ClearBeforeFill = true;
            // 
            // dT_ResultTableAdapter
            // 
            this.dT_ResultTableAdapter.ClearBeforeFill = true;
            // 
            // dT_BHGTableAdapter
            // 
            this.dT_BHGTableAdapter.ClearBeforeFill = true;
            // 
            // dT_SBTableAdapter
            // 
            this.dT_SBTableAdapter.ClearBeforeFill = true;
            // 
            // 界面刷新ToolStripMenuItem
            // 
            this.界面刷新ToolStripMenuItem.Name = "界面刷新ToolStripMenuItem";
            this.界面刷新ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.界面刷新ToolStripMenuItem.Text = "界面刷新";
            // 
            // PB_LIS
            // 
            this.PB_LIS.BackColor = System.Drawing.SystemColors.Control;
            this.PB_LIS.Image = global::NewPlat.Properties.Resources.lisenter;
            this.PB_LIS.Location = new System.Drawing.Point(1113, 55);
            this.PB_LIS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PB_LIS.Name = "PB_LIS";
            this.PB_LIS.Size = new System.Drawing.Size(40, 35);
            this.PB_LIS.TabIndex = 10;
            this.PB_LIS.TabStop = false;
            // 
            // TSB_search
            // 
            this.TSB_search.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TSB_search.Image = global::NewPlat.Properties.Resources.f12;
            this.TSB_search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_search.Name = "TSB_search";
            this.TSB_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TSB_search.Size = new System.Drawing.Size(154, 28);
            this.TSB_search.Text = "数据库查询";
            this.TSB_search.Click += new System.EventHandler(this.TSB_search_Click);
            // 
            // PlatManger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1924, 937);
            this.Controls.Add(this.BT_Canccel);
            this.Controls.Add(this.BT_SE);
            this.Controls.Add(this.DGV_MeterInfo);
            this.Controls.Add(this.TB_show);
            this.Controls.Add(this.PB_LIS);
            this.Controls.Add(this.TB_Listener);
            this.Controls.Add(this.test);
            this.Controls.Add(this.DGV_plat);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PlatManger";
            this.Text = "分级智能检测平台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlatManger_FormClosing);
            this.Load += new System.EventHandler(this.PlatManger_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlatManger_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtMeterInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_plat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPlateInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MeterInfo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTSBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BHG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTBHGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_HG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LIS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource myDataSetBindingSource;
        private MyDataSet myDataSet;
        private System.Windows.Forms.BindingSource dtMeterInfoBindingSource;
        private MyDataSetTableAdapters.Dt_MeterInfoTableAdapter dt_MeterInfoTableAdapter;
        private System.Windows.Forms.BindingSource dtPlateInfoBindingSource;
        private MyDataSetTableAdapters.Dt_PlateInfoTableAdapter dt_PlateInfoTableAdapter;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.PictureBox PB_LIS;
        private System.Windows.Forms.Label TB_Listener;
        public System.Windows.Forms.TextBox TB_show;
        private System.Windows.Forms.DataGridView DGV_plat;
        private System.Windows.Forms.DataGridView DGV_MeterInfo;
        private System.Windows.Forms.Button BT_Canccel;
        private System.Windows.Forms.Button BT_SE;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatComs;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatIcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatChus_msb;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatChus_xzy;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatChus_csb;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatZhos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DGV_SB;
        private System.Windows.Forms.BindingSource dTResultBindingSource;
        private System.Windows.Forms.DataGridView DGV_BHG;
        private System.Windows.Forms.DataGridView DGV_HG;
        private MyDataSetTableAdapters.DT_ResultTableAdapter dT_ResultTableAdapter;
        private System.Windows.Forms.BindingSource dTBHGBindingSource;
        private MyDataSetTableAdapters.DT_BHGTableAdapter dT_BHGTableAdapter;
        private System.Windows.Forms.BindingSource dTSBBindingSource;
        private MyDataSetTableAdapters.DT_SBTableAdapter dT_SBTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolStripMenuItem 界面刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterType;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterIcState;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterChuState;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterComState;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterZhongState;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterState;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MeterCancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MeterPrivilege;
        private System.Windows.Forms.ToolStripButton TSB_search;
    }
}