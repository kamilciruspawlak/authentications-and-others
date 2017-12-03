using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using StringCalculator;

namespace StringCalculatorTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private Calculator _calculator;
        [SetUp]
        public void Init()
        {
            _calculator = new Calculator();
        }
        [Test]
        public void Should_ReturEnmptyString_WhenInputIsEmptyString()
       { 
           
            var result = _calculator.Add(string.Empty);
            Assert.AreEqual(0,result);
        }
        [Test]
        public void Should_ReturnOne_WhenInputIsOne()
        {
            
            var result = _calculator.Add("1");
            Assert.AreEqual(1,result);
        }

        [Test]
        public void Should_ReturnSum_WhenInputIsTwoNumbers()
        {
            
            var result = _calculator.Add("1,2");
            Assert.AreEqual(3,result);
        }

        [Test]
        public void Should_ReturnSum_WhenInputIsThreeNumbers()
        {
            var result = _calculator.Add("1,2,4");
            Assert.AreEqual(7,result);
        }

        [Test]
        public void Should_ReturnSum_WhenSeparatorIsNewLine()
        {
            var result = _calculator.Add("1\n2,4");
            Assert.AreEqual(7, result);
        }

        [Test]
        public void Should_ThrowInvalidInputException_WhenCombineTwoSeparators()
        {
            Assert.That(()=>_calculator.Add("1,\n"),Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Should_ReturnSum_WhenIntroduceCustomSeparator()
        {
            var result = _calculator.Add("//;\n1;2");
            Assert.AreEqual(3,result);
        }

        [Test]
        public void Should_ThrowNotAllowedException_WhenInputIsNegativeNumber()
        {
            var ex = Assert.Throws<ArgumentException>(() => _calculator.Add("1,-3"));
            Assert.That(ex.Message, Is.EqualTo("Negatives not allowed: -3"));
        }
    }
}
