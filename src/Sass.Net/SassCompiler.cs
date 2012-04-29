using System;

using Sass.Net.NativeInterop;

namespace Sass.Net
{
    public class SassCompiler
    {
        private readonly SassCompilerOptions _options;

        public SassCompiler(SassCompilerOptions options)
        {
            _options = options;
        }
        
        public string Compile(string rawSass)
        {
            var inputContext = new NativeWrapper<sass_context>();

            try
            {
                inputContext.Value.input_string = rawSass.ToPointer();
                SassLibNative.sass_compile(inputContext.Pointer);
                inputContext.Refresh();

                return inputContext.Value.output_string.ToManagedString();
            }
            finally
            {
                inputContext.Dispose();
            }
        }
    }
}