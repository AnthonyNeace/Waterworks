using Waterworks.Filters;

namespace Waterworks.Tests.Examples.PasswordFilters
{
    public class MinimumLengthFilter : NullProcessFilter<string>
    {
        private int _minLength = 8;

        public override bool Stop(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                return true;
            }
            else if (password.Length < _minLength)
            {
                return true;
            }

            return false;
        }
    }
}
