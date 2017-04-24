namespace mipsed.application.framework
{
    using System;

    public class IncorrectDatabaseFormatException : Exception
    {
        public IncorrectDatabaseFormatException() : base(FrameworkResources.IncorrectDatabaseFormatException)
        {
        }
    }
}

