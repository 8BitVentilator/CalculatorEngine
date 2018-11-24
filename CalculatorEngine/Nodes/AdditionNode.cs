namespace CalculatorEngine.Nodes
{
    public sealed class AdditionNode : BinaryOperationNode
    {
        public AdditionNode(INode left, INode right)
            : base(left, right)
        { }

        public override double Evaluate() => this.Left.Evaluate() + this.Right.Evaluate();
    }
}
