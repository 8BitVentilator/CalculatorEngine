namespace CalculatorEngine.Nodes
{
    public sealed class DivisionNode : BinaryOperationNode
    {
        public DivisionNode(INode left, INode right)
            : base(left, right)
        { }

        public override double Evaluate() => this.Left.Evaluate() / this.Right.Evaluate();
    }
}
