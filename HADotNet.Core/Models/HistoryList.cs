using System;
using System.Collections.Generic;
using System.Linq;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents a list of one or more historical states for an entity.
    /// </summary>
    public class HistoryList : List<StateObject>
    {
        /// <summary>
        /// Gets the EntityId for the state objects in this list.
        /// </summary>
        public string EntityId => Count > 0 ? this[0].EntityId : null;

        /// <summary>
        /// Gets the earliest point in time represented by this history list.
        /// </summary>
        public DateTimeOffset DateFrom => Count > 0 ? this.OrderBy(s => s.LastUpdated).First().LastUpdated : DateTimeOffset.MinValue;

        /// <summary>
        /// Gets the most recent point in time represented by this history list.
        /// </summary>
        public DateTimeOffset DateTo => Count > 0 ? this.OrderByDescending(s => s.LastUpdated).First().LastUpdated : DateTimeOffset.MaxValue;

        /// <summary>
        /// Gets a string representation of this object.
        /// </summary>
        public override string ToString() => $"Historical state: {EntityId} - {Count} state(s)";
    }
}
