namespace CalculatorEngine.Nodes
{
    public sealed class MultiplicationNode : BinaryOperationNode<decimal>
    {
        public MultiplicationNode(INode<decimal> left, INode<decimal> right)
            : base(left, right)
        { }

        public override decimal Evaluate() => this.Left.Evaluate() * this.Right.Evaluate();
    }
}
