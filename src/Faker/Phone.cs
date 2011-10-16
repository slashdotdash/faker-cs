using Faker.Extensions;

namespace Faker
{
    public static class Phone
    {
        public static string Number()
        {
            return Number(Languages.en_US);
        }

        public static string Number(Languages languages)
        {
            string result;
            switch (languages) {
                case Languages.de_DE:
                    result = _formatsDeDe.Random().Numerify();
                    break;
                default:
                    result = _formatsEnUs.Random().Numerify();
                    break;
            }
            return result;
        }

        private static readonly string[] _formatsEnUs = new[]
        {
            "###-###-####",
            "(###)###-####",
            "1-###-###-####",
            "###.###.####",
            "###-###-####",
            "(###)###-####",
            "1-###-###-####",
            "###.###.####",
            "###-###-#### x###",
            "(###)###-#### x###",
            "1-###-###-#### x###",
            "###.###.#### x###",
            "###-###-#### x####",
            "(###)###-#### x####",
            "1-###-###-#### x####",
            "###.###.#### x####",
            "###-###-#### x#####",
            "(###)###-#### x#####",
            "1-###-###-#### x#####",
            "###.###.#### x#####"
        };
    
        private static readonly string[] _formatsDeDe = new[]
        {
            "(0###) #########'", "(0####) #######","+49-###-#######","+49-####-########"
        };
    }
}