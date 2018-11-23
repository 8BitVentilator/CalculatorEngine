using System;

namespace CalculatorEngine.Nodes
{
    public abstract class UnaryOperationNode<T> : Node<T>
    {
        protected INode<T> Value { get; }

        internal UnaryOperationNode(INode<T> value)
        {
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
