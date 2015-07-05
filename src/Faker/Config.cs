namespace Faker
{
    public static class Config
    {
        private static char _separator = ';';
        public static char Separator { get { return _separator; } set { _separator = value; } }
    }
}
