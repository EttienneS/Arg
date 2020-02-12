using Arg;
using System;

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
                    new StringArgument("Name"),
                    new StringArgument("X"),
                    new SwitchArgument("Save", "S"),
                    new SwitchArgument("yes", "y"));


            foreach (var arg in argsParser.Parse("-F:'test.txt' /Name=\"Ettienne Scharneck\" -X=Test -S -yes"))
            {
                Console.WriteLine($"Matched: {arg}");
            }
            ConsoleHelper.WaitForAnyKey();
        }
    }
}