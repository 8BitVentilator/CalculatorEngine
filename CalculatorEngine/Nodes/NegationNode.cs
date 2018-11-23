namespace CalculatorEngine.Nodes
{
    public sealed class NegationNode : UnaryOperationNode<decimal>
    {
        public NegationNode(INode<decimal> evaluable)
            : base(evaluable)
        { }

        public override decimal Evaluate() => -this.Value.Evaluate();
    }
}
