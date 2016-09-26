using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Faker.Tests
{
    [TestFixture]
    public class EventsFixture
    {
        [Test]
        public void Should_Generate_Name()
        {
            var name = Events.Name();

            // Name should match one of the given formats
            Assert.IsTrue(new List<Func<bool>>
                              {
                                  () => Regex.IsMatch(name, @"\w+ \w+"),
                                  () => Regex.IsMatch(name, @"\w+-\w+"),
                              }.Any(x => x.Invoke()));
        }

    }
}
