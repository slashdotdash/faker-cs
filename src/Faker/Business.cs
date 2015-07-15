using System;
using Faker.Extensions;

namespace Faker
{
    public class Business
    {
        public static string CreditCardNumber()
        {
            return Resources.Business.CreditCardNumbers.RandomResource();
        }

        public static DateTime CreditCardExpiryDate()
        {
            return DateTime.Now.AddDays((365*(RandomNumber.Next(4) + 1)));
        }

        public static string CreditCardType()
        {
            return Resources.Business.CreditCardTypes.RandomResource();
        }
    }
}