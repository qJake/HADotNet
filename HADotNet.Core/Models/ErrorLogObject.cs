using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents an error log entry.
    /// </summary>
    public class ErrorLogObject
    {
        /// <summary>
        /// Gets a Regex object representing a new log line.
        /// </summary>
        private static Regex NewLogLineRegex = new Regex(@"^\d{4}-\d{2}-\d{2}", RegexOptions.Compiled);

        /// <summary>
        /// Gets a Regex object representing an error line.
        /// </summary>
        private static Regex LogTypeError = new Regex(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2} ERROR", RegexOptions.Compiled);

        /// <summary>
        /// Gets a Regex object representing a warning line.
        /// </summary>
        private static Regex LogTypeWarning = new Regex(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2} WARNING", RegexOptions.Compiled);

        /// <summary>
        /// Gets the full, raw log text.
        /// </summary>
        public string RawLog { get; private set; }

        /// <summary>
        /// Gets the list of log entries.
        /// </summary>
        public List<string> LogEntries { get; private set; }

        /// <summary>
        /// Gets only log lines with a type of "ERROR".
        /// </summary>
        public List<string> Errors => LogEntries.Where(e => LogTypeError.IsMatch(e)).ToList();

        /// <summary>
        /// Gets only log lines with a type of "WARNING".
        /// </summary>
        public List<string> Warnings => LogEntries.Where(e => LogTypeWarning.IsMatch(e)).ToList();

        /// <summary>
        /// Gets the most recent <paramref name="count" /> of entries, sorted newest first.
        /// </summary>
        /// <param name="count">The number of entries to retrieve.</param>
        /// <returns>A list of log entries of the specified <paramref name="count" />, newest first.</returns>
        public List<string> this[int count] => LogEntries.AsEnumerable().Reverse().Take(count).ToList();

        /// <summary>
        /// Initializes a new instance of the error log object with the specified <paramref name="log" /> data.
        /// </summary>
        /// <param name="log">The raw log data to parse.</param>
        public ErrorLogObject(string log)
        {
            RawLog = log;
            LogEntries = ParseLog(log);
        }

        /// <summary>
        /// Parses the raw log text and splits each entry out based on whether or not the line starts with a date.
        /// </summary>
        /// <param name="log">The log text to parse.</param>
        /// <returns>A parsed list of log entries.</returns>
        private static List<string> ParseLog(string log)
        {
            List<string> entries = new List<string>();
            var currentLine = "";

            foreach (var line in log.Replace("\r", "").Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                // If the first part of the entry is a date-like thing (DDDD-DD-DD), then consider this a "new" entry.
                // Sample: 2015-12-20 11:02:50 homeassistant.components.recorder: Found unfinished sessions
                if (NewLogLineRegex.IsMatch(line) && !string.IsNullOrWhiteSpace(currentLine))
                {
                    entries.Add(currentLine.Trim());
                    currentLine = "";
                }

                currentLine += line + "\r\n";
            }
            entries.Add(currentLine.Trim());

            return entries;
        }
    }
}
