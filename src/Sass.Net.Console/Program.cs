using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sass.Net.Tests;

namespace Sass.Net.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            SassCompilerTests tests = new SassCompilerTests();
            tests.SetupContext();
            tests.CanCompileBasicSass();
        }
    }
}
