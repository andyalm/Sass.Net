using System;

using Sass.Net.NativeInterop;

namespace Sass.Net
{
    public class SassCompiler
    {
        public string Compile(string rawSass)
        {
            var inputContext = new NativeWrapper<sass_context>();
            NativeWrapper<sass_context> outputContext = null;

            try
            {
                inputContext.Value.input_string = rawSass.ToPointer();
                SassLibNative.sass_compile(inputContext.Value);
                outputContext = new NativeWrapper<sass_context>(inputContext.Pointer);

                return outputContext.Value.output_string.ToManagedString();
            }
            finally
            {
                inputContext.Dispose();
                if (outputContext != null)
                    outputContext.Dispose();
            }
        }
    }
}