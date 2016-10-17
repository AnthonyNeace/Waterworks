using NUnit.Framework;
using System;
using System.Collections.Generic;
using Waterworks.Tests.Examples.ChatFilters;
using Waterworks.Filters;

namespace Waterworks.Tests.Examples
{
    /// <summary>
    /// An example case where Waterworks is used as a chat string builder.
    /// </summary>
    [TestFixture(Category = "ChatExample")]
    public class ChatPipelineTests
    {
        private IPipeline<ChatInput, ChatOutput> buildPipeline()
        {
            IEnumerable<IProcessFilter<ChatInput, ChatOutput>> filters = new List<IProcessFilter<ChatInput, ChatOutput>>()
            {
                new AppendDateTimeFilter(),
                new AppendUserNameFilter(),
                new AppendUserInputFilter()
            };

            return new Pipeline<ChatInput, ChatOutput>(filters);
        }

        [Test]
        public void Given_Server_Message_Then_Print_Chat()
        {
            ChatOutput output = new ChatOutput();

            bool success = buildPipeline().Flow(new ChatInput()
            {
                UserName = "Server",
                HideUserName = true,
                Message = "(Message of the day) Welcome!",
                Timestamp = new DateTimeOffset(2016, 1, 1, 0, 0, 0, new TimeSpan(0, 0, 0))
            }, ref output);

            Assert.IsTrue(success);
            Assert.AreEqual("20160101-0000 - (Message of the day) Welcome!", output.Message.ToString());
        }

        [Test]
        public void Given_User_Message_Then_Print_Chat()
        {
            ChatOutput output = new ChatOutput();

            bool success = buildPipeline().Flow(new ChatInput()
            {
                UserName = "Anthony",
                HideUserName = false,
                Message = "Hello, World!",
                Timestamp = new DateTimeOffset(2016, 1, 1, 0, 0, 0, new TimeSpan(0, 0, 0))
            }, ref output);

            Assert.IsTrue(success);
            Assert.AreEqual("20160101-0000 - Anthony: Hello, World!", output.Message.ToString());
        }

        [Test]
        public void Given_User_Message_Where_Input_Is_Null_Then_Stop()
        {
            ChatOutput output = new ChatOutput();

            bool success = buildPipeline().Flow(new ChatInput()
            {
                UserName = "Anthony",
                HideUserName = false,
                Message = null,
                Timestamp = new DateTimeOffset(2016, 1, 1, 0, 0, 0, new TimeSpan(0, 0, 0))
            }, ref output);

            Assert.IsFalse(success);
        }

        [Test]
        public void Given_User_Message_Where_Input_Is_Empty_Then_Stop()
        {
            ChatOutput output = new ChatOutput();

            bool success = buildPipeline().Flow(new ChatInput()
            {
                UserName = "Anthony",
                HideUserName = false,
                Message = "",
                Timestamp = new DateTimeOffset(2016, 1, 1, 0, 0, 0, new TimeSpan(0, 0, 0))
            }, ref output);

            Assert.IsFalse(success);
        }
    }
}
