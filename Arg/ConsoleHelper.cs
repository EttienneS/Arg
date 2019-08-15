using System;

namespace Arg
{
    public static class ConsoleHelper
    {
        public static void WaitForAnyKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static string RequestInfo(string valueName, string defaultValue)
        {
            Console.Write($"Please choose an option value for '{valueName}' (Press Enter for: {defaultValue}): ");
            var value = Console.ReadLine();

            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }
    }
}