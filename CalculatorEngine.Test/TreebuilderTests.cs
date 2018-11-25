using CalculatorEngine.Nodes;
using CalculatorEngine.Tokens;
using Xunit;

namespace CalculatorEngine.Test
{
    public class TreebuilderTests
    {
        TreeBuilder sut;

        public TreebuilderTests()
        {
            this.sut = new TreeBuilder();
        }

        [Fact]
        public void One_Two_Plus()
        {
            // 1 2 +
            var postfix = new IToken[]
            {
                new ConstantToken(1),
                new ConstantToken(2),
                new AdditionToken()
            };
            //    +
            //   / \
            //  1   2
            var actual = this.sut.Build(postfix);

            Assert.True(actual is AdditionNode);
            Assert.True(((AdditionNode)actual).Left is ConstantNode);
            Assert.True(((AdditionNode)actual).Right is ConstantNode);
            Assert.Equal(1, ((AdditionNode)actual).Left.Evaluate());
            Assert.Equal(2, ((AdditionNode)actual).Right.Evaluate());
        }

        [Fact]
        public void Wikipedia_Example_1()
        {
            // infix: 
            // 1 2 3 * + 4 -
            var postfix = new IToken[]
            {
                new ConstantToken(1),
                new ConstantToken(2),
                new ConstantToken(3),
                new MultiplicationToken(),
                new AdditionToken(),
                new ConstantToken(4),
                new SubtractionToken(),
            };

            var actual = this.sut.Build(postfix);

            //      -
            //     / \
            //    +   4
            //   / \
            //  1   *
            //     / \
            //    2   3
            var expected =
                new SubtractionNode(
                    new AdditionNode(
                        new ConstantNode(1),
                        new MultiplicationNode(
                            new ConstantNode(2),
                            new ConstantNode(3))),
                    new ConstantNode(4));

            Assert.True(new NodeComparer().Equals(expected, actual));
        }
    }
}
