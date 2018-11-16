﻿namespace UILibrary.Win32.Struct
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct NMTTDISPINFO
    {
        public NMHDR hdr;
        public IntPtr lpszText;
        public IntPtr szText;
        public IntPtr hinst;
        public int uFlags;
        public IntPtr lParam;
        public NMTTDISPINFO(int flags)
        {
            this.hdr = new NMHDR(0);
            this.lpszText = IntPtr.Zero;
            this.szText = IntPtr.Zero;
            this.hinst = IntPtr.Zero;
            this.uFlags = 0;
            this.lParam = IntPtr.Zero;
        }
    }
}

