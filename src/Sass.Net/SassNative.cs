using System;
using System.Runtime.InteropServices;

namespace Sass.Net
{
    //help: http://blogs.msdn.com/b/dsvc/archive/2009/02/18/marshalling-complicated-structures-using-pinvoke.aspx
    internal static class SassLibNative
    {
        public const CharSet DefaultCharSet = CharSet.Ansi;

        [DllImport("libsass.dll", CharSet = DefaultCharSet)]
        public static extern int sass_compile(IntPtr c_ctx);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = SassLibNative.DefaultCharSet)]
    internal class sass_options
    {
        /// int
        public int output_style;

        /// char*
        public IntPtr include_paths;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = SassLibNative.DefaultCharSet)]
    internal class sass_context
    {

        /// char*
        public IntPtr input_string;

        /// char*
        public IntPtr output_string;

        /// sass_options
        public IntPtr options;

        /// int
        public int error_status;

        /// char*
        public IntPtr error_message;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class sass_file_context
    {

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string input_path;

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string output_string;

        /// sass_options
        public sass_options options;

        /// int
        public int error_status;

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string error_message;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class sass_folder_context
    {

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string search_path;

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string output_path;

        /// sass_options
        public sass_options options;

        /// int
        public int error_status;

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string error_message;
    }

}
