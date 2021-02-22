using Newtonsoft.Json;
using System.Collections.Generic;

namespace EATools.LogDNA
{
    /// <summary>
    /// Data structure for data sent to LogDNA servers.
    /// </summary>
    public class BufferMessage
    {
        /// <summary>
        /// Gets the log lines.
        /// </summary>
        /// <value>
        /// The log lines.
        /// </value>
        [JsonProperty("lines")]
        public IEnumerable<LogLine> LogLines { get; set; }
    }
}
