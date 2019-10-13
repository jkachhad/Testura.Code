using NUnit.Framework;
using Testura.Code.Statements;

namespace Testura.Code.Tests.Statements
{
    public class PreprecessorDirectiveStatementTests
    {
        private PreprocessorDirectiveStatement _preprocessorDirectiveStatement;

        [SetUp]
        public void SetUp()
        {
            _preprocessorDirectiveStatement = new PreprocessorDirectiveStatement();
        }

        [Test]
        public void Create_WhenCreatingIfPreprecessorDirective_ShouldGetPreprecessor()
        {
            Assert.AreEqual("#ifSomething", _preprocessorDirectiveStatement.If("Something").ToFullString());
        }

        [Test]
        public void Create_WhenCreatingEndIfPreprecessorDirective_ShouldGetPreprecessor()
        {
            Assert.AreEqual("#endif", _preprocessorDirectiveStatement.Endif().ToFullString());
        }

        [Test]
        public void Create_WhenCreatingElsePreprecessorDirective_ShouldGetPreprecessor()
        {
            Assert.AreEqual("#else", _preprocessorDirectiveStatement.Else().ToFullString());
        }

        [Test]
        public void Create_WhenCreatingDefinePreprecessorDirective_ShouldGetPreprecessor()
        {
            Assert.AreEqual("#defineSomething", _preprocessorDirectiveStatement.Define("Something").ToFullString());
        }

        [Test]
        public void Create_WhenCreatingUndefPreprecessorDirective_ShouldGetPreprecessor()
        {
            Assert.AreEqual("#undefSomething", _preprocessorDirectiveStatement.Undef("Something").ToFullString());
        }

        [Test]
        public void Create_WhenCreatingWarningPreprecessorDirective_ShouldGetPreprecessor()
        {
            Assert.AreEqual("#warningSomething", _preprocessorDirectiveStatement.Warning("Something").ToFullString());
        }

        [Test]
        public void Create_WhenCreatingErrorPreprecessorDirective_ShouldGetPreprecessor()
        {
            Assert.AreEqual("#errorSomething", _preprocessorDirectiveStatement.Error("Something").ToFullString());
        }

        [Test]
        public void Create_WhenCreatingLinePreprecessorDirective_ShouldGetPreprecessor()
        {
            Assert.AreEqual("#line350\"Something\"", _preprocessorDirectiveStatement.Line(350, "Something").ToFullString());
        }

        [Test]
        public void Create_WhenCreatingRegionPreprecessorDirective_ShouldGetPreprecessor()
        {
            Assert.AreEqual("#regionSomething", _preprocessorDirectiveStatement.Region( "Something").ToFullString());
        }

        [Test]
        public void Create_WhenCreatingEndRegionPreprecessorDirective_ShouldGetPreprecessor()
        {
            Assert.AreEqual("#endregion", _preprocessorDirectiveStatement.Endregion().ToFullString());
        }

        [Test]
        public void Create_WhenCreatingPragmaPreprecessorDirective_ShouldGetPreprecessor()
        {
            Assert.AreEqual("#pragmaSomething", _preprocessorDirectiveStatement.Pragma("Something").ToFullString());
        }
    }
}
