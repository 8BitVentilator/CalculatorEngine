using System;
using CalculatorEngine.Nodes;

namespace CalculatorEngine.Tokens
{
    public sealed class SubtractionToken : BinaryOperationToken
    {
        public override int Precedence => 2;
        public override Associativity Associativity => Associativity.Left;
        public override Func<INode, INode, INode> CreateNode => (left, right) => new SubtractionNode(left, right);
    }
}
