using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Faker.Extensions;

namespace Faker
{
    public static class Internet
    {
        public static string Email()
        {
            return String.Format("{0}@{1}", UserName(), DomainName());
        }

        public static string Email(string name)
        {
            return String.Format("{0}@{1}", UserName(name), DomainName());
        }

        public static string FreeEmail()
        {
            return String.Format("{0}@{1}", UserName(), Resources.Internet.FreeMail.Split(Config.Separator).Random());
        }

        public static string UserName()
        {
            return _userNameFormats.Random();
        }

        public static string UserName(string name)
        {
            return Regex.Replace(name, @"[^\w]+", new MatchEvaluator(x => new [] { ".", "_" }.Random()), RegexOptions.Compiled).ToLowerInvariant();
        }

        public static string DomainName()
        {
            return String.Format("{0}.{1}", DomainWord(), DomainSuffix());
        }

        public static string DomainWord()
        {
            return Company.Name().Split(' ').First().AlphanumericOnly().ToLowerInvariant();
        }

        public static string DomainSuffix()
        {
            return Resources.Internet.DomainSuffix.Split(Config.Separator).Random();
        }

        public static string IPv4Address()
        {
            Random random = new Random();
            int min = 2;
            int max = 255;
            string[] parts = new string[] {
                random.Next(min, max).ToString(),
                random.Next(min, max).ToString(),
                random.Next(min, max).ToString(),
                random.Next(min, max).ToString(),
            };
            return String.Join(".", parts);
        }

        public static string IPv6Address()
        {
            Random random = new Random();
            int min = 0;
            int max = 65536;
            string[] parts = new string[] {
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
            };
            return String.Join(":", parts);
        }

        public static string Url()
        {
            return String.Format("http://{0}/{1}", DomainName(), UserName());
        }

        private static readonly IEnumerable<Func<string>> _userNameFormats = new List<Func<string>>
        {
            () => Name.First().AlphanumericOnly().ToLowerInvariant(),
            () => string.Format("{0}{1}{2}", Name.First().AlphanumericOnly(), 
                new [] { ".", "_" }.Random(), Name.Last().AlphanumericOnly()).ToLowerInvariant()
        };
    }
}