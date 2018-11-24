using System;

namespace CalculatorEngine.Nodes
{
    public abstract class BinaryOperationNode : INode
    {
        protected INode Left { get; }
        protected INode Right { get; }

        internal BinaryOperationNode(INode left, INode right)
        {
            this.Left = left ?? throw new ArgumentNullException(nameof(left));
            this.Right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public abstract double Evaluate();
    }
}
