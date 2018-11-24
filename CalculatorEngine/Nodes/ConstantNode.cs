namespace CalculatorEngine.Nodes
{
    public sealed class ConstantNode : INode
    {
        private readonly double value;

        public ConstantNode(double value)
        {
            this.value = value;
        }

        public double Evaluate() => this.value;
    }
}
