using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

/// <summary>
///
/// </summary>
namespace SolingScrew.FileOpAPI
{
    class IniFileHelper
    {
        //public string FileName; //INI文件名
        //ini文件名称
        private static string inifilename = "Config.ini";
        //获取ini文件路径
        private string FileName = Directory.GetCurrentDirectory() + "\\" + inifilename;
        //声明读写INI文件的API函数
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);
        
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSection(string lpAppName, IntPtr lpReturnedString, uint nSize, string lpFileName);
        //类的构造函数，传递INI文件名
        public IniFileHelper()
        {
            //FileStream fs;
            //if (File.Exists(FileName))
            //{
            //    fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);//创建写入文件
            //    StreamWriter sw = new StreamWriter(fs);
            //    sw.WriteLine("螺丝机上位机配置文件");//开始写入值
            //    sw.Close();
            //    fs.Close();
            //}
            //else
            //{
            //    fs = new FileStream(FileName, FileMode.Open, FileAccess.Write);
            //    StreamWriter sr = new StreamWriter(fs);
            //    sr.WriteLine("螺丝机上位机配置文件");//开始写入值
            //    sr.Close();
            //    fs.Close();
            //}
            //根据文件名获取文件信息
            FileInfo fileInfo = new FileInfo(FileName);
            
            //判断文件是否存在
            if((!fileInfo.Exists))
            {
                //文件不存在，建立文件
                System.IO.StreamWriter sw = new System.IO.StreamWriter(FileName, false, System.Text.Encoding.Default);
                
                try
                {
                    sw.Write("螺丝机上位机配置文件");
                    sw.Close();
                }
                catch
                {
                    throw(new ApplicationException("Ini文件不存在"));
                }
            }
        }
        public IniFileHelper(string fileName)
        {
            //根据文件名获取文件信息
            FileInfo fileInfo = new FileInfo(fileName);
            
            //判断文件是否存在
            if((!fileInfo.Exists))
            {
                //文件不存在，建立文件
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, System.Text.Encoding.Default);
                
                try
                {
                    sw.Write("螺丝机上位机配置文件");
                    sw.Close();
                }
                catch
                {
                    throw(new ApplicationException("Ini文件不存在"));
                }
            }
            
