using System;

namespace EATools.LogDNA
{
    // ReSharper disable once InconsistentNaming
    /// <summary>
    /// An exception related to the EATools.LogDNA library.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class LogDNAException : Exception
    {
        public LogDNAException(string message) : base(message) { }
    }
}
