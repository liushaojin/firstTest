using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
//using System.IO.Ports;


namespace SolingScrew
{
    using SolingScrew.UI;
    using SolingScrew.DataDal;
    using SolingScrew.XYGraph;
    using SolingScrew.FileOpAPI;
    
    public partial class solingScrew : Form
    {
        /// <summary>
        /// 读取PLC控制状态信息枚举
        /// </summary>
        public enum ReadPlcCtrlCmd
        {
            None,
            ReadW3300,  //PLC启动工控机状态的读取
            ReadW3301,  //是否打完一个螺丝的状态读取
            ReadW3302,  //PLC是否启动工控机采集扭矩状态的读取
            ReadW3303,  //参数写入
        }
        /// <summary>
        /// 读取当前坐标各点的值
        /// </summary>
        public enum ReadPointCmd
        {
            None,
            ReadX1D250,  //读取当前的X1坐标值
            ReadZ1D252,  //读取当前的Z1坐标值
            ReadYD254,   //读取当前的Y坐标值
            ReadX2D256,  //读取当前的X2坐标值
            ReadZ2D258,  //读取当前的Z2坐标值
        }
        /// <summary>
        /// 读取错误报警信息的指令枚举
        /// </summary>
        public enum ReadErrorCmd
        {
            None,
            ReadW20000,  //供料1无料
            ReadW20001,  //供料2无料
            ReadW20002,  //真空检测1异常
            ReadW20003,  //真空检测2异常
            ReadW20004,  //打螺丝1异常
            ReadW20005,  //打螺丝2异常
            ReadW20006,  //无物料
            
            ReadW20201,  //伺服电机异常
            ReadW20202,  //电批1报错A
            ReadW20203,  //电批2报错B
            
            ReadW20300,  //轴控模块X轴异常
            ReadW20301,  //轴控模块Y轴异常
            
            ReadW20400,  //急停中
            ReadW20405,  //X1平移伺服异常
            ReadW20406,  //Y轴伺服异常
        }
        
        
        private int totalScrewNum = 0;  //总的锁螺丝数
        private int passNum = 0;    //通过的数量
        private int failNum = 0;    //失败的数量
        private int screwTime = 0;  //测试时间
        private float passRate = 0; //直通率
        float torsionUp = 0;        //扭力上限
        float torsionDown = 0;      //扭力下限
        
        private ReadPlcCtrlCmd curPlcCmd = ReadPlcCtrlCmd.None; //当前读取的PLC控制状态
        private ReadPointCmd curPointCmd = ReadPointCmd.None;   //当前读取的点的值
        private ReadErrorCmd curErrorCmd = ReadErrorCmd.ReadW20000;   //当前读取的报警信息
        
        private bool readTorsionEnableFlag = false; //扭力采集便能标志
        private bool completeOneScrewFlag = false;      //打完一个螺丝
        
        private string curProduct = string.Empty;   //当前操作的产品
        private bool sendToPlcFlag = true;  //是否发送点位信息到PLC,只有在刚打开上位机或切换产品时才需发送点位信息
        private List<string> curPointList = new List<string>(); //从系统设置文件中读到的点位信息的缓存链表
        
        //对象的实例化
        DataTable mDt = new DataTable();
        XYChat torsionCurve = new XYChat();
        IniFileHelper iniFileOp = new IniFileHelper();
        ProExpertDev dianpi1 = new ProExpertDev("192.168.0.1");
        ProExpertDev dianpi2 = new ProExpertDev("192.168.0.2");
        SerialComm comm = SerialComm.GetScomInstance();
        //ProExpertDev modTcp = ProExpertDev.GetTcpInstance();
        
        private delegate void ModbusDataHandler(string dat);
        private delegate void ShortDataHandler(short addr, List<short> list);
        private delegate void WrDataHandler(string[] dat);
        private delegate void DmDataHandler(string[] dat);
        public solingScrew()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            //开启双缓冲，防止最小化后再显示时闪屏或重绘（不起作用，可能双缓冲不适用这种情况），
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            //this.UpdateStyles();
        }
        
