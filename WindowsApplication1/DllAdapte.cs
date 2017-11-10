using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WindowsApplication1
{
    class DllAdapte
    {
        public DllAdapte()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="DeviceType"></param>
        /// <param name="DeviceInd"></param>
        /// <param name="Reserved"></param>
        /// <returns></returns>
        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_OpenDevice ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 Reserved );
        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_CloseDevice ( UInt32 DeviceType, UInt32 DeviceInd );
        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_InitCAN ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_INIT_CONFIG pInitConfig );
        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_ReadBoardInfo ( UInt32 DeviceType, UInt32 DeviceInd, ref VCI_BOARD_INFO pInfo );
        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_ReadErrInfo ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_ERR_INFO pErrInfo );
        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_ReadCANStatus ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_STATUS pCANStatus );

        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_GetReference ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData );
        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_SetReference ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData );

        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_GetReceiveNum ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd );
        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_ClearBuffer ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd );

        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_StartCAN ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd );
        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_ResetCAN ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd );

        [DllImport ( "controlcan.dll" )]
        public static extern UInt32 VCI_Transmit ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pSend, UInt32 Len );

        //[DllImport("controlcan.dll")]
        //public static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pReceive, UInt32 Len, Int32 WaitTime);
        [DllImport ( "controlcan.dll", CharSet = CharSet.Ansi )]
        public static extern UInt32 VCI_Receive ( UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, IntPtr pReceive, UInt32 Len, Int32 WaitTime );
    }
}
