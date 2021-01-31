using System;

namespace HADotNet.Core.Domain
{
    /// <summary>
    /// The exception that occurs when a Supervisor-only API call is made to a non-Supervisor environment.
    /// </summary>
    public class SupervisorNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the SupervisorNotFoundException.
        /// </summary>
        public SupervisorNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SupervisorNotFoundException.
        /// </summary>
        public SupervisorNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SupervisorNotFoundException.
        /// </summary>
        public SupervisorNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
