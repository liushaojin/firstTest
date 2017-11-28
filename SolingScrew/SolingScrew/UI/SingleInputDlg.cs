using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolingScrew.UI
{
    public partial class SingleInputDlg : Form
    {
        private string m_title = string.Empty;  //窗口标题
        private string newName = string.Empty;  //新输入的产品名称
        private List<string> nameList = new List<string>(); //已有的产品名称表
        public SingleInputDlg()
        {
            InitializeComponent();
        }
        
        public SingleInputDlg(string dlgTitle)
        {
            m_title = dlgTitle;
            InitializeComponent();
            this.Text = m_title;
        }
        
        public string NewName
        {
            get
            {
                return newName;
            }
            set
            {
                newName = value;
            }
        }
        
        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            label5.Text = title;
        }
        /// <summary>
        /// 设置已有产品名称表
        /// </summary>
        public void SetNameList(List<string> list)
        {
            nameList = list;
        }
        
        private void saveBtn_Click(object sender, EventArgs e)
        {
            newName = productName.Text.Trim();   //获取文本框内容
            
            if(string.IsNullOrEmpty(newName))   //判断文本框是否为空，为空则先进行提示并返回
            {
                MessageBox.Show("请输入产品名称", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if(nameList.Contains(newName))
            {
                MessageBox.Show("该产品名称已存在，请输入一个新的名称", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else//如果文本框中有内容则设置关闭状态并关闭本产品输入对话框
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
