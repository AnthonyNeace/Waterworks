﻿using System.Text;
using Waterworks.Filters;

namespace Waterworks.Tests.Examples.ChatFilters
{
    public class AppendUserNameFilter : IFilter<ChatInput, ChatOutput>
    {
        public bool Stop(ChatInput input, ChatOutput output)
        {
            if (input == null || (!input.HideUserName && string.IsNullOrEmpty(input.UserName)))
            {
                return true;
            }

            return false;
        }

        public bool CanModify(ChatInput input, ChatOutput output)
        {
            return !input.HideUserName;
        }

        public ChatOutput Modify(ChatInput input, ChatOutput output)
        {
            if(output.Message == null)
            {
                output.Message = new StringBuilder();
            }

            if (output.Message.Length > 0)
            {
                output.Message.Append(" ");
            }

            output.Message.Append($"{input.UserName}:");

            return output;
        }
    }
}
