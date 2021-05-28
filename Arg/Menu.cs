using System;

namespace Arg
{
    public class Menu<T>
    {
        private readonly Func<T, string> _convertFunction;
        private string _lineString;

        public Menu(string menuTitle, Func<T, string> convertFunction, params T[] options)
        {
            Title = menuTitle;
            Options = options;
            _convertFunction = convertFunction;
        }

        public Menu(string menuTitle, params T[] options) : this(menuTitle, (T v) => v.ToString().SplitCamelCase(), options)
        {
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

        public T[] Options { get; set; }
        public string Title { get; set; }

        public void BlankLine(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                WriteColor(string.Empty);
            }
        }

        public void DrawLine()
        {
            WriteColor(LineString);
        }

        public T GetOption(int defaultOption = 0)
        {
            return Options[RequestOption(defaultOption, Options)];
        }

        public int GetOptionId(int defaultOption = 0)
        {
            return RequestOption(defaultOption, Options);
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
            WriteColor(Title);
            BlankLine();
            DrawLine();
            BlankLine();
        }

        private string GetPrettyString(T option)
        {
            return _convertFunction.Invoke(option);
        }

        private int RequestOption(int defaultValue, T[] options)
        {
            WriteTitle();

            const string message = "Please select an option: ";
            var value = ShowOptions(message, defaultValue, options);

            var parseResult = int.TryParse(value, out int selected);

            if (!parseResult || selected < 0 || selected > options.Length)
            {
                Write($"Invalid selection: {selected}");
                BlankLine(2);

                selected = RequestOption(defaultValue, options);
            }

            return Math.Max(0, selected - 1);
        }

        private string ShowOptions(string message, int defaultOption, T[] options)
        {
            Write(message);
            BlankLine();

            var index = 1;
            foreach (var option in options)
            {
                Console.WriteLine($"  {index}. {GetPrettyString(option)}");
                index++;
            }

            Write("  C. Cancel");
            Write($"  Enter for Default ({GetPrettyString(options[defaultOption])}):  ");
            var value = Console.ReadKey().KeyChar.ToString();
            BlankLine();

            if (value.Equals("c", StringComparison.OrdinalIgnoreCase))
            {
                Write("Selection canceled");
                throw new MenuCancelledException("Canceled selection");
            }

            if (value == "\r")
            {
                value = defaultOption.ToString();
            }

            return value;
        }
    }
}