﻿namespace AAS.API.Repository.Adt.Exceptions
{
    public class ConfigurationNotSetExceptions : Exception
    {
        public ConfigurationNotSetExceptions(string message) : base(message)
        {
        }

        public ConfigurationNotSetExceptions(string message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
