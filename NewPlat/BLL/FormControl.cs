﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPlat.BLL
{
    
    class FormControl
    {
        //int x_h = 0, x_w = 0, x_l = 0;
        //int c = 0;
        public string ControlName { get; set; }
        public Control Paraent { get; set; }
        public List<FormControl> Child { get; set; }
        /// <summary>
        /// 记录当前的位置，
        /// </summary>
        public int Left { get; set; }
        /// <summary>
        /// 记录最开始的数据，用来恢复窗体布局
        /// </summary>
        public int InitLeft { get; set; }
        public int Top { get; set; }
        public int InitTop { get; set; }

        public int Height { get; set; }
        public int InitHeight { get; set; }

        public int Width { get; set; }
        public int InitWidth { get; set; }
        /// <summary>
        /// 字体大小
        /// </summary>
        public double FontSize { get; set; }
        public double InitFontSize { get; set; }
        /// <summary>
        /// 作为中间变量，记录每次变化后的最上层paraent 窗体的大小-X
        /// 只有最上层的控件的有意义，子控件也有这个属性，但是在计算缩放时，因所有控件缩放比例一样，只用的最上层控件的
        /// 在MyResize 事件中。
        /// </summary>
        private int RootParaentX;
        private int RootParaentY;
        public FormControl(Control con)
        {
            this.Paraent = con;
            this.ControlName = con.Name;

            this.Left = con.Left;
            this.Top = con.Top;
            this.Width = con.Width;
            this.Height = con.Height;

            this.InitLeft = con.Left;
            this.InitTop = con.Top;
            this.InitWidth = con.Width;
            this.InitHeight = con.Height;

            this.FontSize = con.Font.Size;
            this.InitFontSize = con.Font.Size;

            this.Child = new List<FormControl>();

            this.RootParaentX = this.Width;
            this.RootParaentY = this.Height;

            Form form = con as Form;
            if (form != null)
            {
                form.Resize += this.MyResize;
            }
        }
        /// <summary>
        /// 窗体变化后自适应
        /// </summary>
        /// 
        public void MyResize(object sender, EventArgs e)
        {
            double newx = Convert.ToDouble(this.Paraent.Width) / RootParaentX;
            double newy = Convert.ToDouble(this.Paraent.Height) / RootParaentY;

            RootParaentX = this.Paraent.Width;
            RootParaentY = this.Paraent.Height;

            this.SetControls(newx, newy, this.Paraent);
        }
        /// <summary>
        /// 记录所有初始值
        /// </summary>
        /// <param name="cons"></param>
        /// <param name="paraent"></param>
        public void GetInit(Control cons, FormControl paraent)
        {
            if (cons.Controls.Count > 0)
            {
                foreach (Control con in cons.Controls)
                {
                    con.Anchor = AnchorStyles.Left | AnchorStyles.Top;

                    FormControl fc = new FormControl(con);

                    fc.GetInit(con, fc);
                    paraent.Child.Add(fc);
                }
            }
            else
            {
                return;
            }

        }
        private void SetControls(double newX, double newY, Control cons)//改变控件的大小
        {
            //c++;
            foreach (Control con in cons.Controls)
            {
                //if (c == 1)
                //{
                //    x_h = con.Height;
                //    x_w = con.Width;
                //    x_l = con.Left;
                //}
               // Debug.Print("变化前：" + con.Width + "  " + con.Height + "  " + con.Left + "  " + con.Height);
                double a = Convert.ToSingle(con.Width * newX);
                con.Width = Convert.ToInt32(a);
                a = Convert.ToSingle(con.Height * newY);
                con.Height = Convert.ToInt32(a);
                a = Convert.ToSingle(con.Left * newX);
                con.Left = Convert.ToInt32(a);
                a = Convert.ToSingle(con.Top * newY);
                con.Top = Convert.ToInt32(a);
                // Debug.Print("差：" + Math.Abs(con.Height - x));
                //if (c == 2)
                //{
                //    c = 0;
                //    if (Math.Abs(con.Height - x_h) < 8)
                //        con.Height = x_h;
                //    if (Math.Abs(con.Width - x_w) < 8)
                //        con.Width = x_w;
                //    if (Math.Abs(con.Left - x_l) < 8)
                //        con.Left = x_l;
                //}
                //Debug.Print("变化后：" + con.Width + "  " + con.Height + "  " + con.Left + "  " + con.Height);
                double m, k;
                k = newY / newX;
                m = Math.Pow(k, 0.5) / (k + 1);
                Single currentSize = Convert.ToSingle(con.Font.Size * m * (newY + newX));
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    SetControls(newX, newY, con);
                }
            }
            //Debug.Print("c：" + c + "  " + x);          
        }
        /// <summary>
        /// 回到初始状态
        /// </summary>
        /// <param name="cons"></param>
        public void Reset(Control cons, FormControl fcs)
        {
            if (cons.Controls.Count > 0)
            {
                foreach (Control con in cons.Controls)
                {
                    foreach (FormControl fc in fcs.Child)
                    {
                        if (fc.ControlName == con.Name)
                        {
                            con.Left = fc.InitLeft;
                            con.Top = fc.InitTop;
                            con.Width = fc.Width;
                            con.Height = fc.Height;

                            Single currentSize = Convert.ToSingle(fc.InitFontSize);
                            con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);

                            fc.Reset(con, fc);
                        }
                    }
                }
            }

        }
    }
}
