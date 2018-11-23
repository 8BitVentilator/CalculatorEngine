namespace CalculatorEngine.Nodes
{
    public abstract class Node<T> : INode<T>
    {
        public abstract T Evaluate();

        object INode.Evaluate() => this.Evaluate();

        internal Node()
        { }
    }
}
