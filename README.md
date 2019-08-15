# Arg
Arg is a c# library to eliminate boilerplate command line and argument parsing.  Arg is written in .net Standard to be compatible with both .net Core and .net Framework.

## Installation

Import from Nuget

```nuget
Install-Package Arg
```

## Usage

```c#
using Arg;

var menu = new Menu("\tExample :)", "Option 1", "Cheese", "That option with the long name");
var option = menu.GetOption();

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
