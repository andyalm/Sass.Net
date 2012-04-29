using System;

using FluentAssertions;

using NUnit.Framework;

namespace Sass.Net.Tests
{
    [TestFixture]
    public class SassCompilerTests
    {
        private SassCompiler _compiler;
        private SassCompilerOptions _compilerOptions;

        [SetUp]
        public void SetupContext()
        {
            _compilerOptions = new SassCompilerOptions();
            _compiler = new SassCompiler(_compilerOptions);
        }

        [Test]
        public void CanCompileBasicSass()
        {
            var sass = "div { a { color: red; } }";
            var compiledSass = _compiler.Compile(sass);
            compiledSass.Should().Be("div a {\n  color: red; }\n");
        }

        [Test]
        [Ignore("Options not implemented yet")]
        public void CanCompileSassCompressed()
        {
            var sass = "div { a { color: red; } }";
            _compilerOptions.OutputStyle = SassOutputStyle.Compressed;
            var compiledSass = _compiler.Compile(sass);
            compiledSass.Should().Be("div a{color:red;}");
        }
    }
}
