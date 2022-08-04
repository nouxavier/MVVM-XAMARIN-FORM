using System;
using System.Runtime.Serialization;

namespace PokemonExceptions.Exceptions
{
    public class ErrorException : Exception
    {
        public string Title { get; private set; }
        public EnumBehaviorException EnumBehavior { get; private set; }
        public ErrorException()
        {
        }

        public ErrorException(string message, string title, EnumBehaviorException enumBehavior) : base(message)
        {
            Title = title;
            EnumBehavior = enumBehavior;
        }

        public ErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
