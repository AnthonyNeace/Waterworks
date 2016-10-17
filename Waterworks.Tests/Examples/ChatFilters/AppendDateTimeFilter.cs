using System.Text;
using Waterworks.Filters;

namespace Waterworks.Tests.Examples.ChatFilters
{
    public class AppendDateTimeFilter : IFilter<ChatInput, ChatOutput>
    {
        public bool Stop(ChatInput input, ChatOutput output)
        {
            if (input == null)
            {
                return true;
            }

            return false;
        }

        public bool CanModify(ChatInput input, ChatOutput output)
        {
            return input.Timestamp.HasValue;
        }

        public void Modify(ChatInput input, ref ChatOutput output)
        {
            if (output.Message == null)
            {
                output.Message = new StringBuilder();
            }

            output.Message.Append(input.Timestamp.Value.ToString("yyyyMMdd-HHmm -"));
        }
    }
}
