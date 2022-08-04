using System;
using System.Runtime.Serialization;

namespace PokemonExceptions.Exceptions
{
    public class CredentialException : Exception
    {
        public string Title { get; private set; }
        public EnumBehaviorException EnumBehavior { get; private set; }
        public CredentialException()
        {
        }

        public CredentialException(string message, string title, EnumBehaviorException enumBehavior) : base(message)
        {
            Title = title;
            EnumBehavior = enumBehavior;
        }

        public CredentialException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CredentialException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
