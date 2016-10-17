using NUnit.Framework;
using System.Collections.Generic;
using Waterworks.Filters;
using Waterworks.Tests.Examples.PasswordFilters;

namespace Waterworks.Tests.Examples
{
    /// <summary>
    /// An example case where Waterworks is used as a password validation pipeline.
    /// </summary>
    [TestFixture(Category = "PasswordExample")]
    public class PasswordPipelineTests
    {
        private IPipeline<string> buildPipeline()
        {
            IEnumerable<IProcessFilter<string>> filters = new List<IProcessFilter<string>>()
            {
                new MinimumLengthFilter(),
                new InvalidCharactersFilter()
            };

            return new Pipeline<string>(filters);
        }

        [Test]
        public void Given_Password_With_Invalid_Characters_Then_Invalidate()
        {
            string password = "big ' potato";

            bool isValid = buildPipeline().Flow(ref password);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void Given_Short_Password_Then_Invalidate()
        {
            string password = "pass";

            bool isValid = buildPipeline().Flow(ref password);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void Given_Valid_Password_Then_Validate()
        {
            string password = "correcthorsebatterystaple";

            bool isValid = buildPipeline().Flow(ref password);

            Assert.IsTrue(isValid);
        }
    }
}