        private void solingScrew_Load(object sender, EventArgs e)
        {
            comm.ScomInit();
            //dianpi1.ModbusTcpInit();
            listBox1.Items.Add(dianpi1.ErrorStr);
            listBox1.Items.Add(dianpi2.ErrorStr);
            TableInit();
            XYCharInit();
            comm.scomDataReceived += new SerialComm.ScomDataReceivedHandler(CommDataReceived);
            comm.bitDataReceived += new SerialComm.BitDataReceivedHandler(WrDataReceived);
            comm.wordDataReceived += new SerialComm.WordDataReceivedHandler(DmDataReceived);
            dianpi1.modTcpDataReceived += new ProExpertDev.ModTcpDataReceivedHandler(ModbusDataReceived);
            dianpi1.shortDataReceived += new ProExpertDev.ShortDataReceiveHandle(ShortDataReceived);
            dianpi2.modTcpDataReceived += new ProExpertDev.ModTcpDataReceivedHandler(ModbusDataReceived);
            dianpi2.shortDataReceived += new ProExpertDev.ShortDataReceiveHandle(ShortDataReceived);
            //comm.ScomSendData("@00TS--PC to PLC communication test success--");
            //comm.ScomSendData("@00RD20000002");
            //comm.ScomSendData("@00WD20000100");
            //comm.ScomSendData("@00FA00000000001018207D0000002");
            comm.ScomSendData("@00FA0000000000101310021000001");    //读W33.00的值
            //comm.ScomSendData("@00FA000000000010231002101000101");  //写W33.01,置1
            //comm.ScomSendData("@00FA00000000001028220000000010256");
            //comm.ScomSendData("@00FA0000000000102820bb80000010082");
            InitProductInfo();                                  //初始化产品信息
            GetTorsionLimit(ref torsionDown, ref torsionUp);    //从设置文件中获取扭力的上下限
            
            if(comm.GetScomState())
            {
                listBox1.Items.Add("串口打开成功");
                tcpTimer.Enabled = true;    //串口打开成功就要向下发送数据了，只有同PLC的串口通信上了，才会有后续的扭力读取等操作，所以在此打开定时器
            }
            else
            {
                listBox1.Items.Add("串口打开失败");
            }
            
            if(dianpi1.Connected)
            {
                listBox1.Items.Add("电批1控制器连接成功");
            }
            else
            {
                listBox1.Items.Add("电批1控制器连接失败");
            }
            
            if(dianpi2.Connected)
            {
                listBox1.Items.Add("电批2控制器连接成功");
            }
            else
            {
                listBox1.Items.Add("电批2控制器连接失败");
            }
            
            tcpTimer.Enabled = true;
        }
        /// <summary>
        /// 初始化产品信息
        /// </summary>
        private void InitProductInfo()
        {
            curProduct = iniFileOp.ReadValue("CurOpProduct", "ProductName");
            productName.Text = curProduct;
            curPointList = GetPointInfoByProduct(curProduct);
        }
        
        private void GetTorsionLimit(ref float down, ref float up)
        {
            down = Convert.ToSingle(iniFileOp.ReadValue("SysSetting", "Screw1TorsionDown"));
            up = Convert.ToSingle(iniFileOp.ReadValue("SysSetting", "Screw1TorsionUp"));
        }
        
