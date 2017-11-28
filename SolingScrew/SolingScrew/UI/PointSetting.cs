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
    using SolingScrew.DataDal;
    using SolingScrew.FileOpAPI;
    public partial class PointSetting : Form
    {
        private string curProductName = string.Empty;   //当前选择的产品名称
        private string curPoint = string.Empty;         //当前选择的点位
        private string curOpProduct = string.Empty;     //当前操作的产品
        
        List<string> productNameList = new List<string>();  //产品名称的链表
        List<string> pointList = new List<string>();  //产品点位信息链表
        
        DataTable mDt = new DataTable();
        SerialComm comm = SerialComm.GetScomInstance();
        IniFileHelper iniFileOp = new IniFileHelper();
        private delegate void ShowPointEventHandler(string[] point);
        public PointSetting()
        {
            InitializeComponent();
        }
        
        private void PointSetting_Load(object sender, EventArgs e)
        {
            TableInit();
            LoadData();
            comm.ReadDMDatas(250, 5);  //进入点位界面就要去读取实时点位信息
            comm.wordDataReceived += new SerialComm.WordDataReceivedHandler(DataReceived);
        }
        
        /// <summary>
        /// 接收数据的处理，主要用来接收各轴的实时点位值
        /// </summary>
        /// <param name="data"></param>
        private void DataReceived(string[] data)
        {
            if(data.Length > 0)
            {
                if(true == this.InvokeRequired)
                {
                    this.Invoke(new ShowPointEventHandler(ShowPointVal), new object[] { data });
                }
                else
                {
                    ShowPointVal(data);
                }
            }
        }
        private void ShowPointVal(string[] point)
        {
            try
            {
                x1Pos.Text = point[0];
                z1Pos.Text = point[1];
                yPos.Text = point[2];
                x2Pos.Text = point[3];
                z2Pos.Text = point[4];
            }
            catch(Exception ex)
            {
            }
        }
        
        private TextBox control;
        
        public string CurOpProduct
        {
            get
            {
                return curOpProduct;
            }
            set
            {
                curOpProduct = value;
            }
        }
        
        /// <summary>
        /// 表格只输入数值类型的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //只对TextBox类型的单元格进行验证
            if(e.Control.GetType().BaseType.Name == "TextBox")
            {
                control = new TextBox();
                control = (TextBox)e.Control;
                control.KeyPress += new KeyPressEventHandler(control_KeyPress);
                //if(control.Text == "")     //需要限制输入数字的单元格
                //{
                //    control.KeyPress += new KeyPressEventHandler(control_KeyPress);
                //}
                //else
                //{
                //    //非数字类型单元格
                //    control.Leave += new EventHandler(control_Leave);
                //}
            }
        }
        /// <summary>
        /// textbox按键输入事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void control_KeyPress(object sender, KeyPressEventArgs e)
        {
            //限制只能输入0-9的数字，退格键，小数点和回车
            if((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '-' || e.KeyChar == 13 || e.KeyChar == 8 || e.KeyChar == 46)//((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                if(control.Text == "0" && e.KeyChar == '0')//防止输入以００开头
                {
                    e.Handled = true;
                }
                else if((control.Text == "" || control.Text.Contains('.')) && e.KeyChar == '.')//开始输入时防止首输为点及重复点
                {
                    e.Handled = true;
                }
                else if((control.Text.Contains('-') && e.KeyChar == '-') || (control.Text == "-" && e.KeyChar == '.'))//防止首输为'－'时接着输入'.',及重复输入'-'
                {
                    e.Handled = true;
                }
                else if(control.Text.Contains('.') && ((control.Text.IndexOf('.') + 3) == control.Text.Length) && e.KeyChar != 8 && e.KeyChar != 13)
                {
                    e.Handled = true;
                }
                else if(control.Text.Length > 0 && e.KeyChar == '-')    //防止编辑已有数据时可以输入符号-的不足
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                e.Handled = true;
                //MessageBox.Show("只能输入数字！");
            }
        }
        
        void control_Leave(object sender, EventArgs e)
        {
            //如果需要限制字符串输入长度
            //if(control.Text.Length != 11)
            //{
            //    MessageBox.Show("只能为位！");
            //    control.Focus();
            //}
        }
        
        
        
        /// <summary>
        /// lis服务器连接状态(来自lis接口的子线程发出的事件)
        /// </summary>
        /// <param name="origStatus">旧状态</param>
        /// <param name="nowStatus">新状态</param>
        /*void LisStatusStation_LisStatusChanged(LisStatus origStatus, LisStatus nowStatus)
        {
            if (true == this.InvokeRequired)
            {
                this.Invoke(new LisServerStausChangeEventHandler(this.DealWithLisServerStatusChange), new object[] { origStatus, nowStatus });
            }
            else
            {
                this.DealWithLisServerStatusChange(origStatus, nowStatus);
            }
        }
        
        /// <summary>
        /// 处理lis服务器状态改变
        /// </summary>
        /// <param name="origStatus">旧的状态</param>
        /// <param name="nowStatus">新的状态</param>
        private void DealWithLisServerStatusChange(LisStatus origStatus, LisStatus nowStatus)
        {
            // lis服务器连接状态判断
            if (LisStatus.LIS_UnConnected == LisStatusStation.CurrentStatus && !m_bStopSend)
            {
                string strText = string.Empty;
                PublicFunction.JudgeWhetherCanCommunicationByStatus(LisStatusStation.CurrentStatus, out strText);
                ShowMessageBLL.ShowMessageBox(this, strText);
                this.CancelCommunication();            // 取消通信/还原界面
            }
        }*/
        
        /// <summary>
        /// 点位设置表格的初始化
        /// </summary>
        private void TableInit()
        {
            //设置列表头30列
            for(int i = 0; i < 31; i++)
            {
                DataColumn col = null;
                
                if(i == 0)
                {
                    col = new DataColumn(string.Format("  ", i), typeof(string));
                }
                else
                {
                    col = new DataColumn(string.Format("点{0}", i), typeof(string));
                }
                
                mDt.Columns.Add(col);
            }
            
            //添加行
            for(int i = 0; i < 7; i++)
            {
                DataRow row = mDt.NewRow();
                mDt.Rows.Add(row);
            }
            
            // 添加行
            //             DataRow row = mDt.NewRow();
            //             row["点位"] = "x10001";
            //             row["扭力值(kgf.cm)"] = "345";
            //             row["上限(kgf.cm)"] = "368";
            //             row["下限(kgf.cm)"] = "300";
            //             row["结果"] = "正常";
            //             mDt.Rows.Add(row);
            /*for (int i = 0; i < dataGridView1.Height / dataGridView1.RowTemplate.Height - 2; i++)
                //for (int i = 0; i < dataGridView1.Height / dataGridView1.RowTemplate.Height; i++)
                //for(int i=0; i<25; i++)
            {
                // 添加空白行
                DataRow blankRow = mDt.NewRow();
                //                 row["点位"] = "x10001";
                //                 row["扭力值(kgf.cm)"] = "345";
                //                 row["上限(kgf.cm)"] = "368";
                //                 row["下限(kgf.cm)"] = "300";
                //                 row["结果"] = "正常";
                mDt.Rows.Add(blankRow);
            }*/
            dataGridView1.DataSource = mDt;
            //dataGridView1.ReadOnly = false;
            //datagridview1.RowCount = 23;
            dataGridView1.RowHeadersVisible = false;
            //dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //DataGridView1.AllowUserToResizeColumns = false;   // 禁止用户改变DataGridView1的所有列的列宽
            dataGridView1.AllowUserToResizeRows = false;    //禁止用户改变DataGridView1の所有行的行高
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;    // 禁止用户改变列头的高度
            dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            //dataGridView1.Columns[0].FillWeight = 10;      //第一列的相对宽度为10%
            dataGridView1.Rows[0].Cells[0].Value = "x1";
            dataGridView1.Rows[1].Cells[0].Value = "z1";
            dataGridView1.Rows[2].Cells[0].Value = "y";
            dataGridView1.Rows[3].Cells[0].Value = "x2";
            dataGridView1.Rows[4].Cells[0].Value = "z2";
            dataGridView1.Rows[5].Cells[0].Value = "电批";
            dataGridView1.Rows[6].Cells[0].Value = "面";
            
            for(int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if(i == 0)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }
                
                dataGridView1.Columns[i].Width = 60;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
            //设置标题字段(先把ColumnsHeadersVisible设置为true)
            //dataGridView1.Columns[0].HeaderText = "点位";
            //设置属性
            //             DataGridTableStyle tablestyle = new DataGridTableStyle();
            //             this.dataGridView1.TableStyles.Add(tablestyle);
            //             dataGridView1.TableStyles[0].GridColumnStyles[0].Width = 75;
            //             dataGridView1.TableStyles[0].GridColumnStyles[1].Width = 75;
            //             dataGridView1.TableStyles[0].GridColumnStyles[2].Width = 75;
            //             dataGridView1.TableStyles[0].GridColumnStyles[3].Width = 75;
            //             dataGridView1.TableStyles[0].GridColumnStyles[4].Width = 75;
            //             dataGridView1.TableStyles[0].GridColumnStyles[5].Width = 120;
            //dataGridView1.Rows[0].HeaderCell.Value = "x1";
            //dataGridView1.Rows[1].HeaderCell.Value = "z1";
            //dataGridView1.Rows[2].HeaderCell.Value = "y";
            //dataGridView1.Rows[3].HeaderCell.Value = "x2";
            //dataGridView1.Rows[4].HeaderCell.Value = "z2";
            //dataGridView1.Rows[5].HeaderCell.Value = "电批";
            //dataGridView1.Rows[6].HeaderCell.Value = "面";
            //dataGridView1.RowHeadersWidth = 30;
            //dataGridView1.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }
        
        private void ClearTable()
        {
            int rows = dataGridView1.RowCount;
            
            for(int i = 0; i < rows; i++)
            {
                for(int j = 1; j < 31; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = string.Empty;
                }
            }
        }
        
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            UpdateProductCombo();
            UpdatePointCombo();
        }
        
        private void UpdateProductCombo()
        {
            //加载产品名称
            List<string> secList = new List<string>();
            secList = iniFileOp.ReadSections();
            productNameList.Clear();
            
            for(int i = 0; i < secList.Count; i++)
            {
                if(secList[i] == "SysSetting" || secList[i] == "CurOpProduct")
                {
                    secList.RemoveAt(i);
                }
            }
            
            if(secList.Count <= 0)
            {
                return;
            }
            
            foreach(string sec in secList)
            {
                productNameList.Add(sec);
                //productCombo.Items.Add(sec);
            }
            
            productCombo.Items.AddRange(secList.ToArray());
            productCombo.SelectedIndex = 0;
            curProductName = secList[0];
        }
        
        private void UpdatePointCombo()
        {
            //加载当前产品的点位信息
            List<string> pList = new List<string>();
            pointCombo.Items.Clear();
            pointCombo.SelectedIndex = -1;
            pointCombo.Text = "";
            pList = iniFileOp.ReadKeys(curProductName);
            pointList = pList;
            
            if(pList.Count <= 0)
            {
                return;
            }
            
            pointCombo.Items.AddRange(pList.ToArray());
            pointCombo.SelectedIndex = 0;
            ClearTable();//先清空表格再添加新的数据
            
            //加载点位信息到表格中去
            for(int i = 0; i < pList.Count; i++)
            {
                string val = iniFileOp.ReadValue(curProductName, pList[i]);
                string[] pointUnit = val.Split(',');
                
                for(int j = 0; j < pointUnit.Count(); j++)
                {
                    dataGridView1.Rows[j].Cells[i + 1].Value = pointUnit[j];
                }
            }
        }
        
        private void switchBtn_Click(object sender, EventArgs e)
        {
            string section = "CurOpProduct";    //当前操作的产品信息
            string key = "ProductName";
            
            //只有当产品数大于0时才能切换
            if(productCombo.Items.Count > 0)
            {
                CurOpProduct = productCombo.SelectedItem.ToString();
                iniFileOp.WriteString(section, key, CurOpProduct);
                //this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请先输入产品名称", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// 添加新产品事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtn_Click(object sender, EventArgs e)
        {
            string title = "新增产品";
            SingleInputDlg inputWin = new SingleInputDlg(title);
            inputWin.SetTitle(title);
            inputWin.SetNameList(productNameList);
            inputWin.StartPosition = FormStartPosition.CenterParent;
            
            if(inputWin.ShowDialog() == DialogResult.OK)
            {
                productNameList.Add(inputWin.NewName);
                productCombo.Items.Add(inputWin.NewName);
                productCombo.SelectedIndex = productCombo.Items.Count - 1;
            }
        }
        
        private void delBtn_Click(object sender, EventArgs e)
        {
            //有产品时才响应删除
            if(productCombo.Items.Count > 0)
            {
                //先提示用户是否确认删除操作
                DialogResult res = MessageBox.Show("您确定要删除该产品吗?", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                
                if(res == DialogResult.OK)
                {
                    int index = productCombo.SelectedIndex;
                    productCombo.Items.RemoveAt(index);
                    productNameList.RemoveAt(index);
                    //包含则从文件中删除
                    iniFileOp.ClearSection(curProductName);
                    
                    //并及时更新显示
                    if(productCombo.Items.Count > 0)
                    {
                        productCombo.SelectedIndex = 0;
                        curProductName = productCombo.SelectedItem.ToString();
                    }
                    else
                    {
                        productCombo.Items.Clear();
                        productCombo.Text = "";
                        curProductName = "";
                    }
                }
            }
        }
        
        private void shieldPointBtn_Click(object sender, EventArgs e)
        {
        }
        
        private void cancelShieldBtn_Click(object sender, EventArgs e)
        {
        }
        
        //删除产品按键响应事件
        private void delPointBtn_Click(object sender, EventArgs e)
        {
            //先判断是否包含
            if(pointCombo.Items.Count > 0)
            {
                DialogResult res = MessageBox.Show("您确定要删除该点吗?", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                
                if(res == DialogResult.OK)
                {
                    int index = pointCombo.SelectedIndex;
                    pointCombo.Items.RemoveAt(index);
                    pointList.RemoveAt(index);
                    
                    for(int i = 0; i < 7; i++)
                    {
                        dataGridView1.Rows[i].Cells[index + 1].Value = "";
                    }
                    
                    iniFileOp.DeleteKey(curProductName, curPoint);
                    
                    //并及时更新显示
                    if(pointCombo.Items.Count > 0)
                    {
                        pointCombo.SelectedIndex = 0;
                        curPoint = pointCombo.SelectedItem.ToString();
                    }
                    else
                    {
                        pointCombo.Items.Clear();
                        pointCombo.Text = "";
                    }
                }
            }
        }
        
        private void changeProgramBtn_Click(object sender, EventArgs e)
        {
        }
        
        private void productCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            curProductName = productCombo.SelectedItem.ToString();
            UpdatePointCombo();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            curPoint = pointCombo.SelectedItem.ToString();
        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        
        private void saveBtn_Click(object sender, EventArgs e)
        {
            pointList.Clear();  //保存前先清空点链表信息缓存
            
            //先判断当前产品名称是否选择或是否存在
            if(productCombo.SelectedIndex >= 0)
            {
                //再判断当前表格中输入的信息，扫描所有的30列
                for(int col = 1; col < 31; col++)
                {
                    string point = string.Empty;
                    List<string> pointUnit = new List<string>();
                    
                    //获取一个点的信息
                    for(int row = 0; row < 7; row++)
                    {
                        string temp = dataGridView1.Rows[row].Cells[col].Value.ToString();
                        
                        //判断当前单元格的内容是否为空，不为空时才加入单元点集合中去
                        if(!string.IsNullOrEmpty(temp) && temp != "")
                        {
                            pointUnit.Add(temp);
                            
                            if(row == 6)
                            {
                                point += temp;
                            }
                            else
                            {
                                point += temp + ',';
                            }
                        }
                    }
                    
                    if(pointUnit.Count <= 0)
                    {
                        //当前扫描列输入为空时跳过
                    }
                    else
                    {
                        if(pointUnit.Count < 7)
                        {
                            MessageBox.Show("表中点位信息输入不全，请先补全！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        
                        pointList.Add(point);   //当输入全时再添加到链表中去
                    }
                }
                
                SavePointData();    //保存
                UpdatePointComboItems();//更新
            }
        }
        
        /// <summary>
        /// 保存
        /// </summary>
        private void SavePointData()
        {
            string product = string.Empty;
            string point = string.Empty;
            product = productCombo.SelectedItem.ToString();
            pointCombo.Items.Clear();//更新前先清空
            
            for(int i = 0; i < pointList.Count; i++)
            {
                point = string.Format("Point{0}", i);
                pointCombo.Items.Add(point);
                iniFileOp.WriteString(product, point, pointList[i]);
            }
            
            pointCombo.SelectedIndex = 0;
        }
        
        /// <summary>
        /// 更新点位下拉控件
        /// </summary>
        private void UpdatePointComboItems()
        {
        }
        
        private void PointSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
