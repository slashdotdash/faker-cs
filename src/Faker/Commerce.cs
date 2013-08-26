using System;
using System.Collections.Generic;
using Faker.Extensions;

namespace Faker
{
    public static class Commerce
    {
        public static string Color()
        {
            return Resources.Commerce.Color.Split(Config.Separator).Random();
        }

        public static string Department()
        {
            return Resources.Commerce.Department.Split(Config.Separator).Random();
        }

        public static string ProductName()
        {
            return String.Join(" ",
                               new[]
                               {
                                   Resources.Commerce.Adjective.Split(Config.Separator).Random(),
                                   Resources.Commerce.Material.Split(Config.Separator).Random(),
                                   Resources.Commerce.Product.Split(Config.Separator).Random()
                               });
        }
    }
}