        private string chartTitle = "扭力-点坐标图";
        private string yName = "扭力值(kgm.cm)";
        private string xName = "点";
        /// <summary>
        /// 扭力曲线图窗口部件的初始化
        /// </summary>
        private void XYCharInit()
        {
            //chart1.Series.Clear();
            //chart1.Width = 520;                      //图表宽度
            //chart1.Height = 320;                     //图表高度
            chart1.BackColor = Color.Azure;             //图表背景色
            chart1.Titles.Add("点位扭力值图表");                //图表标题
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;//设置曲线类型
            chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;//1.设置当前X轴Label自动设置格式 = 关闭
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;//2.设置适应全部数据点
            chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false;//3.设置当前X轴Label的双行显示格式 = 关闭
            chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;//4.设置X轴从0开始
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;//设置滚动条是在外部显示
            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
            chart1.ChartAreas[0].AxisX.ScrollBar.Size = 10;//设置滚动条的宽度
            chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;//滚动条只显示向前的按钮，主要是为了不显示取消显示的按钮
            chart1.ChartAreas[0].AxisX.ScaleView.Size = 8;//设置图表可视区域数据点数，说白了一次可以看到多少个X轴区域
            chart1.ChartAreas[0].AxisX.LineColor = Color.Blue;           //X轴颜色
            chart1.ChartAreas[0].AxisY.LineColor = Color.Blue;           //Y轴颜色
            chart1.ChartAreas[0].AxisX.LineWidth = 1;                    //X轴宽度
            chart1.ChartAreas[0].AxisY.LineWidth = 1;                    //Y轴宽度
            chart1.ChartAreas[0].AxisX.Interval = 1;                     //X轴间隔
            chart1.ChartAreas[0].AxisX.Title = xName;                    //X轴名称
            chart1.ChartAreas[0].AxisY.Title = yName;                    //Y轴名称
            chart1.ChartAreas[0].AxisX.Minimum = 0;     //坐标最小值，这样的话，X轴坐标是从1开始
            chart1.ChartAreas[0].AxisY.Maximum = 5;     //设置Y轴最大值
            //chart1.ChartAreas[0].AxisY.Minimum = 0;   //设置Y轴最小值
            chart1.ChartAreas[0].BackColor = Color.Black;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;    //网格线线型设置
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;     //网格线颜色设置
            // 线的颜色为红色
            chart1.Series[0].Color = Color.LawnGreen;
            chart1.Series[0].MarkerStyle = MarkerStyle.Circle;   //线条上的数据点标志类型
            chart1.Series[0].MarkerColor = Color.Red;
            chart1.Series[0].IsValueShownAsLabel = false;    //是否显示数据，值作为标签显示在图表中
            chart1.Series[0].IsVisibleInLegend = false;      //是否显示数据说明
            chart1.Series[0].LabelForeColor = Color.Red;
            chart1.Series[0].XValueType = ChartValueType.Auto;//设置X轴绑定值的类型
            chart1.Series[0].MarkerSize = 3;                 //绘制点的标志大小
            //chart1.Series[0].LegendToolTip = "Target Output";//鼠标放到系列上出现的文字
            //chart1.Series[0].LegendText = "Target Output";//系列名字
            //chart1.Series[0].BorderWidth = 1;//设置线宽
            // Y的最大值
            // 隐藏图示
            chart1.Legends[0].Enabled = false;
        }
        
        private string pointCol = "点位";
        private string niuliCol = "扭力值(kgf.cm)";
        private string upLimitCol = "上限(kgf.cm)";
        private string downLimitCol = "下限(kgf.cm)";
        private string resultCol = "结果";
        
        /// <summary>
        /// 点位信息表格的初始化
        /// </summary>
        private void TableInit()
        {
            //表格列的初始化
            DataColumn col1 = new DataColumn(pointCol, typeof(string));
            DataColumn col2 = new DataColumn(niuliCol, typeof(string));
            DataColumn col3 = new DataColumn(upLimitCol, typeof(string));
            DataColumn col4 = new DataColumn(downLimitCol, typeof(string));
            DataColumn col5 = new DataColumn(resultCol, typeof(string));
            // 表格添加列
            mDt.Columns.Add(col1);
            mDt.Columns.Add(col2);
            mDt.Columns.Add(col3);
            mDt.Columns.Add(col4);
            mDt.Columns.Add(col5);
            
            for(int i = 0; i < dataGridView1.Height / dataGridView1.RowTemplate.Height - 2; i++)
            {
                // 添加空白行
                DataRow blankRow = mDt.NewRow();
                //row["点位"] = "x10001";
                //row["扭力值(kgf.cm)"] = "345";
                //row["上限(kgf.cm)"] = "368";
                //row["下限(kgf.cm)"] = "300";
                //row["结果"] = "正常";
                mDt.Rows.Add(blankRow);
            }
            
            dataGridView1.DataSource = mDt;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //DataGridView1.AllowUserToResizeColumns = false;   // 禁止用户改变DataGridView1的所有列的列宽
            dataGridView1.AllowUserToResizeRows = false;    //禁止用户改变DataGridView1の所有行的行高
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;    // 禁止用户改变列头的高度
            //dataGridView1.Columns[0].FillWeight = 10;      //第一列的相对宽度为10%
            ////设置标题字段(先把ColumnsHeadersVisible设置为true)
            //dataGridView1.Columns[0].HeaderText = "点位";
            ////设置属性
            //DataGridTableStyle tablestyle = new DataGridTableStyle();
            //this.dataGridView1.TableStyles.Add(tablestyle);
            //dataGridView1.TableStyles[0].GridColumnStyles[0].Width = 75;
            //dataGridView1.TableStyles[0].GridColumnStyles[1].Width = 75;
            //dataGridView1.TableStyles[0].GridColumnStyles[2].Width = 75;
            //dataGridView1.TableStyles[0].GridColumnStyles[3].Width = 75;
            //dataGridView1.TableStyles[0].GridColumnStyles[4].Width = 75;
            //dataGridView1.TableStyles[0].GridColumnStyles[5].Width = 120;
        }
        
