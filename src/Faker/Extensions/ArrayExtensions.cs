using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Extensions
{
    public static class ArrayExtensions
    {
        private static readonly Random _rnd = new Random();

        /// <summary>
        /// Select a random element from the IEnumerable list.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Random(this string[] list)
        {
            if (list.Count() == 0) throw new InvalidOperationException("Array must contain at least one item");

            return list[_rnd.Next(list.Length - 1)];
        }
    }
}