namespace CalculatorEngine.Nodes
{
    public sealed class DivisionNode : BinaryOperationNode<decimal>
    {
        public DivisionNode(INode<decimal> left, INode<decimal> right)
            : base(left, right)
        { }

        public override decimal Evaluate() => this.Left.Evaluate() / this.Right.Evaluate();
    }
}
