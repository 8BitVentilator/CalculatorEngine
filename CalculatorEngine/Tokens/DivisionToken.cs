using CalculatorEngine.Nodes;
using System;

namespace CalculatorEngine.Tokens
{
    public sealed class DivisionToken : BinaryOperationToken
    {
        public override int Precedence => 3;
        public override Associativity Associativity => Associativity.Left;
        public override Func<INode, INode, INode> CreateNode => (left, right) => new DivisionNode(left, right);
    }
}
