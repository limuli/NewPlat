namespace NewPlat.UI
{
    partial class JianceConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JianceConfig));
            this.DGPlatConfig = new System.Windows.Forms.DataGridView();
            this.iPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.platComsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.platIcsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.platChusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PlatChus_xzy = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PlatChus_csb = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.platZhosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.platCompDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.platIcpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.platChupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatChup_xzy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatChup_csb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.platZhopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtPlateInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataSet = new NewPlat.MyDataSet();
            this.bt_configplatinfo = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_add = new System.Windows.Forms.TextBox();
            this.tb_delet = new System.Windows.Forms.TextBox();
            this.bt_delet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_save = new System.Windows.Forms.Button();
            this.dt_PlateInfoTableAdapter = new NewPlat.MyDataSetTableAdapters.Dt_PlateInfoTableAdapter();
            this.TB_IP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_PORT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BT_Save_host = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGPlatConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPlateInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGPlatConfig
            // 
            this.DGPlatConfig.AutoGenerateColumns = false;
            this.DGPlatConfig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGPlatConfig.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("华文楷体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGPlatConfig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGPlatConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGPlatConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iPDataGridViewTextBoxColumn,
            this.platComsDataGridViewTextBoxColumn,
            this.platIcsDataGridViewTextBoxColumn,
            this.platChusDataGridViewTextBoxColumn,
            this.PlatChus_xzy,
            this.PlatChus_csb,
            this.platZhosDataGridViewTextBoxColumn,
            this.platCompDataGridViewTextBoxColumn,
            this.platIcpDataGridViewTextBoxColumn,
            this.platChupDataGridViewTextBoxColumn,
            this.PlatChup_xzy,
            this.PlatChup_csb,
            this.platZhopDataGridViewTextBoxColumn});
            this.DGPlatConfig.DataSource = this.dtPlateInfoBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGPlatConfig.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGPlatConfig.EnableHeadersVisualStyles = false;
            this.DGPlatConfig.Location = new System.Drawing.Point(12, 105);
            this.DGPlatConfig.Name = "DGPlatConfig";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("华文楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGPlatConfig.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGPlatConfig.RowHeadersVisible = false;
            this.DGPlatConfig.RowTemplate.Height = 23;
            this.DGPlatConfig.Size = new System.Drawing.Size(1263, 238);
            this.DGPlatConfig.TabIndex = 0;
            // 
            // iPDataGridViewTextBoxColumn
            // 
            this.iPDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iPDataGridViewTextBoxColumn.DataPropertyName = "IP";
            this.iPDataGridViewTextBoxColumn.HeaderText = "IP";
            this.iPDataGridViewTextBoxColumn.Name = "iPDataGridViewTextBoxColumn";
            this.iPDataGridViewTextBoxColumn.Width = 46;
            // 
            // platComsDataGridViewTextBoxColumn
            // 
            this.platComsDataGridViewTextBoxColumn.DataPropertyName = "PlatComs";
            this.platComsDataGridViewTextBoxColumn.DropDownWidth = 3;
            this.platComsDataGridViewTextBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.platComsDataGridViewTextBoxColumn.HeaderText = "命令状态";
            this.platComsDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "未启用",
            "空闲",
            "准备",
            "就绪",
            "正忙",
            "异常"});
            this.platComsDataGridViewTextBoxColumn.Name = "platComsDataGridViewTextBoxColumn";
            this.platComsDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.platComsDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // platIcsDataGridViewTextBoxColumn
            // 
            this.platIcsDataGridViewTextBoxColumn.DataPropertyName = "PlatIcs";
            this.platIcsDataGridViewTextBoxColumn.DropDownWidth = 3;
            this.platIcsDataGridViewTextBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.platIcsDataGridViewTextBoxColumn.HeaderText = "IC状态";
            this.platIcsDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "未启用",
            "空闲",
            "准备",
            "就绪",
            "正忙",
            "异常"});
            this.platIcsDataGridViewTextBoxColumn.Name = "platIcsDataGridViewTextBoxColumn";
            this.platIcsDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.platIcsDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // platChusDataGridViewTextBoxColumn
            // 
            this.platChusDataGridViewTextBoxColumn.DataPropertyName = "PlatChus_msb";
            this.platChusDataGridViewTextBoxColumn.DropDownWidth = 3;
            this.platChusDataGridViewTextBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.platChusDataGridViewTextBoxColumn.HeaderText = "膜式初检";
            this.platChusDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "未启用",
            "空闲",
            "准备",
            "就绪",
            "正忙",
            "异常"});
            this.platChusDataGridViewTextBoxColumn.Name = "platChusDataGridViewTextBoxColumn";
            this.platChusDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.platChusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PlatChus_xzy
            // 
            this.PlatChus_xzy.DataPropertyName = "PlatChus_xzy";
            this.PlatChus_xzy.DropDownWidth = 3;
            this.PlatChus_xzy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlatChus_xzy.HeaderText = "修正初检";
            this.PlatChus_xzy.Items.AddRange(new object[] {
            "未启用",
            "空闲",
            "准备",
            "就绪",
            "正忙",
            "异常"});
            this.PlatChus_xzy.Name = "PlatChus_xzy";
            this.PlatChus_xzy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PlatChus_xzy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PlatChus_csb
            // 
            this.PlatChus_csb.DataPropertyName = "PlatChus_csb";
            this.PlatChus_csb.DropDownWidth = 3;
            this.PlatChus_csb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlatChus_csb.HeaderText = "超声初检";
            this.PlatChus_csb.Items.AddRange(new object[] {
            "未启用",
            "空闲",
            "准备",
            "就绪",
            "正忙",
            "异常"});
            this.PlatChus_csb.Name = "PlatChus_csb";
            // 
            // platZhosDataGridViewTextBoxColumn
            // 
            this.platZhosDataGridViewTextBoxColumn.DataPropertyName = "PlatZhos";
            this.platZhosDataGridViewTextBoxColumn.DropDownWidth = 3;
            this.platZhosDataGridViewTextBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.platZhosDataGridViewTextBoxColumn.HeaderText = "终检状态";
            this.platZhosDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "未启用",
            "空闲",
            "准备",
            "就绪",
            "正忙",
            "异常"});
            this.platZhosDataGridViewTextBoxColumn.Name = "platZhosDataGridViewTextBoxColumn";
            this.platZhosDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.platZhosDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // platCompDataGridViewTextBoxColumn
            // 
            this.platCompDataGridViewTextBoxColumn.DataPropertyName = "PlatComp";
            this.platCompDataGridViewTextBoxColumn.HeaderText = "命令端口";
            this.platCompDataGridViewTextBoxColumn.Name = "platCompDataGridViewTextBoxColumn";
            // 
            // platIcpDataGridViewTextBoxColumn
            // 
            this.platIcpDataGridViewTextBoxColumn.DataPropertyName = "PlatIcp";
            this.platIcpDataGridViewTextBoxColumn.HeaderText = "IC端口";
            this.platIcpDataGridViewTextBoxColumn.Name = "platIcpDataGridViewTextBoxColumn";
            // 
            // platChupDataGridViewTextBoxColumn
            // 
            this.platChupDataGridViewTextBoxColumn.DataPropertyName = "PlatChup_msb";
            this.platChupDataGridViewTextBoxColumn.HeaderText = "MSB端口";
            this.platChupDataGridViewTextBoxColumn.Name = "platChupDataGridViewTextBoxColumn";
            // 
            // PlatChup_xzy
            // 
            this.PlatChup_xzy.DataPropertyName = "PlatChup_xzy";
            this.PlatChup_xzy.HeaderText = "XZY端口";
            this.PlatChup_xzy.Name = "PlatChup_xzy";
            // 
            // PlatChup_csb
            // 
            this.PlatChup_csb.DataPropertyName = "PlatChup_csb";
            this.PlatChup_csb.HeaderText = "CSB端口";
            this.PlatChup_csb.Name = "PlatChup_csb";
            // 
            // platZhopDataGridViewTextBoxColumn
            // 
            this.platZhopDataGridViewTextBoxColumn.DataPropertyName = "PlatZhop";
            this.platZhopDataGridViewTextBoxColumn.HeaderText = "终检端口";
            this.platZhopDataGridViewTextBoxColumn.Name = "platZhopDataGridViewTextBoxColumn";
            // 
            // dtPlateInfoBindingSource
            // 
            this.dtPlateInfoBindingSource.DataMember = "Dt_PlateInfo";
            this.dtPlateInfoBindingSource.DataSource = this.myDataSet;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "MyDataSet";
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bt_configplatinfo
            // 
            this.bt_configplatinfo.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_configplatinfo.Location = new System.Drawing.Point(1068, 456);
            this.bt_configplatinfo.Name = "bt_configplatinfo";
            this.bt_configplatinfo.Size = new System.Drawing.Size(126, 57);
            this.bt_configplatinfo.TabIndex = 3;
            this.bt_configplatinfo.Text = "确认";
            this.bt_configplatinfo.UseVisualStyleBackColor = true;
            this.bt_configplatinfo.Click += new System.EventHandler(this.bt_configplatinfo_Click);
            // 
            // bt_add
            // 
            this.bt_add.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_add.Location = new System.Drawing.Point(296, 37);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(91, 35);
            this.bt_add.TabIndex = 4;
            this.bt_add.Text = "添加平台";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(572, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "检测平台初始状态配置";
            // 
            // tb_add
            // 
            this.tb_add.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_add.Location = new System.Drawing.Point(237, 37);
            this.tb_add.Margin = new System.Windows.Forms.Padding(5);
            this.tb_add.Name = "tb_add";
            this.tb_add.Size = new System.Drawing.Size(42, 35);
            this.tb_add.TabIndex = 6;
            this.tb_add.Tag = "";
            this.tb_add.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_delet
            // 
            this.tb_delet.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_delet.Location = new System.Drawing.Point(237, 93);
            this.tb_delet.Margin = new System.Windows.Forms.Padding(5);
            this.tb_delet.Name = "tb_delet";
            this.tb_delet.Size = new System.Drawing.Size(42, 35);
            this.tb_delet.TabIndex = 7;
            this.tb_delet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_delet
            // 
            this.bt_delet.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_delet.Location = new System.Drawing.Point(296, 93);
            this.bt_delet.Name = "bt_delet";
            this.bt_delet.Size = new System.Drawing.Size(91, 35);
            this.bt_delet.TabIndex = 8;
            this.bt_delet.Text = "删除平台";
            this.bt_delet.UseVisualStyleBackColor = true;
            this.bt_delet.Click += new System.EventHandler(this.bt_delet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "添加或删除的平台号：";
            // 
            // bt_save
            // 
            this.bt_save.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_save.Location = new System.Drawing.Point(104, 183);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(126, 57);
            this.bt_save.TabIndex = 10;
            this.bt_save.Text = "保存配置";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // dt_PlateInfoTableAdapter
            // 
            this.dt_PlateInfoTableAdapter.ClearBeforeFill = true;
            // 
            // TB_IP
            // 
            this.TB_IP.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_IP.Location = new System.Drawing.Point(158, 42);
            this.TB_IP.Name = "TB_IP";
            this.TB_IP.Size = new System.Drawing.Size(167, 31);
            this.TB_IP.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bt_add);
            this.groupBox1.Controls.Add(this.bt_save);
            this.groupBox1.Controls.Add(this.tb_add);
            this.groupBox1.Controls.Add(this.tb_delet);
            this.groupBox1.Controls.Add(this.bt_delet);
            this.groupBox1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(76, 366);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 292);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检测平台配置";
            // 
            // TB_PORT
            // 
            this.TB_PORT.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_PORT.Location = new System.Drawing.Point(158, 98);
            this.TB_PORT.Name = "TB_PORT";
            this.TB_PORT.Size = new System.Drawing.Size(167, 31);
            this.TB_PORT.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(34, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "本机IP ：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(28, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "本机端口：";
            // 
            // BT_Save_host
            // 
            this.BT_Save_host.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Save_host.Location = new System.Drawing.Point(106, 183);
            this.BT_Save_host.Name = "BT_Save_host";
            this.BT_Save_host.Size = new System.Drawing.Size(126, 57);
            this.BT_Save_host.TabIndex = 16;
            this.BT_Save_host.Text = "保存修改";
            this.BT_Save_host.UseVisualStyleBackColor = true;
            this.BT_Save_host.Click += new System.EventHandler(this.BT_Save_host_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.BT_Save_host);
            this.groupBox2.Controls.Add(this.TB_IP);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TB_PORT);
            this.groupBox2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(586, 366);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 292);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "本机配置";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(1286, 28);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton1.Image = global::NewPlat.Properties.Resources.shuxin;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton1.Size = new System.Drawing.Size(118, 25);
            this.toolStripButton1.Text = "控件初始";
            // 
            // JianceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 667);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bt_configplatinfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGPlatConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JianceConfig";
            this.Text = "分级智能检测平台";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JianceConfig_FormClosed);
            this.Load += new System.EventHandler(this.JianceConfig_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JianceConfig_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGPlatConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPlateInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGPlatConfig;
        private System.Windows.Forms.Button bt_configplatinfo;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Label label1;
        private MyDataSet myDataSet;
        private System.Windows.Forms.BindingSource dtPlateInfoBindingSource;
        private MyDataSetTableAdapters.Dt_PlateInfoTableAdapter dt_PlateInfoTableAdapter;
        private System.Windows.Forms.TextBox tb_add;
        private System.Windows.Forms.TextBox tb_delet;
        private System.Windows.Forms.Button bt_delet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.TextBox TB_IP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TB_PORT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BT_Save_host;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn platComsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn platIcsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn platChusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn PlatChus_xzy;
        private System.Windows.Forms.DataGridViewComboBoxColumn PlatChus_csb;
        private System.Windows.Forms.DataGridViewComboBoxColumn platZhosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn platCompDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn platIcpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn platChupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatChup_xzy;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatChup_csb;
        private System.Windows.Forms.DataGridViewTextBoxColumn platZhopDataGridViewTextBoxColumn;
    }
}