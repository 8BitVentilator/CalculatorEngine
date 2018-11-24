using System;
using CalculatorEngine.Nodes;

namespace CalculatorEngine.Tokens
{
    public sealed class NegationToken : UnaryOperationToken
    {
        public override Func<INode, INode> CreateNode => value => new NegationNode(value);
    }
}
