using System;
using Xunit;

namespace Arg.Test
{
    public class ArgParserTests
    {
        public const string SwitchesOnly = "-save /force -yolo";
        public const string StringsOnly = "-name=Ettienne -command:Execute /file:\"c:\\test.xml\"";

        public const string Mixed = SwitchesOnly + " " + StringsOnly;


        [Fact]
        public void When_Parsing_An_Empty_String()
        {
            Assert.Empty(new ArgsParser().Parse(string.Empty));
            Assert.Empty(new ArgsParser(new SwitchArgument("test")).Parse(string.Empty));
        }

        [Fact]
        public void When_Parsing_A_Garbage_String()
        {
            var garbage = "-sdlfjdslf1321 \"321312kajflksdajf\" -safjasdl:123312 /kfjasd=lkfjsa d;lfj ==sdaf;lka -j flksadj 'fsadfjsadl' fjsadf=321213aaa";
            Assert.Empty(new ArgsParser().Parse(garbage));
            Assert.Empty(new ArgsParser(new SwitchArgument("test")).Parse(garbage));
        }

        [Fact]
        public void When_Parsing_A_String_With_No_Definded_Args()
        {
            Assert.Empty(new ArgsParser().Parse(SwitchesOnly));
            Assert.Empty(new ArgsParser().Parse(StringsOnly));
            Assert.Empty(new ArgsParser().Parse(Mixed));
        }

        [Fact]
        public void When_Parsing_A_String_With_Definded_Args()
        {
            var parser = new ArgsParser(new SwitchArgument("save"), new StringArgument("name"));

            Assert.True(parser.Parse(Mixed).Count == 2);
            Assert.True(parser.Parse(SwitchesOnly).Count == 1);
            Assert.True(parser.Parse(StringsOnly).Count == 1);
        }


        [Fact]
        public void When_Parsing_A_String_With_Alternate_Identifiers()
        {
            var parser = new ArgsParser(new SwitchArgument("TEST", "save"), new StringArgument("TEST2", "name"));

            Assert.True(parser.Parse(Mixed).Count == 2);
            Assert.True(parser.Parse(SwitchesOnly).Count == 1);
            Assert.True(parser.Parse(StringsOnly).Count == 1);
        }

    }
}
