using System;
using CalculatorEngine.Nodes;

namespace CalculatorEngine.Tokens
{
    public sealed class MultiplicationToken : BinaryOperationToken
    {
        public override int Precedence => 3;
        public override Associativity Associativity => Associativity.Left;
        public override Func<INode, INode, INode> CreateNode => (left, right) => new MultiplicationNode(left, right);
    }
}
