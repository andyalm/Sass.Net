using System;

using FluentAssertions;

using NUnit.Framework;

namespace Sass.Net.Tests
{
    [TestFixture]
    public class SassCompilerTests
    {
        [Test]
        public void CanParseSass()
        {
            var sass = "div { a { color: red; } }";
            var compiler = new SassCompiler();
            var compiledSass = compiler.Compile(sass);
            compiledSass.Should().Be("div a {\n  color: red; }\n");
        }
    }
}
