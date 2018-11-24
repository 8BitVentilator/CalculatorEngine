using CalculatorEngine.Tokens;
using Xunit;

namespace CalculatorEngine.Test
{
    public class TokenParserTests
    {
        private readonly TokenParser sut;

        public TokenParserTests()
        {
            this.sut = new TokenParser();
        }

        [Fact]
        public void ConstantTest()
        {
            var infix = new IToken[]
            {
                new ConstantToken(12.34)
            };

            Assert.Equal(12.34, this.sut.Parse(infix).Evaluate());
        }

        [Fact]
        public void Negate_of_Two()
        {
            var infix = new IToken[]
            {
                new NegationToken(),
                new ConstantToken(2)
            };

            Assert.Equal(-2, this.sut.Parse(infix).Evaluate());
        }

        [Fact]
        public void One_Plus_Two_Equals_Three()
        {
            var infix = new IToken[]
            {
                new ConstantToken(1),
                new AdditionToken(),
                new ConstantToken(2)
            };

            Assert.Equal(3, this.sut.Parse(infix).Evaluate());
        }

        [Fact]
        public void Three_Minus_Two_Equals_One()
        {
            var infix = new IToken[]
            {
                new ConstantToken(3),
                new SubtractionToken(),
                new ConstantToken(2)
            };

            Assert.Equal(1, this.sut.Parse(infix).Evaluate());
        }

        [Fact]
        public void Two_Multiplicate_By_Six_Equals_Twelve()
        {
            var infix = new IToken[]
            {
                new ConstantToken(2),
                new MultiplicationToken(),
                new ConstantToken(6)
            };

            Assert.Equal(12, this.sut.Parse(infix).Evaluate());
        }

        [Fact]
        public void Twelve_Divide_By_Six_Equals_Two()
        {
            var infix = new IToken[]
            {
                new ConstantToken(12),
                new DivisionToken(),
                new ConstantToken(6)
            };

            Assert.Equal(2, this.sut.Parse(infix).Evaluate());
        }
    }
}
