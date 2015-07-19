using NUnit.Framework;

namespace Faker.Tests.en_US
{
    [TestFixture]
    [SetUICulture("en-US")]
    [SetCulture("en-US")]
    [Category("Culture 'en_US'")]
    public class AddressAmericanTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Get_Building_Number()
        {
            string buildingNum = Address.BuildingNumber();

            Assert.That(buildingNum, Has.Length.GreaterThanOrEqualTo(3)
                                        .Or.Length.LessThanOrEqualTo(5));

            buildingNum.AssertFormats(Resources.Address.BuildingNumber.ToFormat());
        }

        [Test]
        [Repeat(1000)]
        public virtual void Should_Get_City()
        {
            string cityPrefixFormat = Resources.Address.CityPrefix.ToFormat();
            string firstNameFormat = Resources.Name.First.ToFormat();
            string citySuffixFormat = Resources.Address.CitySuffix.ToFormat();
            string lastNameFormat = Resources.Name.Last.ToFormat();

            string city = Address.City();

            city.AssertFormats(cityPrefixFormat + " " + firstNameFormat + citySuffixFormat,
                               cityPrefixFormat + " " + firstNameFormat,
                               firstNameFormat + citySuffixFormat, lastNameFormat + citySuffixFormat);
        }

        [Test]
        [Repeat(1000)]
        public virtual void Should_Get_Street_Address()
        {
            string buildingNumberFormat = Resources.Address.BuildingNumber.ToFormat();
            string firstNameFormat = Resources.Name.First.ToFormat();
            string lastNameFormat = Resources.Name.Last.ToFormat();
            string addressStreetSuffixFormat = Resources.Address.StreetSuffix.ToFormat();

            string address = Address.StreetAddress();

            address.AssertFormats(buildingNumberFormat + " " + firstNameFormat + " " + addressStreetSuffixFormat,
                                  buildingNumberFormat + " " + lastNameFormat + " " + addressStreetSuffixFormat);
        }

        [Test]
        [Repeat(1000)]
        public virtual void Should_Get_Street_Address_With_Secondary_Address()
        {
            string buildingNumberFormat = Resources.Address.BuildingNumber.ToFormat();
            string firstNameFormat = Resources.Name.First.ToFormat();
            string lastNameFormat = Resources.Name.Last.ToFormat();
            string addressStreetSuffixFormat = Resources.Address.StreetSuffix.ToFormat();
            string secondaryAddressFormat = Resources.Address.SecondaryAddress.ToFormat();

            string address = Address.StreetAddress(true);

            address.AssertFormats(
                                  buildingNumberFormat + " " + firstNameFormat + " " + addressStreetSuffixFormat + " "
                                  + secondaryAddressFormat,
                                  buildingNumberFormat + " " + lastNameFormat + " " + addressStreetSuffixFormat + " "
                                  + secondaryAddressFormat);
        }

        [Test]
        [Repeat(1000)]
        public void Should_Get_Zip_Code()
        {
            string zipcodeFormat = Resources.Address.ZipCode.ToFormat(true);

            string zipcode = Address.ZipCode();

            zipcode.AssertFormats(zipcodeFormat);
        }
    }
}
