# Arg

*Arg* is a c# library to eliminate boilerplate command line and argument parsing.  Arg is written in .net Standard to be compatible with both .net Core and .net Framework.

![alt text](https://raw.githubusercontent.com/EttienneS/Arg/master/icon.png "Arrrgg!")

## Installation

Import from [Nuget](https://www.nuget.org/packages/Arg)

```nuget
Install-Package Arg -Version 1.0.2
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
foreach (var arg in argsParser.Parse("-F:test.txt /Name=\"EttienneS\" -S -x"))
{
    Console.WriteLine($"Matched: {arg}");
}

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
