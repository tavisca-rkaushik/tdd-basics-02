using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        private CalculatorOperations operation = new CalculatorOperations();
        public string SendKeyPress(char key)
        {
            return operation.PerformOperation(key);
            throw new NotImplementedException();
        }
    }
}