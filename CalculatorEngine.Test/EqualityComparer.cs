using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorEngine.Test
{
    internal abstract class EqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly IEnumerable<Func<T, T, bool>> comparers;
        private readonly Func<T, int> hashCodeEvaluator;

        public EqualityComparer(IEnumerable<Func<T, T, bool>> comparers)
            : this(comparers, null)
        { }

        public EqualityComparer(IEnumerable<Func<T, T, bool>> comparers, Func<T, int> hashCodeEvaluator)
        {
            this.comparers = comparers;
            this.hashCodeEvaluator = hashCodeEvaluator;
        }

        public bool Equals(T x, T y)
        {
            return this.comparers.All(comparer => comparer(x, y));
        }

        public int GetHashCode(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            if (this.hashCodeEvaluator == null)
                return 0;

            return this.hashCodeEvaluator(obj);
        }
    }
}
