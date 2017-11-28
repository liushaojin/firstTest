using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace SolingScrew.DataDal
{
    /// <summary>
    /// modbus tcp功能码枚举
    /// </summary>
    enum ModbusFuncCode
    {
        FCode01,
        FCode02,
        FCode03,
        FCode04,
        FCode05,
        FCode06,
        FCode0A,
        FCode10,
    }
    
    public struct RegisterUnit
    {
        public short regAddr;    //寄存器地址
        public short regNum;     //对应功能寄存器数量
        public short regDat;     //寄存器数据
        //byte code;      //功能码
        //public string regDisp;  //寄存器地址描述
    };
    
    public struct CurCmd
    {
        public short addr;     //当前操作寄存器地址
        public byte code;      //当前操作的功能码
        public short num;      //当前操作的寄存器数量
        public bool backStatus;    //当前返回码的状态；false：返回错误；true：返回正确
    };
    
    
    class ModbusTcpComm
    {
        #region 成员变量区
        private Socket newClient = null;   //套接字变量声明
        private bool connected = false;     //连接标志
        private Thread tcpThread = null;
        private string errorStr = string.Empty;    //连接状态信息
        private bool writeStatusFlag = false; //写入状态标志
        
        private string ip = string.Empty;   //连接IP
        private static ModbusTcpComm tcpInstance = null;    //单例模式下实例的声明
        private int readId = 0;     //modbus读指令事务ID
        private bool sendRecFlag = false;   //收发同步控制，发送后要等待接收完成才能再次发送
        private CurCmd curCmd = new CurCmd()
        {
            addr = -1, code = 0, num = 0, backStatus = false
        };
        
        public delegate void ModTcpDataReceivedHandler(string recDat);
        public event ModTcpDataReceivedHandler modTcpDataReceived;
        
        public delegate void ShortDataReceiveHandle(short addr, List<short> datList);
        public event ShortDataReceiveHandle shortDataReceived;
        
        public delegate void WaveDataReceiveHandle(short[] dat);
        public event WaveDataReceiveHandle waveDataReceived;
        
        public string ErrorStr
        {
            get
            {
                return errorStr;
            }
            set
            {
                errorStr = value;
            }
        }
        
        public bool Connected
        {
            get
            {
                return connected;
            }
            set
            {
                connected = value;
            }
        }
        
        public bool WriteStatusFlag
        {
            get
            {
                return writeStatusFlag;
            }
            set
            {
                writeStatusFlag = value;
            }
        }
        
        public const short addr04 = 0x0000;
        public const short addr03 = 0x0000;
        /// <summary>
        /// 变量所对应的地址 在此位置
        /// </summary>
        public static RegisterUnit[] dataTable04 =
        {
            new RegisterUnit(){regAddr = addr04, regNum = 1, regDat = new short()}, //TMC Version
            new RegisterUnit(){regAddr = addr04 + 1, regNum = 1, regDat = new short()},//SDC Version
            new RegisterUnit(){regAddr = addr04 + 2, regNum = 1, regDat = new short()},//总锁付螺丝根数（上位）
            new RegisterUnit(){regAddr = addr04 + 3, regNum = 1, regDat = new short()},//总锁付螺丝根数（下位）
            new RegisterUnit(){regAddr = addr04 + 4, regNum = 1, regDat = new short()},//工具型号
            
            new RegisterUnit(){regAddr = addr04 + 5, regNum = 1, regDat = new short()},//ID序列号
            new RegisterUnit(){regAddr = addr04 + 0x10, regNum = 1, regDat = new short()},//数位输入
            new RegisterUnit(){regAddr = addr04 + 0x11, regNum = 1, regDat = new short()},//系统警报
            new RegisterUnit(){regAddr = addr04 + 0x15, regNum = 1, regDat = new short()},//实际马达速度
            new RegisterUnit(){regAddr = addr04 + 0x16, regNum = 1, regDat = new short()},//实际圈数
            
            new RegisterUnit(){regAddr = addr04 + 0x17, regNum = 1, regDat = new short()},//实际扭力值
            new RegisterUnit(){regAddr = addr04 + 0x30, regNum = 1, regDat = new short()},//可否取得锁付螺丝数据
            new RegisterUnit(){regAddr = addr04 + 0x31, regNum = 1, regDat = new short()},//Program No.程序号
            new RegisterUnit(){regAddr = addr04 + 0x32, regNum = 1, regDat = new short()},//锁付螺丝回转数
            new RegisterUnit(){regAddr = addr04 + 0x33, regNum = 1, regDat = new short()},//锁付螺丝扭力值
            
            new RegisterUnit(){regAddr = addr04 + 0x34, regNum = 1, regDat = new short()},//锁付时间
            new RegisterUnit(){regAddr = addr04 + 0x35, regNum = 1, regDat = new short()},//锁付螺丝结果
            new RegisterUnit(){regAddr = addr04 + 0x36, regNum = 1, regDat = new short()},//详细错误
            new RegisterUnit(){regAddr = addr04 + 0x3F, regNum = 1, regDat = new short()},//锁付螺丝扭力波形数据数
            new RegisterUnit(){regAddr = addr04 + 0x40, regNum = 4096, regDat = new short()},//锁付螺丝扭力波形数据
            
        };
        public static RegisterUnit[] dataTable03 =
        {
            //new RegisterUnit(){regAddr = addr04, regNum = 2, regDat = new short()}, //网络IP地址
            //new RegisterUnit(){regAddr = addr04 + 2, regNum = 2, regDat = new short()},//子网掩码(遮罩)
            //new RegisterUnit(){regAddr = addr04 + 4, regNum = 2, regDat = new short()},//网关
            //new RegisterUnit(){regAddr = addr04 + 6, regNum = 3, regDat = new short()},//mac地址
            //new RegisterUnit(){regAddr = addr04 + 9, regNum = 16, regDat = new short()},//CT-Cont 序列号
            
            new RegisterUnit(){regAddr = addr04 + 0x1A, regNum = 1, regDat = new short()},//数据取样角度
            new RegisterUnit(){regAddr = addr04 + 0x1B, regNum = 1, regDat = new short()},//扭力辅正值
            new RegisterUnit(){regAddr = addr04 + 0x40, regNum = 1, regDat = new short()},//检查窗1判定图表
            new RegisterUnit(){regAddr = addr04 + 0x41, regNum = 1, regDat = new short()},//检查窗1开始回转
            new RegisterUnit(){regAddr = addr04 + 0x42, regNum = 1, regDat = new short()},//检查窗1结束回转
            
            new RegisterUnit(){regAddr = addr04 + 0x43, regNum = 1, regDat = new short()},//检查窗1开始扭力
            new RegisterUnit(){regAddr = addr04 + 0x44, regNum = 1, regDat = new short()},//检查窗1结束扭力
            new RegisterUnit(){regAddr = addr04 + 0x45, regNum = 1, regDat = new short()},//检查窗1扭力宽度
            //new RegisterUnit(){regAddr = addr04 + 0x48, regNum = 56, regDat = new short()},//检查窗2-窗8
            new RegisterUnit(){regAddr = addr04 + 0x80, regNum = 1, regDat = new short()},//锁付螺丝基本参数，回转方向
            
            new RegisterUnit(){regAddr = addr04 + 0x81, regNum = 1, regDat = new short()},//锁付螺丝基本参数，目标扭力
            new RegisterUnit(){regAddr = addr04 + 0x82, regNum = 1, regDat = new short()},//锁付螺丝特殊参数有效Flag
            new RegisterUnit(){regAddr = addr04 + 0x83, regNum = 1, regDat = new short()},//锁付螺丝特殊参数,锁付模式
            new RegisterUnit(){regAddr = addr04 + 0x84, regNum = 1, regDat = new short()},//锁付螺丝特殊参数,锁付开始检出量
            new RegisterUnit(){regAddr = addr04 + 0x85, regNum = 1, regDat = new short()},//锁付螺丝特殊参数,初期自攻扭力
            
            new RegisterUnit(){regAddr = addr04 + 0x86, regNum = 1, regDat = new short()},//锁付螺丝特殊参数,到达扭力检出时间
            new RegisterUnit(){regAddr = addr04 + 0x87, regNum = 1, regDat = new short()},//锁付螺丝特殊参数,-侧容许回转数
            new RegisterUnit(){regAddr = addr04 + 0x88, regNum = 1, regDat = new short()},//锁付螺丝特殊参数,+侧容许回转数
            new RegisterUnit(){regAddr = addr04 + 0x89, regNum = 1, regDat = new short()},//锁付螺丝特殊参数,逆旋转角度
            new RegisterUnit(){regAddr = addr04 + 0x8E, regNum = 1, regDat = new short()},//锁付螺丝Step-0旋转数
            
            new RegisterUnit(){regAddr = addr04 + 0x8F, regNum = 1, regDat = new short()},//锁付螺丝Step-0速度
            new RegisterUnit(){regAddr = addr04 + 0x90, regNum = 1, regDat = new short()},//锁付螺丝Step-1旋转数
            new RegisterUnit(){regAddr = addr04 + 0x91, regNum = 1, regDat = new short()},//锁付螺丝Step-1速度
            new RegisterUnit(){regAddr = addr04 + 0x92, regNum = 1, regDat = new short()},//锁付螺丝Step-2旋转数
            new RegisterUnit(){regAddr = addr04 + 0x93, regNum = 1, regDat = new short()},//锁付螺丝Step-2速度
            
            new RegisterUnit(){regAddr = addr04 + 0x94, regNum = 1, regDat = new short()},//锁付螺丝Step-3旋转数
            new RegisterUnit(){regAddr = addr04 + 0x95, regNum = 1, regDat = new short()},//锁付螺丝Step-3速度
            new RegisterUnit(){regAddr = addr04 + 0x96, regNum = 1, regDat = new short()},//锁付螺丝Step-4旋转数
            new RegisterUnit(){regAddr = addr04 + 0x97, regNum = 1, regDat = new short()},//锁付螺丝Step-4速度
            new RegisterUnit(){regAddr = addr04 + 0xA0, regNum = 1, regDat = new short()},//转开螺丝基本参数,旋转方向
            
            new RegisterUnit(){regAddr = addr04 + 0xA1, regNum = 1, regDat = new short()},//转开螺丝基本参数,目标扭力
            new RegisterUnit(){regAddr = addr04 + 0xA2, regNum = 1, regDat = new short()},//转开螺丝Step-0旋转数
            new RegisterUnit(){regAddr = addr04 + 0xA3, regNum = 1, regDat = new short()},//转开螺丝Step-0速度
            new RegisterUnit(){regAddr = addr04 + 0xA4, regNum = 1, regDat = new short()},//转开螺丝Step-1旋转数
            new RegisterUnit(){regAddr = addr04 + 0xA5, regNum = 1, regDat = new short()},//转开螺丝Step-2速度
            
            new RegisterUnit(){regAddr = addr04 + 0xB0, regNum = 1, regDat = new short()},//螺丝机旋转基本参数,旋转方向
            new RegisterUnit(){regAddr = addr04 + 0xB1, regNum = 1, regDat = new short()},//螺丝机旋转基本参数,目标扭力
            new RegisterUnit(){regAddr = addr04 + 0xB2, regNum = 1, regDat = new short()},//螺丝机旋转Step-0旋转数
            new RegisterUnit(){regAddr = addr04 + 0xB3, regNum = 1, regDat = new short()},//螺丝机旋转Step-0速度
            
            new RegisterUnit(){regAddr = addr04 + 0xC0, regNum = 1, regDat = new short()},//PRG数据号选择
            new RegisterUnit(){regAddr = addr04 + 0xC1, regNum = 1, regDat = new short()},//执行要求
            new RegisterUnit(){regAddr = addr04 + 0xC2, regNum = 1, regDat = new short()},//数字位输出
            new RegisterUnit(){regAddr = addr04 + 0xC3, regNum = 1, regDat = new short()},//数字位输入
            new RegisterUnit(){regAddr = addr04 + 0xC4, regNum = 1, regDat = new short()},//数字位输入输出许可
        };
        #endregion 成员变量区
        
        #region 成员函数区
        private ModbusTcpComm()
        {
            //单例的构造函数
        }
        
        public static ModbusTcpComm GetTcpInstance()
        {
            if(tcpInstance == null)
            {
                tcpInstance = new ModbusTcpComm();
            }
            
            return tcpInstance;
        }
        
        public void ModbusTcpInit()
        {
            ConnectModbusTcp();
        }
        
        /// <summary>
        /// 连接电批设备
        /// </summary>
        private void ConnectModbusTcp()
        {
            //byte[] data = new byte[1024];
            string commIp = "192.168.0.1";  //电批1的IP通信地址
            string comm2Ip = "192.168.0.2"; //电批2的IP通信地址
            int commPort = 502;
            //创建一个套接字
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(commIp), commPort);
            IPEndPoint ip2EndPoint = new IPEndPoint(IPAddress.Parse(comm2Ip), commPort);
            newClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            //将套接字同远程服务器连接
            try
            {
                newClient.Connect(ipEndPoint);  //连接
                Connected = true;   //连接标志置位
            }
            catch(SocketException ex)
            {
                ErrorStr = ex.Message;
                return;
            }
            
            ThreadStart threadStartDelegate = new ThreadStart(ModbusTcpReceived);
            tcpThread = new Thread(threadStartDelegate);
            tcpThread.Start();
            //定时发送功能设置
        }
        
        private void ModbusTcpReceived()
        {
            while(true)
            {
                short dataNum = 1024;
                byte[] data = new byte[dataNum];   //定义接收数据数组
                newClient.Receive(data);
                //newClient.Receive(byte, size, SocketFlags.None)
                short len = data[5];  //读取数据长度
                byte[] aFrameData = new byte[len + 6]; //定义实际接收的数据
                
                for(int i = 0; i <= len + 5; i++)
                {
                    aFrameData[i] = data[i];
                }
                
                string recData = BitConverter.ToString(aFrameData); //把数组转成16进制字符串
                byte funcCode = data[7];    //获取功能码
                short recDatNum = 0;  //接收到的数据的个数
                
                switch(funcCode)    //根据功能码解析数据
                {
                    case 0x01:
                    case 0x02:
                    case 0x03:
                    case 0x04:
                        recDatNum = data[8];     //接收数据的长度
                        List<short> recDataList = new List<short>();
                        
                        //写入读到的数据
                        for(int i = 0; i < curCmd.num; i++)
                        {
                            short dat = Convert.ToInt16(data[9 + 2 * i] << 8 | data[10 + 2 * i]);
                            recDataList.Add(dat);
                        }
                        
                        if(recDataList.Count > 0)
                        {
                            shortDataReceived(curCmd.addr, recDataList);    //收到数据后抛出
                        }
                        
                        //for(int i = 0; i < dataTable03.Length; i++)
                        //{
                        //    //匹配首地址
                        //    if(dataTable03[i].regAddr == curCmd.addr && recDatNum == curCmd.num && curCmd.addr < (addr04 + 0x3F))
                        //    {
                        //        //写入读到的数据
                        //        for(int j = 0; j < curCmd.num; j++)
                        //        {
                        //            dataTable03[i + j].regDat = Convert.ToInt16(data[9 + 2 * i] << 8 | data[10 + 2 * i]);
                        //            shortDataReceived(dataTable03[i + j].regDat);
                        //        }
                        //    }
                        //    if(curCmd.addr == (addr04 + 0x3F))
                        //    {
                        //    }
                        //}
                        break;
                        
                    case 0x05:
                        break;
                        
                    case 0x06:
                        break;
                        
                    case 0x0f:
                        break;
                        
                    case 0x10:
                        if(curCmd.addr == Convert.ToInt16(data[8] << 8 | data[9]) && curCmd.num == Convert.ToInt16(data[10] << 8 | data[11]))
                        {
                            WriteStatusFlag = true; //写入成功
                        }
                        
                        break;
                        
                    default:
                        //modTcpDataReceived(recData);
                        break;
                }
                
                sendRecFlag = false;
                curCmd.addr = -1;
                curCmd.num = 0;
                curCmd.code = 0;    //接收完后
            }
        }
        
        /// <summary>
        /// 根据提供的信息组合成待发送的命令
        /// </summary>
        /// <param name="softId"></param>
        /// <param name="devId"></param>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private byte[] GetCmdToSend(short softId, short devId, short addr, short len)
        {
            List<byte> cmd = new List<byte>(255);
            cmd.AddRange(DataEndian.Instance.GetBytes(softId));
            cmd.AddRange(new byte[] { 0x00, 0x00 });
            cmd.AddRange(DataEndian.Instance.GetBytes(Convert.ToInt16(6)));
            cmd.Add(Convert.ToByte(devId));
            cmd.Add(Convert.ToByte(3));
            cmd.AddRange(DataEndian.Instance.GetBytes(addr));
            cmd.AddRange(DataEndian.Instance.GetBytes(len));
            return cmd.ToArray();
        }
        
        /// <summary>
        /// 发送写命令的获取
        /// </summary>
        /// <param name="softId"></param>
        /// <param name="devId"></param>
        /// <param name="code"></param>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        /// <param name="dat"></param>
        /// <returns></returns>
        private byte[] GetCmdToSend(short softId, short devId, short code, short addr, short len, byte[] dat)
        {
            short datLen = 6;
            List<byte> cmd = new List<byte>(255);
            cmd.AddRange(DataEndian.Instance.GetBytes(softId));
            cmd.AddRange(new byte[] { 0x00, 0x00 });
            
            if(code == 16)
            {
                datLen = (short)(7 + 2 * len);  //获取传输命令中第5元素后面的字节数
            }
            
            cmd.AddRange(DataEndian.Instance.GetBytes(datLen));
            cmd.Add(Convert.ToByte(devId));
            cmd.Add(Convert.ToByte(3));
            cmd.AddRange(DataEndian.Instance.GetBytes(addr));
            cmd.AddRange(DataEndian.Instance.GetBytes(len));
            
            if(code == 16)
            {
                cmd.Add(Convert.ToByte(2 * len));
                cmd.AddRange(dat);
            }
            
            return cmd.ToArray();
        }
        
        
        byte[] writeCmd = new byte[13] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] readCmd = new byte[12] {0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };  //定义并初始化一个读命令，由12个字节构成的
        /// <summary>
        /// 读保持寄存器
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        public void ReadDataByFc03(short addr, short len)
        {
            readCmd[7] = 0x03;
            readCmd[8] = (byte)((addr >> 8) & 0xff);
            readCmd[9] = (byte)(addr & 0xff);
            readCmd[10] = (byte)((len >> 8) & 0xff);
            readCmd[11] = (byte)(len & 0xff);
            SendData(readCmd);
            curCmd.addr = addr;
            curCmd.code = readCmd[7];
            curCmd.num = len;
        }
        
        /// <summary>
        /// 读输入寄存器
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        public void ReadDataByFc04(short addr, short len)
        {
            readCmd[7] = 0x04;
            readCmd[8] = (byte)((addr >> 8) & 0xff);
            readCmd[9] = (byte)(addr & 0xff);
            readCmd[10] = (byte)((len >> 8) & 0xff);
            readCmd[11] = (byte)(len & 0xff);
            SendData(readCmd);
            curCmd.addr = addr;
            curCmd.code = readCmd[7];
            curCmd.num = len;
        }
        
        /// <summary>
        /// 写单个寄存器
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        /// <param name="dat"></param>
        public void WriteDataByFc06(short addr, short dat)
        {
            readCmd[7] = 0x06;
            readCmd[8] = (byte)((addr >> 8) & 0xff);
            readCmd[9] = (byte)(addr & 0xff);
            readCmd[10] = (byte)((dat >> 8) & 0xff);
            readCmd[11] = (byte)(dat & 0xff);
            SendData(readCmd);
            curCmd.addr = addr;
            curCmd.code = readCmd[7];
            curCmd.num = 1;
            WriteStatusFlag = false;
        }
        
        /// <summary>
        /// 写多个寄存器
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="len"></param>
        /// <param name="dat"></param>
        public void WriteDataByFc10(short addr, short len, byte[] dat)
        {
            byte[] temp = new byte[writeCmd.Length + dat.Length];    //拼接最终要发送命令的形式
            short len1 = Convert.ToInt16(dat.Length + 7);   //从数组下标0开始先计算出待发送指令第4、5两元素表示的字节数据个数
            System.Buffer.BlockCopy(writeCmd, 0, temp, 0, writeCmd.Length);
            System.Buffer.BlockCopy(dat, 0, temp, writeCmd.Length, dat.Length);
            temp[4] = (byte)((len1 >> 8) & 0xff);
            temp[5] = (byte)(len1 & 0xff);
            temp[7] = 0x10;
            temp[8] = (byte)((addr >> 8) & 0xff);
            temp[9] = (byte)(addr & 0xff);
            temp[10] = (byte)((len >> 8) & 0xff);
            temp[11] = (byte)(len & 0xff);
            temp[12] = (byte)(2 * len);
            SendData(temp);
            curCmd.addr = addr;
            curCmd.code = readCmd[7];
            curCmd.num = len;
            WriteStatusFlag = false;
        }
        
        /// <summary>
        /// 发送字节数据
        /// </summary>
        /// <param name="bytes"></param>
        public bool SendTcpData(byte[] bytes)
        {
            bool res = false;
            
            try
            {
                if(newClient.Send(bytes) > 0)
                {
                    res = true;
                }
            }
            catch(SocketException ex)
            {
                ErrorStr = ex.Message;
            }
            
            return res;
        }
        
        /// <summary>
        /// 发送字节数据
        /// </summary>
        /// <param name="bytes"></param>
        public void SendData(byte [] bytes)
        {
            try
            {
                newClient.Send(bytes);
                sendRecFlag = true;
            }
            catch(SocketException ex)
            {
                ErrorStr = ex.Message;
            }
        }
        
        
        /// <summary>
        /// 发送字符串数据
        /// </summary>
        /// <param name="str"></param>
        public void SendStringData(string str)
        {
            byte[] dat = Encoding.ASCII.GetBytes(str.ToCharArray());
            SendData(dat);
        }
        
        /// <summary>
        /// 字节数据转字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string bytesToString(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }
        #endregion 成员函数区
    }
}
