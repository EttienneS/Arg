using System;
using System.Collections.Generic;
using System.Linq;

namespace Arg
{
    public class ArgsParser
    {
        public ArgsParser(params IArgument[] arguments)
        {
            ArgumentDefinitions.AddRange(arguments);
        }

        public List<IArgument> ArgumentDefinitions = new List<IArgument>();

        public List<IArgument> Parse(string inputArgs)
        {
            return Parse(inputArgs.Split(' '));
        }

        public List<IArgument> Parse(string[] inputArgs)
        {
            var matchedArgs = new List<IArgument>();
            foreach (var inputArg in inputArgs)
            {
                var commandParts = inputArg.TrimStart('/', '-').Split(new[] { ':', '=' }, 2);
                var command = commandParts[0];
                var value = (commandParts.Length > 1 ? commandParts[1] : string.Empty).Trim(new[] { '\"', '\''});

                foreach (var arg in ArgumentDefinitions)
                {
                    if (arg.Identifiers.Any(a => a.Equals(command, StringComparison.OrdinalIgnoreCase)))
                    {
                        if (arg is StringArgument stringArg)
                        {
                            stringArg.Value = value;
                        }
                        else
                        {
                            (arg as SwitchArgument).Present = true;
                        }

                        matchedArgs.Add(arg);
                        break;
                    }
                }
            }

            return matchedArgs;
        }
    }
}