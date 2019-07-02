using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class CalculatorOperations
    {
        private bool hasProcesed = true;
        private string operand1 = "";
        private string operand2 = "";
        private char? _operator = null;
        private string digits = "1234567890.";
        private string operators = "+-/xX";
        private string result = "0";

        private const string Error = "-E-";

        public string PerformOperation(char key)
        {
            if (digits.Contains(key.ToString()))
            {
                FormDigit(key);
            }
            else if (operators.Contains(key.ToString()))
            {
                ActionOnOperator(key);
            }

            else if (key == 'C' || key == 'c')
            {
                ClearConsole();
            }

            else if (key == 's' || key == 'S')
            {
                ToggleSign(key);
            }
            else if (key == '=')
            {
                if (_operator != null && operators.Contains(_operator.ToString()))
                {
                    operand1 = CalculateResult(operand1, operand2, _operator);
                };
                operand2 = "0";
            }
            return operand1;
        }

        private void ClearConsole()
        {
            operand1 = "0";
            operand2 = "0";
            hasProcesed = true;
        }

        private void FormDigit(char key)
        {
            if (hasProcesed)
            {
                if (IsValidDigit(operand1, key))
                    operand1 += key;
            }
            else
            {
                if (IsValidDigit(operand2, key))
                    operand2 += key;
            }
        }

        private void ActionOnOperator(char key)
        {
            if (_operator == null)
                _operator = key;
            if (hasProcesed)
            {
                hasProcesed = false;
            }
            else
            {
                operand1 = CalculateResult(operand1, operand2, _operator);
                operand2 = "0";
                if (_operator != null) _operator = key;
            }
        }

        private void ToggleSign(char key)
        {
            if (hasProcesed)
            {
                operand1 = $"{(Double.Parse(operand1) * -1)}";
            }
            else
            {
                operand2 = $"{(Double.Parse(operand2) * -1)}";
            }
        }
        private string CalculateResult(string operand1, string operand2, char? @operator)
        {
            double number1 = double.Parse(operand1);
            double number2 = double.Parse(operand2);

            switch (@operator)
            {
                case '+':
                    return $"{number1 + number2}";

                case '-':
                    return $"{number1 - number2}";

                case 'x':
                case 'X':
                    return $"{number1 * number2}";

                case '/':
                    if (number2 == 0)
                        return Error;
                    return $"{number1 / number2}";

                default:
                    return "0";
            }
        }

        private bool IsValidDigit(string number, char key)
        {
            if (number.Contains(".") && key == '.')
                return false;
            else if (number.Equals("0") && key == '0')
                return false;
            else return true;
        }
    }
}
