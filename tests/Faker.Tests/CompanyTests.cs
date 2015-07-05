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
        public void Should_Generate_Bs()
        {
            string bs = Company.BS();
            //Assert.IsTrue(Regex.IsMatch(bs, @"[\w\-]+ [\w\-]+ [\w\-]+"));
            Assert.That(bs,
                        Is.StringMatching(@"^([\w\-]+ ?){3,4}$")
                          .Or.StringMatching(@"^[\w\-]+ [0-9]+\/[0-9]+ ([\w\-]+ ?){1,2}$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Generate_Catchphrase()
        {
            string catchPhrase = Company.CatchPhrase();
            //Assert.IsTrue(Regex.IsMatch(catchPhrase, @"[\w\-]+ [\w\-]+ [\w\-]+"));
            Assert.That(catchPhrase,
                        Is.StringMatching(@"^([\w\-]+ ?){3,}$")
                          .Or.StringMatching(@"^([\w\-]+ ?)+ [0-9]+\/[0-9]+ ([\w\-]+ ?)+$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Generate_Company_Name()
        {
            string name = Company.Name();

            // Name should match one of the given formats
            //Assert.IsTrue(new List<Func<bool>>
            //                  {
            //                      () => Regex.IsMatch(name, @"\w+ \w+"),
            //                      () => Regex.IsMatch(name, @"\w+-\w+"),
            //                      () => Regex.IsMatch(name, @"\w+, \w+ and \w+")
            //                  }.Any(x => x.Invoke()));

            Assert.That(name,
                        Is.StringMatching(@"^[\w']+ [\w']+$")
                          .Or.StringMatching(@"[\w']+-[\w']+")
                          .Or.StringMatching(@"[\w']+ [\w']+ and [\w']+")
                          .Or.StringMatching(@"[\w']+, [\w']+ and [\w']+"));
        }
    }
}
