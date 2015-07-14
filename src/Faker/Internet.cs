using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Faker.Extensions;

namespace Faker
{
    /// <summary>
    ///     A collection of address related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="false" />
    public static class Internet
    {
        private static readonly IEnumerable<Func<string>> s_userNameFormats = new Func<string>[]
        {
            () => Name.First().AlphanumericOnly(),
            () => string.Format(CultureInfo.CurrentCulture, "{0}{1}{2}", Name.First().AlphanumericOnly(),
                                new[] {".", "_"}.Random(), Name.Last().AlphanumericOnly())
        };

        /// <summary>
        ///     Generates the name of a random domain.
        /// </summary>
        /// <returns>The random domain name.</returns>
        public static string DomainName()
        {
            var prefix = new[] {string.Empty, "www.", "www2."};

            return string.Format("{0}{1}.{2}", prefix.Random(), DomainWord(), DomainSuffix());
        }

        /// <summary>
        ///     Generates a random domain suffix (ex. com,net,info etc.).
        /// </summary>
        /// <returns>A random Domain suffix.</returns>
        public static string DomainSuffix()
        {
            return Resources.Internet.DomainSuffix.Split(Config.SEPARATOR).Random();
        }

        /// <summary>
        ///     Generates a random domain word.
        /// </summary>
        /// <returns>The random domain word.</returns>
        public static string DomainWord()
        {
            return Company.Name().Split(' ').First().AlphanumericOnly().ToLowerInvariant();
        }

        /// <summary>
        ///     Generates a random email address.
        /// </summary>
        /// <returns>A random email address.</returns>
        public static string Email()
        {
            return string.Format("{0}@{1}", UserName(), DomainName());
        }

        /// <summary>
        ///     Generates a random email address.
        /// </summary>
        /// <param name="name">The name to generate the username from.</param>
        /// <returns>The random email address, with the generated username.</returns>
        public static string Email(string name)
        {
            return string.Format("{0}@{1}", UserName(name), DomainName());
        }

        /// <summary>
        ///     Generates a random free email address.
        /// </summary>
        /// <returns>The random free email address.</returns>
        /// <example>
        ///     <code language="cs">
        /// var email = Faker.Internet.FreeEmail();
        /// 
        /// Console.WriteLine("Result = " + email);
        /// // Result = abe.linky@gmail.com
        /// </code>
        /// </example>
        public static string FreeEmail()
        {
            return string.Format("{0}@{1}", UserName(), Resources.Internet.FreeMail.Split(Config.SEPARATOR).Random());
        }

        /// <summary>
        ///     Gets a random URL.
        /// </summary>
        /// <returns>A random URL.</returns>
        public static string Url()
        {
            string protocol = new[] {"http", "https"}.Random();

            return string.Format("{0}://{1}/{2}", protocol, DomainName(), UserName());
        }

        /// <summary>
        ///     Gets a random ip v4 address.
        /// </summary>
        /// <returns>A random ip v4 address.</returns>
        // ReSharper disable once InconsistentNaming
        public static string IPv4Address()
        {
            const int min = 2;
            const int max = 255;

            return string.Join(".", 4.Times(c => RandomNumber.Next(min, max).ToString()));
        }

        /// <summary>
        ///     Gets a random ip v6 address.
        /// </summary>
        /// <returns>A random ip v6 address.</returns>
        // ReSharper disable once InconsistentNaming
        public static string IPv6Address()
        {
            const int min = 0;
            const int max = 65536;

            return string.Join(":", 8.Times(c => RandomNumber.Next(min, max).ToString("x")));
        }

        /// <summary>
        ///     Generates a random username.
        /// </summary>
        /// <returns>The random username.</returns>
        public static string UserName()
        {
            return UserName(s_userNameFormats.Random());
        }

        /// <summary>
        ///     Generates a random username.
        /// </summary>
        /// <param name="name">The name to generate the user name from.</param>
        /// <returns>The generated username.</returns>
        public static string UserName(string name)
        {
            return Regex.Replace(name, @"[^\w]+", x => new[] {".", "_"}.Random()).ToLowerInvariant();
        }
    }
}
