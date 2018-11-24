using CalculatorEngine.Nodes;
using System;

namespace CalculatorEngine.Tokens
{
    public sealed class ConstantToken : IToken
    {
        public double Number { get; }

        public ConstantToken(double number)
        {
            this.Number = number;
        }

        public Func<INode> CreateNode => () => new ConstantNode(this.Number);
    }
}