            //必须是完全路径，不能是相对路径
            FileName = fileInfo.FullName;
        }
        
        
        public string GetValue(string key)
        {
            byte[] buf = new byte[1024];
            GetPrivateProfileString("Config", key, "", buf, 1024, FileName);
            return buf.ToString();
        }
        public void SetValue(string key, string value)
        {
            try
            {
                WritePrivateProfileString("Config", key, value, FileName);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        //写INI文件
        public void WriteString(string section, string key, string value)
        {
            if(!WritePrivateProfileString(section, key, value, FileName))
            {
                throw(new ApplicationException("写Ini文件出错"));
            }
        }
        //读取INI文件指定
        public string ReadString(string section, string key, string val)
        {
            Byte[] buffer = new Byte[255];//new Byte[65535];
            int bufLen = GetPrivateProfileString(section, key, val, buffer, buffer.GetUpperBound(0), FileName);
            //必须设定0（系统默认的代码页）的编码方式，否则无法支持中文
            string s = Encoding.GetEncoding(0).GetString(buffer);
            s = s.Substring(0, bufLen);
            return s.Trim();
        }
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="section">节点</param>
        /// <param name="key">关键字</param>
        /// <returns>返回值</returns>
        public string ReadValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, string.Empty, temp, 255, FileName);
            return temp.ToString();
        }
        
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="section">节点</param>
        /// <param name="key">关键字</param>
        /// <returns>返回值，byte格式</returns>
        public byte[] ReadValues(string section, string key)
        {
            byte[] temp = new byte[255];
            int i = GetPrivateProfileString(section, key, string.Empty, temp, 255, FileName);
            return temp;
        }
        
        /// <summary>
        /// 读取指定节点下的所有值
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public List<string> ReadValues(string section)
        {
            List<string> list = new List<string>();
            StringCollection keyList = new StringCollection();
            ReadSection(section, keyList);
            
            foreach(string key in keyList)
            {
                list.Add(ReadString(section, key, ""));
            }
            
            return list;
        }
        
        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="section">节点</param>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        public void WriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, FileName);
        }
        
        /// <summary>
        /// 删除ini文件下所有段落
        /// </summary>
        public void ClearAllSection()
        {
            this.WriteValue(null, null, null);
        }
        
        /// <summary>
        /// 删除ini文件下personal段落下的所有键
        /// </summary>
        /// <param name="section">节点</param>
        public void ClearSection(string section)
        {
            this.WriteValue(section, null, null);
        }
        
        /// <summary>
        /// 读取某个节点下的所以键
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <returns>返回节点值</returns>
        public List<string> ReadKeys(string section)
        {
            List<string> list = new List<string>();
            byte[] buffer = new byte[16384];
            int buflen = GetPrivateProfileString(section, null, null, buffer, buffer.GetUpperBound(0), FileName);
            this.GetStringsFromBuffer(buffer, buflen, list);
            return list;
        }
        
        /// <summary>
        /// 获取字符串byte流
        /// </summary>
        /// <param name="buffer">缓冲区</param>
        /// <param name="bufLen">缓冲区大小</param>
        /// <param name="list">返回list结果</param>
        private void GetStringsFromBuffer(byte[] buffer, int bufLen, List<string> list)
        {
            list.Clear();
            
            if(bufLen != 0)
            {
                int start = 0;
                
                for(int i = 0; i < bufLen; i++)
                {
                    if((buffer[i] == 0) && ((i - start) > 0))
                    {
                        string s = Encoding.GetEncoding(0).GetString(buffer, start, i - start);
                        list.Add(s);
                        start = i + 1;
                    }
                }
            }
        }
        
        //读整数
        public int ReadInteger(string section, string key, int val)
        {
            string intStr = ReadString(section, key, Convert.ToString(val));
            
            try
            {
                return Convert.ToInt32(intStr);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return val;
            }
        }
        
        //写整数
        public void WriteInteger(string section, string key, int value)
        {
            WriteString(section, key, value.ToString());
        }
        
        //读布尔
        public bool ReadBool(string section, string key, bool val)
        {
            try
            {
                return Convert.ToBoolean(ReadString(section, key, Convert.ToString(val)));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return val;
            }
        }
        
        //写Bool
        public void WriteBool(string section, string key, bool value)
        {
            WriteString(section, key, Convert.ToString(value));
        }
        
        //从Ini文件中，将指定的Section名称中的所有key添加到列表中
        public void ReadSection(string section, StringCollection keys)
        {
            Byte[] buffer = new Byte[16384];
            //keys.Clear();
            int bufLen = GetPrivateProfileString(section, null, null, buffer, buffer.GetUpperBound(0), FileName);
            //对section进行解析
            GetStringsFromBuffer(buffer, bufLen, keys);
        }
        
        private void GetStringsFromBuffer(Byte[] buffer, int bufLen, StringCollection strings)
        {
            strings.Clear();
            
            if(bufLen != 0)
            {
                int start = 0;
                
                for(int i = 0; i < bufLen; i++)
                {
                    if((buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.GetEncoding(0).GetString(buffer, start, i - start);
                        strings.Add(s);
                        start = i + 1;
                    }
                }
            }
        }
        
        /// <summary>
        /// 获取所有段集合
        /// </summary>
        /// <returns></returns>
        public List<string> ReadSections()
        {
            List<string> secList = new List<string>();
            byte[] buffer = new byte[65535];
            int bufLen = 0;
            bufLen = GetPrivateProfileString(null, null, null, buffer, buffer.GetUpperBound(0), FileName);
            
            if(bufLen != 0)
            {
                int start = 0;
                
                for(int i = 0; i < bufLen; i++)
                {
                    if((buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.GetEncoding(0).GetString(buffer, start, i - start);
                        secList.Add(s);
                        start = i + 1;
                    }
                }
            }
            
            return secList;
        }
        
        //从Ini文件中，读取所有的Sections的名称
        public void ReadSections(StringCollection sectionList)
        {
            //Note:必须得用Bytes来实现，StringBuilder只能取到第一个Section
            byte[] buffer = new byte[65535];
            int bufLen = 0;
            bufLen = GetPrivateProfileString(null, null, null, buffer,
                                             buffer.GetUpperBound(0), FileName);
            GetStringsFromBuffer(buffer, bufLen, sectionList);
        }
        //读取指定的Section的所有Value到列表中
        public void ReadSectionValues(string section, NameValueCollection values)
        {
            StringCollection keyList = new StringCollection();
            ReadSection(section, keyList);
            values.Clear();
            
            foreach(string key in keyList)
            {
                values.Add(key, ReadString(section, key, ""));
            }
        }
        ////读取指定的Section的所有Value到列表中，
        //public void ReadSectionValues(string Section, NameValueCollection Values,char splitString)
        //{　 string sectionValue;
        //　　string[] sectionValueSplit;
        //　　StringCollection KeyList = new StringCollection();
        //　　ReadSection(Section, KeyList);
        //　　Values.Clear();
        //　　foreach (string key in KeyList)
        //　　{
        //　　　　sectionValue=ReadString(Section, key, "");
        //　　　　sectionValueSplit=sectionValue.Split(splitString);
        //　　　　Values.Add(key, sectionValueSplit[0].ToString(),sectionValueSplit[1].ToString());
        
        //　　}
        //}
        //清除某个Section
        public void EraseSection(string section)
        {
            //
            if(!WritePrivateProfileString(section, null, null, FileName))
            {
                throw(new ApplicationException("无法清除Ini文件中的Section"));
            }
        }
        //删除某个Section下的键
        public void DeleteKey(string section, string key)
        {
            WritePrivateProfileString(section, key, null, FileName);
        }
        //Note:对于Win9X，来说需要实现UpdateFile方法将缓冲中的数据写入文件
        //在Win NT, 2000和XP上，都是直接写文件，没有缓冲，所以，无须实现UpdateFile
        //执行完对Ini文件的修改之后，应该调用本方法更新缓冲区。
        public void UpdateFile()
        {
            WritePrivateProfileString(null, null, null, FileName);
        }
        
        //检查某个Section下的某个键值是否存在
        public bool ValueExists(string section, string key)
        {
            StringCollection keys = new StringCollection();
            ReadSection(section, keys);
            return key.IndexOf(key) > -1;
        }
        
        //确保资源的释放
        ~IniFileHelper()
        {
            UpdateFile();
        }
    }
}
