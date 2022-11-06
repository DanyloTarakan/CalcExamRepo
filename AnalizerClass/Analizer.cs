using System;
using System.Collections.Generic;
using Cacl;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizerClass
{
    public class Analizer
    {
        static public double Calculate(string input)
        {
            string output = GetExpression(input);
            double result = Counting(output);
            return result;
        }
        static private string GetExpression(string input)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (IsDelimeter(input[i]))
                    continue;

                if (Char.IsDigit(input[i]))
                {
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        i++;

                        if (i == input.Length) break;
                    }

                    output += " ";
                    i--;
                }
                else if (IsOperator(input[i]))
                {
                    if (i != 0)
                    {
                        if (IsOperator(input[i - 1]) && !IsPriorityOperator(input[i - 1]) && !IsPriorityOperator(input[i]))
                            throw (new Exception($"Two consecutive operators on the <{i}> character"));
                    }

                    if (input[i] == '(')
                        operStack.Push(input[i]);
                    else if (input[i] == ')')
                    {
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count > 0)
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                                output += operStack.Pop().ToString() + " ";

                        operStack.Push(char.Parse(input[i].ToString()));

                    }
                }
                else
                {
                    throw (new Exception($"Unknown operator on <{i}> character"));
                }
            }

            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            if (output.Split(' ').Length > 30)
                throw (new Exception("The total number of numbers and operators exceeds 30"));

            if (output.Length > 65536)
                throw (new Exception("A very long expression. The maximum length is 65536 characters"));

            if (output.Contains('(') || output.Contains(')'))
                throw (new Exception("Incorrect structure in parentheses"));

            return output;
        }
        static private double Counting(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }
                else if (IsOperator(input[i]))
                {
                    try
                    {
                        double a = temp.Pop();
                        double b = temp.Pop();

                        switch (input[i])
                        {
                            case '+': result = Calcu.Sum(b, a); break;
                            case '-': result = Calcu.Min(b, a); break;
                            case '*': result = Calcu.Mul(b, a); break;
                            case '/': result = Calcu.Div(b, a); break;
                            case '%': result = Calcu.Mod(b, a); break;
                        }
                        temp.Push(result);
                    }
                    catch
                    {
                        throw (new Exception("An incomplete expression"));
                    }

                }
            }
            return temp.Peek();
        }
        static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private bool IsOperator(char c)
        {
            if (("+-/*%()".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private bool IsPriorityOperator(char c)
        {
            if (("()".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '%': return 4;
                default: return 5;
            }
        }
    }
}
