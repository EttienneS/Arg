using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Arg.Test
{


    public class ExtensionsTests
    {
        public List<IArgument> GetTestList()
        {
            const string testcommand = "-name=Ettienne -command:Execute /file:\"c:\\test.xml\" -save /junk:Value /undefined ";
            return new ArgsParser(new StringArgument("Name"),
                                  new StringArgument("Command", "C"),
                                  new StringArgument("File", "f"),
                                  new StringArgument("Missing", "m"),
                                  new SwitchArgument("What", "w"),
                                  new SwitchArgument("Save", "S")).Parse(testcommand);
        }

        [Fact]
        public void When_getting_a_valid_value()
        {
            Assert.Equal("Ettienne", GetTestList().GetValue("name"));
            Assert.True(GetTestList().GetValue<bool>("s"));
        }

        [Fact]
        public void When_getting_an_invalid_value()
        {
            Assert.Throws<KeyNotFoundException>(() => GetTestList().GetValue(Guid.NewGuid().ToString()));
            Assert.Throws<KeyNotFoundException>(() => GetTestList().GetValue("junk"));
            Assert.Throws<KeyNotFoundException>(() => GetTestList().GetValue("undefined"));
        }

        [Fact]
        public void When_getting_a_valid_value_with_default()
        {
            Assert.Equal("Ettienne", GetTestList().GetValueOrDefault("name", "Steve"));
            Assert.True(GetTestList().GetValueOrDefault("s", false));
        }

        [Fact]
        public void When_getting_a_missing_value_with_default()
        {
            Assert.Equal("Bob", GetTestList().GetValueOrDefault("Missing", "Bob"));
            Assert.False(GetTestList().GetValueOrDefault("w", false));
        }

        [Fact]
        public void Check_If_Value_Given()
        {
            Assert.False(GetTestList().HasValue("w"));
            Assert.True(GetTestList().HasValue("name"));
            Assert.True(GetTestList().HasValue("s"));
            Assert.False(GetTestList().HasValue("junk"));
        }
    }
}
