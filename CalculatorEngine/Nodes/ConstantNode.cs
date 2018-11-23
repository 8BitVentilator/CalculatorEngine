namespace CalculatorEngine.Nodes
{
    public sealed class ConstantNode : Node<decimal>
    {
        private readonly decimal value;

        public ConstantNode(decimal value)
        {
            this.value = value;
        }

        public override decimal Evaluate() => this.value;
    }
}
