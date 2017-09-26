using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;



//1.ZLGCAN系列接口卡信息的数据类型。
public struct VCI_BOARD_INFO
{
    public UInt16 hw_Version;
    public UInt16 fw_Version;
    public UInt16 dr_Version;
    public UInt16 in_Version;
    public UInt16 irq_Num;
    public byte can_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public byte[] str_Serial_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
    public byte[] str_hw_Type;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] Reserved;
}


//2.定义CAN信息帧的数据类型。
unsafe public struct VCI_CAN_OBJ  //使用不安全代码
{
    public uint ID;
    public uint TimeStamp;
    public byte TimeFlag;
    public byte SendType;
    public byte RemoteFlag;//是否是远程帧
    public byte ExternFlag;//是否是扩展帧
    public byte DataLen;

    public fixed byte Data[8];

    public fixed byte Reserved[3];

}
////2.定义CAN信息帧的数据类型。
//public struct VCI_CAN_OBJ
//{
//    public UInt32 ID;
//    public UInt32 TimeStamp;
//    public byte TimeFlag;
//    public byte SendType;
//    public byte RemoteFlag;//是否是远程帧
//    public byte ExternFlag;//是否是扩展帧
//    public byte DataLen;
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//    public byte[] Data;
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//    public byte[] Reserved;

//    public void Init()
//    {
//        Data = new byte[8];
//        Reserved = new byte[3];
//    }
//}

//3.定义CAN控制器状态的数据类型。
public struct VCI_CAN_STATUS
{
    public byte ErrInterrupt;
    public byte regMode;
    public byte regStatus;
    public byte regALCapture;
    public byte regECCapture;
    public byte regEWLimit;
    public byte regRECounter;
    public byte regTECounter;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] Reserved;
}

//4.定义错误信息的数据类型。
public struct VCI_ERR_INFO
{
    public UInt32 ErrCode;
    public byte Passive_ErrData1;
    public byte Passive_ErrData2;
    public byte Passive_ErrData3;
    public byte ArLost_ErrData;
}

//5.定义初始化CAN的数据类型
public struct VCI_INIT_CONFIG
{
    public UInt32 AccCode;
    public UInt32 AccMask;
    public UInt32 Reserved;
    public byte Filter;
    public byte Timing0;
    public byte Timing1;
    public byte Mode;
}

public struct CHGDESIPANDPORT
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public byte[] szpwd;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public byte[] szdesip;
    public Int32 desport;

    public void Init()
    {
        szpwd = new byte[10];
        szdesip = new byte[20];
    }
}

public struct CanBautRate
{
    public string timer0Str;
    public string timer1Str;
    public string bautRateStr;
}

