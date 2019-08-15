using System.Collections.Generic;
using System.Linq;

namespace Arg
{
    public class SwitchArgument : IArgument
    {
        public SwitchArgument(string name, params string[] identifiers)
        {
            Name = name;
            Identifiers = identifiers.ToList();
            Identifiers.Add(name);
        }

        public List<string> Identifiers { get; set; }
        public string Name { get; set; }
        public bool Present { get; set; }

        public string Value
        {
            get
            {
                return Present.ToString();
            }
        }

        public override string ToString()
        {
            return $"{Name}: '{Value}'";
        }
    }
}