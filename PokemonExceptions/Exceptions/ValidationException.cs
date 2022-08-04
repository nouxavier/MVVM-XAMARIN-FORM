using System;
using System.Runtime.Serialization;

namespace PokemonExceptions.Exceptions
{
    public class ValidationException: Exception
    {
        public string Title { get; private set; }
        public EnumBehaviorException EnumBehavior { get; private set; }
        public ValidationException()
        {
        }

        public ValidationException(string message, string title, EnumBehaviorException enumBehavior) : base(message)
        {
            Title = title;
            EnumBehavior = enumBehavior;
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
