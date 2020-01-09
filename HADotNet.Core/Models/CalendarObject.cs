using System;
using System.Collections.Generic;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents a calendar item from the Calendar API.
    /// </summary>
    public class CalendarObject
    {
        /// <summary>
        /// Gets or sets the Attendee list, if applicable.
        /// </summary>
        public List<CalendarPersonObject> Attendees { get; set; }

        /// <summary>
        /// Gets or sets the Created time of the event.
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the creator of the event.
        /// </summary>
        public CalendarPersonObject Creator { get; set; }

        /// <summary>
        /// Gets or sets the end time of the event.
        /// </summary>
        public CalendarDateTimeObject End { get; set; }

        /// <summary>
        /// Gets or sets the eTag for this object.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the HTML link for this calendar item.
        /// </summary>
        public string HtmlLink { get; set; }

        /// <summary>
        /// Gets or sets the iCal UID for this calendar item.
        /// </summary>
        public string ICalUID { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of this calendar item.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the kind of item (e.g. "calendar#event").
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the location of the event.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the organizer of the event.
        /// </summary>
        public CalendarPersonObject Organizer { get; set; }

        /// <summary>
        /// Gets or sets the original start time of the event.
        /// </summary>
        public CalendarDateTimeObject OriginalStartTime { get; set; }

        /// <summary>
        /// Gets or sets the recurring ID, if this is a recurring item.
        /// </summary>
        public string RecurringEventId { get; set; }

        /// <summary>
        /// Gets or sets if there are any reminders for this event.
        /// </summary>
        public CalendarRemindersObject Reminders { get; set; }

        /// <summary>
        /// Gets or sets the sequence number of this event, if applicable.
        /// </summary>
        public int? Sequence { get; set; }

        /// <summary>
        /// Gets or sets the start time of the event.
        /// </summary>
        public CalendarDateTimeObject Start { get; set; }

        /// <summary>
        /// Gets or sets the status of this event (e.g. "confirmed").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the summary, or title, of this event.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the transparency of this event (e.g. "transparent").
        /// </summary>
        public string Transparency { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when this item was last updated.
        /// </summary>
        public DateTime? Updated { get; set; }
    }

    /// <summary>
    /// Represents a person (an organizer, an attendee, etc) for an event.
    /// </summary>
    public class CalendarPersonObject
    {
        /// <summary>
        /// Gets or sets the display name for this person.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the person's e-mail address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the response if this is an attendee person (e.g. "accepted").
        /// </summary>
        public string ResponseStatus { get; set; }

        /// <summary>
        /// Gets or sets if this is the same person as the owner of this calendar (yourself).
        /// </summary>
        public bool? Self { get; set; }

        /// <summary>
        /// Gets or sets if this is the organizer of the event, for attendees.
        /// </summary>
        public bool? Organizer { get; set; }
    }

    /// <summary>
    /// Represents a date/time with a timezone.
    /// </summary>
    public class CalendarDateTimeObject
    {
        /// <summary>
        /// The date of the event, if the event is all-day.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// The date/time of the event, in local time (with an offset).
        /// </summary>
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// The timezone of this date/time. Not always present.
        /// </summary>
        public string TimeZone { get; set; }
    }

    /// <summary>
    /// Represents a reminder override notification.
    /// </summary>
    public class CalendarReminderOverrideObject
    {
        /// <summary>
        /// The method of notification.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// The number of minutes before the event starts.
        /// </summary>
        public int? Minutes { get; set; }
    }

    /// <summary>
    /// Represents a set of reminders for an event.
    /// </summary>
    public class CalendarRemindersObject
    {
        /// <summary>
        /// Whether or not to use the account's default reminder period for this event.
        /// </summary>
        public bool? UseDefault { get; set; }

        /// <summary>
        /// A list of specific notifications or reminders for this event only.
        /// </summary>
        public List<CalendarReminderOverrideObject> Overrides { get; set; }
    }
}
