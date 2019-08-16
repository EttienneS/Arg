using System;
using Xunit;

namespace Arg.Test
{
    public class SwitchArgTests
    {
        [Fact]
        public void ctor()
        {
            var name = Guid.NewGuid().ToString();
            var arg = new SwitchArgument(name);

            Assert.Equal(name, arg.Name);
            Assert.Contains(name, arg.Identifiers);
            Assert.False(arg.Present);
            Assert.Equal(false.ToString(), arg.Value);

            Assert.Equal($"{name}: '{false.ToString()}'", arg.ToString());
        }

        [Fact]
        public void Setting_Present_Should_Affect_Value()
        {
            var name = Guid.NewGuid().ToString();
            var arg = new SwitchArgument(name)
            {
                Present = true
            };
            Assert.True(arg.Present);
            Assert.Equal(true.ToString(), arg.Value);
        }


    }
}
