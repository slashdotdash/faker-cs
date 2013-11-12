using System;

namespace Faker
{
    /// <summary>
    /// Provide access to random number geenrator.
    /// </summary>
    public static class RandomNumber
    {
        private static Random _rnd = new Random();
        
        public static void ResetSeed(int seed)
        {
            _rnd = new Random(seed);
        }
        
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
