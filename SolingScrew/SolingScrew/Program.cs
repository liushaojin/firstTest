using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SolingScrew
{
    static class Program
    {
        /// <summary>
        /// 需要定义为类变量，而非局部变量
        /// </summary>
        static System.Threading.Mutex appMutex;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //是否可以打开新进程(用于在一台电脑中只能运行唯一实例的场合)
            bool createNew;
            
            //获取程序集Guid作为唯一标识
            Attribute guid_attr = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
            string guid = ((GuidAttribute)guid_attr).Value;
            
            appMutex = new System.Threading.Mutex(true, guid, out createNew);
            
            if (false == createNew)
            {
                //发现重复进程
                return;
            }
            
            appMutex.ReleaseMutex();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new solingScrew());
        }
    }
}
