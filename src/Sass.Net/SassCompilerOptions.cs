using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sass.Net
{
    public class SassCompilerOptions
    {
        public SassOutputStyle OutputStyle { get; set; }

        public SassCompilerOptions()
        {
            OutputStyle = SassOutputStyle.Nested;
        }
    }

    public enum SassOutputStyle : int
    {
        Nested = 0,
        Expanded = 1,
        Compact = 2,
        Compressed = 3,
        Echo = 4
    }

    //enum CSS_Style { nested, expanded, compact, compressed, echo };
}
