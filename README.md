# Arg

*Arg* is a c# library to eliminate boilerplate command line and argument parsing.  Arg is written in .net Standard to be compatible with both .net Core and .net Framework.

![alt text](https://raw.githubusercontent.com/EttienneS/Arg/master/icon.png "Arrrgg!")

## Installation

Import from [Nuget](https://www.nuget.org/packages/Arg)

```nuget
Install-Package Arg -Version 1.0.6
```

## Usage

```c#
// parse command line inputs in a menu form
using Arg;

var menu = new Menu("\tExample :)", "Option 1", "Cheese", "That option with the long name");
var option = menu.GetOption();

```

```c#
// parse command line paramaters from external input
using Arg;

// create parser object and define expected arguments
var argsParser = new ArgsParser(new StringArgument("FileName", "File", "F"),
                                new StringArgument("Surname", "LastName"),
                                new SwitchArgument("Save", "S"),
                                new StringArgument("Name"));

// have the parser parse the string (or string[]), returns only matched arguments
var parseResult = argsParser.Parse("-F:test.txt /Name=\"EttienneS\" -S -x");
foreach (var arg in parseResult)
{
    Console.WriteLine($"Matched: {arg}");
}

// find a value of a specific arg in the bundle using extension methods introducted in v1.0.5
var name = parseResult.GetValue("Name");
var surname = parseResult.GetValueOrDefault("LastName", "Smith"); // returns smith if no value is given

var boolValue = parseResult.GetValue<bool>("Save");
var booldefault = parseResult.GetValueOrDefault("yes", true); // returns true if no value is given (result is a bool)

var intDefault = parseResult.GetValueOrDefault("number", 13); // returns 13 if no value is given, result is convert to int

var exception = parseResult.GetValue("nonsense"); // throws keynotfound exception


```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
