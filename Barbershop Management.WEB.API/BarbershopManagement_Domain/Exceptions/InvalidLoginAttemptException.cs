using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Domain.Exceptions;

public class InvalidLoginAttemptException : Exception
{
    public InvalidLoginAttemptException() : base() { }

    public InvalidLoginAttemptException(string message) : base(message) { }

    public InvalidLoginAttemptException(string message, Exception inner) : base(message, inner) { }
}
