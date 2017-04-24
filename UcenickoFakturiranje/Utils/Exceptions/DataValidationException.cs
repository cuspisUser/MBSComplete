using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UcenickoFakturiranje.Utils.Exceptions
{
    /// <summary>
    /// Custom exception class that is been used for data validation.
    /// </summary>
    public class DataValidationException
    {
        public string ControlToFocus { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="controlToFocus">Control that is being validated.</param>
        /// <param name="message">Message to display.</param>
        public DataValidationException(string controlToFocus, string message)
        {
            this.ControlToFocus = controlToFocus;
            this.Message = message;
        }
    }
}
