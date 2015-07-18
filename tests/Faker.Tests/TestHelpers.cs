using System;

namespace Faker.Tests
{
    internal static class TestHelpers
    {
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
                                   .Replace("?", onlyAToZLetters ? "[A-Za-z]" : "\\w") +
                   ")";
        }
    }
}
