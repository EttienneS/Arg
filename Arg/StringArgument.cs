using System.Collections.Generic;
using System.Linq;

namespace Arg
{
    public class StringArgument : IArgument
    {

        public StringArgument(string name, params string[] identifiers)
        {
            Name = name;
            Identifiers = identifiers.ToList();
            Identifiers.Add(name);
        }

        public List<string> Identifiers { get; set; }
        public string Name { get; set; }
        public bool Present { get { return !string.IsNullOrEmpty(Value); } }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name}: '{Value}'";
        }
    }
}