using System;
using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;

namespace EATools.LogDNA
{
    /// <summary>
    /// Represents a single line of a log file.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class LogLine
    {
        /// <summary>
        /// Gets or sets the timestamp of the log line.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the content of the line.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        [JsonProperty("line")]
        public string Line { get; set; }

        /// <summary>
        /// Gets or sets the filename from which the log line originates. In many cases, this won't be a file but a process name.
        /// </summary>
        /// <value>
        /// The filename or process name.
        /// </value>
        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("meta")]
        public IDictionary<object, object> Metadata { get; set; } = new Dictionary<object, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LogLine"/> class using the current date and time as the timestamp.
        /// </summary>
        /// <param name="logName">Name of the log. This will be used as the 'filename'.</param>
        /// <param name="content">The content of the log line.</param>
        public LogLine(string logName, string content) : this(logName, content, DateTime.UtcNow)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="LogLine"/> class.
        /// </summary>
        /// <param name="logName">Name of the log. This will be used as the 'filename'.</param>
        /// <param name="content">The content of the log line.</param>
        /// <param name="timestamp">The date and time to associate with this log line.</param>
        public LogLine(string logName, string content, DateTime timestamp)
        {
            Timestamp = timestamp.ToJavaTimestamp();
            Line = content.Length > 32000 ? content.Substring(0, 32000) : content;
            App = logName;
            Level = "DEBUG";
        }
    }
}
