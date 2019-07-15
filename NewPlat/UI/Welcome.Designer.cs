namespace NewPlat.UI
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.button1 = new System.Windows.Forms.Button();
            this.lb_sqltest = new System.Windows.Forms.Label();
            this.bt_sqltest = new System.Windows.Forms.Button();
            this.pb_wait = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_wait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(432, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "进入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_sqltest
            // 
            this.lb_sqltest.AutoSize = true;
            this.lb_sqltest.Font = new System.Drawing.Font("华文楷体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_sqltest.Location = new System.Drawing.Point(267, 396);
            this.lb_sqltest.Name = "lb_sqltest";
            this.lb_sqltest.Size = new System.Drawing.Size(252, 27);
            this.lb_sqltest.TabIndex = 1;
            this.lb_sqltest.Text = "请检测数据库连接情况";
            this.lb_sqltest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_sqltest
            // 
            this.bt_sqltest.AutoSize = true;
            this.bt_sqltest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bt_sqltest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_sqltest.FlatAppearance.BorderSize = 2;
            this.bt_sqltest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bt_sqltest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.bt_sqltest.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_sqltest.Location = new System.Drawing.Point(253, 331);
            this.bt_sqltest.Name = "bt_sqltest";
            this.bt_sqltest.Size = new System.Drawing.Size(125, 35);
            this.bt_sqltest.TabIndex = 2;
            this.bt_sqltest.Text = "测试数据库";
            this.bt_sqltest.UseVisualStyleBackColor = true;
            this.bt_sqltest.Click += new System.EventHandler(this.bt_sqltest_Click);
            // 
            // pb_wait
            // 
            this.pb_wait.Image = global::NewPlat.Properties.Resources.waiting_Image;
            this.pb_wait.Location = new System.Drawing.Point(279, 212);
            this.pb_wait.Name = "pb_wait";
            this.pb_wait.Size = new System.Drawing.Size(279, 112);
            this.pb_wait.TabIndex = 3;
            this.pb_wait.TabStop = false;
            this.pb_wait.Click += new System.EventHandler(this.pb_wait_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::NewPlat.Properties.Resources.rq;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(322, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 176);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(629, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pb_wait);
            this.Controls.Add(this.bt_sqltest);
            this.Controls.Add(this.lb_sqltest);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Welcome";
            this.Text = "分级智能检测平台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Welcome_FormClosing);
            this.Load += new System.EventHandler(this.Welcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_wait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_sqltest;
        private System.Windows.Forms.Button bt_sqltest;
        private System.Windows.Forms.PictureBox pb_wait;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
    }
}