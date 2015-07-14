using System;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    [SetCulture("en-US")]
    public class CompanyTests
    {
        [Test]
        [Repeat(10000)]
        public void Should_Generate_Bullshit()
        {
            string bs = Company.Bullshit();
            Assert.That(bs,
                        Is.StringMatching(@"^([\w\-]+ ?){3,4}$")
                          .Or.StringMatching(@"^[\w\-]+ [0-9]+\/[0-9]+ ([\w\-]+ ?){1,2}$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Generate_Catchphrase()
        {
            string catchPhrase = Company.CatchPhrase();
            Assert.That(catchPhrase,
                        Is.StringMatching(@"^([\w\-]+ ?){3,}$")
                          .Or.StringMatching(@"^([\w\-]+ ?)+ [0-9]+\/[0-9]+ ([\w\-]+ ?)+$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Generate_Company_Name()
        {
            string name = Company.Name();

            Assert.That(name,
                Is.StringMatching(@"^[\w']+ (and )?[\w]+$")
                .Or.StringMatching(@"^[\w']+-[\w']+$")
                .Or.StringMatching(@"^[\w']+, [\w']+ and [\w']+$"));
        }
    }
}
