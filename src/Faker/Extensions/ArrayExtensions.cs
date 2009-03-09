using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Select a random element from the array.
        /// </summary>
        public static string Random(this string[] list)
        {
            if (list.Count() == 0) throw new InvalidOperationException("Array must contain at least one item");

            return list[RandomNumber.Next(0, list.Length)];
        }

        /// <summary>
        /// Select a random string from the Enumerable list.
        /// </summary>
        public static string Random(this IEnumerable<Func<string>> list)
        {
            if (list.Count() == 0) throw new InvalidOperationException("Enumerable list must contain at least one item");

            return list.ElementAt(RandomNumber.Next(0, list.Count())).Invoke();
        }

        /// <summary>
        /// Select a random string array from the Enumerable list.
        /// </summary>
        public static string[] Random(this IEnumerable<Func<string[]>> list)
        {
            if (list.Count() == 0) throw new InvalidOperationException("Enumerable list must contain at least one item");

            return list.ElementAt(RandomNumber.Next(0, list.Count())).Invoke();
        }
    }
}