using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterworks.Filters;
using Waterworks.Tests.Examples.ArithmeticFilters;

namespace Waterworks.Tests.Examples
{
    /// <summary>
    /// Simple tests to verify processing of value types.
    /// </summary>
    public class ArithmeticFilterTests
    {
        private IPipeline<int> buildSingleInputPipeline(int add, int divide)
        {
            IEnumerable<IProcessFilter<int>> filters = new List<IProcessFilter<int>>()
            {
                new SingleInputAdditionFilter(add),
                new SingleInputDivisionFilter(divide)
            };

            return new Pipeline<int>(filters);
        }

        private IPipeline<int, int> buildDualInputPipeline()
        {
            IEnumerable<IProcessFilter<int, int>> filters = new List<IProcessFilter<int, int>>()
            {
                new DualInputAdditionFilter(),
                new DualInputDivisionFilter()
            };

            return new Pipeline<int, int>(filters);
        }

        [TestCase(0, 1, 1)]
        public void Given_Valid_Ints_Then_Calculate_With_SingleInputPipeline(int startValue, int add, int divide)
        {
            int expected = startValue + add / divide;
            int actual = startValue;

            bool isValid = buildSingleInputPipeline(add, divide).Flow(ref actual);

            Assert.IsTrue(isValid);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 1, 0)]
        public void Given_Invalid_Ints_Then_Calculate_With_SingleInputPipeline(int startValue, int add, int divide)
        {
            bool isValid = buildSingleInputPipeline(add, divide).Flow(ref startValue);

            Assert.IsFalse(isValid);
        }

        [TestCase(0, 1)]
        public void Given_Valid_Ints_Then_Calculate_With_DualInputPipeline(int startValue, int input)
        {
            int expected = startValue + input / input;
            int actual = startValue;

            bool isValid = buildDualInputPipeline().Flow(input, ref actual);

            Assert.IsTrue(isValid);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 0)]
        public void Given_Invalid_Ints_Then_Calculate_With_DualInputPipeline(int startValue, int input)
        {
            bool isValid = buildDualInputPipeline().Flow(input, ref startValue);

            Assert.IsFalse(isValid);
        }
    }
}
