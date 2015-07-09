using System;

// ReSharper disable ExceptionNotThrown

namespace Faker
{
    /// <summary>
    ///     Provides access to random number generator.
    /// </summary>
    /// <seealso cref="Random" />
    /// <threadsafety static="false" />
    public static class RandomNumber
    {
        private static Random s_rnd = new Random();

        /// <inheritdoc cref="Random.Next()" />
        /// <seealso cref="Random.Next()" />
        public static int Next()
        {
            return s_rnd.Next();
        }

        /// <inheritdoc cref="Random.Next(int)" />
        /// <seealso cref="Random.Next(int)" />
        /// <include file='Docs/RevisionHistory.xml' path='Revisions/RandomNumber[@id="NextMaxValue"]/revisionHistory' />
        public static int Next(int maxValue)
        {
            return s_rnd.Next(maxValue);
        }

        /// <inheritdoc cref="Random.Next(int,int)" />
        /// <seealso cref="Random.Next(int,int)" />
        /// <include file='Docs/RevisionHistory.xml' path='Revisions/RandomNumber[@id="NextMinValueMaxValue"]/revisionHistory' />
        public static int Next(int minValue, int maxValue)
        {
            return s_rnd.Next(minValue, maxValue);
        }

        /// <inheritdoc cref="System.Random(int)" />
        /// <seealso cref="Random" />
        /// <include file='Docs/RevisionHistory.xml' path='Revisions/RandomNumber[@id="ResetSeed"]/revisionHistory' />
        // ReSharper disable once InconsistentNaming
        public static void ResetSeed(int Seed)
        {
            s_rnd = new Random(Seed);
        }
    }
}
