using System;
using NUnit.Framework;

namespace Faker.Tests
{
    internal static class TestHelpers
    {
        public static void AssertFormats(this string actual, string expectedFormat1)
        {
            Assert.That(actual, Is.StringMatching("^" + expectedFormat1 + "$"));
        }

        public static void AssertFormats(this string actual, string expectedFormat1, string expectedFormat2)
        {
            Assert.That(actual, Is.StringMatching("^" + expectedFormat1 + "$")
                                  .Or.StringMatching("^" + expectedFormat2 + "$"));
        }

        public static void AssertFormats(this string actual, string expectedFormat1, string expectedFormat2,
                                         string expectedFormat3)
        {
            Assert.That(actual, Is.StringMatching("^" + expectedFormat1 + "$")
                                  .Or.StringMatching("^" + expectedFormat2 + "$")
                                  .Or.StringMatching("^" + expectedFormat3 + "$"));
        }

        public static void AssertFormats(this string actual, string expectedFormat1, string expectedFormat2,
                                         string expectedFormat3, string expectedFormat4)
        {
            Assert.That(actual, Is.StringMatching("^" + expectedFormat1 + "$")
                                  .Or.StringMatching("^" + expectedFormat2 + "$")
                                  .Or.StringMatching("^" + expectedFormat3 + "$")
                                  .Or.StringMatching("^" + expectedFormat4 + "$"));
        }

        public static void AssertFormats(this string actual, string expectedFormat1, string expectedFormat2,
                                         string expectedFormat3, string expectedFormat4, string expectedFormat5)
        {
            Assert.That(actual, Is.StringMatching("^" + expectedFormat1 + "$")
                                  .Or.StringMatching("^" + expectedFormat2 + "$")
                                  .Or.StringMatching("^" + expectedFormat3 + "$")
                                  .Or.StringMatching("^" + expectedFormat4 + "$")
                                  .Or.StringMatching("^" + expectedFormat5 + "$"));
        }

        public static void AssertFormats(this string actual, string expectedFormat1, string expectedFormat2,
                                         string expectedFormat3, string expectedFormat4, string expectedFormat5,
                                         string expectedFormat6)
        {
            Assert.That(actual, Is.StringMatching("^" + expectedFormat1 + "$")
                                  .Or.StringMatching("^" + expectedFormat2 + "$")
                                  .Or.StringMatching("^" + expectedFormat3 + "$")
                                  .Or.StringMatching("^" + expectedFormat4 + "$")
                                  .Or.StringMatching("^" + expectedFormat5 + "$")
                                  .Or.StringMatching("^" + expectedFormat6 + "$"));
        }

        public static void AssertFormats(this string actual, string expectedFormat1, string expectedFormat2,
                                         string expectedFormat3, string expectedFormat4, string expectedFormat5,
                                         string expectedFormat6, string expectedFormat7)
        {
            Assert.That(actual, Is.StringMatching("^" + expectedFormat1 + "$")
                                  .Or.StringMatching("^" + expectedFormat2 + "$")
                                  .Or.StringMatching("^" + expectedFormat3 + "$")
                                  .Or.StringMatching("^" + expectedFormat4 + "$")
                                  .Or.StringMatching("^" + expectedFormat5 + "$")
                                  .Or.StringMatching("^" + expectedFormat6 + "$")
                                  .Or.StringMatching("^" + expectedFormat7 + "$"));
        }

        public static void AssertFormats(this string actual, string expectedFormat1, string expectedFormat2,
                                         string expectedFormat3, string expectedFormat4, string expectedFormat5,
                                         string expectedFormat6, string expectedFormat7, string expectedFormat8)
        {
            Assert.That(actual, Is.StringMatching("^" + expectedFormat1 + "$")
                                  .Or.StringMatching("^" + expectedFormat2 + "$")
                                  .Or.StringMatching("^" + expectedFormat3 + "$")
                                  .Or.StringMatching("^" + expectedFormat4 + "$")
                                  .Or.StringMatching("^" + expectedFormat5 + "$")
                                  .Or.StringMatching("^" + expectedFormat6 + "$")
                                  .Or.StringMatching("^" + expectedFormat7 + "$")
                                  .Or.StringMatching("^" + expectedFormat8 + "$"));
        }

        public static string Combine(this string firstFormat, params string[] restOfFormats)
        {
            return firstFormat + " " + string.Join(" ", restOfFormats);
        }

        public static void Repeat(this Action actionMethod, int times)
        {
            for (var i = 0; i < times; i++)
                actionMethod();
        }

        public static string ToFormat(this string formatToBe, bool onlyAToZLetters = false)
        {
            return "(" + formatToBe.Replace(';', '|')
                                   .Replace(".", "\\.")
                                   .Replace("#", "\\d")
                                   .Replace("?", onlyAToZLetters ? "[A-Za-z]" : "\\w")
                                   .Replace("(", "\\(")
                                   .Replace(")", "\\)")
                                   .Replace("+", "\\+") +
                   ")";
        }
    }
}
