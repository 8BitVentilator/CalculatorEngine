using System;
using CalculatorEngine.Nodes;

namespace CalculatorEngine.Tokens
{
    public sealed class ExponentiationToken : BinaryOperationToken
    {
        public override int Precedence => 4;
        public override Associativity Associativity => Associativity.Right;
        public override Func<INode, INode, INode> CreateNode => (left, right) => new ExponentiationNode(left, right);
    }
}
