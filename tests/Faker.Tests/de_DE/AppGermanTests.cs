using Faker.Extensions;
using Faker.Tests.Base;
using NUnit.Framework;

namespace Faker.Tests.de_DE
{
    [TestFixture]
    [SetUICulture("de-DE")]
    [SetCulture("de-DE")]
    [Category("Culture 'de_DE'")]
    public class AppGermanTests : AppTestsBase
    {
        [Test]
        [Repeat(10000)]
        public override void Should_Generate_Author()
        {
            string prefixes = Resources.Name.Prefix.ToFormat(false);
            string suffixes = Resources.Name.Suffix.ToFormat(false);

            string author = App.Author();

            Assert.That(author,
                        Is.StringMatching(@"^(" + prefixes + @" )?([\w']+\.? ?){2,4}( " + suffixes + ")?$")
                          .Or.StringMatching(@"^[\w']+ (and )?[\w]+$")
                          .Or.StringMatching(@"^[\w']+-[\w']+$")
                          .Or.StringMatching(@"^[\w']+, [\w']+ and [\w']+$"));
        }
    }
}
