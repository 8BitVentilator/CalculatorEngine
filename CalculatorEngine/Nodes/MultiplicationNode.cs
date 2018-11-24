namespace CalculatorEngine.Nodes
{
    public sealed class MultiplicationNode : BinaryOperationNode
    {
        public MultiplicationNode(INode left, INode right)
            : base(left, right)
        { }

        public override double Evaluate() => this.Left.Evaluate() * this.Right.Evaluate();
    }
}
