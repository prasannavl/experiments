using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming

namespace TestRunner
{
#if WINDOWS
    public partial class NativeConstants
    {

        /// TRUE -> 1
        public const int TRUE = 1;

        /// FALSE -> 0
        public const int FALSE = 0;

        /// CTRL_SHUTDOWN_EVENT -> 6
        public const int CTRL_SHUTDOWN_EVENT = 6;

        /// CTRL_LOGOFF_EVENT -> 5
        public const int CTRL_LOGOFF_EVENT = 5;

        /// CTRL_CLOSE_EVENT -> 2
        public const int CTRL_CLOSE_EVENT = 2;

        /// CTRL_BREAK_EVENT -> 1
        public const int CTRL_BREAK_EVENT = 1;

        /// CTRL_C_EVENT -> 0
        public const int CTRL_C_EVENT = 0;
    }

    public class NativeTypes
    {
        /// Return Type: BOOL->int
        ///CtrlType: DWORD->unsigned int
        public delegate int PHANDLER_ROUTINE(uint CtrlType);
    }

    public class NativeMethods
    {
        /// Return Type: BOOL->int
        ///HandlerRoutine: PHANDLER_ROUTINE
        ///Add: BOOL->int
        [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "SetConsoleCtrlHandler")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool SetConsoleCtrlHandler(NativeTypes.PHANDLER_ROUTINE HandlerRoutine, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool Add);

    }
#endif
}
