using System;

namespace Waterworks.Tests.Examples.ChatFilters
{
    public class ChatInput
    {
        public string UserName { get; set; }

        public bool HideUserName { get; set; }

        public string Message { get; set; }

        public DateTimeOffset? Timestamp { get; set; }
    }
}
