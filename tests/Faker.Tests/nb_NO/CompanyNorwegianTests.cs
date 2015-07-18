using Faker.Tests.Base;
using NUnit.Framework;

namespace Faker.Tests.nb_NO
{
    [TestFixture]
    [SetUICulture("nb-NO")]
    [SetCulture("nb-NO")]
    [Category("Culture 'nb_NO'")]
    public class CompanyNorwegianTests : CompanyTestsBase
    {
        [Test]
        [Repeat(10000)]
        public override void Should_Generate_Company_Name()
        {
            string name = Company.Name();

            Assert.That(name,
                        Is.StringMatching(@"^[\w']+( |-)[\w']+$")
                        .Or.StringMatching(@"^([\w']+, )?[\w']+ og [\w']+$"));
        }
    }
}