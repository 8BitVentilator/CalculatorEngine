using CalculatorEngine.Tokens;
using System;

namespace CalculatorEngine.Test
{
    internal class ConstantTokenComparer : EqualityComparer<ConstantToken>
    {
        public ConstantTokenComparer()
            : base(new Func<ConstantToken, ConstantToken, bool>[] {
                (x, y) => x.Number == y.Number
            })
        { }
    }
}
