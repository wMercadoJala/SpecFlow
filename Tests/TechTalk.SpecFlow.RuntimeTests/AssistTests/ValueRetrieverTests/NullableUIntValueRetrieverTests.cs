using System;
using NUnit.Framework;
using FluentAssertions;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

namespace TechTalk.SpecFlow.RuntimeTests.AssistTests.ValueRetrieverTests
{
    [TestFixture]
    public class NullableUIntValueRetrieverTests
    {
        [Test]
        public void Returns_null_when_the_value_is_null()
        {
            var retriever = new NullableUIntValueRetriever(v => 0);
            retriever.GetValue(null).Should().Be(null);
        }

        [Test]
        public void Returns_value_from_UIntValueRetriever_when_passed_not_empty_string()
        {
            Func<string, uint> func = v =>
                                         {
                                             if (v == "test value") return 123;
                                             if (v == "another test value") return 456;
                                             return 0;
                                         };

            var retriever = new NullableUIntValueRetriever(func);
            retriever.GetValue("test value").Should().Be((uint?)123);
            retriever.GetValue("another test value").Should().Be((uint?)456);
        }

        [Test]
        public void Returns_null_when_passed_empty_string()
        {
            var retriever = new NullableUIntValueRetriever(v => 3);
            retriever.GetValue(string.Empty).Should().Be(null);
        }
    }
}