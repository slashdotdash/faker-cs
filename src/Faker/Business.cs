using System;
using Faker.Extensions;

namespace Faker
{
    /// <summary>
    ///     A collection of Business related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="true" />
    public class Business
    {
        /// <summary>
        ///     Generates a random Credit card number.
        /// </summary>
        /// <returns>A random Credit card number</returns>
        public static string CreditCardNumber()
        {
            return Resources.Business.CreditCardNumbers.RandomResource();
        }

        /// <summary>
        ///     Generates a random credit card expiration date.
        /// </summary>
        /// <returns>A random credit card expiration date.</returns>
        public static DateTime CreditCardExpiryDate()
        {
            return DateTime.Now.AddDays(365*(RandomNumber.Next(4) + 1));
        }

        /// <summary>
        ///     Generates a random credit card type.
        /// </summary>
        /// <returns>A random credit card type.</returns>
        public static string CreditCardType()
        {
            return Resources.Business.CreditCardTypes.RandomResource();
        }
    }
}