using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Faker.Tests.Extensions
{
    class EnumerableExtensions
    {
    }

    public static class NumberExtensions
    {
        public static IEnumerable<T> Times<T>(this int count, Func<int, T> func)
        {
            for (var i = 0; i < count; i++)
                yield return func.Invoke(i);
        }
    }
}
