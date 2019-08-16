using System;

namespace Arg
{
    [Serializable]
    public class MenuCancelledException : Exception
    {
        public MenuCancelledException(string message) : base(message)
        {
        }

        public MenuCancelledException() : base()
        {
        }

        public MenuCancelledException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}