using System;
using System.Collections.Generic;
using Faker.Extensions;

namespace Faker
{
    public static class Events
    {

        public static string Activity()
        {
            return Resources.Events.Activity.Split(Config.Separator).Random();
        }
        public static string Season()
        {
            return Resources.Events.Season.Split(Config.Separator).Random();
        }


        /// <summary>
        /// Generate a buzzword-laden catch phrase.
        /// Wordlist from http://www.1728.com/buzzword.htm
        /// </summary>
        public static string Name()
        {
            return String.Join(" ",
                               new[]
                               {
                                   Resources.Events.Season.Split(Config.Separator).Random(),
                                   Resources.Events.Activity.Split(Config.Separator).Random(),
                               });
        }


    }
}