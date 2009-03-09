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
            return String.Format("{0}@{1}", UserName(), new[] {"gmail.com", "yahoo.com", "hotmail.com"}.Random());
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
            return _domainSuffixes.Random();
        }

        private static readonly IEnumerable<Func<string>> _userNameFormats = new List<Func<string>>
        {
            () => Name.First().AlphanumericOnly().ToLowerInvariant(),
            () => string.Format("{0}{1}{2}", Name.First().AlphanumericOnly(), 
                new [] { ".", "_" }.Random(), Name.Last().AlphanumericOnly()).ToLowerInvariant()
        };
        private static readonly string[] _domainSuffixes = new [] { "co.uk", "com", "us", "uk", "ca", "biz", "info", "name" };
    }
}