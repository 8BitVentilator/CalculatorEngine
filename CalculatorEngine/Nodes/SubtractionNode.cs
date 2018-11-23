namespace CalculatorEngine.Nodes
{
    public sealed class SubtractionNode : BinaryOperationNode<decimal>
    {
        public SubtractionNode(INode<decimal> left, INode<decimal> right) 
            : base(left, right)
        { }

        public override decimal Evaluate() => this.Left.Evaluate() - this.Right.Evaluate();
    }
}
