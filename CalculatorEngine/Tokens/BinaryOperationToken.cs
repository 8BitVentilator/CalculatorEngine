using CalculatorEngine.Nodes;
using System;

namespace CalculatorEngine.Tokens
{
    public enum Associativity
    {
        Left, Right
    }

    public abstract class BinaryOperationToken : IToken
    {
        public abstract int Precedence { get; }
        public abstract Associativity Associativity { get; }
        public abstract Func<INode, INode, INode> CreateNode { get; }

        internal BinaryOperationToken()
        { }
    }
}
