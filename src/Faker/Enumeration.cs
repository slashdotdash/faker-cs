using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;

namespace Faker
{

    public static class Enumeration
    {

        /// <summary>
        /// Choose a random enum.
        /// </summary>     
        public static T Random<T>()
            where T : struct, IConvertible
        {
            var values = Enum.GetValues(typeof(T));
            return (T)values
                .GetValue(RandomNumber.Next(values.Length));
        }
    }
}