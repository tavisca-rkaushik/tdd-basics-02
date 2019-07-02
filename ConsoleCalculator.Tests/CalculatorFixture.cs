using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        Calculator calculator;

        public CalculatorFixture()
        {
            calculator = new Calculator();
        }

        public string ProcessOutput(string Input)
        {
            string Output = "";

            foreach (char token in Input)
            {
                Output = calculator.SendKeyPress(token);
            }
            return Output;
        }
        [Fact]
        public void TestCalculatorFixture()
        {
            Assert.IsType<Calculator>(calculator);
        }

        [Fact]
        public void TestSimpleOperation()
        {
            calculator.SendKeyPress('2');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('4');
            Assert.Equal("6", calculator.SendKeyPress('='));
        }

        [Fact]
        public void TestDoubleOperation()
        {
            calculator.SendKeyPress('2');
            calculator.SendKeyPress('x');
            calculator.SendKeyPress('4');
            calculator.SendKeyPress('X');
            calculator.SendKeyPress('3');
            Assert.Equal("24", calculator.SendKeyPress('='));
        }

        [Fact]
        public void TestAdditionAndMultiplication()
        {
            //2+4*6=36
            calculator.SendKeyPress('2');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('4');
            calculator.SendKeyPress('x');
            calculator.SendKeyPress('6');
            Assert.Equal("36", calculator.SendKeyPress('='));
        }

        [Fact]
        public void TestDivideByZero()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('/');
            calculator.SendKeyPress('0');
            Assert.Equal("-E-", calculator.SendKeyPress('='));
        }

        [Fact]
        public void TestMultipleZeroBeforeDecimal()
        {
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('.');
            calculator.SendKeyPress('1');
            Assert.Equal("0.1", calculator.SendKeyPress('='));
        }

        [Fact]
        public void TestDoubleDecimal()
        {
            calculator.SendKeyPress('1');
            calculator.SendKeyPress('0');
            calculator.SendKeyPress('.');
            calculator.SendKeyPress('.');
            calculator.SendKeyPress('2');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('4');
            Assert.Equal("14.2", calculator.SendKeyPress('='));
        }

        [Fact]
        public void TestCLearConsole()
        {
            //7+4 clear 6
            calculator.SendKeyPress('7');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('4');
            calculator.SendKeyPress('c');
            calculator.SendKeyPress('6');
            Assert.Equal("6", calculator.SendKeyPress('='));
        }

        //[Fact]
        /*public void TestP()
        {
            //-7+-6=-13
            calculator.SendKeyPress('7');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('4');
            calculator.SendKeyPress('s');
            Assert.Equal("-11", calculator.SendKeyPress('='));
        }*/

        [Fact]
        public void TestUnexpectedEnding()
        {
            //-7+-6=-13
            calculator.SendKeyPress('7');
            calculator.SendKeyPress('+');
            calculator.SendKeyPress('4');
            calculator.SendKeyPress('+');
            Assert.Equal("11", calculator.SendKeyPress('='));
        }
    }
}