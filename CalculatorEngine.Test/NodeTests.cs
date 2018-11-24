using CalculatorEngine.Nodes;
using Xunit;

namespace CalculatorEngine.Test
{
    public class NodeTests
    {
        [Fact]
        public void ConstantTest()
        {
            var sut = new ConstantNode(12.34);
            Assert.Equal(12.34, sut.Evaluate());
        }

        [Fact]
        public void Negate_of_Two()
        {
            var sut = new NegationNode(new ConstantNode(2));
            Assert.Equal(-2, sut.Evaluate());
        }

        [Fact]
        public void One_Plus_Two_Equals_Three()
        {
            var sut = new AdditionNode(new ConstantNode(1), new ConstantNode(2));
            Assert.Equal(3, sut.Evaluate());
        }

        [Fact]
        public void Three_Minus_Two_Equals_One()
        {
            var sut = new SubtractionNode(new ConstantNode(3), new ConstantNode(2));
            Assert.Equal(1, sut.Evaluate());
        }

        [Fact]
        public void Two_Multiplicate_By_Six_Equals_Twelve()
        {
            var sut = new MultiplicationNode(new ConstantNode(2), new ConstantNode(6));
            Assert.Equal(12, sut.Evaluate());
        }

        [Fact]
        public void Twelve_Divide_By_Six_Equals_Two()
        {
            var sut = new DivisionNode(new ConstantNode(12), new ConstantNode(6));
            Assert.Equal(2, sut.Evaluate());
        }
    }
}
