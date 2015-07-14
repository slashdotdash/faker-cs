using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Faker.Extensions
{
    /// <summary>
    ///     A collection of Array helper extensions
    /// </summary>
    /// <threadsafety static="true" />
    [SuppressMessage("ReSharper", "UseNameofExpression")]
    public static class ArrayExtensions
    {
        /// <summary>
        ///     Select a random element from the array.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="list">The list.</param>
        /// <returns>The selected element from the array.</returns>
        /// <exception cref="System.InvalidOperationException">Array must contain at least one item</exception>
        public static TResult Random<TResult>(this TResult[] list)
        {
            if (!list.Any())
                throw new InvalidOperationException("Array must contain at least one item");

            return list[RandomNumber.Next(0, list.Length)];
        }

        /// <summary>
        ///     Selects a random character from the specified <paramref name="source" />
        /// </summary>
        /// <param name="source">The source containing characters to select from.</param>
        /// <returns>System.Char.</returns>
        /// <exception cref="System.ArgumentNullException">source is <c>null</c></exception>
        /// <exception cref="System.ArgumentException">The specified source can not be an empty string.</exception>
        public static char Random(this string source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (source.Trim() == string.Empty)
                throw new ArgumentException("The specified source can not be an empty string.", "source");

            return source[RandomNumber.Next(0, source.Length)];
        }

        /// <summary>
        ///     A small helper methods which splits a resource string and selects a random item.
        /// </summary>
        /// <param name="resourceString">The resource string.</param>
        /// <returns>The selected item.</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="resourceString" /> is <see langword="null" />.</exception>
        public static string RandomResource(this string resourceString)
        {
            if (resourceString == null)
                throw new ArgumentNullException("resourceString");

            return resourceString.Split(Config.SEPARATOR).Random().Trim();
        }
    }
}
