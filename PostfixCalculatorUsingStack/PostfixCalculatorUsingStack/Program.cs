using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixCalculatorUsingStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            foreach(string token in args)
            {
                int value;
                if(int.TryParse(token, out value))
                {
                    stack.Push(value);
                }
                else
                {
                    int rhs = stack.Pop();
                    int lhs = stack.Pop();
                    
                    switch (token)
                    {
                        case "+":
                            stack.Push(lhs+rhs);
                            break;
                        case "-":
                            stack.Push(lhs - rhs);
                            break;
                        case "*":
                            stack.Push(lhs * rhs);
                            break;
                        default:
                            throw new ArgumentException(string.Format("Unrecognized token: {0}",token));
                         
                    }
                }
            }

            Console.WriteLine(stack.Pop());
            Console.ReadKey();
        }
    }
}
