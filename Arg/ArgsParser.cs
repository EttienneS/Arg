using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            var args = new List<IArgument>();
            var regex = @"(?:\s*)(?<=[-|\/])(?<name>\w*)[:|=](['""]((?<quoted>.*?)(?<!\\)['""])|(?<unquoted>[\w]*))|(?<novalue>[\w]+)";
            foreach (Match match in Regex.Matches(inputArgs, regex))
            {
                if (TryParseArg(match.Value, out IArgument arg))
                {
                    args.Add(arg);
                }
            }
            return args;
        }

      

        private bool TryParseArg(string inputArg, out IArgument argument)
        {
            var commandParts = inputArg.TrimStart('/', '-').Split(new[] { ':', '=' }, 2);
            var command = commandParts[0];
            var value = (commandParts.Length > 1 ? commandParts[1] : string.Empty).Trim(new[] { '\"', '\'' });

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

                    argument = arg;
                    return true;
                }
            }

            argument = null;
            return false;
        }
    }
}