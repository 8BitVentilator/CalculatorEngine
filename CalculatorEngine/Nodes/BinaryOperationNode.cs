using System;

namespace CalculatorEngine.Nodes
{
    public abstract class BinaryOperationNode<T> : Node<T>
    {
        protected INode<T> Left { get; }
        protected INode<T> Right { get; }

        internal BinaryOperationNode(INode<T> left, INode<T> right)
        {
            this.Left = left ?? throw new ArgumentNullException(nameof(left));
            this.Right = right ?? throw new ArgumentNullException(nameof(right));
        }
    }
}
