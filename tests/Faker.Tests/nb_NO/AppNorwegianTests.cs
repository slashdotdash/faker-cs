using Faker.Tests.Base;
using NUnit.Framework;

namespace Faker.Tests.nb_NO
{
    [TestFixture]
    [SetUICulture("nb-NO")]
    [SetCulture("nb-NO")]
    [Category("Culture 'nb_NO'")]
    public class AppNorwegianTests : AppTestsBase
    {
        [Test]
        [Repeat(10000)]
        public override void Should_Generate_Author()
        {
            string author = App.Author();

            Assert.That(author,
                        Is.StringMatching(@"^([\w']+\.? ?){2,4}$")
                          .Or.StringMatching(@"^[\w']+ (og )?[\w]+$")
                          .Or.StringMatching(@"^[\w']+-[\w']+$")
                          .Or.StringMatching(@"^[\w']+, [\w']+ og [\w']+$"));
        }
    }
}