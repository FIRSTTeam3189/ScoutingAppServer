using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Text;
using flipyserverService.SQLDataObjects;
using Newtonsoft.Json.Linq;

namespace ScoutingModels.Test
{
    public static class JTokenExtensions
    {
        private const string EventLocation = "location";
        private const string EventType = "event_type";
        private const string EventCode = "event_code";
        private const string EventYear = "year";
        private const string EventWebsite = "website";
        private const string StartDate = "start_date";
        private const string EndDate = "end_date";
        private const string DateFormat = "yyyy-MM-dd";
        private const string EventName = "name";
        private const string EventOfficial = "official";

        /// <summary>
        /// Gets an Event from the JToken provided
        /// </summary>
        /// <param name="obj">Object to get it from</param>
        /// <returns>The Event</returns>
        public static Event GetEventFromJToken(this JToken obj)
        {
            obj.IsNotNull();

            DateTime? start = null;
            DateTime? end = null;
            DateTime t;

            // Get the DateTimes for start, end
            if (DateTime.TryParseExact(obj[StartDate].ToObject<string>(), DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal,
                out t))
                start = DateTime.ParseExact(obj[StartDate].ToObject<string>(), DateFormat,
                    CultureInfo.InvariantCulture);

            if (DateTime.TryParseExact(obj[EndDate].ToObject<string>(), DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal,
                out t))
                end = DateTime.ParseExact(obj[EndDate].ToObject<string>(), DateFormat,
                    CultureInfo.InvariantCulture);

            var ev = new Event
            {
                Location = obj[EventLocation].ToObject<string>(),
                Year = obj[EventYear].ToObject<int>(),
                EventCode = obj[EventCode].ToObject<string>(),
                Website = obj[EventWebsite].ToObject<string>() ?? "No EventWebsite",
                Id = Guid.NewGuid().ToString(),
                StartDate = start,
                EndDate = end,
                Name = obj[EventName].ToObject<string>(),
                Official = obj[EventOfficial].ToObject<bool>()
            };

            return ev;
        }

        /// <summary>
        /// Gets a Team's Information from JToken provided
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Team GetTeamFromJToken(this JToken obj)
        {
            obj.IsNotNull();

            var te = new Team
            {
                TeamNumber = obj["team_number"].ToObject<int>(),
                NickName = obj["nickname"].ToObject<string>(),
                RookieYear = obj["rookie_year"].ToObject<int?>() ?? -1,
                TeamLocation = obj["location"].ToObject<string>(),
                TeamPerformance = new List<Performance >()
            };

            return te;
        }

        /// <summary>
        /// Assertion test to check if an object of type T is not null
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Object to test</param>
        /// <returns>The object its self</returns>
        public static T IsNotNull<T>(this T obj) where T : class
        {
            Contract.Requires(obj != null);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            Contract.EndContractBlock();

            return obj;
        }
    }
}
