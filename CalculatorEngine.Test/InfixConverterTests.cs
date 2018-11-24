using CalculatorEngine.Tokens;
using System.Linq;
using Xunit;

namespace CalculatorEngine.Test
{
    public class InfixConverterTests
    {
        private readonly InfixConverter sut;
        private readonly ConstantTokenComparer constantTokenComparer;


        public InfixConverterTests()
        {
            this.sut = new InfixConverter();
            this.constantTokenComparer = new ConstantTokenComparer();
        }

        [Fact]
        public void One_Plus_Two()
        {
            // 1 + 2
            var infix = new IToken[]
            {
                new ConstantToken(1),
                new AdditionToken(),
                new ConstantToken(2)
            };

            // 1 2 +
            var postfix = this.sut.ToPostfix(infix).ToArray();

            Assert.Equal(3, postfix.Length);
            Assert.True(postfix[0] is ConstantToken);
            Assert.True(postfix[1] is ConstantToken);
            Assert.True(postfix[2] is AdditionToken);
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[0], new ConstantToken(1)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[1], new ConstantToken(2)));
        }

        [Fact]
        public void Wikipedia_Example_1()
        {
            // 1 + 2 * 3 - 4
            var infix = new IToken[]
            {
                new ConstantToken(1),
                new AdditionToken(),
                new ConstantToken(2),
                new MultiplicationToken(),
                new ConstantToken(3),
                new SubtractionToken(),
                new ConstantToken(4)
            };

            // 1 2 3 * + 4 -
            var postfix = this.sut.ToPostfix(infix).ToArray();

            Assert.Equal(7, postfix.Length);
            Assert.True(postfix[0] is ConstantToken);
            Assert.True(postfix[1] is ConstantToken);
            Assert.True(postfix[2] is ConstantToken);
            Assert.True(postfix[3] is MultiplicationToken);
            Assert.True(postfix[4] is AdditionToken);
            Assert.True(postfix[5] is ConstantToken);
            Assert.True(postfix[6] is SubtractionToken);

            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[0], new ConstantToken(1)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[1], new ConstantToken(2)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[2], new ConstantToken(3)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[5], new ConstantToken(4)));
        }

        [Fact]
        public void Wikipedia_Example_2()
        {
            // (3 + 4) * (5 − 6)
            var infix = new IToken[]
            {
                new LeftParenthesisToken(),
                new ConstantToken(3),
                new AdditionToken(),
                new ConstantToken(4),
                new RightParenthesisToken(),
                new MultiplicationToken(),
                new LeftParenthesisToken(),
                new ConstantToken(5),
                new SubtractionToken(),
                new ConstantToken(6),
                new RightParenthesisToken(),
            };

            // 3 4 + 5 6 - *
            var postfix = this.sut.ToPostfix(infix).ToArray();

            Assert.Equal(7, postfix.Length);
            Assert.True(postfix[0] is ConstantToken);
            Assert.True(postfix[1] is ConstantToken);
            Assert.True(postfix[2] is AdditionToken);
            Assert.True(postfix[3] is ConstantToken);
            Assert.True(postfix[4] is ConstantToken);
            Assert.True(postfix[5] is SubtractionToken);
            Assert.True(postfix[6] is MultiplicationToken);

            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[0], new ConstantToken(3)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[1], new ConstantToken(4)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[3], new ConstantToken(5)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[4], new ConstantToken(6)));
        }

        [Fact]
        public void Wikipedia_Example_3()
        {
            // 1 + 2 − 3 * 4 + 5 ^ 6 ^ 7 * 8 − 9
            var infix = new IToken[]
            {
                new ConstantToken(1),
                new AdditionToken(),
                new ConstantToken(2),
                new SubtractionToken(),
                new ConstantToken(3),
                new MultiplicationToken(),
                new ConstantToken(4),
                new AdditionToken(),
                new ConstantToken(5),
                new ExponentiationToken(),
                new ConstantToken(6),
                new ExponentiationToken(),
                new ConstantToken(7),
                new MultiplicationToken(),
                new ConstantToken(8),
                new SubtractionToken(),
                new ConstantToken(9)
            };

            // 1 2 + 3 4 * - 5 6 7 ^ ^ 8 * + 9 -
            var postfix = this.sut.ToPostfix(infix).ToArray();

            Assert.Equal(17, postfix.Length);
            Assert.True(postfix[0] is ConstantToken);
            Assert.True(postfix[1] is ConstantToken);
            Assert.True(postfix[2] is AdditionToken);
            Assert.True(postfix[3] is ConstantToken);
            Assert.True(postfix[4] is ConstantToken);
            Assert.True(postfix[5] is MultiplicationToken);
            Assert.True(postfix[6] is SubtractionToken);
            Assert.True(postfix[7] is ConstantToken);
            Assert.True(postfix[8] is ConstantToken);
            Assert.True(postfix[9] is ConstantToken);
            Assert.True(postfix[10] is ExponentiationToken);
            Assert.True(postfix[11] is ExponentiationToken);
            Assert.True(postfix[12] is ConstantToken);
            Assert.True(postfix[13] is MultiplicationToken);
            Assert.True(postfix[14] is AdditionToken);
            Assert.True(postfix[15] is ConstantToken);
            Assert.True(postfix[16] is SubtractionToken);

            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[0], new ConstantToken(1)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[1], new ConstantToken(2)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[3], new ConstantToken(3)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[4], new ConstantToken(4)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[7], new ConstantToken(5)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[8], new ConstantToken(6)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[9], new ConstantToken(7)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[12], new ConstantToken(8)));
            Assert.True(this.constantTokenComparer.Equals((ConstantToken)postfix[15], new ConstantToken(9)));

        }
    }
}
