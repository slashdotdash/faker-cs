using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Extensions
{
    /// <summary>
    ///     A collection of Enumerable helper extensions.
    /// </summary>
    /// <threadsafety static="true" />
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Select a random element from the Func Enumerable list
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="list">The list.</param>
        /// <returns>The selected element from the Enumerable list.</returns>
        /// <exception cref="System.InvalidOperationException">Enumerable list must contain at least one item</exception>
        /// <example>
        ///     <code source="..\src\Faker\Address.cs" language="CSharp" region="Random Example"></code>
        /// </example>
        public static TResult Random<TResult>(this IEnumerable<Func<TResult>> list)
        {
            IEnumerable<Func<TResult>> enumerable = list as Func<TResult>[] ?? list.ToArray();
            if (!enumerable.Any())
                throw new InvalidOperationException("Enumerable list must contain at least one item");

            return enumerable.ElementAt(RandomNumber.Next(0, enumerable.Count())).Invoke();
        }

        /// <summary>
        ///     Calls the specified <paramref name="func">function</paramref> according to the specified <paramref name="count" />
        /// </summary>
        /// <typeparam name="T">The type of item the function returns.</typeparam>
        /// <param name="count">How many times to call the function.</param>
        /// <param name="func">The function to call.</param>
        /// <returns>An enumerable of the result from the called function.</returns>
        public static IEnumerable<T> Times<T>(this int count, Func<int, T> func)
        {
            for (var i = 0; i < count; i++)
                // ReSharper disable once EventExceptionNotDocumented
                yield return func.Invoke(i);
        }
    }
}
