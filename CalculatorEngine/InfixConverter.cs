using CalculatorEngine.Tokens;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CalculatorEngine.Test")]
namespace CalculatorEngine
{
    internal class InfixConverter
    {
        public IEnumerable<IToken> ToPostfix(IEnumerable<IToken> tokens)
        {
            Stack<IToken> stack = new Stack<IToken>();
            Queue<IToken> result = new Queue<IToken>();

            foreach (IToken token in tokens)
            {
                if (token is ConstantToken)
                {
                    result.Enqueue(token);
                }
                else if (token is UnaryOperationToken)
                {
                    stack.Push(token);
                }
                // TODO Argumenttrennzeichen?
                else if (token is BinaryOperationToken)
                {
                    BinaryOperationToken operation = (BinaryOperationToken)token;

                    while (stack.Count != 0
                        && stack.Peek() is BinaryOperationToken
                        && operation.Associativity == Associativity.Left
                        && operation.Precedence <= ((BinaryOperationToken)stack.Peek()).Precedence)
                    {
                        result.Enqueue(stack.Pop());
                    }
                    stack.Push(token);
                }
                else if (token is LeftParenthesisToken)
                {
                    stack.Push(token);
                }
                else if (token is RightParenthesisToken)
                {
                    while (!(stack.Peek() is LeftParenthesisToken))
                    {
                        result.Enqueue(stack.Pop());
                    }
                    stack.Pop();
                }
            }

            while (stack.Count != 0)
            {
                result.Enqueue(stack.Pop());
            }

            return result;
        }
    }
}
