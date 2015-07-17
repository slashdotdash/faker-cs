using System;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class AvatarTests
    {
        private const string IMAGE_FORMAT = @"{0}\.{1}\?size={2}&set={3}$";
        private const string URL_STARTS_WITH = "http://robohash.org/";

        [Test]
        public static void Should_Get_Avatar_Image_With_Custom_Format()
        {
            string avatar = Avatar.Image(format: ImageFormat.jpg);

            string expectedFormat = string.Format(IMAGE_FORMAT, "[a-z]+", "jpg", "300x300", "set1");

            Assert.That(avatar,
                        Is.StringStarting(URL_STARTS_WITH)
                          .And.StringMatching(expectedFormat));
        }

        [Test]
        public static void Should_Get_Avatar_Image_With_Custom_Set()
        {
            string avatar = Avatar.Image(set: "MySet");

            string expectedFormat = string.Format(IMAGE_FORMAT, "[a-z]+", "png", "300x300", "MySet");

            Assert.That(avatar,
                        Is.StringMatching(URL_STARTS_WITH)
                          .And.StringMatching(expectedFormat));
        }

        [Test]
        public static void Should_Get_Avatar_Image_With_Custom_Size()
        {
            string avatar = Avatar.Image(size: "200x140");

            string expectedFormat = string.Format(IMAGE_FORMAT, "[a-z]+", "png", "200x140", "set1");

            Assert.That(avatar,
                        Is.StringStarting(URL_STARTS_WITH)
                          .And.StringMatching(expectedFormat));
        }

        [Test]
        public static void Should_Get_Avatar_Image_With_Custom_Slug()
        {
            string avatar = Avatar.Image("YOOOOOOOO");

            string expectedFormat = string.Format(IMAGE_FORMAT, "YOOOOOOOO", "png", "300x300", "set1");

            Assert.That(avatar,
                        Is.StringStarting(URL_STARTS_WITH)
                          .And.StringMatching(expectedFormat));
        }

        [Test]
        public static void Should_Get_Avatar_Image_With_Default_Values()
        {
            string avatar = Avatar.Image();

            string expectedFormat = string.Format(IMAGE_FORMAT, "[a-z]+", "png", "300x300", "set1");

            Assert.That(avatar,
                        Is.StringStarting(URL_STARTS_WITH)
                          .And.StringMatching(expectedFormat));
        }

        [Test]
        public static void Should_Throw_Argument_Exception_If_Size_Not_Valid()
        {
            var ex = Assert.Throws<ArgumentException>(() => Avatar.Image(size: "NotValid"));
            Assert.That(ex.Message, Is.StringStarting("Size should be specified in format 300x300"));
            Assert.That(ex.ParamName, Is.EqualTo("size"));
        }

        [Test]
        public static void Should_Throw_Argument_Null_Exception_If_Set_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Avatar.Image(set: null));
            Assert.That(ex.ParamName, Is.EqualTo("set"));
        }
    }
}
