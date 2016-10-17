using System.Collections.Generic;
using Waterworks.Filters;

namespace Waterworks.Tests.Examples.PasswordFilters
{
    public class InvalidCharactersFilter : NullFilter<string>
    {
        private List<string> _invalidCharacters = new List<string>();

        public InvalidCharactersFilter()
        {
            _invalidCharacters.Add(" ");
            _invalidCharacters.Add("\n");
            _invalidCharacters.Add("\t");
            _invalidCharacters.Add("\'");
            _invalidCharacters.Add("\"");
        }

        public override bool Stop(string data)
        {
            foreach(var character in _invalidCharacters)
            {
                if(data.Contains(character))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
