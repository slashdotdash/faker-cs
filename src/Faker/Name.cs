using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;

namespace Faker
{
    /// <summary>
    ///     Enumeration of which Name format to use in the <see cref="Name.FullName(NameFormats)" /> method.
    /// </summary>
    /// <include file='Docs/NameFormatsExample.xml' path='example' />
    [Flags]
    public enum NameFormats : byte
    {
        /// <summary>
        ///     The standard (First and Last name only).
        /// </summary>
        Standard = 1 << 0,

        /// <summary>
        ///     First and Last name with a Prefix.
        /// </summary>
        WithPrefix = 1 << 1,

        /// <summary>
        ///     First and Last name with a Suffix.
        /// </summary>
        WithSuffix = 1 << 2,

        /// <summary>
        ///     First Last name with both a Prefix and a Suffix.
        /// </summary>
        WithPrefixAndSuffix = WithPrefix | WithSuffix
    }

    /// <summary>
    ///     A collection of Personal name related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="false" />
    public static class Name
    {
        /// <summary>
        ///     Creates a random first name.
        /// </summary>
        /// <returns>The randomly created first name.</returns>
        public static string First()
        {
            return Resources.Name.First.Split(Config.SEPARATOR).Random().Trim();
        }

        /// <summary>
        ///     Creates a name using random format.
        /// </summary>
        /// <returns>The randomly created name.</returns>
        public static string FullName()
        {
            return FullName(s_formats.ElementAt(RandomNumber.Next(s_formats.Count() - 1)));
        }

        /// <summary>
        ///     Creates a random name using the specified format.
        /// </summary>
        /// <param name="format">The name format.</param>
        /// <returns>A random name with the specified format.</returns>
        /// <include file='Docs/NameFormatsExample.xml' path='example' />
        public static string FullName(NameFormats format)
        {
            return string.Join(" ", s_formatMap[format].Invoke());
        }

        /// <summary>
        ///     Creates a random Last name
        /// </summary>
        /// <returns>The randomly created last name.</returns>
        public static string Last()
        {
            return Resources.Name.Last.Split(Config.SEPARATOR).Random().Trim();
        }

        /// <summary>
        ///     Creates a random prefix.
        /// </summary>
        /// <returns>The randomly created prefix.</returns>
        public static string Prefix()
        {
            return Resources.Name.Prefix.Split(Config.SEPARATOR).Random();
        }

        /// <summary>
        ///     Creates a random suffix.
        /// </summary>
        /// <returns>The randomly created suffix.</returns>
        public static string Suffix()
        {
            return Resources.Name.Suffix.Split(Config.SEPARATOR).Random();
        }

        #region Format Mappings

        private static readonly IEnumerable<NameFormats> s_formats = new[]
        {
            NameFormats.WithPrefix, NameFormats.WithSuffix, NameFormats.WithPrefixAndSuffix, NameFormats.Standard,
            NameFormats.Standard,
            NameFormats.Standard, NameFormats.Standard, NameFormats.Standard, NameFormats.Standard, NameFormats.Standard,
            NameFormats.Standard, NameFormats.Standard
        };

        private static readonly IDictionary<NameFormats, Func<string[]>> s_formatMap = new Dictionary
            <NameFormats, Func<string[]>>
        {
            {NameFormats.Standard, () => new[] {First(), Last()}},
            {NameFormats.WithPrefix, () => new[] {Prefix(), First(), Last()}},
            {NameFormats.WithSuffix, () => new[] {First(), Last(), Suffix()}},
            {NameFormats.WithPrefixAndSuffix, () => new[] {Prefix(), First(), Last(), Suffix()}}
        };

        #endregion
    }
}
