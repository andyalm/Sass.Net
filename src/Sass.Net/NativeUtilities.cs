using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sass.Net.NativeInterop
{
    internal class NativeWrapper<T> : IDisposable where T : class,new()
    {
        private IntPtr _nativePointer = IntPtr.Zero;
        private T _object;

        public NativeWrapper()
        {

        }

        public NativeWrapper(IntPtr nativePointer)
        {
            _object = (T)Marshal.PtrToStructure(nativePointer, typeof(T));
            _nativePointer = nativePointer;
        }

        public T Value
        {
            get
            {
                if (_object == null)
                {
                    _object = new T();
                }

                return _object;
            }
        }

        public IntPtr Pointer
        {
            get
            {
                if (_nativePointer != IntPtr.Zero)
                    return _nativePointer;

                var nativeSize = Marshal.SizeOf(Value);
                _nativePointer = Marshal.AllocHGlobal(nativeSize);
                Marshal.StructureToPtr(Value, _nativePointer, false);

                return _nativePointer;
            }
        }

        public void Dispose()
        {
            if (_nativePointer != IntPtr.Zero)
            {
                Marshal.DestroyStructure(_nativePointer, typeof(T));
                _nativePointer = IntPtr.Zero;
            }
        }
    }

    public static class NativeStringExtensions
    {
        public static string ToManagedString(this IntPtr pointer)
        {
            return Marshal.PtrToStringAnsi(pointer);
        }

        public static IntPtr ToPointer(this string value)
        {
            return Marshal.StringToHGlobalAnsi(value);
        }
    }
}
