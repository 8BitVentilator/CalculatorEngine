using System;

namespace CalculatorEngine.Nodes
{
    public abstract class UnaryOperationNode : INode
    {
        public INode Value { get; }

        internal UnaryOperationNode(INode value)
        {
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public abstract double Evaluate();
    }
}
