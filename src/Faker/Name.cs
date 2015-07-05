using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;

namespace Faker
{

    public enum NameFormats
    {
        Standard,
        WithPrefix,
        WithSuffix
    }

    public static class Name
    {

        /// <summary>
        /// Create a name using a random format.
        /// </summary>     
        public static string FullName()
        {
            return FullName(_formats.ElementAt(RandomNumber.Next(_formats.Count() - 1)));
        }

        /// <summary>
        /// Create a name using a specified format.
        /// </summary>        
        public static string FullName(NameFormats format)
        {
            return String.Join(" ", _formatMap[format].Invoke());
        }

        public static string First()
        {
            return Resources.Name.First.Split(Config.Separator).Random().Trim();
        }

        public static string Last()
        {
            return Resources.Name.Last.Split(Config.Separator).Random().Trim();
        }

        public static string Prefix()
        {
            return Resources.Name.Prefix.Split(Config.Separator).Random();
        }

        public static string Suffix()
        {
            return Resources.Name.Suffix.Split(Config.Separator).Random();
        }

        #region Format Mappings
        private static readonly IEnumerable<NameFormats> _formats = new List<NameFormats>
        {
            NameFormats.WithPrefix, NameFormats.WithSuffix, NameFormats.Standard, NameFormats.Standard, NameFormats.Standard, NameFormats.Standard, NameFormats.Standard, NameFormats.Standard, NameFormats.Standard
        };
        private static readonly IDictionary<NameFormats, Func<string[]>> _formatMap = new Dictionary<NameFormats, Func<string[]>>
        {
            { NameFormats.Standard,     () => new [] { First(), Last() } },
            { NameFormats.WithPrefix,   () => new [] { Prefix(), First(), Last() } },
            { NameFormats.WithSuffix,   () => new [] { First(), Last(), Suffix() } }
        };
        #endregion
    }
}