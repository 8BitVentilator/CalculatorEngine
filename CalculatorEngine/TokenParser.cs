using CalculatorEngine.Nodes;
using CalculatorEngine.Tokens;
using System.Collections.Generic;

namespace CalculatorEngine
{
    public class TokenParser
    {
        private readonly InfixConverter converter = new InfixConverter();
        private readonly TreeBuilder builder = new TreeBuilder();

        public INode Parse(IEnumerable<IToken> tokens)
        {
            return this.builder.Build(this.converter.ToPostfix(tokens));
        }
    }
}
