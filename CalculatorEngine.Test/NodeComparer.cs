using CalculatorEngine.Nodes;
using System;

namespace CalculatorEngine.Test
{
    internal class NodeComparer : EqualityComparer<INode>
    {
        public NodeComparer()
            : base(new Func<INode, INode, bool>[]
            {
                (x, y) => x.GetType() == y.GetType(),
                (x, y) => x is ConstantNode 
                            ? ((ConstantNode)x).Evaluate() == ((ConstantNode)y).Evaluate()
                            : x is UnaryOperationNode 
                                ? new NodeComparer().Equals(((UnaryOperationNode)x).Value, ((UnaryOperationNode)y).Value)
                                : x is BinaryOperationNode
                                    ? new NodeComparer().Equals(((BinaryOperationNode)x).Left, ((BinaryOperationNode)y).Left)
                                        && new NodeComparer().Equals(((BinaryOperationNode)x).Right, ((BinaryOperationNode)y).Right)
                                : false
            })
        { }
    }
}