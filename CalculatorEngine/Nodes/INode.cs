namespace CalculatorEngine.Nodes
{
    public interface INode
    {
        object Evaluate();
    }

    public interface INode<T> : INode
    {
        new T Evaluate();
    }
}
