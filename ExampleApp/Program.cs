using Arg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //try
            //{
            //    var menu = new Menu("\tExample :)", "Option 1", "Cheese", "That option with the long name");
            //    var option = menu.GetOption();

            //    var name = ConsoleHelper.RequestInfo("Name", "Ettienne");

            //    Console.WriteLine($"Selected: {option}");
            //    Console.WriteLine($"Name: {name}");
            //}
            //catch (MenuCancelledException)
            //{
            //    // do something here
            //}

            var argsParser = new ArgsParser(
                    new StringArgument("FileName", "File", "F"),
                    new StringArgument("Surname", "LastName"),
                    new StringArgument("Name", "N"),
                    new StringArgument("X"),
                    new SwitchArgument("Save", "S"),
                    new SwitchArgument("yes", "y"));

            var parseResult = argsParser.Parse("-F:'test.txt' /Name=\"Ettienne Scharneck\" -X=Test -S -yes");
            foreach (var arg in parseResult)
            {
                Console.WriteLine($"Matched: {arg}");
            }

            var name = parseResult.GetValue("Name");
            var surname = parseResult.GetValueOrDefault("LastName", "Smith"); // returns smith if no value is given

            var boolValue = parseResult.GetValue<bool>("Save");
            var booldefault = parseResult.GetValueOrDefault("yes", true); // returns true if no value is given (result is a bool)

            var intDefault = parseResult.GetValueOrDefault("number", 13); // returns 13 if no value is given, result is convert to int

            var exception = parseResult.GetValue("nonsense"); // throws keynotfound exception

            Console.WriteLine($"Name: {parseResult.GetValueOrDefault("N", "Steve")}");
            Console.WriteLine($"Save: {parseResult.GetValueOrDefault("Save", false)}");
            Console.WriteLine($"Dummy: {parseResult.GetValueOrDefault("d", 15)}");

            ConsoleHelper.WaitForAnyKey();
        }
    }
}