﻿namespace WMS.Domain.Exceptions;

public class InvalidUserException : Exception
{
    public InvalidUserException() : base() { }
    public InvalidUserException(string message) : base(message) { }
    public InvalidUserException(string message, Exception innerException) : base(message, innerException) { }
}
