namespace CalculatorEngine.Nodes
{
    public sealed class SubtractionNode : BinaryOperationNode
    {
        public SubtractionNode(INode left, INode right) 
            : base(left, right)
        { }

        public override double Evaluate() => this.Left.Evaluate() - this.Right.Evaluate();
    }
}