        /// <summary>
        /// ModbusTCP通信收到数据事件的处理委托
        /// </summary>
        /// <param name="dat"></param>
        private void ModbusDataReceived(string dat)
        {
            if(true == this.InvokeRequired)
            {
                this.Invoke(new ModbusDataHandler(ShowPointVal), new object[] { dat });
            }
            else
            {
                ShowPointVal(dat);
            }
        }
        private void ShowPointVal(string dat)
        {
            listBox1.Items.Add(dat);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        
        private void ShortDataReceived(short addr, List<short> list)
        {
            if(true == this.InvokeRequired)
            {
                this.Invoke(new ShortDataHandler(UpdateTableAndWave), new object[] { addr, list});
            }
            else
            {
                UpdateTableAndWave(addr, list);
            }
        }
        //private int mPointNum = 0;//
        private void UpdateTableAndWave(short addr, List<short> list)
        {
            int rows = dataGridView1.RowCount;   //添加数据前先获取表格中现有的行数
            
            for(int i = 0; i < list.Count; i++)
            {
                int j = rows + i;   //新数据要添加到的行的索引
                float torsion = ((float)list[i] / 10000);
                dataGridView1.Rows[j].Cells[0].Value = string.Format("点{0}", i);
                dataGridView1.Rows[j].Cells[1].Value = torsion;
                dataGridView1.Rows[j].Cells[2].Value = torsionUp;
                dataGridView1.Rows[j].Cells[3].Value = torsionDown;
                totalScrewNum++;
                testNum.Text = totalScrewNum.ToString();
                
                if(torsion >= torsionDown && torsion <= torsionUp)
                {
                    passNum++;
                    dataGridView1.Rows[j].Cells[4].Value = "Pass";
                }
                else
                {
                    failNum++;
                    dataGridView1.Rows[j].Cells[4].Value = "Fail";
                }
                
                passRate = passNum / totalScrewNum * 100;
                straitRate.Text = string.Format("{0}%", passRate.ToString("f2"));   //passRate.ToString("f2");
                //根据最新点位及扭力数据更新波形图
                PointF point = new PointF(j, torsion);
                SetChart(chart1, point);
            }
        }
        /// <summary>
        /// 串口接收到PLC数据事件的响应
        /// </summary>
        /// <param name="e"></param>
        private void CommDataReceived(DataReceivedEventArgs e)
        {
            string str = e.DataReceived;    //System.Text.Encoding.Default.GetString(e.DataRecv);
            listBox1.BeginInvoke(
                new MethodInvoker(() =>     //delegate <=> () => 两者等价，委托的符号表示
            {
                ShowPointVal(str);//输出到主窗口文本控件
            }
                                 )
            );
        }
        
        //WR区位读取信息的返回事件处理
        private void WrDataReceived(string[] dat)
        {
            if(true == this.InvokeRequired)
            {
                this.Invoke(new WrDataHandler(WrDataReceive), new object[] {dat});
            }
            else
            {
                WrDataReceive(dat);
            }
        }
        
        int[] plcStatus = new int[4];//读取plc的状态返回值保存数组变量
        
        int[] plcErrors = new int[20];//读取plc的状态返回值保存数组变量
        /// <summary>
        /// 对接收的位查询结果信息进行解析
        /// </summary>
        /// <param name="dat"></param>
        private void WrDataReceive(string[] dat)
        {
            //先查询PLC的状态
            switch(curPlcCmd)
            {
                case ReadPlcCtrlCmd.ReadW3300:      //先查询PLC是否启动工控机
                    if(dat.Length == 1)
                    {
                        plcStatus[0] = (dat[0] == "01") ? 1 : 0;
                        
                        if(plcStatus[0] == 1)
                        {
                            curPlcCmd = ReadPlcCtrlCmd.ReadW3301;//若启动工控机，则切换到下一个状态
                        }
                    }
                    
                    break;
                    
                case ReadPlcCtrlCmd.ReadW3301:      //先查询PLC是否打完一个螺丝
                    if(dat.Length == 1)
                    {
                        plcStatus[1] = (dat[0] == "01") ? 1 : 0;
                        
                        if(plcStatus[1] == 1)
                        {
                            curPlcCmd = ReadPlcCtrlCmd.ReadW3302;//若打完一个螺丝，则切换到下一个状态
                            completeOneScrewFlag = true;
                        }
                        else
                        {
                            completeOneScrewFlag = false;
                        }
                    }
                    
                    break;
                    
                case ReadPlcCtrlCmd.ReadW3302:      //先查询PLC是否启动工控机采集扭矩
                    if(dat.Length == 1)
                    {
                        plcStatus[2] = (dat[0] == "01") ? 1 : 0;
                        
                        if(plcStatus[2] == 1)
                        {
                            curPlcCmd = ReadPlcCtrlCmd.ReadW3303;//若启动工控机采集扭矩，则使能扭力的采集并切换到下一个状态
                            readTorsionEnableFlag = true;   //使能扭力采集
                        }
                        else
                        {
                            readTorsionEnableFlag = false;  //禁能扭力采集
                        }
                    }
                    
                    break;
                    
                case ReadPlcCtrlCmd.ReadW3303:      //先查询PLC是否允许参数写入
                    if(dat.Length == 1)
                    {
                        plcStatus[3] = (dat[0] == "01") ? 1 : 0;
                    }
                    
                    curPlcCmd = ReadPlcCtrlCmd.None;
                    break;
                    
                default:
                    for(int i = 0; i < dat.Length; i++) //默认4个连续位置的状态连续读取
                    {
                        if(i < 4)
                        {
                            plcStatus[i] = (dat[i] == "01") ? 1 : 0;
                        }
                    }
                    
                    curPlcCmd = ReadPlcCtrlCmd.None;
                    break;
            }
            
            //再查询报警信息（要不要先判断是否启动工控机）
            switch(curErrorCmd)
            {
                case ReadErrorCmd.ReadW20000:       //先查看w20000开始的七个报警信息
                    for(int i = 0; i < dat.Length; i++)  //默认7个连续位置的状态连续读取
                    {
                        if(i < 7)
                        {
                            plcErrors[i] = (dat[i] == "01") ? 1 : 0;
                        }
                    }
                    
                    curErrorCmd = ReadErrorCmd.ReadW20201;
                    break;
                    
                case ReadErrorCmd.ReadW20201:       //再查询w20201开始的三个报警信息
                    for(int i = 0; i < dat.Length; i++)   //默认4个连续位置的状态连续读取
                    {
                        if(i < 4)
                        {
                            plcErrors[7 + i] = (dat[i] == "01") ? 1 : 0;
                        }
                    }
                    
                    curErrorCmd = ReadErrorCmd.ReadW20300;
                    break;
                    
                case ReadErrorCmd.ReadW20300:      //再查询w20300开始的两个报警信息
                    for(int i = 0; i < dat.Length; i++)   //默认2个连续位置的状态连续读取
                    {
                        if(i < 2)
                        {
                            plcErrors[11 + i] = (dat[i] == "01") ? 1 : 0;
                        }
                    }
                    
                    curErrorCmd = ReadErrorCmd.ReadW20400;
                    break;
                    
                case ReadErrorCmd.ReadW20400:      //再查询w20400开始的七个报警信息
                    for(int i = 0; i < dat.Length; i++)   //默认3个连续位置的状态连续读取
                    {
                        if(i < 7)
                        {
                            plcErrors[13 + i] = (dat[i] == "01") ? 1 : 0;
                        }
                    }
                    
                    curErrorCmd = ReadErrorCmd.None;
                    break;
                    
                default:
                    break;
            }
            
            //对PLC状态返回的处理
            if(plcStatus[1] == 1)
            {
                completeOneScrewFlag = true;    //完成置位
            }
            else
            {
                completeOneScrewFlag = false;   //未完成复位
            }
            
            if(plcStatus[2] == 1)
            {
                readTorsionEnableFlag = true;   //使能扭力采集
            }
            else
            {
                readTorsionEnableFlag = false;  //禁能扭力采集
            }
            
            string errorStr = string.Empty;
            
            //错误的显示处理
            for(int j = 0; j < plcErrors.Length; j++)
            {
                if(plcErrors[0] == 1)
                {
                    errorStr = "供料1无料";
                }
                
                if(plcErrors[1] == 1)
                {
                    errorStr = "供料2无料";
                }
                
                if(plcErrors[2] == 1)
                {
                    errorStr = "真空检测1异常";
                }
                
                if(plcErrors[3] == 1)
                {
                    errorStr = "真空检测2异常";
                }
                
                if(plcErrors[4] == 1)
                {
                    errorStr = "打螺丝1异常";
                }
                
                if(plcErrors[5] == 1)
                {
                    errorStr = "打螺丝2异常";
                }
                
                if(plcErrors[6] == 1)
                {
                    errorStr = "无物料";
                }
                
                if(plcErrors[8] == 1)
                {
                    errorStr = "伺服电机异常";
                }
                
                if(plcErrors[9] == 1)
                {
                    errorStr = "电批1报错A";
                }
                
                if(plcErrors[10] == 1)
                {
                    errorStr = "电批2报错B";
                }
                
                if(plcErrors[11] == 1)
                {
                    errorStr = "轴控模块X轴异常";
                }
                
                if(plcErrors[12] == 1)
                {
                    errorStr = "轴控模块Y轴异常";
                }
                
                if(plcErrors[13] == 1)
                {
                    errorStr = "急停中";
                }
                
                if(plcErrors[18] == 1)
                {
                    errorStr = "X1平移伺服异常";
                }
                
                if(plcErrors[19] == 1)
                {
                    errorStr = "Y轴伺服异常";
                }
                
                listBox2.Items.Add(errorStr);
                listBox2.SelectedIndex = listBox1.Items.Count - 1;
            }
        }
        //DM区字读取信息的返回事件处理
        private void DmDataReceived(string[] dat)
        {
            if(true == this.InvokeRequired)
            {
                this.Invoke(new DmDataHandler(DmDataReceive), new object[] {dat});
            }
            else
            {
                DmDataReceive(dat);
            }
        }
        private void DmDataReceive(string[] dat)
        {
            listBox1.Items.Add(dat);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        /// <summary>
        /// 系统设置按钮事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sysSetBtn_Click(object sender, EventArgs e)
        {
            SysSetting sysSetWin = new SysSetting();
            sysSetWin.StartPosition = FormStartPosition.CenterParent;
            sysSetWin.ShowDialog();
            //SingleShow(sysSetWin);
        }
        
        /// <summary>
        /// 点位设置按钮事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void posSetBtn_Click(object sender, EventArgs e)
        {
            PointSetting posSetWin = new PointSetting();
            posSetWin.StartPosition = FormStartPosition.CenterParent;
            
            if(posSetWin.ShowDialog() == DialogResult.OK)
            {
                if(posSetWin.CurOpProduct == "" || string.IsNullOrEmpty(posSetWin.CurOpProduct))
                {
                }
                else
                {
                    productName.Text = posSetWin.CurOpProduct;
                    //tcpTimer.Enabled = true;    //切换产品后要重新发送点位信息到PLC
                    sendToPlcFlag = true;
                }
            }
        }
        
        /// <summary>
        /// CPK计算按钮事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CPKBtn_Click(object sender, EventArgs e)
        {
            CpkCalculate cpkCalWin = new CpkCalculate();
            cpkCalWin.StartPosition = FormStartPosition.CenterParent;
            cpkCalWin.ShowDialog();
        }
        
        //static int pointNo = 0;
        private void datCleanBtn_Click(object sender, EventArgs e)
        {
            ClearTable();
            //float x1 = 229.00f;
            //float z1 = 239.00f;
            //float y = 24.87f;
            //float x2 = 243.35f;
            //float z2 = 76.54f;
            //float[] point = new float[5];
            //point[0] = x1;
            //point[1] = z1;
            //point[2] = y;
            //point[3] = x2;
            //point[4] = z2;
            //comm.WriteDMData(2000, point[pointNo]);
            //if(pointNo++ >= 4)
            //{
            //    pointNo = 0;
            //}
            //comm.WritePoint(2000, point);
            //string str = "@00FA0000000000102820BB80000010082";
            //comm.ScomSendData(str);
            //str = SerialComm.FCSCheck(str);
            //comm.ScomSendData(SerialComm.strToHexByte(str));
        }
        
        /// <summary>
        /// 清空表格数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearTable()
        {
            int rows = dataGridView1.RowCount;
            
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = string.Empty;
                }
            }
        }
        
