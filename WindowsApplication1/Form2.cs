using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class SetForm : Form
    {
        public SetForm()
        {
            InitializeComponent();
        }

        private void SetForm_Load(object sender, EventArgs e)
        {
            setTabControl.DrawItem += new DrawItemEventHandler(this.SetTabPageDrawItem);
        }

        private void SetTabPageDrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle tabArea = setTabControl.GetTabRect(e.Index);//主要是做个转换来获得TAB项的RECTANGELF 
            RectangleF tabTextArea = (RectangleF)(setTabControl.GetTabRect(e.Index));
            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat();//封装文本布局信息 
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Near;
            Font font = this.setTabControl.Font;
            SolidBrush brush = new SolidBrush(Color.Black);//绘制边框的画笔 
            g.DrawString(((TabControl)(sender)).TabPages[e.Index].Text, font, brush, tabTextArea, sf);
        }
    }
}
