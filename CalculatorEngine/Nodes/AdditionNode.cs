namespace CalculatorEngine.Nodes
{
    public sealed class AdditionNode : BinaryOperationNode<decimal>
    {
        public AdditionNode(INode<decimal> left, INode<decimal> right)
            : base(left, right)
        { }

        public override decimal Evaluate() => this.Left.Evaluate() + this.Right.Evaluate();
    }
}
