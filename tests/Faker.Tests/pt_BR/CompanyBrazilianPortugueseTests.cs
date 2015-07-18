using Faker.Tests.Base;
using NUnit.Framework;

namespace Faker.Tests.pt_BR
{
    [TestFixture]
    [SetUICulture("pt-BR")]
    [SetCulture("pt-BR")]
    [Category("Culture 'pt_BR'")]
    public class CompanyBrazilianPortugueseTests : CompanyTestsBase
    {
        [Test]
        [Repeat(10000)]
        public override void Should_Generate_Company_Name()
        {
            string name = Company.Name();

            Assert.That(name,
                        Is.StringMatching(@"^(\w+ ?){1,3}, (\w+ ){1,3}and (\w+ ?){1,3}$")
                        .Or.StringMatching(@"^(\w+ ){1,3}and Sons$")
                          .Or.StringMatching(@"^([\w\-]+ ?){1,5}$"));
        }
    }
}
