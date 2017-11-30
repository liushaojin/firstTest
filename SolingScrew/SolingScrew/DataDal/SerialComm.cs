using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace SolingScrew.DataDal
{
    enum ScomError
    {
        ScomNormal, //正常
        ScomNone,   //没有串口设备
        ScomOpenFailed,//串口打开失败
        ScomCloseFailed,//串口关闭失败
    };
    
    /// <summary>
    /// 数据传输操作的命令类型枚举
    /// </summary>
    enum CmdType
    {
        CmdNone,    //无命令
        CmdRead,    //读命令
        CmdWrite,   //写命令
    }
    
    /// <summary>
    /// 数据类型枚举
    /// </summary>
    enum DataType
    {
        BitData,
        IntData,
        FloatData,
    }
    
    /// <summary>
    /// 操作数据所在存储区的类型枚举
    /// </summary>
    enum DataArea
    {
        AreaNone,
        CIOBit,         //30
        WRBit,          //31
        HRBit,          //32
        ARBit,          //33
        CIOWord,        //B0
        WRWord,         //B1
        HRWord,         //B2
        ARWord,         //B3
        TIMFlag,        //09
        CNTFlag,        //09
        TIMPv,          //89
        CNTPv,          //89
        DMBit,          //02
        DMWord,         //82
        
    }
    
    /// <summary>
    /// HostLink协议命令识别号枚举
    /// </summary>
    enum IDNumBer
    {
    
    };
    
    
    public class DataReceivedEventArgs : EventArgs
    {
        public string DataReceived;
        public byte[] DataRecv;
        public short ShortDataRecv;
        public DataReceivedEventArgs(string m_DataReceived)
        {
            this.DataReceived = m_DataReceived;
        }
        public DataReceivedEventArgs(byte[] m_DataRecv)
        {
            this.DataRecv = m_DataRecv;
        }
        public DataReceivedEventArgs(short shortDataRecv)
        {
            this.ShortDataRecv = shortDataRecv;
        }
    }
    /*
    public delegate void DataReceivedEventHandler(DataReceivedEventArgs e);
    */
    
    class SerialComm
    {
        string startChar = "@"; //hostlink命令的开始符
        string deviceNo = string.Empty; //hostlink命令中的设备号
        string identiNo = string.Empty; //hostlink命令中的识别号
        string recDat = string.Empty;   //hostlink命令中的正文即接收数据
        string fcsCheck = string.Empty; //hostlink命令中的帧检查序列
        string endChar = "*/";  //hostlink命令中的结束符
        
        private SerialPort scom = null;     //声明一个串口实例
        private ScomError scomErr = ScomError.ScomNormal;
        private bool scomIsOpen = false;
        private CmdType curOpCmd = CmdType.CmdNone;
        private DataArea curOpArea = DataArea.AreaNone; //实时记录当前读的区域类型,以便数据解析
        private DataType curOpData = DataType.FloatData;    //记录当前读操作的数据类型
        private int curReadNum = 0; //实时记录当前读数据的个数
        private int curAddr = 0;    //实时记录当前数据操作地址
        private bool recFlag = false;   //接收到数据标志
        
        private static SerialComm scomInstance = null;
        
        //委托及事件的声明
        //public delegate void ScomDataReceivedHandler(string infoMessage);
        public delegate void ScomDataReceivedHandler(DataReceivedEventArgs e);
        public event ScomDataReceivedHandler scomDataReceived;
        public delegate void BitDataReceivedHandler(string[] bitArray);
        public event BitDataReceivedHandler bitDataReceived;
        public delegate void WordDataReceivedHandler(string[] wordArray);
        public event WordDataReceivedHandler wordDataReceived;
        public delegate void WordsReceivedHandler(int addr, int len, string[] wordArray);
        public event WordsReceivedHandler wordsReceived;
        
        private SerialComm()
        {
        }
        public static SerialComm GetScomInstance()
        {
            if(scomInstance == null)
            {
                scomInstance = new SerialComm();//new SerialComm()
            }
            
            return scomInstance;
        }
        /*private Thread receiveThread;
        
        public void ImportDataToSQLServer()
        {
            if (this.receiveThread != null && this.receiveThread.ThreadState == ThreadState.Running)
            {
                return;
            }
        
            this.receiveThread = new Thread(new ThreadStart(ImportDataProc));
            this.receiveThread.Start();
        }
        
        private void ImportDataProc()
        {
            if (scomDataReceived != null)
            {
                scomDataReceived("导入成功!");
            }
        }*/
        
        /// <summary>
        /// 初始化串口
        /// </summary>
        public void ScomInit()
        {
            if(ScanScom())
            {
                scom = new SerialPort();    //存在串口设备则初始化串口实例
                ScomConfig();
                ScomOpen();
            }
            else
            {
                scomErr = ScomError.ScomNone;
            }
        }
        
        /// <summary>
        /// 给数据加上FCS帧校验结果，并组合成最终要发布的数据
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        public static string FCSCheck(string dat)
        {
            string fcsDat = dat + HostLinkFCSCheck(dat) + "*" + (char) 13;
            return fcsDat;
        }
        
        /// <summary>
        /// 对没有FCS校验的数据进行校验
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        private static string HostLinkFCSCheck(string dat)
        {
            char fcs = (char) dat[0];
            int fcsRes = (int) fcs;
            
            for(int i = 1; i < dat.Length; i++)
            {
                fcs = (char) dat[i];
                fcsRes ^= (int) fcs;
            }
            
            return fcsRes.ToString("X2");    //转换成16进制数据
        }
        
        /// <summary>
        /// 对带有FCS校验的数据进行校验
        /// </summary>
        /// <param name="recDat"></param>
        /// <returns></returns>
        public static bool CheckFCS(string recDat)
        {
            int i = recDat.IndexOf('*');
            
            if(i <= 1)
            {
                return false;
            }
            
            string dat = recDat.Substring(0, i - 2);
            
            if(recDat.Substring(i - 2, 2).Equals(HostLinkFCSCheck(dat)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        
        /// <summary>
        /// 扫描是是否存在串口设备
        /// </summary>
        /// <returns></returns>
        private bool ScanScom()
        {
            bool res = false;
            
            if(SerialPort.GetPortNames().Count() > 0)
            {
                res = true;
            }
            
            return res;
        }
        
        /// <summary>
        /// 配置串口属性
        /// </summary>
        private void ScomConfig()
        {
            scom.PortName = "COM1";
            scom.BaudRate = 115200; //9600;
            scom.DataBits = 7;
            scom.Parity = Parity.Even;
            scom.StopBits = StopBits.Two;
            //scom.ReadTimeout = -1;  //超时读取时间的设置
            scom.DataReceived += new SerialDataReceivedEventHandler(ScomDataReceived);
        }
        
        private string recTemp = string.Empty;
        /// <summary>
        /// 串口接收数据处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScomDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string recStr = string.Empty;
            //int itemp = scom.BytesToRead;
            //byte[] ReDatas = new byte[itemp];       //开辟接收缓冲区
            //scom.Read(ReDatas, 0, ReDatas.Length);  //从串口读取数据
            //recStr = System.Text.Encoding.Default.GetString(ReDatas);
            recStr = scom.ReadExisting(); //这里存在一个问题，即本该一帧数据一起读，但实际情况是分两次读的
            //if (recStr.LastIndexOf((char)13) < 0)
            //{
            recTemp += recStr;
            //}
            
            if(recTemp.LastIndexOf((char) 13) >= 0)
            {
                bool re = CheckFCS(recTemp);
                
                try
                {
                    if(!string.IsNullOrEmpty(recTemp))
                    {
                        recFlag = true; //接收到一个完整的帧数据时，置位接收标志
                        scomDataReceived(new DataReceivedEventArgs(recTemp));
                        DecodeReceiveData(recTemp); //解析接收到的数据
                        recTemp = string.Empty;
                    }
                }
                catch(System.Exception ex)
                {
                }
            }
            
            //int rcvByteLen = 0;
            //try
            //{
            //    if(!string.IsNullOrEmpty(recStr))
            //    {
            //        scomDataReceived(new DataReceivedEventArgs(recStr));
            //    }
            //for (int i = 0; i < itemp; i++)
            //{
            //    ReDatas[i] = Convert.ToByte(scom.ReadByte());
            //    rcvByteLen++;
            //}
            //if (ReDatas != null)
            //{
            //    scomDataReceived(new DataReceivedEventArgs(ReDatas));//将在串口数据类中接收到的数据通过事件抛到界面层
            //    //if(ReDatas[ReDatas.Length-1] == 13) //有收到结束符的判断，即一帧完整数据的判断
            //    //{
            //    //    scomDataReceived(new DataReceivedEventArgs(ReDatas));//将在串口数据类中接收到的数据通过事件抛到界面层
            //    //}
            //}
            //}
            //catch (System.Exception ex)
            //{
            //}
            //实现数据的解码与显示
            //DecodeData(ReDatas);
        }
        /// <summary>
        /// 接收数据的解析
        /// </summary>
        /// <param name="idat"></param>
        public void DecodeReceiveData(string idat)
        {
            string dat = idat.Substring(0, idat.Length - 4);    //移除FCS两个校验字符及一个分隔符和一个结束符等后面4个字符串
            
            //判断是否是hostlink协议数据
            if(!string.IsNullOrEmpty(dat))
            {
                try
                {
                    string subStr = dat.Substring(0, 15);    //尝试获取固定的开头字符串“@00FA0040000000”
                    
                    if(subStr == "@00FA0040000000")
                    {
                        subStr = dat.Substring(15, 4);
                        
                        if(subStr == "0101")    //判断是否是读返回
                        {
                            subStr = dat.Substring(19, 4);    //判断是否出错
                            
                            if(subStr == "0000")    //正常时的处理
                            {
                                subStr = dat.Substring(23);    //获取数据字符串
                                
                                switch(curOpArea)   //根据之前发送的读指令中的数据操作区，解析收到的数据
                                {
                                    case DataArea.WRBit:
                                        string[] bitArray = new string[subStr.Length / 2];
                                        
                                        for(int i = 0; i < subStr.Length / 2; i++)
                                        {
                                            bitArray[i] = subStr.Substring(i * 2, 2);
                                        }
                                        
                                        bitDataReceived(bitArray);   //抛出数据接收事件
                                        break;
                                        
                                    case DataArea.DMWord:
                                        //中间化的十六进制数据
                                        string[] wordArray = new string[subStr.Length / 4];
                                        
                                        for(int i = 0; i < subStr.Length / 4; i++)
                                        {
                                            wordArray[i] = subStr.Substring(i * 4, 4);
                                        }
                                        
                                        //可视化的十进制数据
                                        string[] valueArray = new string[wordArray.Length / 2];
                                        
                                        for(int i = 0; i < wordArray.Length / 2; i++)
                                        {
                                            string dataL = wordArray[i * 2];  //获取数据高字部分
                                            string dataH = wordArray[i * 2 + 1];  //获取数据低字部分
                                            
                                            if(curOpData == DataType.IntData)
                                            {
                                                valueArray[i] = Convert.ToInt32(dataH + dataL, 10).ToString(); //int.Parse(dataH + data);
                                            }
                                            else if(curOpData == DataType.FloatData)
                                            {
                                                valueArray[i] = HexToFloat(dataH + dataL).ToString("f2");    //将16进制字符串
                                            }
                                        }
                                        
                                        wordDataReceived(valueArray);   //抛出数据接收事件
                                        //wordsReceived(curAddr, curReadNum, valueArray);   //抛出数据接收事件
                                        break;
                                        
                                    default:
                                        break;
                                }
                                
                                //int datNum = Convert.ToInt16(dat.Substring(27, 4), 16); //获取读取数据的个数
                            }
                            else//出错处理
                            {
                            }
                        }
                        else if(subStr == "0102")    //判断是否是写返回
                        {
                        }
                    }
                }
                catch(Exception ex)
                {
                }
            }
        }
        /// <summary>
        /// 根据协议对接收数据进行解析
        /// </summary>
        /// <param name="data"></param>
        private void DecodeReceiveData(byte[] data, int dataLen)
        {
            //判断是否是hostlink协议数据
            if(data[0] == Convert.ToByte(startChar))
            {
            }
        }
        
        /// <summary>
        /// 根据协议对数据进行解析
        /// </summary>
        /// <param name="data"></param>
        private void DecodeData(byte[] data)
        {
            int codeType = 0;
            
            if(codeType == 0)
            {
                AddContent(new ASCIIEncoding().GetString(data));
            }
            else if(codeType == 1)
            {
                AddContent(new UTF8Encoding().GetString(data));
            }
            else if(codeType == 2)
            {
                AddContent(new UnicodeEncoding().GetString(data));
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                
                for(int i = 0; i < data.Length; i++)
                {
                    sb.AppendFormat("{0:x2}" + " ", data[i]);
                }
                
                AddContent(sb.ToString().ToUpper());
            }
        }
        
        private void AddContent(string content)
        {
            //这里serialReadString即为读取到串口输入缓冲区的数据。 要想将其显示到RichTextBox rTB_receive中，这里出现了一个跨线程的问题，因为DataReceived事件是在辅助线程中被激发的，所以要将数据显示到rTB_receive的主线程中就要进行一定的处理，处理方法如下： C#中SerialPort类中DataReceived事件GUI实时处理方法
            //             BeginInvoke(new MethodInvoker(delegate
            //             {
            //                 textBox_Receive.AppendText(content);
            //             }));
            //this.rTB_receive.Invoke(newMethodInvoker(delegate { this.rTB_receive.AppendText(serialReadString); }));
            //串口数据的读取还涉及到其他的读取函数， Read已重载。从SerialPort输入缓冲区中读取。 ReadByte从SerialPort输入缓冲区中同步读取一个字节。 ReadChar从SerialPort输入缓冲区中同步读取一个字符。 ReadExistin g 在编码的基础上，读取SerialPort对象的流和输入缓冲区中所有立即可用的字节。 ReadLine一直读取到输入缓冲区中的NewLine值。 ReadTo 一直读取到输入缓冲区中的指定value的字符串。 根据需要自己选择就行了，很简单，就不再啰嗦了。
        }
        
        /// <summary>
        /// 同步收发数据的处理
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private string[] ReadBaseData(int addr, int len, CmdType cmdType, DataArea datArea)
        {
            string revDat = string.Empty;
            curAddr = addr;
            curReadNum = len;
            curOpArea = datArea;
            string cmdstr = FormatCmd(cmdType, datArea);
            cmdstr = string.Format("{0}{1}00{2}", cmdstr, addr.ToString("X4"), len.ToString("X4"));
            ScomSendData(cmdstr);
            //int itemp = scom.BytesToRead;
            //byte[] ReDatas = new byte[itemp];       //开辟接收缓冲区
            //scom.Read(ReDatas, 0, ReDatas.Length);  //从串口读取数据
            //revDat = System.Text.Encoding.Default.GetString(ReDatas);
            revDat = scom.ReadExisting(); //这里存在一个问题，即本该一帧数据一起读，但实际情况是分两次读的，再说一发送完读命令就接收能保证接收到数据吗
            
            if(CheckFCS(revDat))
            {
                string dat = revDat.Substring(0, revDat.Length - 4);    //移除FCS两个校验字符及一个分隔符和一个结束符等后面4个字符串
                
                //判断是否是hostlink协议数据
                if(!string.IsNullOrEmpty(dat))
                {
                    try
                    {
                        string subStr = dat.Substring(0, 15);    //尝试获取固定的开头字符串“@00FA0040000000”
                        
                        if(subStr == "@00FA0040000000")
                        {
                            subStr = dat.Substring(15, 4);
                            
                            if(subStr == "0101")     //判断是否是读返回
                            {
                                subStr = dat.Substring(19, 4);    //判断是否出错
                                
                                if(subStr == "0000")     //正常时的处理
                                {
                                    subStr = dat.Substring(23);    //获取数据字符串
                                    
                                    switch(datArea)    //根据之前发送的读指令中的数据操作区，解析收到的数据
                                    {
                                        case DataArea.WRBit:
                                            string[] bitArray = new string[subStr.Length / 2];
                                            
                                            for(int i = 0; i < subStr.Length / 2; i++)
                                            {
                                                bitArray[i] = Convert.ToInt32(subStr.Substring(i * 2, 2), 10).ToString();
                                            }
                                            
                                            return bitArray;
                                            
                                        //break;
                                        
                                        case DataArea.DMWord:
                                            //中间化的十六进制数据
                                            string[] wordArray = new string[subStr.Length / 4];
                                            
                                            for(int i = 0; i < subStr.Length / 4; i++)
                                            {
                                                wordArray[i] = subStr.Substring(i * 4, 4);
                                            }
                                            
                                            //可视化的十进制数据
                                            string[] valueArray = new string[wordArray.Length / 2];
                                            
                                            for(int i = 0; i < wordArray.Length / 2; i++)
                                            {
                                                string dataL = wordArray[i * 2];  //获取数据高字部分
                                                string dataH = wordArray[i * 2 + 1];  //获取数据低字部分
                                                
                                                if(curOpData == DataType.IntData)
                                                {
                                                    valueArray[i] = Convert.ToInt32(dataH + dataL, 10).ToString(); //int.Parse(dataH + data);
                                                }
                                                else if(curOpData == DataType.FloatData)
                                                {
                                                    valueArray[i] = HexToFloat(dataH + dataL).ToString("f2");    //将16进制字符串
                                                }
                                            }
                                            
                                            return valueArray;
                                            
                                        //break;
                                        
                                        default:
                                            break;
                                    }
                                }
                                else//出错处理
                                {
                                }
                            }
                            else if(subStr == "0102")     //判断是否是写返回
                            {
                                subStr = dat.Substring(19, 4);    //判断是否出错
                                string[] res = new string[1];     //写入成功返回“@00FA004000000001020000 FA*/”
                                
                                if(subStr == "0000")       //正常时的处理
                                {
                                    res[0] = "1";   //写入成功
                                }
                                else
                                {
                                    res[0] = "0";   //写入失败
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                    }
                }
            }
            
            return null;
        }
        
        
        
        /// <summary>
        /// 数据发送
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        public bool ScomSendData(string dat)
        {
            bool res = false;
            string data = FCSCheck(dat);
            
            if(scomIsOpen == true)
            {
                try
                {
                    recFlag = false;
                    scom.Write(data);
                }
                catch(Exception ex)
                {
                }
            }
            
            return res;
        }
        
        /// <summary>
        /// 数据发送
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        public bool ScomSendData(byte[] dat)
        {
            bool res = false;
            
            try
            {
                scom.Write(dat, 0, dat.Length);
            }
            catch(System.Exception ex)
            {
            }
            
            return res;
        }
        
        /// <summary>
        /// 将字符串转换成16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] strToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", ""); //删除字符串中的空格
            
            if((hexString.Length % 2) != 0)
            {
                hexString += " ";   //补全字符串的长度为2的整数倍
            }
            
            byte[] returnBytes = new byte[hexString.Length / 2];
            
            for(int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            }
            
            return returnBytes;
        }
        
        /// <summary>
        /// 转换十六进制字符串到字节数组
        /// </summary>
        /// <param name="msg">待转换字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");    //移除空格
            //创建一个长度为字符串长度的二分之一的字节数组，一个字节用16进制表示就占用2个字符
            byte[] comBuffer = new byte[msg.Length / 2];
            
            for(int i = 0; i < msg.Length; i += 2)
            {
                //将每2个字符转换成一个字节并添加到数组中去
                comBuffer[i / 2] = (byte) Convert.ToByte(msg.Substring(i, 2), 16);
            }
            
            return comBuffer;
        }
        
        /// <summary>
        /// 转换字节数组到十六进制字符串
        /// </summary>
        /// <param name="comByte">待转换字节数组</param>
        /// <returns>十六进制字符串</returns>
        public static string ByteToHex(byte[] comByte)
        {
            string returnStr = "";
            
            if(comByte != null)
            {
                for(int i = 0; i < comByte.Length; i++)
                {
                    returnStr += comByte[i].ToString("X2") + " ";
                }
            }
            
            return returnStr;
        }
        
        /// <summary>
        /// 通信命令发送前的协议格式化
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string FormatCmd(CmdType cmdType, DataArea areaType)
        {
            string cmdStr = "@00FA000000000";  //读写指令字符串的前缀
            
            //先拼接读写命令
            if(cmdType == CmdType.CmdRead)
            {
                cmdStr += "0101";
            }
            else if(cmdType == CmdType.CmdWrite)
            {
                cmdStr += "0102";
            }
            
            //再拼接操作区代码
            if(areaType == DataArea.DMWord)
            {
                cmdStr += "82";
            }
            else if(areaType == DataArea.WRBit)
            {
                cmdStr += "31";
            }
            
            return cmdStr;
        }
        
        public void ReadWRData(int addr, int start, int len)
        {
            if(len > 538)
            {
                len = 538;  //使用fins指令最大可以读取538个字节，PLC中一个字节占16位
            }
            
            curAddr = addr;
            curReadNum = len;
            curOpArea = DataArea.WRBit;
            string cmdstr = FormatCmd(CmdType.CmdRead, DataArea.WRBit);
            cmdstr = string.Format("{0}{1}{2}{3}", cmdstr, addr.ToString("X4"), start.ToString("X2"), len.ToString("X4"));
            ScomSendData(cmdstr);
        }
        /// <summary>
        /// 从PLC读WR区寄存器位数据
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        public void ReadWRData(int addr, int len)
        {
            if(len > 538)
            {
                len = 538;  //使用fins指令最大可以读取538个字节，PLC中一个字节占16位
            }
            
            curAddr = addr;
            curReadNum = len;
            curOpArea = DataArea.WRBit;
            string cmdstr = FormatCmd(CmdType.CmdRead, DataArea.WRBit);
            cmdstr = string.Format("{0}{1}00{2}", cmdstr, addr.ToString("X4"), len.ToString("X4"));
            ScomSendData(cmdstr);
        }
        
        /// <summary>
        /// 从PLC读一个DM区字数据
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        public void ReadDMData(int addr)
        {
            curAddr = addr;
            curReadNum = 1;
            curOpArea = DataArea.DMWord;
            string cmdstr = FormatCmd(CmdType.CmdRead, DataArea.DMWord);
            cmdstr = string.Format("{0}{1}000001", cmdstr, addr.ToString("X4"));
            ScomSendData(cmdstr);
        }
        
        /// <summary>
        /// 从PLC读DM区字数据
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        public void ReadDMDatas(int addr, int len)
        {
            curAddr = addr;
            curReadNum = len * 2;
            curOpArea = DataArea.DMWord;
            string cmdstr = FormatCmd(CmdType.CmdRead, DataArea.DMWord);
            cmdstr = string.Format("{0}{1}00{2}", cmdstr, addr.ToString("X4"), curReadNum.ToString("X4"));
            ScomSendData(cmdstr);
        }
        
        /// <summary>
        /// 读一个点的位置数据
        /// </summary>
        /// <param name="addr"></param>
        public void ReadPoint(int addr)
        {
            for(int i = 0; i < 5; i++)
            {
                ReadDMData(addr + (i * 100));
            }
        }
        
        /// <summary>
        /// 写入一个的位置数据
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="point"></param>
        public void WritePoint(int addr, float[] point)
        {
            for(int i = 0; i < 5; i++)
            {
                WriteDMData(addr + (i * 100), point[i]);
            }
        }
        
        /// <summary>
        /// 向PLC的WR寄存器中写入一个字节的数据
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        /// <param name="data"></param>
        public void WriteWRData(int addr, int data)
        {
            string cmdstr = FormatCmd(CmdType.CmdWrite, DataArea.WRBit);
            cmdstr = string.Format("{0}{1}000001{2}", cmdstr, addr.ToString("X4"), data.ToString("X4"));
            ScomSendData(cmdstr);
        }
        
        /// <summary>
        /// 向DM区域写入一个字节的数据
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="data"></param>
        public void WriteDMData(int addr, int data)
        {
            string cmdstr = FormatCmd(CmdType.CmdWrite, DataArea.DMWord);
            cmdstr = string.Format("{0}{1}000001{2}", cmdstr, addr.ToString("X4"), data.ToString("X4"));
            ScomSendData(cmdstr);
        }
        
        /// <summary>
        /// 向DM区域写入一个浮点数据占两个字节
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="data"></param>
        public void WriteDMData(int addr, float data)
        {
            string cmdstr = FormatCmd(CmdType.CmdWrite, DataArea.DMWord);
            cmdstr = string.Format("{0}{1}000002{2}", cmdstr, addr.ToString("X4"), FloatToHex(data));
            ScomSendData(cmdstr);
        }
        
        /// <summary>
        /// 向DM区域写入一串字（节）数据
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="data"></param>
        public void WriteDMData(int addr, int len, int[] datas)
        {
            string datStr = string.Empty;
            
            for(int i = 0; i < datas.Length; i++)
            {
                datStr = string.Format("{0}{1}", datStr, datas[i].ToString("X4"));
            }
            
            string cmdstr = FormatCmd(CmdType.CmdWrite, DataArea.DMWord);
            cmdstr = string.Format("{0}{1}00{2}{3}", cmdstr, addr.ToString("X4"), len.ToString("X4"), datStr);
            ScomSendData(cmdstr);
        }
        
        /// <summary>
        /// 向DM区域写入一串浮点数据
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="data"></param>
        public void WriteDMDatas(int addr, int len, float[] datas)
        {
            string datStr = string.Empty;
            
            for(int i = 0; i < datas.Length; i++)
            {
                datStr = string.Format("{0}{1}", datStr, FloatToHex(datas[i]));       //FloatToHex(data)
            }
            
            string cmdstr = FormatCmd(CmdType.CmdWrite, DataArea.DMWord);
            cmdstr = string.Format("{0}{1}00{2}{3}", cmdstr, addr.ToString("X4"), len.ToString("X4"), datStr);
            ScomSendData(cmdstr);
        }
        
        /// <summary>
        /// 浮点数转十六进制
        /// </summary>
        /// <param name="fv"></param>
        /// <returns></returns>
        private string FloatToHex(float fv)
        {
            byte[] buf = BitConverter.GetBytes(fv);
            int len = buf.Length;
            //转换顺序
            byte[] tbuf = new byte[len];
            tbuf[0] = buf[2];
            tbuf[1] = buf[3];
            tbuf[2] = buf[0];
            tbuf[3] = buf[1];
            string hexStr = BitConverter.ToString(tbuf.Reverse().ToArray()).Replace("-", "");
            return hexStr;
        }
        
        /// <summary>
        /// 将十六进制字符串转换成4字节的十六进制数据再转换成对应的浮点数
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        private float HexToFloat(string hexStr)
        {
            hexStr = hexStr.Replace(" ", "");
            
            if((hexStr.Length % 2) != 0)
            {
                hexStr += "";
            }
            
            byte[] buf = new byte[hexStr.Length / 2];
            
            for(int i = 0; i < buf.Length; i++)
            {
                buf[i] = Convert.ToByte(hexStr.Substring(i * 2, 2), 16);
            }
            
            float f = BitConverter.ToSingle(buf, 0);
            return f;
        }
        
        /// <summary>
        /// 打开串口
        /// </summary>
        public void ScomOpen()
        {
            try
            {
                scom.Open();
                scomIsOpen = true;
            }
            catch(Exception)
            {
                scomErr = ScomError.ScomOpenFailed;
            }
        }
        
        /// <summary>
        /// 关闭串口设备
        /// </summary>
        public void ScomClose()
        {
            try
            {
                scom.Close();
                scomIsOpen = false;
            }
            catch(Exception)
            {
                scomErr = ScomError.ScomCloseFailed;
            }
        }
        
        /// <summary>
        /// 获取串口打开状态
        /// </summary>
        /// <returns></returns>
        public bool GetScomState()
        {
            return scomIsOpen;
        }
        
        /// <summary>
        /// 获取串口工作状态
        /// </summary>
        /// <returns></returns>
        public ScomError GetScomStatus()
        {
            return scomErr;
        }
    }
}
