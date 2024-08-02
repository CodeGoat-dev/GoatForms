using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace GoatForms
{
    // Native methods class
    internal static class NativeMethods
    {
        private const int SHGFI_ICON = 0x100;
        private const int SHGFI_LARGEICON = 0x0;    // Large icon
        private const int SHGFI_SMALLICON = 0x1;    // Small icon

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private extern static bool SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbFileInfo,
            uint uFlags);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        internal static Icon IconFromShell32(int iconIndex)
        {
            SHFILEINFO shinfo = new SHFILEINFO();

            SHGetFileInfo(
                Environment.SystemDirectory + @"\shell32.dll",
                0,
                ref shinfo,
                (uint)Marshal.SizeOf(shinfo),
                SHGFI_ICON | SHGFI_LARGEICON | (uint)iconIndex);

            return Icon.FromHandle(shinfo.hIcon);
        }
    }
}
