using CalculatorEngine.Nodes;
using CalculatorEngine.Tokens;
using System.Collections.Generic;

namespace CalculatorEngine
{
    internal class TreeBuilder
    {
        public INode Build(IEnumerable<IToken> tokens)
        {
            Stack<INode> stack = new Stack<INode>();

            foreach (IToken token in tokens)
            {
                if (token is ConstantToken)
                    stack.Push(((ConstantToken)token).CreateNode());
                else if (token is UnaryOperationToken)
                    stack.Push(((UnaryOperationToken)token).CreateNode(stack.Pop()));
                else if (token is BinaryOperationToken)
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    stack.Push(((BinaryOperationToken)token).CreateNode(left, right));
                }           
            }

            return stack.Pop();
        }
    }
}
