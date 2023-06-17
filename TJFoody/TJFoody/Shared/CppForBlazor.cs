using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TJFoody.Shared
{
    public class CppForBlazor
    {
        [DllImport("DllForBlazor.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MyAdd(int x, int y);

        [DllImport("DllForBlazor.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MyMinus(int x, int y);

        [DllImport("DllForBlazor.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MyAvatar();  //string avatarUrl = Marshal.PtrToStringAuto(MyAvatar());

    }
}
