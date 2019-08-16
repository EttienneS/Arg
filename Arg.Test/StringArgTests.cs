using System;
using Xunit;

namespace Arg.Test
{
    public class StringArgTests
    {
        [Fact]
        public void ctor()
        {
            var name = Guid.NewGuid().ToString();
            var arg = new StringArgument(name);

            Assert.Equal(name, arg.Name);
            Assert.Contains(name, arg.Identifiers);
            Assert.False(arg.Present);
            Assert.Equal(string.Empty, arg.Value);

            Assert.Equal($"{name}: ''", arg.ToString());
        }

        [Fact]
        public void Setting_Value_Should_Affect_Value()
        {
            var name = Guid.NewGuid().ToString();
            var value = Guid.NewGuid().ToString();
            var arg = new StringArgument(name)
            {
                Value = value
            };
            Assert.Equal(value, arg.Value);
            Assert.True(arg.Present);
        }


    }
}
