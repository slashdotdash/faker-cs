using System;
using NUnit.Framework;

namespace Faker.Tests.nb_NO
{
    [TestFixture]
    [SetUICulture("nb-NO")]
    [SetCulture("nb-NO")]
    [Category("Culture 'nb_NO'")]
    public class AddressNorwegianTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Get_Building_Number()
        {
            string buildingNum = Address.BuildingNumber();

            Assert.That(buildingNum, Has.Length.GreaterThanOrEqualTo(3)
                                        .Or.Length.LessThanOrEqualTo(5));
            //Assert.That(buildingNum, Is.StringMatching("^[0-9]+$"));
            buildingNum.AssertFormats(Resources.Address.BuildingNumber.ToFormat());
        }

        [Test]
        [Repeat(1000)]
        public virtual void Should_Get_City()
        {
            string cityRootFormat = Resources.Address.CityRoot.ToFormat();
            string citySuffixFormat = Resources.Address.CitySuffix.ToFormat();

            string city = Address.City();

            city.AssertFormats(cityRootFormat + citySuffixFormat);
        }

        [Test]
        [Repeat(1000)]
        public virtual void Should_Get_Street_Address()
        {
            string buildingNumberFormat = Resources.Address.BuildingNumber.ToFormat();
            string firstNameFormat = Resources.Name.First.ToFormat();
            string lastNameFormat = Resources.Name.Last.ToFormat();
            string streetSuffixFormat = Resources.Address.StreetSuffix.ToFormat();
            string streetPrefixFormat = Resources.Address.StreetPrefix.ToFormat();
            string streetRootFormat = Resources.Address.StreetRoot.ToFormat();
            string commonStreetSuffixFormat = Resources.Address.CommonStreetSuffixes.ToFormat();

            string address = Address.StreetAddress();

            address.AssertFormats((streetRootFormat + streetSuffixFormat).Combine(buildingNumberFormat),
                                  streetPrefixFormat
                                      .Combine(streetRootFormat + streetSuffixFormat, buildingNumberFormat),
                                  (firstNameFormat + commonStreetSuffixFormat).Combine(buildingNumberFormat),
                                  (lastNameFormat + commonStreetSuffixFormat).Combine(buildingNumberFormat));
        }

        [Test]
        [Repeat(1000)]
        public virtual void Should_Get_Street_Address_With_Secondary_Address()
        {
            string buildingNumberFormat = Resources.Address.BuildingNumber.ToFormat();
            string firstNameFormat = Resources.Name.First.ToFormat();
            string lastNameFormat = Resources.Name.Last.ToFormat();
            string streetSuffixFormat = Resources.Address.StreetSuffix.ToFormat();
            string streetPrefixFormat = Resources.Address.StreetPrefix.ToFormat();
            string streetRootFormat = Resources.Address.StreetRoot.ToFormat();
            string commonStreetSuffixFormat = Resources.Address.CommonStreetSuffixes.ToFormat();
            string secondaryAddressFormat = Resources.Address.SecondaryAddress.ToFormat();

            string address = Address.StreetAddress(true);

            address.AssertFormats(
                                  (streetRootFormat + streetSuffixFormat).Combine(buildingNumberFormat,
                                                                                  secondaryAddressFormat),
                                  streetPrefixFormat
                                      .Combine(streetRootFormat + streetSuffixFormat, buildingNumberFormat,
                                               secondaryAddressFormat),
                                  (firstNameFormat + commonStreetSuffixFormat).Combine(buildingNumberFormat,
                                                                                       secondaryAddressFormat),
                                  (lastNameFormat + commonStreetSuffixFormat).Combine(buildingNumberFormat,
                                                                                      secondaryAddressFormat));
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
