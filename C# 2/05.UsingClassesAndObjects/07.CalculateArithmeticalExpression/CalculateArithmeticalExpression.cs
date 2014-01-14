using System;
using System.Collections.Generic;
using System.Text;

class MathExpressionCalc
{
    public static List<string> functions = new List<string>() { "pow", "sqrt", "ln" };
    public static List<string> operators = new List<string>() { "+", "-", "*", "/" };
    public static List<string> brackets = new List<string>() { "(", ")" };

    static bool IsFunction(char symbol)
    {
        return (symbol == 's' || symbol == 'p' || symbol == 'l');
    }


    static int GetPriority(string symbol)
    {
        if (symbol == "+" || symbol == "-")
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    static List<string> SeparateTokens(string input)
    {
        List<string> separatedExpression = new List<string>();

        StringBuilder number = new StringBuilder();

        input = input.Replace(" ", "");

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '-' && (i == 0 || input[i - 1] == '(' || input[i - 1] == ','))
            {
                number.Append('-');
            }
            else if (char.IsDigit(input[i]) || input[i] == '.')
            {
                number.Append(input[i]);
            }
            else if (!char.IsDigit(input[i]) && input[i] != '.' && number.Length != 0)
            {
                separatedExpression.Add(number.ToString());
                number.Clear();
                i--;
            }

            else if (brackets.Contains(input[i].ToString()))
            {
                separatedExpression.Add(input[i].ToString());
            }

            else if (operators.Contains(input[i].ToString()))
            {
                separatedExpression.Add(input[i].ToString());
            }

            else if (input[i] == ',')
            {
                separatedExpression.Add(",");
            }

            else if (IsFunction(input[i]))
            {
                if (i + 1 < input.Length && input.Substring(i, 2) == "ln")
                {
                    separatedExpression.Add("ln");
                    i++;
                }
                else if (i + 2 < input.Length && input.Substring(i, 3) == "pow")
                {
                    separatedExpression.Add("pow");
                    i += 2;
                }
                else if (i + 3 < input.Length && input.Substring(i, 4) == "sqrt")
                {
                    separatedExpression.Add("sqrt");
                    i += 3;
                }
            }

            else
            {
                throw new ArgumentException("Invalid expression");
            }

        }

        if (number.Length != 0)
        {
            separatedExpression.Add(number.ToString());
        }

        return separatedExpression;
    }

    static Queue<string> ConvertToRPN(List<string> separatedExpression)
    {
        Queue<string> result = new Queue<string>();
        Stack<string> notUsedOperators = new Stack<string>();

        for (int i = 0; i < separatedExpression.Count; i++)
        {
            string currentToken = separatedExpression[i];
            double number;

            if (double.TryParse(currentToken, out number))
            {
                result.Enqueue(currentToken);
            }
            else if (functions.Contains(currentToken))
            {
                notUsedOperators.Push(currentToken);
            }
            else if (currentToken == ",")
            {
                if (notUsedOperators.Contains("(") == false || notUsedOperators.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets or function separator");
                }

                while (notUsedOperators.Peek() != "(")
                {
                    result.Enqueue(notUsedOperators.Pop());
                }
            }

            else if (operators.Contains(currentToken))
            {
                while (notUsedOperators.Count != 0 && operators.Contains(notUsedOperators.Peek()) && GetPriority(currentToken) <= GetPriority(notUsedOperators.Peek()))
                {
                    result.Enqueue(notUsedOperators.Pop());
                }

                notUsedOperators.Push(currentToken);
            }

            else if (currentToken == "(")
            {
                notUsedOperators.Push("(");
            }

            else if (currentToken == ")")
            {
                if (notUsedOperators.Contains("(") == false || notUsedOperators.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets position");
                }

                while (notUsedOperators.Peek() != "(")
                {
                    result.Enqueue(notUsedOperators.Pop());
                }

                notUsedOperators.Pop();

                if (notUsedOperators.Count != 0 && functions.Contains(notUsedOperators.Peek()))
                {
                    result.Enqueue(notUsedOperators.Pop());
                }
            }
        }

        while (notUsedOperators.Count != 0)
        {
            if (brackets.Contains(notUsedOperators.Peek()))
            {
                throw new ArgumentException("Invalid brackets position");
            }

            result.Enqueue(notUsedOperators.Pop());
        }

        return result;

    }

    static double CalculateExpressionAsRPN(Queue<string> expression)
    {
        Stack<double> resultAsStack = new Stack<double>();

        while (expression.Count != 0)
        {
            string currentToken = expression.Dequeue();
            double number;

            if (double.TryParse(currentToken, out number))
            {
                resultAsStack.Push(number);
            }
            else if (operators.Contains(currentToken))
            {
                if (resultAsStack.Count < 2)
                {
                    throw new ArgumentException("Invalid expression");
                }
                else
                {
                    double firstValue = resultAsStack.Pop();
                    double secondValue = resultAsStack.Pop();

                    switch (currentToken)
                    {
                        case "+":
                            resultAsStack.Push(firstValue + secondValue);
                            break;
                        case "-":
                            resultAsStack.Push(secondValue - firstValue);
                            break;
                        case "*":
                            resultAsStack.Push(firstValue * secondValue);
                            break;
                        case "/":
                            resultAsStack.Push(secondValue / firstValue);
                            break;
                    }
                }
            }

            else if (currentToken == "sqrt")
            {
                if (resultAsStack.Count < 1)
                {
                    throw new ArgumentException("Invalid expression");
                }

                double value = Math.Sqrt(resultAsStack.Pop());

                resultAsStack.Push(value);
            }

            else if (currentToken == "ln")
            {
                if (resultAsStack.Count < 1)
                {
                    throw new ArgumentException("Invalid expression");
                }

                double value = Math.Log(resultAsStack.Pop());

                resultAsStack.Push(value);
            }

            else if (currentToken == "pow")
            {
                if (resultAsStack.Count < 2)
                {
                    throw new ArgumentException("Invalid expression");
                }
                else
                {
                    double firstValue = resultAsStack.Pop();
                    double secondValue = resultAsStack.Pop();

                    double result = Math.Pow(secondValue, firstValue);

                    resultAsStack.Push(result);
                }
            }

        }

        if (resultAsStack.Count == 1)
        {
            double result = resultAsStack.Pop();

            return result;
        }
        else
        {
            throw new ArgumentException("Invalid expression");
        }
    }


    static void Main()
    {
        string input = Console.ReadLine();

        List<string> separated = SeparateTokens(input);

        Queue<string> expressionAsRPN = ConvertToRPN(separated);

        double resultOfExpression = CalculateExpressionAsRPN(expressionAsRPN);

        Console.WriteLine(resultOfExpression);
    }
}

