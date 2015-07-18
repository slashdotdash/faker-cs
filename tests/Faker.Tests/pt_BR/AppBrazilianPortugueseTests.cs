using Faker.Tests.Base;
using NUnit.Framework;

namespace Faker.Tests.pt_BR
{
    [TestFixture]
    [SetUICulture("pt-BR")]
    [SetCulture("pt-BR")]
    [Category("Culture 'pt_BR'")]
    public class AppBrazilianPortugueseTests : AppTestsBase
    {
        [Test]
        [Repeat(10000)]
        public override void Should_Generate_Author()
        {
            string author = App.Author();

            Assert.That(author,
                        Is.StringMatching(@"^([\w\-]+\.? ){1,5}([\w\-]\.?)+$")
                        .Or.StringMatching(@"^[\w\-]+$")
                        .Or.StringMatching(@"^\w+, \w+ and \w+$")
                        .Or.StringMatching(@"^(\w+ ?){1,3}, (\w+ ){1,3}and (\w+ ?){1,3}$")
                        .Or.StringMatching(@"^([\w]+ ){1,3}and Sons$"));
        }
    }
}