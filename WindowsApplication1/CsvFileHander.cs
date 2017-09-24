using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Reflection;
    using System.IO;
    using System.Data.Odbc;
    class CsvFileHander
    {
        //这里写了一个通用的类


        #region Fields
        DataTable _dataSource;//数据源
        string[] _titles = null;//列标题
        string[] _fields = null;//字段名
        #endregion
        #region .ctor
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataSource">数据源</param>
        public CsvFileHander()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="titles">要输出到 Excel 的列标题的数组</param>
        /// <param name="fields">要输出到 Excel 的字段名称数组</param>
        /// <param name="dataSource">数据源</param>
        public CsvFileHander ( string[] titles, string[] fields, DataTable dataSource )
        : this ( titles, dataSource )
        {
            if ( fields == null || fields.Length == 0 )
            {
                throw new ArgumentNullException ( "fields" );
            }

            if ( titles.Length != fields.Length )
            {
                throw new ArgumentException ( "titles.Length != fields.Length", "fields" );
            }

            _fields = fields;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="titles">要输出到 Excel 的列标题的数组</param>
        /// <param name="dataSource">数据源</param>
        public CsvFileHander ( string[] titles, DataTable dataSource )
        : this ( dataSource )
        {
            if ( titles == null || titles.Length == 0 )
            {
                throw new ArgumentNullException ( "titles" );
            }

            _titles = titles;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataSource">数据源</param>
        public CsvFileHander ( DataTable dataSource )
        {
            if ( dataSource == null )
            {
                throw new ArgumentNullException ( "dataSource" );
            }

            // maybe more checks needed here (IEnumerable, IList, IListSource, ) ???
            // 很难判断，先简单的使用 DataTable
            _dataSource = dataSource;
        }
        #endregion
        #region public Methods
        #region 导出到CSV文件并且提示下载
        /// <summary>
        /// 导出到CSV文件并且提示下载
        /// </summary>
        /// <param name="fileName"></param>
        public void DataToCSV ( string fileName )
        {
            // 确保有一个合法的输出文件名
            //if (fileName == null || fileName == string.Empty || !(fileName.ToLower().EndsWith(".csv")))
            // fileName = GetRandomFileName();
            string data = ExportCSV();
        }
        #endregion
        /// <summary>
        /// 获取CSV导入的数据
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名称(.csv不用加)</param>
        /// <returns></returns>
        public DataTable GetCsvData ( string filePath, string fileName )
        {
            string path = Path.Combine ( filePath, fileName + ".csv" );
            string connString = @"Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + filePath + ";Extensions=asc,csv,tab,txt;";

            try
            {
                using ( OdbcConnection odbcConn = new OdbcConnection ( connString ) )
                {
                    odbcConn.Open();
                    OdbcCommand oleComm = new OdbcCommand();
                    oleComm.Connection = odbcConn;
                    oleComm.CommandText = "select * from [" + fileName + "#csv]";
                    OdbcDataAdapter adapter = new OdbcDataAdapter ( oleComm );
                    DataSet ds = new DataSet();
                    adapter.Fill ( ds, fileName );
                    return ds.Tables[0];
                    odbcConn.Close();
                }

                if ( File.Exists ( path ) )
                {
                    File.Delete ( path );
                }
            }

            catch ( Exception ex )
            {
                if ( File.Exists ( path ) )
                {
                    File.Delete ( path );
                }

                throw ex;
            }
        }
        #endregion
        #region 返回写入CSV的字符串
        /// <summary>
        /// 返回写入CSV的字符串
        /// </summary>
        /// <returns></returns>
        private string ExportCSV()
        {
            if ( _dataSource == null )
            {
                throw new ArgumentNullException ( "dataSource" );
            }

            StringBuilder strbData = new StringBuilder();

            if ( _titles == null )
            {
                //添加列名
                foreach ( DataColumn column in _dataSource.Columns )
                {
                    strbData.Append ( column.ColumnName + "," );
                }

                strbData.Append ( "\n" );

                foreach ( DataRow dr in _dataSource.Rows )
                {
                    for ( int i = 0; i < _dataSource.Columns.Count; i++ )
                    {
                        strbData.Append ( dr[i].ToString() + "," );
                    }

                    strbData.Append ( "\n" );
                }

                return strbData.ToString();
            }

            else
            {
                foreach ( string columnName in _titles )
                {
                    strbData.Append ( columnName + "," );
                }

                strbData.Append ( "\n" );

                if ( _fields == null )
                {
                    foreach ( DataRow dr in _dataSource.Rows )
                    {
                        for ( int i = 0; i < _dataSource.Columns.Count; i++ )
                        {
                            strbData.Append ( dr[i].ToString() + "," );
                        }

                        strbData.Append ( "\n" );
                    }

                    return strbData.ToString();
                }

                else
                {
                    foreach ( DataRow dr in _dataSource.Rows )
                    {
                        for ( int i = 0; i < _fields.Length; i++ )
                        {
                            strbData.Append ( _fields[i].ToString() + "," );
                        }

                        strbData.Append ( "\n" );
                    }

                    return strbData.ToString();
                }
            }
        }
        #endregion
        #region 得到一个随意的文件名
        /// <summary>
        /// 得到一个随意的文件名
        /// </summary>
        /// <returns></returns>
        private string GetRandomFileName()
        {
            Random rnd = new Random ( ( int ) ( DateTime.Now.Ticks ) );
            string s = rnd.Next ( Int32.MaxValue ).ToString();
            return DateTime.Now.ToShortDateString() + "_" + s + ".csv";
        }
        #endregion

        /// <summary>
        /// 将DataTable中数据写入到CSV文件中
        /// </summary>
        /// <param name="dt">提供保存数据的DataTable</param>
        /// <param name="fileName">CSV的文件路径</param>
        public static void SaveCSV ( DataTable dt, string fullPath )
        {
            FileInfo fi = new FileInfo ( fullPath );

            if ( !fi.Directory.Exists )
            {
                fi.Directory.Create();
            }

            FileStream fs = new FileStream ( fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write );
            //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            StreamWriter sw = new StreamWriter ( fs, System.Text.Encoding.UTF8 );
            string data = "";

            //写出列名称
            for ( int i = 0; i < dt.Columns.Count; i++ )
            {
                data += dt.Columns[i].ColumnName.ToString();

                if ( i < dt.Columns.Count - 1 )
                {
                    data += ",";
                }
            }

            sw.WriteLine ( data );

            //写出各行数据
            for ( int i = 0; i < dt.Rows.Count; i++ )
            {
                data = "";

                for ( int j = 0; j < dt.Columns.Count; j++ )
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace ( "\"", "\"\"" ); //替换英文冒号 英文冒号需要换成两个冒号

                    if ( str.Contains ( "," ) || str.Contains ( "\"" )
                            || str.Contains ( "\r" ) || str.Contains ( "\n" ) ) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format ( "\"{0}\"", str );
                    }

                    data += str;

                    if ( j < dt.Columns.Count - 1 )
                    {
                        data += ",";
                    }
                }

                sw.WriteLine ( data );
            }

            sw.Close();
            fs.Close();
            DialogResult result = MessageBox.Show ( "CSV文件保存成功！" );

            if ( result == DialogResult.OK )
            {
                System.Diagnostics.Process.Start ( "explorer.exe" /*,CommonDialog.PATH_LANG*/ );
            }
        }

        /// <summary>
        /// 将CSV文件的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public static DataTable OpenCSV ( string filePath )
        {
            Encoding encoding = Encoding.Default; //Common.GetType ( filePath );
            DataTable dt = new DataTable();
            FileStream fs = new FileStream ( filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read );

            //StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            StreamReader sr = new StreamReader ( fs, encoding );
            //string fileContent = sr.ReadToEnd();
            //encoding = sr.CurrentEncoding;
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;

            //逐行读取CSV中的数据
            while ( ( strLine = sr.ReadLine() ) != null )
            {
                //strLine = Common.ConvertStringUTF8(strLine, encoding);
                //strLine = Common.ConvertStringUTF8(strLine);

                if ( IsFirst == true )
                {
                    tableHead = strLine.Split ( ',' );
                    IsFirst = false;
                    columnCount = tableHead.Length;

                    //创建列
                    for ( int i = 0; i < columnCount; i++ )
                    {
                        DataColumn dc = new DataColumn ( tableHead[i] );
                        dt.Columns.Add ( dc );
                    }
                }

                else
                {
                    aryLine = strLine.Split ( ',' );
                    DataRow dr = dt.NewRow();

                    for ( int j = 0; j < columnCount; j++ )
                    {
                        dr[j] = aryLine[j];
                    }

                    dt.Rows.Add ( dr );
                }
            }

            if ( aryLine != null && aryLine.Length > 0 )
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            }

            sr.Close();
            fs.Close();
            return dt;
        }

        private void EstablishCSV ( DataTable dt )
        {
            HttpResponse Response = HttpContext.Current.Response;
            Response.ClearContent();
            Response.AddHeader ( "content-disposition", "attachment; filename=" + DateTime.Now.ToString ( "yyyyMMddHHmmss" ) + ".csv" );
            Response.ContentEncoding = System.Text.Encoding.GetEncoding ( "gb2312" );
            Response.ContentType = "application/excel";
            StringBuilder sb = new StringBuilder();
            string s;

            //Write Field Title
            s = "";

            foreach ( DataColumn dc in dt.Columns )
            {
                s += dc.ColumnName + ",";
            }

            s = s.Substring ( 0, s.Length - 1 ) + "\r\n";
            sb.Append ( s );

            //Write Row
            foreach ( DataRow dr in dt.Rows )
            {
                s = "";

                foreach ( object o in dr.ItemArray )
                {
                    s += o.ToString() + ",";
                }

                s = s.Substring ( 0, s.Length - 1 ) + "\r\n";
                sb.Append ( s );
            }

            Response.Write ( sb.ToString() );
            Response.End();
        }


        public static void SaveDatoToCSV ( DataTable dt, string fullPath ) //table数据写入csv
        {
            System.IO.FileInfo fi = new System.IO.FileInfo ( fullPath );

            if ( !fi.Directory.Exists )
            {
                fi.Directory.Create();
            }

            System.IO.FileStream fs = new System.IO.FileStream ( fullPath, System.IO.FileMode.Create,
                    System.IO.FileAccess.Write );
            System.IO.StreamWriter sw = new System.IO.StreamWriter ( fs, System.Text.Encoding.UTF8 );
            string data = "";

            for ( int i = 0; i < dt.Columns.Count; i++ ) //写入列名
            {
                data += dt.Columns[i].ColumnName.ToString();

                if ( i < dt.Columns.Count - 1 )
                {
                    data += ",";
                }
            }

            sw.WriteLine ( data );

            for ( int i = 0; i < dt.Rows.Count; i++ ) //写入各行数据
            {
                data = "";

                for ( int j = 0; j < dt.Columns.Count; j++ )
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace ( "\"", "\"\"" ); //替换英文冒号 英文冒号需要换成两个冒号

                    if ( str.Contains ( "," ) || str.Contains ( "\"" )
                            || str.Contains ( "\r" ) || str.Contains ( "\n" ) ) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format ( "\"{0}\"", str );
                    }

                    data += str;

                    if ( j < dt.Columns.Count - 1 )
                    {
                        data += ",";
                    }
                }

                sw.WriteLine ( data );
            }

            sw.Close();
            fs.Close();
        }

        public static DataTable OpenCSVFile ( string filePath ) //从csv读取数据返回table
        {
            System.Text.Encoding encoding = GetType ( filePath ); //Encoding.ASCII;//
            DataTable dt = new DataTable();
            System.IO.FileStream fs = new System.IO.FileStream ( filePath, System.IO.FileMode.Open,
                    System.IO.FileAccess.Read );

            System.IO.StreamReader sr = new System.IO.StreamReader ( fs, encoding );

            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;

            //逐行读取CSV中的数据
            while ( ( strLine = sr.ReadLine() ) != null )
            {
                if ( IsFirst == true )
                {
                    tableHead = strLine.Split ( ',' );
                    IsFirst = false;
                    columnCount = tableHead.Length;

                    //创建列
                    for ( int i = 0; i < columnCount; i++ )
                    {
                        DataColumn dc = new DataColumn ( tableHead[i] );
                        dt.Columns.Add ( dc );
                    }
                }

                else
                {
                    aryLine = strLine.Split ( ',' );
                    DataRow dr = dt.NewRow();

                    for ( int j = 0; j < columnCount; j++ )
                    {
                        dr[j] = aryLine[j];
                    }

                    dt.Rows.Add ( dr );
                }
            }

            if ( aryLine != null && aryLine.Length > 0 )
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            }

            sr.Close();
            fs.Close();
            return dt;
        }
        /// 给定文件的路径，读取文件的二进制数据，判断文件的编码类型
        /// <param name="FILE_NAME">文件路径</param>
        /// <returns>文件的编码类型</returns>

        public static System.Text.Encoding GetType ( string FILE_NAME )
        {
            System.IO.FileStream fs = new System.IO.FileStream ( FILE_NAME, System.IO.FileMode.Open,
                    System.IO.FileAccess.Read );
            System.Text.Encoding r = GetType ( fs );
            fs.Close();
            return r;
        }

        /// 通过给定的文件流，判断文件的编码类型
        /// <param name="fs">文件流</param>
        /// <returns>文件的编码类型</returns>
        public static System.Text.Encoding GetType ( System.IO.FileStream fs )
        {
            byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
            byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
            byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //带BOM
            System.Text.Encoding reVal = System.Text.Encoding.Default;

            System.IO.BinaryReader r = new System.IO.BinaryReader ( fs, System.Text.Encoding.Default );
            int i;
            int.TryParse ( fs.Length.ToString(), out i );
            byte[] ss = r.ReadBytes ( i );

            if ( IsUTF8Bytes ( ss ) || ( ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF ) )
            {
                reVal = System.Text.Encoding.UTF8;
            }

            else
                if ( ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00 )
                {
                    reVal = System.Text.Encoding.BigEndianUnicode;
                }

                else
                    if ( ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41 )
                    {
                        reVal = System.Text.Encoding.Unicode;
                    }

            r.Close();
            return reVal;
        }

        /// 判断是否是不带 BOM 的 UTF8 格式
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool IsUTF8Bytes ( byte[] data )
        {
            int charByteCounter = 1;  //计算当前正分析的字符应还有的字节数
            byte curByte; //当前分析的字节.

            for ( int i = 0; i < data.Length; i++ )
            {
                curByte = data[i];

                if ( charByteCounter == 1 )
                {
                    if ( curByte >= 0x80 )
                    {
                        //判断当前
                        while ( ( ( curByte <<= 1 ) & 0x80 ) != 0 )
                        {
                            charByteCounter++;
                        }

                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X　
                        if ( charByteCounter == 1 || charByteCounter > 6 )
                        {
                            return false;
                        }
                    }
                }

                else
                {
                    //若是UTF-8 此时第一位必须为1
                    if ( ( curByte & 0xC0 ) != 0x80 )
                    {
                        return false;
                    }

                    charByteCounter--;
                }
            }

            if ( charByteCounter > 1 )
            {
                throw new Exception ( "非预期的byte格式" );
            }

            return true;
        }

        public static bool ChangeFileName ( string OldPath, string NewPath )
        {
            bool re = false;

            try
            {
                if ( File.Exists ( OldPath ) )
                {
                    File.Move ( OldPath, NewPath );
                    re = true;
                }
            }

            catch
            {
                re = false;
            }

            return re;
        }

        public static bool SaveDataToCSV ( string fullPath, string Data )
        {
            bool re = true;

            try
            {
                FileStream FileStream = new FileStream ( fullPath, FileMode.Append );
                StreamWriter sw = new StreamWriter ( FileStream, System.Text.Encoding.UTF8 );
                sw.WriteLine ( Data );
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                FileStream.Close();
            }

            catch
            {
                re = false;
            }

            return re;
        }
    }

}

