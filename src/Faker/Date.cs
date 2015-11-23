using System;

namespace Faker
{
    /// <summary>
    ///     A collection of Date related resources.
    /// </summary>
    /// <threadsafety static="true" />
    public static class Date
    {
        /// <summary>
        ///     Generates a random <see cref="DateTime" /> between the specified <paramref name="from" /> and
        ///     <paramref name="to" />.
        /// </summary>
        /// <param name="from">The minimum date.</param>
        /// <param name="to">The maximum date.</param>
        /// <returns>The generated <see cref="DateTime" />.</returns>
        public static DateTime Between(DateTime from, DateTime to)
        {
            var randTicks = RandomNumber.Next(from.Ticks, to.Ticks + 1);

            return new DateTime(randTicks);
        }

        /// <summary>
        ///     Generates a random <see cref="DateTime" /> between number of <paramref name="days" /> in the past and
        ///     <see cref="DateTime.Today">Today</see>
        /// </summary>
        /// <param name="days">The number of days to calculate the minimum date.</param>
        /// <returns>The generated <see cref="DateTime" /></returns>
        public static DateTime Backwards(int days = 365)
        {
            var to = DateTime.Today;
            var from = to.AddDays(-days);

            return Between(from, to).Date;
        }

        /// <summary>
        ///     Generates a random <see cref="DateTime" /> between <see cref="DateTime.Today">Today</see> and number of
        ///     <paramref name="days" /> into the future.
        /// </summary>
        /// <param name="days">The number of days to calculate the maximum date.</param>
        /// <returns>The generated <see cref="DateTime" /></returns>
        public static DateTime Forward(int days = 365)
        {
            var from = DateTime.Today;
            var to = from.AddDays(days);

            return Between(from, to).Date;
        }

        /// <summary>
        ///     Generates a random <see cref="DateTime" /> between the specified  <paramref name="maxAge">maximum age</paramref>
        ///     and <paramref name="minAge">minimum age</paramref>.
        /// </summary>
        /// <param name="minAge">The minimum years into the past.</param>
        /// <param name="maxAge">The maximum years into the past.</param>
        /// <returns>The generated <see cref="DateTime" /></returns>
        public static DateTime Birthday(int minAge = 18, int maxAge = 65)
        {
            var today = DateTime.Today;
            var from = today.AddYears(-maxAge);
            var to = today.AddYears(-minAge);

            return Between(from, to).Date;
        }
    }
}