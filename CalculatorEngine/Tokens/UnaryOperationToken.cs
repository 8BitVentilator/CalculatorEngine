using CalculatorEngine.Nodes;
using System;

namespace CalculatorEngine.Tokens
{
    public abstract class UnaryOperationToken : IToken
    {
        public abstract Func<INode, INode> CreateNode { get; }

        internal UnaryOperationToken()
        { }
    }
}
