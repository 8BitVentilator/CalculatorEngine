using System;

namespace CalculatorEngine.Nodes
{
    public sealed class ExponentiationNode : BinaryOperationNode
    {
        internal ExponentiationNode(INode left, INode right)
            : base(left, right)
        { }

        public override double Evaluate() => Math.Pow(this.Left.Evaluate(), this.Right.Evaluate());
    }
}
