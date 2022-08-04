using System;
using System.Runtime.Serialization;

namespace PokemonExceptions.Exceptions
{
    public class ServerException : Exception
    {
        public string Title { get; private set; }
        public EnumBehaviorException EnumBehavior { get; private set; }
        public ServerException()
        {
        }

        public ServerException(string message, string title, EnumBehaviorException enumBehavior) : base(message)
        {
            Title = title;
            EnumBehavior = enumBehavior;
        }

        public ServerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ServerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
