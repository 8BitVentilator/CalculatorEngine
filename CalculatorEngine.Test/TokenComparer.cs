using CalculatorEngine.Tokens;
using System;
using System.Collections.Generic;

namespace CalculatorEngine.Test
{
    internal class TokenComparer : EqualityComparer<IToken>
    {
        public TokenComparer()
            : base(new Func<IToken, IToken, bool>[]
            {
                (x, y) => x.GetType() == y.GetType(),
                (x, y) => x is ConstantToken
                            ? ((ConstantToken)x).Number == ((ConstantToken)y).Number
                            : false
            })
        { }
    }
}
