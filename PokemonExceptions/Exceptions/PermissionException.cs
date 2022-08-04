using System;
using System.Runtime.Serialization;

namespace PokemonExceptions.Exceptions
{
    public class PermissionException : Exception
    {
        public string Title { get; private set; }
        public EnumBehaviorException EnumBehavior { get; private set; }
        public PermissionException()
        {
        }

        public PermissionException(string message, string title, EnumBehaviorException enumBehavior) : base(message)
        {
            Title = title;
            EnumBehavior = enumBehavior;
        }

        public PermissionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PermissionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
