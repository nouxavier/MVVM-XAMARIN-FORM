using System;
using System.Runtime.Serialization;

namespace PokemonExceptions.Exceptions
{
    class DomainException: Exception
    {
        public string Title { get; private set; }
        public EnumBehaviorException EnumBehavior { get; private set; }
        public DomainException()
        {
        }

        public DomainException(string message, string title, EnumBehaviorException enumBehavior) : base(message)
        {
            Title = title;
            EnumBehavior = enumBehavior;
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
