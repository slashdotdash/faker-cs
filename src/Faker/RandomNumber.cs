using System;

namespace Faker
{
    /// <summary>
    /// Provide access to random number generator.
    /// </summary>
    public static class RandomNumber
    {
        private static readonly Random _rnd = new Random();

        public static int Next()
        {
            return _rnd.Next();
        }

        public static int Next(int max)
        {
            return _rnd.Next(max);
        }

        public static int Next(int min, int max)
        {
            return _rnd.Next(min, max);
        }
    }
}