public enum UpgradeCmd
{
    CmdPing = 0x41,
    CmdRun = 0x42,
    CmdUpgrade = 0x43,
    CmdSendData = 0x44,
}

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public enum CanIndex
        {
            Can0,
            Can1,
        }

        const int VCI_USBCAN1 = 3;
        const int VCI_USBCAN2 = 4;
        const int VCI_USBCAN2A = 4;

        /// <summary>
        ///
        /// </summary>
        /// <param name="DeviceType"></param>
        /// <param name="DeviceInd"></param>
        /// <param name="Reserved"></param>
        /// <returns></returns>
        ///
        int mCan0SelectFlag = 0;
        int mCan1SelectFlag = 0;   //can0 或者 can1是否选中的标志,以控制数据的接收

        int mCan0BRIndex = 0;
        int mCan1BRIndex = 0;
        int mPauseFlag = 0; //暂停标志
        int mUpgradeFlag = 0;//升级标志
        string mFilePath = string.Empty;    //拖放文件的绝对路径

        static UInt32 m_devtype = 4;//USBCAN2
        static List<CanBautRate> canBautRateList = new List<CanBautRate>();

        Byte m_filter = (Byte)0;
        Byte m_mode = (Byte)0;
        UInt32 m_bOpen = 0;
        UInt32 m_devind = 0;
        UInt32 m_canind = (UInt32)CanIndex.Can0;


        VCI_CAN_OBJ[] m_recobj = new VCI_CAN_OBJ[50];

        UInt32[] m_arrdevtype = new UInt32[20];

        //主窗口类的构造函数
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            richTextBox.AllowDrop = true;
            richTextBox.DragEnter += new DragEventHandler(FormDragEnter/*RichBoxDragEnter*/);
            richTextBox.DragDrop += new DragEventHandler(FormDragDrop/*RichBoxDragDrop*/);
            groupBox1.Paint += GroupPaint;
            groupBox3.Paint += GroupPaint;
            errorGrpBox.Paint += GroupPaint;//自定义groupbox边框的颜色
            this.tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl.DrawItem += new DrawItemEventHandler(this.TabControl1DrawItem);//自定义tabcontrol的背景
        }

        private void RichBoxDragEnter(object sender, DragEventArgs e)
        {
        }
        private void RichBoxDragDrop(object sender, DragEventArgs e)
        {
        }

        private void TabControl1DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Rectangle mTabCtlRec = tabControl.ClientRectangle;
            e.Graphics.FillRectangle(Brushes.Gray, 0, 0, mTabCtlRec.Width, mTabCtlRec.Height);

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                Rectangle rect = tabControl.GetTabRect(i);

                if (i == tabControl.SelectedIndex)
                {
                    e.Graphics.FillRectangle(Brushes.DarkGray, rect);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Gray, rect);
                }

                e.Graphics.DrawString(((TabControl)sender).TabPages[e.Index].Text,
                                      System.Windows.Forms.SystemInformation.MenuFont, new SolidBrush(Color.LightGreen), rect, sf);
            }
        }

        private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;

            if (e.Index == this.tabControl.SelectedIndex)
            {
                fntTab = new Font(e.Font, FontStyle.Bold);
                bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                bshFore = Brushes.Black;
            }
            else
            {
                fntTab = e.Font;
                bshBack = new SolidBrush(Color.Blue);
                bshFore = new SolidBrush(Color.Black);
            }

            string tabName = this.tabControl.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat();
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
        }
        private void GroupPaint(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;
            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.LightGreen, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);
            e.Graphics.DrawLine(Pens.LightGreen, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.LightGreen, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.LightGreen, 1, vSize.Height / 2, 1, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.LightGreen, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.LightGreen, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);
        }

        //拖文件到窗体上触发DragEnter事件
        private void FormDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        //松开鼠标左键触发DragDrop事件
        private void FormDragDrop(object sender, DragEventArgs e)
        {
            //其中 label1.Text显示的就是拖进文件的文件名；
            mFilePath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            richTextBox.Text = mFilePath;
        }

        //主窗口加载处理函数
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_DevIndex.SelectedIndex = 0;
            comboBox_CANIndex.SelectedIndex = 0;
            textBox_AccCode.Text = "00000000";
            textBox_AccMask.Text = "FFFFFFFF";
            comboBox_Filter.SelectedIndex = 1;
            comboBox_Mode.SelectedIndex = 0;
            comboBox_SendType.SelectedIndex = 2;
            comboBox_FrameFormat.SelectedIndex = 0;
            comboBox_FrameType.SelectedIndex = 0;
            textBox_ID.Text = "00000123";
            textBox_Data.Text = "00 01 02 03 04 05 06 07 ";
            Int32 curindex = 0;
            comboBox_devtype.Items.Clear();
            curindex = comboBox_devtype.Items.Add("USBCAN 1");
            m_arrdevtype[curindex] = VCI_USBCAN1;
            curindex = comboBox_devtype.Items.Add("USBCAN II");
            m_arrdevtype[curindex] = VCI_USBCAN2;
            curindex = comboBox_devtype.Items.Add("USBCAN 2A");
            m_arrdevtype[curindex] = VCI_USBCAN2A;
            comboBox_devtype.SelectedIndex = 1;
            comboBox_devtype.MaxDropDownItems = comboBox_devtype.Items.Count;
            InitBautRateList();
        }

        //主窗口关闭处理函数
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_bOpen == 1)
            {
                DllAdapte.VCI_CloseDevice(m_devtype, m_devind);
            }
        }
        /// <summary>
        /// 初始化波特率控件中的信息
        /// </summary>
        private void InitBautRateList()
        {
            CanBautRate temp;

            //初始化波特率列表项
            if (canBautRateList.Count <= 0)
            {
                temp.timer0Str = "0x03";
                temp.timer1Str = "0x1C";
                temp.bautRateStr = "125kbps";
                canBautRateList.Add(temp);
                temp.timer0Str = "0x01";
                temp.timer1Str = "0x1C";
                temp.bautRateStr = "250kbps";
                canBautRateList.Add(temp);
                temp.timer0Str = "0x00";
                temp.timer1Str = "0x1C";
                temp.bautRateStr = "500kbps";
                canBautRateList.Add(temp);
            }

            //添加波特率列表项
            foreach (CanBautRate tem in canBautRateList)
            {
                can0GrpBox.Items.Add(tem.bautRateStr);
                can1GrpBox.Items.Add(tem.bautRateStr);
            }

            can0GrpBox.SelectedIndex = 0;
            can1GrpBox.SelectedIndex = 1;
            mCan0BRIndex = can0GrpBox.SelectedIndex;
            mCan1BRIndex = can1GrpBox.SelectedIndex;
            can0GrpBox.MaxDropDownItems = can0GrpBox.Items.Count;
            can1GrpBox.MaxDropDownItems = can1GrpBox.Items.Count;
            FillTimerTextBox();
        }

        //填充定时器控件的内容
        private void FillTimerTextBox()
        {
            can0T0TextBox.Text = canBautRateList[mCan0BRIndex].timer0Str;
            can0T1TextBox.Text = canBautRateList[mCan0BRIndex].timer1Str;
            can1T0TextBox.Text = canBautRateList[mCan1BRIndex].timer0Str;
            can1T1TextBox.Text = canBautRateList[mCan1BRIndex].timer1Str;
        }
        /// <summary>
        /// 内容条目增加时,滚动条自动跟随
        /// </summary>
        /// <param name="str"></param>
        private void AddListBoxItem(string str)
        {
            bool isNeedScroll = false;  //是否需要滚动标志

            if (this.RevListBox.TopIndex == this.RevListBox.Items.Count - (int)(this.RevListBox.Height / this.RevListBox.ItemHeight))
            {
                isNeedScroll = true;
            }

            this.RevListBox.Items.Add(str);

            if (isNeedScroll)
            {
                this.RevListBox.TopIndex = this.RevListBox.Items.Count - (int)(this.RevListBox.Height / this.RevListBox.ItemHeight);
            }
        }

        unsafe private void ReceiveDataHandle(UInt32 canId)
        {
            String str = "";
            UInt32 res = new UInt32();
            res = DllAdapte.VCI_GetReceiveNum(m_devtype, m_devind, canId);

            if (res == 0)
            {
                return;
            }

            //res = DllAdapte.VCI_Receive(m_devtype, m_devind, m_canind, ref m_recobj[0],50, 100);
            UInt32 con_maxlen = 50;
            IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VCI_CAN_OBJ)) * (Int32)con_maxlen);
            res = DllAdapte.VCI_Receive(m_devtype, m_devind, canId, pt, con_maxlen, 100);

            for (UInt32 i = 0; i < res; i++)
            {
                VCI_CAN_OBJ obj = (VCI_CAN_OBJ)Marshal.PtrToStructure((IntPtr)((UInt32)pt + i * Marshal.SizeOf(typeof(VCI_CAN_OBJ))), typeof(VCI_CAN_OBJ));
                str = "接收到数据: ";
                str += "  帧ID:0x" + System.Convert.ToString((Int32)obj.ID, 16);
                str += "  帧格式:";

                if (obj.RemoteFlag == 0)
                {
                    str += "数据帧 ";
                }
                else
                {
                    str += "远程帧 ";
                }

                if (obj.ExternFlag == 0)
                {
                    str += "标准帧 ";
                }
                else
                {
                    str += "扩展帧 ";
                }

                if (obj.RemoteFlag == 0)
                {
                    str += "数据: ";
                    byte len = (byte)(obj.DataLen % 9);
                    byte j = 0;

                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[0], 16);
                    }

                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[1], 16);
                    }

                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[2], 16);
                    }

                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[3], 16);
                    }

                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[4], 16);
                    }

                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[5], 16);
                    }

                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[6], 16);
                    }

                    if (j++ < len)
                    {
                        str += " " + System.Convert.ToString(obj.Data[7], 16);
                    }
                }

                if (mPauseFlag == 0)
                {
                    RevListBox.Items.Add(str);
                    RevListBox.SelectedIndex = RevListBox.Items.Count - 1;
                }
            }

            Marshal.FreeHGlobal(pt);
        }

        unsafe private void timer_rec_Tick(object sender, EventArgs e)
        {
            if (mUpgradeFlag == 0)
            {
                if (m_canind == 0)
                {
                    ReceiveDataHandle((UInt32)CanIndex.Can0);   //显示can0通道接收的数据
                }
                else if (m_canind == 1)
                {
                    ReceiveDataHandle((UInt32)CanIndex.Can1);   //显示can1通道接收的数据
                }
                else
                {
                    ReceiveDataHandle((UInt32)CanIndex.Can0);
                    ReceiveDataHandle((UInt32)CanIndex.Can1);   //显示can0、can1通道接收的数据
                }
            }
            else
            {
                ReceiveUpData();
                string id = "1840AAAB";
                string data = string.Empty;
                SendUpData(id, data);
            }
        }

        //发送按钮点击事件处理函数
        unsafe private void button_Send_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
            {
                return;
            }

            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.SendType = (byte)comboBox_SendType.SelectedIndex;
            sendobj.RemoteFlag = (byte)comboBox_FrameFormat.SelectedIndex;
            sendobj.ExternFlag = (byte)comboBox_FrameType.SelectedIndex;
            sendobj.ID = System.Convert.ToUInt32("0x" + textBox_ID.Text, 16);
            int len = (textBox_Data.Text.Length + 1) / 3;
            sendobj.DataLen = System.Convert.ToByte(len);
            String strdata = textBox_Data.Text;
            int i = -1;

            if (i++ < len - 1)
            {
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[1] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[2] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[3] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[4] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[5] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[6] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[7] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (DllAdapte.VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void textBox_AccCode_TextChanged(object sender, EventArgs e)
        {
        }

        //根据指定的can通道进行初始化
        private void InitCanByIndex(UInt32 canInd)
        {
            VCI_INIT_CONFIG config = new VCI_INIT_CONFIG();

            if (canInd == 0)
            {
                config.Timing0 = System.Convert.ToByte(can0T0TextBox.Text, 16);
                config.Timing1 = System.Convert.ToByte(can0T1TextBox.Text, 16);
            }
            else if (canInd == 1)
            {
                config.Timing0 = System.Convert.ToByte(can1T0TextBox.Text, 16);
                config.Timing1 = System.Convert.ToByte(can1T1TextBox.Text, 16);
            }

            config.AccCode = System.Convert.ToUInt32("0x" + textBox_AccCode.Text, 16);
            config.AccMask = System.Convert.ToUInt32("0x" + textBox_AccMask.Text, 16);
            config.Filter = m_filter;   //(Byte)comboBox_Filter.SelectedIndex;
            config.Mode = m_mode;   //(Byte)comboBox_Mode.SelectedIndex;
            DllAdapte.VCI_InitCAN(m_devtype, m_devind, canInd, ref config);
        }

        //初始化所有can通道
        private void InitCanAll()
        {
            VCI_INIT_CONFIG config = new VCI_INIT_CONFIG();
            config.AccCode = System.Convert.ToUInt32("0x" + textBox_AccCode.Text, 16);
            config.AccMask = System.Convert.ToUInt32("0x" + textBox_AccMask.Text, 16);
            config.Filter = m_filter;   //(Byte)comboBox_Filter.SelectedIndex;
            config.Mode = m_mode;   //(Byte)comboBox_Mode.SelectedIndex;
            config.Timing0 = System.Convert.ToByte(can0T0TextBox.Text, 16);
            config.Timing1 = System.Convert.ToByte(can0T1TextBox.Text, 16);
            DllAdapte.VCI_InitCAN(m_devtype, m_devind, 0/*(UInt32)CanIndex.Can0*/, ref config);
            config.Timing0 = System.Convert.ToByte(can1T0TextBox.Text, 16);
            config.Timing1 = System.Convert.ToByte(can1T1TextBox.Text, 16);
            DllAdapte.VCI_InitCAN(m_devtype, m_devind, 1/*(UInt32)CanIndex.Can1*/, ref config);
        }

        private void connectM_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 1)
            {
                DllAdapte.VCI_CloseDevice(m_devtype, m_devind);
                m_bOpen = 0;
            }
            else
            {
                //m_devtype = m_arrdevtype[comboBox_devtype.SelectedIndex];
                //m_devind = (UInt32)comboBox_DevIndex.SelectedIndex;
                //m_canind = (UInt32)comboBox_CANIndex.SelectedIndex;
                uint ret = DllAdapte.VCI_OpenDevice(m_devtype, m_devind, 0);

                if (ret <= 0)
                {
                    MessageBox.Show("打开设备失败,请检查设备类型和设备索引号是否正确", "错误",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    AddListBoxItem("设备连接成功。");
                }

                m_bOpen = 1;
                InitCanAll();
            }

            connectM.Text = m_bOpen == 1 ? "断开" : "连接";
            timer_rec.Enabled = m_bOpen == 1 ? true : false;
        }

        //can启动逻辑
        private void CanStart(UInt32 canId)
        {
            string state = string.Empty;
            //启动Can0通道
            uint ret = DllAdapte.VCI_StartCAN(m_devtype, m_devind, canId);

            if (ret > 0)
            {
                state = "成功";
            }
            else
            {
                state = "失败";
            }

            string disStr = string.Format("CAN{0}通道启动{1}。", canId/*.ToString()*/, state);
            RevListBox.Items.Add(disStr);
        }

        private void startM_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
            {
                return;
            }

            CanStart((UInt32)CanIndex.Can0);//启动Can0通道
            CanStart((UInt32)CanIndex.Can1);//启动Can1通道
        }

        //can复位逻辑
        private void CanReset(UInt32 canId)
        {
            string state = string.Empty;
            //启动Can0通道
            uint ret = DllAdapte.VCI_ResetCAN(m_devtype, m_devind, canId);

            if (ret > 0)
            {
                state = "成功";
            }
            else
            {
                state = "失败";
            }

            string disStr = string.Format("CAN{0}通道复位{1}。", canId/*.ToString()*/, state);
            RevListBox.Items.Add(disStr);
        }

        private void resetM_Click(object sender, EventArgs e)
        {
            if (m_bOpen == 0)
            {
                return;
            }

            CanReset((UInt32)CanIndex.Can0);
            CanReset((UInt32)CanIndex.Can1);
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void can0GrpBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mCan0BRIndex = can0GrpBox.SelectedIndex;
            FillTimerTextBox();
        }

        private void can1GrpBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mCan1BRIndex = can1GrpBox.SelectedIndex;
            FillTimerTextBox();
        }

        private void clearRevBtn_Click(object sender, EventArgs e)
        {
            RevListBox.Items.Clear();
        }

        private void clearSendBtn_Click(object sender, EventArgs e)
        {
            sendListBox.Items.Clear();
        }

        private void Can0Cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Can0Cb.CheckState == CheckState.Checked)
            {
                mCan0SelectFlag = 1;
            }
            else
            {
                mCan0SelectFlag = 0;
            }
        }

        private void Can1Cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Can1Cb.CheckState == CheckState.Checked)
            {
                mCan1SelectFlag = 1;
            }
            else
            {
                mCan1SelectFlag = 0;
            }
        }

        private void comboBox_CANIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            RevListBox.Items.Clear();   //变换通道时先清空屏幕中的接收区内容
            m_canind = (UInt32)comboBox_CANIndex.SelectedIndex;
        }

        private void comboBox_DevIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_devind = (UInt32)comboBox_DevIndex.SelectedIndex;
        }

        private void comboBox_devtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_devtype = m_arrdevtype[comboBox_devtype.SelectedIndex];
        }

        private void comboBox_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_filter = (Byte)comboBox_Filter.SelectedIndex;
        }

        private void comboBox_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_mode = (Byte)comboBox_Mode.SelectedIndex;
        }

        private void stopRevBtn_Click(object sender, EventArgs e)
        {
            if (mPauseFlag == 0)
            {
                mPauseFlag = 1;
                pauseRevBtn.Text = "继续";
            }
            else
            {
                mPauseFlag = 0;
                pauseRevBtn.Text = "暂停";
            }
        }

        private void bmsUp_Click(object sender, EventArgs e)
        {
            mUpgradeFlag = 1;
            string fileType = string.Empty;
            //检查升级文件路径是否为空
            if (string.IsNullOrEmpty(mFilePath))
            {
                MessageBox.Show("请先选择升级文件！", "提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //判断升级文件是否是bin文件
            fileType = Path.GetExtension(mFilePath);
            if (!fileType.Equals(".bin"))
            {
                MessageBox.Show("升级文件类型不是xxx.bin,请选择bin文件！", "提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //if (fileType.Contains("bin"))
            //{
            //    MessageBox.Show("升级文件类型是xxx.bin,请选择bin文件！", "提示",
            //                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

            //先发送ping命令 ID:0x1841AAAB
            //             string id = "1840AAAB";
            //             string data = string.Empty;
            //             SendUpData(id, data);

            //再发送升级下载命令

            //再发送升级命令

            //再发送运行命令


            //发送升级文件
            FileStream stream = new FileStream(mFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);//二进制读写器 
            //StreamReader binStream = new StreamReader(stream);//文本读写器


        }

        //发送升级数据
        unsafe private void SendUpData(string id, string data)
        {
            VCI_CAN_OBJ sendobj = new VCI_CAN_OBJ();
            //sendobj.Init();
            sendobj.SendType = (byte)comboBox_SendType.SelectedIndex;
            sendobj.RemoteFlag = (byte)comboBox_FrameFormat.SelectedIndex;
            sendobj.ExternFlag = (byte)comboBox_FrameType.SelectedIndex;
            sendobj.ID = System.Convert.ToUInt32("0x" + id, 16);
            int len = (data.Length + 1) / 3;
            sendobj.DataLen = System.Convert.ToByte(len);
            String strdata = data;
            int i = -1;

            if (i++ < len - 1)
            {
                sendobj.Data[0] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[1] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[2] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[3] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[4] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[5] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[6] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            if (i++ < len - 1)
            {
                sendobj.Data[7] = System.Convert.ToByte("0x" + strdata.Substring(i * 3, 2), 16);
            }

            sendListBox.Items.Add("0x" + id);

            if (DllAdapte.VCI_Transmit(m_devtype, m_devind, m_canind, ref sendobj, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        unsafe private void ReceiveUpData()
        {
            String str = "";
            UInt32 res = new UInt32();
            UInt32 canId = 0;

            res = DllAdapte.VCI_GetReceiveNum(m_devtype, m_devind, canId);

            if (res == 0)
            {
                return;
            }

            //res = DllAdapte.VCI_Receive(m_devtype, m_devind, m_canind, ref m_recobj[0],50, 100);
            UInt32 con_maxlen = 50;
            IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VCI_CAN_OBJ)) * (Int32)con_maxlen);
            res = DllAdapte.VCI_Receive(m_devtype, m_devind, canId, pt, con_maxlen, 100);

            for (UInt32 i = 0; i < res; i++)
            {
                VCI_CAN_OBJ obj = (VCI_CAN_OBJ)Marshal.PtrToStructure((IntPtr)((UInt32)pt + i * Marshal.SizeOf(typeof(VCI_CAN_OBJ))), typeof(VCI_CAN_OBJ));
                str = System.Convert.ToString((Int32)obj.ID, 16);
                //                 if(str.Contains("41abaa") && mPauseFlag == 0)
                //                 {
                RevListBox.Items.Add("0x" + str);
                RevListBox.SelectedIndex = RevListBox.Items.Count - 1;
                //                 }

                //                 if (obj.RemoteFlag == 0)
                //                 {
                //                     str += "数据: ";
                //                     byte len = (byte)(obj.DataLen % 9);
                //                     byte j = 0;
                // 
                //                     if (j++ < len)
                //                     {
                //                         str += " " + System.Convert.ToString(obj.Data[0], 16);
                //                     }
                // 
                //                     if (j++ < len)
                //                     {
                //                         str += " " + System.Convert.ToString(obj.Data[1], 16);
                //                     }
                // 
                //                     if (j++ < len)
                //                     {
                //                         str += " " + System.Convert.ToString(obj.Data[2], 16);
                //                     }
                // 
                //                     if (j++ < len)
                //                     {
                //                         str += " " + System.Convert.ToString(obj.Data[3], 16);
                //                     }
                // 
                //                     if (j++ < len)
                //                     {
                //                         str += " " + System.Convert.ToString(obj.Data[4], 16);
                //                     }
                // 
                //                     if (j++ < len)
                //                     {
                //                         str += " " + System.Convert.ToString(obj.Data[5], 16);
                //                     }
                // 
                //                     if (j++ < len)
                //                     {
                //                         str += " " + System.Convert.ToString(obj.Data[6], 16);
                //                     }
                // 
                //                     if (j++ < len)
                //                     {
                //                         str += " " + System.Convert.ToString(obj.Data[7], 16);
                //                     }
                //                 }
                // 
                //                 if (mPauseFlag == 0)
                //                 {
                //                     RevListBox.Items.Add(str);
                //                     RevListBox.SelectedIndex = RevListBox.Items.Count - 1;
                //                 }
            }

            Marshal.FreeHGlobal(pt);
        }
    }
}
