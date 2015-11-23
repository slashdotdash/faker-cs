using System;

// ReSharper disable ExceptionNotThrown

namespace Faker
{
    /// <summary>
    ///     Provides access to random number generator.
    /// </summary>
    /// <seealso cref="Random" />
    /// <threadsafety static="true" />
    /// <remarks>
    ///     This is just a convience class and is just wrapping <see cref="Random" />.
    /// </remarks>
    public static class RandomNumber
    {
        private static readonly object s_lockObject = new object();
        private static Random s_rnd = new Random();

        /// <inheritdoc cref="Random.Next()" />
        /// <seealso cref="Random.Next()" />
        public static int Next()
        {
            lock (s_lockObject)
            {
                return s_rnd.Next();
            }
        }

        /// <inheritdoc cref="Random.NextBytes(byte[])" />
        public static void NextBytes(byte[] buffer)
        {
            lock (s_lockObject)
            {
                s_rnd.NextBytes(buffer);
            }
        }

        /// <inheritdoc cref="Random.Next(int)" />
        /// <seealso cref="Random.Next(int)" />
        /// <include file='Docs/RevisionHistory.xml' path='Revisions/RandomNumber[@id="NextMaxValue"]/revisionHistory' />
        public static int Next(int maxValue)
        {
            lock (s_lockObject)
            {
                return s_rnd.Next(maxValue);
            }
        }

        /// <inheritdoc cref="Random.Next(int,int)" />
        /// <seealso cref="Random.Next(int,int)" />
        /// <include file='Docs/RevisionHistory.xml' path='Revisions/RandomNumber[@id="NextMinValueMaxValue"]/revisionHistory' />
        public static int Next(int minValue, int maxValue)
        {
            lock (s_lockObject)
            {
                return s_rnd.Next(minValue, maxValue);
            }
        }

        /// <inheritdoc cref="Next(int,int)" />
        public static long Next(long min, long max)
        {
            var buf = new byte[8];
            NextBytes(buf);
            var longRand = BitConverter.ToInt64(buf, 0);

            return Math.Abs(longRand % (max - min)) + min;
        }

        /// <inheritdoc cref="Random.NextDouble()" />
        public static double NextDouble()
        {
            lock (s_lockObject)
            {
                return s_rnd.NextDouble();
            }
        }

        /// <inheritdoc cref="System.Random(int)" />
        /// <seealso cref="Random" />
        /// <include file='Docs/RevisionHistory.xml' path='Revisions/RandomNumber[@id="ResetSeed"]/revisionHistory' />
        // ReSharper disable once InconsistentNaming
        public static void ResetSeed(int Seed)
        {
            lock (s_lockObject)
            {
                s_rnd = new Random(Seed);
            }
        }
    }
}