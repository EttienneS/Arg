using System.Collections.Generic;

namespace Arg
{
    public interface IArgument
    {
        string Name { get; set; }
        List<string> Identifiers { get; set; }

        bool Present { get; }

        string Value { get; }
    }
}