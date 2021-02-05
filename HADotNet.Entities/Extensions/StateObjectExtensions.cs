using System.Linq;
using Newtonsoft.Json.Linq;
using HADotNet.Core.Models;
using System.Collections.Generic;

namespace HADotNet.Entities.Extensions
{
    public static class StateObjectExtensions
    {
        public static T[] GetAttributeArray<T>(this StateObject stateObject, string name)
        {
            if (!stateObject.Attributes.ContainsKey(name))
                return new T [0];

            var jArray = stateObject.GetAttributeValue<JArray>(name);

            return ToArray<T>(jArray);
        }

        public static T[] GetAttributeArray<T>(this Dictionary<string, object> dictionary, string name)
        {
            if (!dictionary.ContainsKey(name))
                return new T[0];

            var jArray = (JArray) dictionary[name];

            return ToArray<T>(jArray);
        }

        public static T[] ToArray<T>(JArray jArray)
        {
            var result = jArray.Select(t => t.ToObject<T>()).ToArray();
            return result;
        }
    }
}
