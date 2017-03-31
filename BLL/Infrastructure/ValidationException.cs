using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    /// <summary>
    /// The class generates the message with error, which will see users
    /// </summary>
    public class ValidationException : Exception
    {
        public string NameOfProperty { get; protected set; } //the property, which does not pass a validation
        public ValidationException(string message, string property) : base(message)
        {
            NameOfProperty = property;
        }
    }
}
