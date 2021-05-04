using Arg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleApp
{
    internal class Program
    {
        public enum TestEnum
        {
            Value1, Test2, FourtyOne, Seven, AnotherOption
        }

        private static void Main(string[] args)
        {
            try
            {
                var enumMenu = new Menu<TestEnum>("\tExample :)", Enum.GetValues(typeof(TestEnum)).OfType<TestEnum>().ToArray());
                var enumOption = enumMenu.GetOption();

                Console.WriteLine($"Selected: {enumOption}");

                var menu = new Menu<string>("\tExample :)", "Option 1", "Cheese", "That option with the long name");
                var option = menu.GetOption();

                Console.WriteLine($"Selected: {option}");

                var thisName = ConsoleHelper.RequestInfo("Name", "Ettienne");

                Console.WriteLine($"Name: {thisName}");
            }
            catch (MenuCancelledException)
            {
                // do something here
            }

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