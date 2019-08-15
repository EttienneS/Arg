using System;

namespace Arg
{
    public class Menu
    {
        private string _lineString;

        public Menu(string menuTitle, params string[] options)
        {
            Title = menuTitle;
            OptionStrings = options;

        }

        public string LineString
        {
            get
            {
                if (string.IsNullOrEmpty(_lineString))
                {
                    for (var i = 0; i < Console.WindowWidth; i++)
                    {
                        _lineString += "=";
                    }
                }

                return _lineString;
            }
        }

        public string[] OptionStrings { get; set; }
        public string Title { get; set; }
        public void BlankLine()
        {
            WriteColor("");
        }

        public void DrawLine()
        {
            WriteColor(LineString);
        }

        public void Write(string message)
        {
            WriteColor(message);
        }

        public void WriteColor(string message, ConsoleColor color = ConsoleColor.Gray)
        {
            var revert = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Error.WriteLine(message);
            Console.ForegroundColor = revert;
        }

        public void WriteError(string message)
        {
            WriteColor(message, ConsoleColor.Red);
        }

        public void WriteSuccess(string message)
        {
            WriteColor(message, ConsoleColor.Green);
        }

        public void WriteTitle()
        {
            DrawLine();
            BlankLine();
            WriteColor(Title);
            BlankLine();
            DrawLine();
            BlankLine();
        }

        public string GetOption()
        {
            WriteTitle();

            return RequestOption(1, OptionStrings);
        }

       

        private string RequestOption(int defaultValue, string[] options)
        {
            var message = $"Please select an option: ";
            string value = ShowOptions(message, defaultValue, options);
            int selected;
            while (!int.TryParse(value, out selected) && selected <= 0 && selected > options.Length)
            {
                value = ShowOptions(message, defaultValue, options);
            }

            return options[selected - 1];
        }

        private string ShowOptions(string message, int defaultOption, string[] options)
        {
            Write(message);
            BlankLine();

            var index = 1;
            foreach (var option in options)
            {
                Console.WriteLine($"  {index}. {option}");
                index++;
            }

            Write("  C. Cancel");
            Write($"  Enter for Default ({options[defaultOption - 1]}):  ");
            var value = Console.ReadKey().KeyChar.ToString();
            BlankLine();

            if (value.Equals("c", StringComparison.OrdinalIgnoreCase))
            {
                Write("Selection canceled");
                throw new CancellationException("Canceled selection");
            }

            if (value == "\r")
            {
                value = defaultOption.ToString();
            }

            return value;
        }
    }
}