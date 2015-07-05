using Faker.Extensions;

namespace Faker
{
    public static class Phone
    {
        public static string Number()
        {
            return Resources.Phone.Formats.Split(Config.Separator).Random().Trim().Numerify();
        }

        /// <summary>
        /// Allows number to be overridden with any format e.g. 01## ### ####
        /// </summary>
        public static string Number(string pattern)
        {
            return pattern.Trim().Numerify();
        }

    }
}