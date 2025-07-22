using System.Text;

namespace Bonus_task___Mathematical_expression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mathExpression = Console.ReadLine(); 
            double result = Evaluate(mathExpression);

            Console.WriteLine($"This expression is equal to: {result}");
        }

        static double Evaluate(string expression)
        {
            Stack<double> numbers = new Stack<double>();
            Stack<char> operators = new Stack<char>();
            string validOperators = "+-*/^";

            for (int i = 0; i < expression.Length; i++)
            {
                char character = expression[i];
                if (character == '(')
                {
                    operators.Push(character);
                }
                else if (character == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        char @operator = operators.Pop();
                        double firstNum = numbers.Pop();
                        double secondNum = numbers.Pop();

                        double newValue = ApplyOperation(@operator, secondNum, firstNum);
                        numbers.Push(newValue);
                    }

                    operators.Pop();
                }
                else if (validOperators.Contains(character))
                {
                    if (character == '-' && operators.Count > 0 && operators.Peek() == '+')
                    {
                        operators.Pop();
                    }

                    while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(character))
                    {
                        char @operator = operators.Pop();
                        double secondNum = numbers.Pop();
                        double firstNum = numbers.Pop();

                        double newValue = ApplyOperation(@operator, firstNum, secondNum);
                        numbers.Push(newValue);
                    }

                    operators.Push(character);
                }
                else if (char.IsDigit(character) || character == '.')
                {
                    StringBuilder number = new StringBuilder();
                    while (char.IsDigit(character) || character == '.')
                    {
                        number.Append(character);
                        i++;

                        if (i == expression.Length)
                        {
                            break;
                        }

                        character = expression[i];
                    }

                    i--;
                    numbers.Push(double.Parse(number.ToString()));
                }
            }

            while (operators.Count > 0)
            {
                char @operator = operators.Pop();
                double firstNum = numbers.Pop();
                double secondNum = numbers.Pop();

                double newValue = ApplyOperation(@operator, secondNum, firstNum);
                numbers.Push(newValue);
            }

            return numbers.Peek();
        }

        static double ApplyOperation(char operation, double operand1, double operand2)
        {
            switch (operation)
            {
                case '+': return operand1 + operand2;
                case '-': return operand1 - operand2;
                case '*': return operand1 * operand2;
                case '/': return operand1 / operand2;
                case '^': return Math.Pow(operand1, operand2);
                default: return 0.0;
            }
        }

        static int Priority(char operation)
        {
            switch (operation)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                case '^': return 3;
                default: return 0;
            }
        }
    }
}