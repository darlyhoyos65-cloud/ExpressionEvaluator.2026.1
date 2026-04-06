using System.Globalization;

namespace ExpressionEvaluator.Core
{
    public static class Evaluator
    {
        public static double Evaluate(string infix)
        {
            var tokens = Tokenize(infix);
            var postfix = InfixToPostfix(tokens);
            return EvaluatePostfix(postfix);
        }

        private static List<string> Tokenize(string infix)
        {
            var tokens = new List<string>();
            string number = "";

            foreach (char c in infix)
            {
                if (char.IsWhiteSpace(c))
                    continue;

                if (char.IsDigit(c) || c == '.')
                {
                    number += c;
                }
                else if (IsOperator(c) || c == '(' || c == ')')
                {
                    if (number != "")
                    {
                        tokens.Add(number);
                        number = "";
                    }

                    tokens.Add(c.ToString());
                }
                else
                {
                    throw new Exception($"Carácter no válido: {c}");
                }
            }

            if (number != "")
            {
                tokens.Add(number);
            }

            return tokens;
        }

        private static List<string> InfixToPostfix(List<string> tokens)
        {
            var output = new List<string>();
            var operators = new Stack<string>();

            foreach (var token in tokens)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                {
                    output.Add(token);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        output.Add(operators.Pop());
                    }

                    if (operators.Count == 0)
                        throw new Exception("Paréntesis desbalanceados.");

                    operators.Pop();
                }
                else if (IsOperator(token))
                {
                    while (operators.Count > 0 &&
                           operators.Peek() != "(" &&
                           Precedence(operators.Peek()) >= Precedence(token))
                    {
                        output.Add(operators.Pop());
                    }

                    operators.Push(token);
                }
            }

            while (operators.Count > 0)
            {
                if (operators.Peek() == "(")
                    throw new Exception("Paréntesis desbalanceados.");

                output.Add(operators.Pop());
            }

            return output;
        }

        private static double EvaluatePostfix(List<string> postfix)
        {
            var stack = new Stack<double>();

            foreach (var token in postfix)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    stack.Push(number);
                }
                else if (IsOperator(token))
                {
                    if (stack.Count < 2)
                        throw new Exception("Sintaxis incorrecta.");

                    double b = stack.Pop();
                    double a = stack.Pop();

                    double result = token switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => b == 0 ? throw new DivideByZeroException("No se puede dividir entre cero.") : a / b,
                        "^" => Math.Pow(a, b),
                        _ => throw new Exception("Operador inválido.")
                    };

                    stack.Push(result);
                }
            }

            if (stack.Count != 1)
                throw new Exception("Sintaxis incorrecta.");

            return stack.Pop();
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
        }

        private static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "^";
        }

        private static int Precedence(string op)
        {
            return op switch
            {
                "+" => 1,
                "-" => 1,
                "*" => 2,
                "/" => 2,
                "^" => 3,
                _ => 0
            };
        }
    }
}