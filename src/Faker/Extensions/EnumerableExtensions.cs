using System;
using System.Collections.Generic;

namespace Faker.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Times<T>(this int count, Func<int, T> func)
        {
            for (var i = 0; i < count; i++)
                yield return func.Invoke(i);
        }
    }
}