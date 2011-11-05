using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace Faker.Tests
{
    /// <summary>
    /// Creating a new CultureInfo (like 'en-bork' from the original Ruby Faker gem) requires windows *admin privileges* according to
    /// http://msdn.microsoft.com/en-us/library/ms172469(v=VS.85).aspx
    /// That's why 
    ///     (1) we take en-US as default and 
    ///     (2) require de-DE to have an 'extra word' at the beginning of the list within the resx file. 
    ///         In other words: This 'extra word' must differ from the first word in the default (en-US) resx file.
    /// 
    /// And no, we can't access Resource files from another dll directly.
    /// </summary>
    [TestFixture]
    public class CultureInfoFixture
    {
        private const string DefaultCultureInfoString = "en-US";

        #region Setup/TearDown
        [SetUp]
        public void Setup()
        {
            SetCultureToDefault();
        }

        [TearDown]
        public void TearDown()
        {
            SetCultureToDefault();
        } 
        #endregion

        #region TESTS
        [Test]
        public void Should_Be_Default()
        {
            var expected = GetFirstDefaultWord();
            var actual = Lorem.GetFirstWord();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Be_German()
        {
            var expected = GetFirstGermanWord();
            var actual = Lorem.GetFirstWord();
            Assert.AreNotEqual(expected, actual);
        } 
        #endregion

        #region Helper
        private void SetCultureToDefault()
        {
            SetCurrentCulture(DefaultCultureInfoString);
        }

        private void SetCurrentCulture(string cultureInfoString)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureInfoString);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureInfoString);
        }

        private string GetFirstDefaultWord()
        {
            return Lorem.GetFirstWord();
        }

        private string GetFirstGermanWord()
        {
            SetCurrentCulture("de-DE");
            var result = Lorem.GetFirstWord();
            SetCultureToDefault();
            return result;
        }
        #endregion
    }
}
