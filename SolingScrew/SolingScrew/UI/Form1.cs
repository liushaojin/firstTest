using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.IO.Ports;


namespace SolingScrew
{
    using SolingScrew.UI;
    using SolingScrew;
    public partial class solingScrew : Form
    {
        //SerialPort scom = null;


        public solingScrew()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void sysSetBtn_Click(object sender, EventArgs e)
        {
            SysSetting sysSetWin = new SysSetting();
            sysSetWin.StartPosition = FormStartPosition.CenterParent;
            sysSetWin.ShowDialog();
            //SingleShow(sysSetWin);
        }

        private void posSetBtn_Click(object sender, EventArgs e)
        {
            PointSetting posSetWin = new PointSetting();
            posSetWin.StartPosition = FormStartPosition.CenterParent;
            posSetWin.ShowDialog();
        }

        private void CPKBtn_Click(object sender, EventArgs e)
        {
            CpkCalculate cpkCalWin = new CpkCalculate();
            cpkCalWin.StartPosition = FormStartPosition.CenterParent;
            cpkCalWin.ShowDialog();
        }

        private void datCleanBtn_Click(object sender, EventArgs e)
        {

        }

        private void quitSysBtn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("您确定要退出吗?", "退出确认",
                                               MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if(res == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 显示唯一的窗体
        /// </summary>
        List<Form> formList = new List<Form>();
        private void SingleShow(Form form)
        {
            //判断窗体是否已经弹出，默认false
            bool hasform = false;

            //遍历所有窗体对象
            foreach (Form f in formList)
            {
                //判断弹出的窗体是否重复
                if (f.Name == form.Name)
                {
                    //重复，修改为true
                    hasform = true;
                    f.WindowState = FormWindowState.Normal;
                    //获取焦点
                    f.Focus();
                }
            }

            if (hasform)
            {
                form.Close();
            }

            else
            {
                //添加到所有窗体中
                formList.Add(form);
                //并打开该窗体
                form.ShowDialog();
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Login loginWin = new Login();
            loginWin.StartPosition = FormStartPosition.CenterParent;
            //loginWin.MdiParent = this;
            loginWin.ShowDialog();    //子窗口的不关闭时，其它的窗口无法操作    //loginWin.Show();
            //SingleShow(loginWin);
        }
    }
}