        private void quitSysBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
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
            foreach(Form f in formList)
            {
                //判断弹出的窗体是否重复
                if(f.Name == form.Name)
                {
                    //重复，修改为true
                    hasform = true;
                    f.WindowState = FormWindowState.Normal;
                    //获取焦点
                    f.Focus();
                }
            }
            
            if(hasform)
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
        
        //private static int cnt = 0;
        private void loginBtn_Click(object sender, EventArgs e)
        {
            //comm.ReadPoint(2000);
            //comm.ScomSendData("@00RD20000002");
            //comm.ScomSendData("@00FA0000000000101820BB8000001");
            //comm.ScomSendData("@00FA0000000000101820001000001");
            //string sendStr = "@00RD20";
            //if(cnt++ >= 40)
            //{
            //    cnt = 0;
            //}
            //string str = string.Format("{0}{1:D2}{2:D4}", sendStr, 2 * (cnt / 2), 2);
            ////comm.ScomSendData("@00TS--PC to PLC communication test success--");
            //comm.ScomSendData(str);//"@00RD20000002"
        }
        
        private void solingScrew_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("您确定要退出程序吗?", "退出确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            
            if(res == DialogResult.OK)
            {
                comm.ScomClose();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        
        private static int addrX1 = 2000;  //x1在PLC DM域内的起始地址
        private static int addrZ1 = addrX1 + 100;
        private static int addrY = addrX1 + 200;
        private static int addrX2 = addrX1 + 300;
        private static int addrZ2 = addrX1 + 400;
        private static int addrDp = addrX1 + 500;
        private static int addrPe = addrX1 + 600;
        private static int curSendPoint = 0;    //当前发送点
        
        List<PointF> points = new List<PointF>();
        private static float datX = 0;
        private static float datY = 0;
        /// <summary>
        /// 定时器1时间到的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcpTimer_Tick(object sender, EventArgs e)
        {
            if(sendToPlcFlag)
            {
                SendPointToPLC();   //只有在需要发送点位信息时才发送
            }
            
            //发送完点位信息后，就要查询PLC当前的控制状态和报警信息
            PollPLCStatus();
            ReadErrorFromPLC(); //读取错误信息
            
            //读取扭力值
            if(readTorsionEnableFlag)   //使能扭力采集时发送扭力采集指令
            {
                byte[] bytes = new byte[] { 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x01, 0x03, 0x00, 0x33, 0x00, 0x01};
                dianpi1.ReadDataByFc03(17, 1);
                dianpi2.ReadDataByFc03(17, 1);
            }
            
            Random ran = new Random();
            int RandKey = ran.Next(2, 4);
            datY = (float)1.23 * RandKey;
            PointF point = new PointF(datX, datY);
            //points.Add(point);
            //SetChart(chart1, points);
            //torsionCurve.SetPointData(new PointF(datX, datY));
            //torsionCurve.Update();
            SetChart(chart1, point);
            
            if(datX++ > 200)
            {
                datX = 0;
            }
        }
        
        /// <summary>
        /// 查询PLC的状态信息
        /// </summary>
        private void PollPLCStatus()
        {
            //先查询PLC的状态
            switch(curPlcCmd)
            {
                case ReadPlcCtrlCmd.ReadW3300:      //先查询PLC是否启动工控机
                    comm.ReadWRData(33, 0, 1);
                    break;
                    
                case ReadPlcCtrlCmd.ReadW3301:      //先查询PLC是否打完一个螺丝
                    comm.ReadWRData(33, 1, 1);
                    break;
                    
                case ReadPlcCtrlCmd.ReadW3302:      //先查询PLC是否启动工控机采集扭矩
                    comm.ReadWRData(33, 2, 1);
                    break;
                    
                case ReadPlcCtrlCmd.ReadW3303:      //先查询PLC是否允许参数写入
                    comm.ReadWRData(33, 3, 1);
                    break;
                    
                default:
                    comm.ReadWRData(33, 4);
                    break;
            }
            
            //再查询报警信息（要不要先判断是否启动工控机）
            switch(curErrorCmd)
            {
                case ReadErrorCmd.ReadW20000:       //先查看w20000开始的七个报警信息
                    comm.ReadWRData(200, 7);
                    break;
                    
                case ReadErrorCmd.ReadW20201:       //再查询w20201开始的四个报警信息
                    comm.ReadWRData(202, 4);
                    break;
                    
                case ReadErrorCmd.ReadW20300:      //再查询w20300开始的两个报警信息
                    comm.ReadWRData(203, 2);
                    break;
                    
                case ReadErrorCmd.ReadW20400:      //再查询w20400开始的七个报警信息
                    comm.ReadWRData(204, 7);
                    break;
                    
                default:
                    break;
            }
        }
        
        /// <summary>
        /// 发送点位数据到PLC
        /// </summary>
        private void SendPointToPLC()
        {
            string curTime = DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss");//获取格式化的当前时间
            
            if(curPointList.Count > 0)
            {
                string[] pointUnit = curPointList[curSendPoint].Split(',');
                float x1 = Convert.ToSingle(pointUnit[0]);
                float z1 = Convert.ToSingle(pointUnit[1]);
                float y = Convert.ToSingle(pointUnit[2]);
                float x2 = Convert.ToSingle(pointUnit[3]);
                float z2 = Convert.ToSingle(pointUnit[4]);
                int dp = Convert.ToInt32(pointUnit[5]);
                int pe = Convert.ToInt32(pointUnit[6]);
                
                for(int i = 0; i < pointUnit.Length; i++)
                {
                    comm.WriteDMData(addrX1 + 2 * curSendPoint, x1);
                    comm.WriteDMData(addrZ1 + 2 * curSendPoint, z1);
                    comm.WriteDMData(addrY + 2 * curSendPoint, y);
                    comm.WriteDMData(addrX2 + 2 * curSendPoint, x2);
                    comm.WriteDMData(addrZ2 + 2 * curSendPoint, z2);
                    comm.WriteDMData(addrDp + 2 * curSendPoint, dp);
                    comm.WriteDMData(addrPe + 2 * curSendPoint, pe);
                }
                
                string msg = string.Format("{0} - 点{1}: {2}", curTime, curSendPoint + 1, curPointList[curSendPoint]);
                listBox1.Items.Add(msg);
            }
            
            if(++curSendPoint >= curPointList.Count)
            {
                curSendPoint = 0;
                sendToPlcFlag = false;//发送完点位信息后就没必要再发送点位信息了
                //tcpTimer.Enabled = false;//发送完成先停止定时器
            }
        }
        
        /// <summary>
        /// 发送点位数据到PLC
        /// </summary>
        private void ReadErrorFromPLC()
        {
            int errorAddr = 200;  //运行错误在PLC
            comm.ReadWRData(errorAddr, 7);
            comm.ReadWRData(errorAddr + 2, 4);
            comm.ReadWRData(errorAddr + 3, 2);
            comm.ReadWRData(errorAddr + 4, 3);
            //comm.ScomSendData("@00FA0000000000101310021000001");    //读W33.00的值
        }
        
        /// <summary>
        /// 获取当前产品的点位信息
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private List<string> GetPointInfoByProduct(string product)
        {
            //加载当前产品的点位信息
            List<string> pList = new List<string>();
            pList = iniFileOp.ReadValues(product);
            return pList;
        }
        
        /// <summary>
        /// 根据最新获取的点位信息绘制曲线
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="point"></param>
        public void SetChart(Chart chart, PointF point)
        {
            // 添加数据
            chart.Series[0].Points.AddXY(point.X, point.Y);
            
            //曲线整体向左平移一个点位
            if(chart.Series[0].Points.Count > 8)     //8为chart.ChartAreas[0].AxisX.ScaleView.size.
            {
                chart.ChartAreas[0].AxisX.ScaleView.Position = chart.Series[0].Points.Count - 8;//chart.Series[0].Points.Count - 1;
            }
        }
        /// <summary>
        /// 根据最新数据设置更新图表曲线
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="plist"></param>
        public void SetChart(Chart chart, List<PointF> plist)
        {
            chart.Series[0].Points.Clear();
            
            // 添加数据
            for(int i = 0; i < plist.Count; i++)
            {
                chart.Series[0].Points.AddXY(plist[i].X, plist[i].Y);
                
                //曲线整体向左平移一个点位
                if(i > 8)   //8为chart.ChartAreas[0].AxisX.ScaleView.size.
                {
                    chart.ChartAreas[0].AxisX.ScaleView.Position = plist.Count - 8;//chart.Series[0].Points.Count - 1;
                }
            }
        }
    }
}
