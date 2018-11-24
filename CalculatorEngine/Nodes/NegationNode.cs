namespace CalculatorEngine.Nodes
{
    public sealed class NegationNode : UnaryOperationNode
    {
        public NegationNode(INode evaluable)
            : base(evaluable)
        { }

        public override double Evaluate() => -this.Value.Evaluate();
    }
}
