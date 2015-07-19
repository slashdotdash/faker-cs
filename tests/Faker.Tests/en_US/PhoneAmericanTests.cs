using System;
using NUnit.Framework;

namespace Faker.Tests.en_US
{
    [TestFixture]
    [SetUICulture("en-US")]
    [SetCulture("en-US")]
    [Category("Culture 'en_US'")]
    public class PhoneAmericanTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Generate_Cell_Phone_Number()
        {
            string expectedFormat = Resources.Phone.CellPhoneFormats.ToFormat();

            string number = Phone.CellNumber();

            number.AssertFormats(expectedFormat);
        }

        [Test]
        [Repeat(1000)]
        [SetUICulture("en-US")]
        [SetCulture("en-US")]
        public void Should_Generate_Phone_Number()
        {
            string areaCodeFormat = Resources.Phone.AreaCode.ToFormat();
            string exchangeCodeFormat = Resources.Phone.ExchangeCode.ToFormat();
            string subscriberFormat = "####".ToFormat();
            string extensionFormat = subscriberFormat;

            string number = Phone.Number();

            number.AssertFormats(areaCodeFormat + "-" + exchangeCodeFormat + "-" + subscriberFormat,
                                 "\\(" + areaCodeFormat + "\\) " + exchangeCodeFormat + "-" + subscriberFormat,
                                 "1-" + areaCodeFormat + "-" + exchangeCodeFormat + "-" + subscriberFormat,
                                 areaCodeFormat + "\\." + exchangeCodeFormat + "\\." + subscriberFormat,
                                 areaCodeFormat + "-" + exchangeCodeFormat + "-" + subscriberFormat + " x"
                                 + extensionFormat,
                                 "\\(" + areaCodeFormat + "\\) " + exchangeCodeFormat + "-" + subscriberFormat + " x"
                                 + extensionFormat,
                                 "1-" + areaCodeFormat + "-" + exchangeCodeFormat + "-" + subscriberFormat + " x"
                                 + extensionFormat,
                                 areaCodeFormat + "\\." + exchangeCodeFormat + "\\." + subscriberFormat + " x"
                                 + extensionFormat);
        }
    }
}
