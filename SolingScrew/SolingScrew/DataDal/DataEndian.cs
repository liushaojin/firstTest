using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolingScrew.DataDal
{
    class DataEndian
    {
        public static bool littleEndian = false;
        static DataEndian()
        {
            unsafe
            {
                int tester = 1;
                littleEndian = (*(byte*)(&tester)) == (byte)1;  //大小端测试
            }
        }
        
        #region Factory
        private static DataEndian instance = null;
        internal static DataEndian Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = littleEndian ? new DataLittleEndian() : new DataEndian();
                }
                
                return instance;
            }
        }
        #endregion
        
        public virtual Byte[] GetBytes(short val)
        {
            return BitConverter.GetBytes(val);
        }
        public virtual Byte[] GetBytes(int val)
        {
            return BitConverter.GetBytes(val);
        }
        public virtual Byte[] GetBytes(float val)
        {
            return BitConverter.GetBytes(val);
        }
        public virtual Byte[] GetBytes(double val)
        {
            return BitConverter.GetBytes(val);
        }
        public virtual short GetShort(byte[] dat)
        {
            return BitConverter.ToInt16(dat, 0);
        }
        public virtual int GetInt(byte[] dat)
        {
            return BitConverter.ToInt32(dat, 0);
        }
        public virtual float GetFloat(byte[] dat)
        {
            return BitConverter.ToSingle(dat, 0);
        }
        public virtual double GetDouble(byte[] dat)
        {
            return BitConverter.ToDouble(dat, 0);
        }
    }
    
    internal class DataLittleEndian: DataEndian
    {
    
        public override Byte[] GetBytes(short val)
        {
            return Reverse(BitConverter.GetBytes(val));
        }
        public override Byte[] GetBytes(int val)
        {
            return Reverse(BitConverter.GetBytes(val));
        }
        public override Byte[] GetBytes(float val)
        {
            return Reverse(BitConverter.GetBytes(val));
        }
        public override Byte[] GetBytes(double val)
        {
            return Reverse(BitConverter.GetBytes(val));
        }
        public override short GetShort(byte[] dat)
        {
            return BitConverter.ToInt16(Reverse(dat), 0);
        }
        public override int GetInt(byte[] dat)
        {
            return BitConverter.ToInt32(Reverse(dat), 0);
        }
        public override float GetFloat(byte[] dat)
        {
            return BitConverter.ToSingle(Reverse(dat), 0);
        }
        public override double GetDouble(byte[] dat)
        {
            return BitConverter.ToDouble(Reverse(dat), 0);
        }
        
        private Byte[] Reverse(Byte[] dat)
        {
            Array.Reverse(dat);
            return dat;
        }
    }
}
