using System.Text;
using Waterworks.Filters;

namespace Waterworks.Tests.Examples.ChatFilters
{
    public class AppendUserInputFilter : NullProcessFilter<ChatInput, ChatOutput>
    {
        public override bool Stop(ChatInput input, ChatOutput output)
        {
            if(input == null || string.IsNullOrEmpty(input.Message))
            {
                return true;
            }

            return false;
        }

        public override void Process(ChatInput input, ref ChatOutput output)
        {
            if (output.Message == null)
            {
                output.Message = new StringBuilder();
            }

            if(output.Message.Length > 0)
            {
                output.Message.Append(" ");
            }

            output.Message.Append(input.Message);
        }
    }
}
