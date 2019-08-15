using Arg;
using System;

namespace ExampleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var menu = new Menu("\tExample :)", "Option 1", "Cheese", "That option with the long name");
                var option = menu.GetOption();

                var name = ConsoleHelper.RequestInfo("Name", "Ettienne");

                Console.WriteLine($"Selected: {option}");
                Console.WriteLine($"Name: {name}");
            }
            catch (CancellationException)
            {
                // do something here
            }


            ConsoleHelper.WaitForAnyKey();
        }
    }
}