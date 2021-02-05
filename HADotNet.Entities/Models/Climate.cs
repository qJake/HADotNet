using System.Collections.Generic;
using System.Threading.Tasks;
using HADotNet.Core.Constants;
using HADotNet.Core.Models;

namespace HADotNet.Entities.Models
{
    /// <summary>
    /// Represents a climate entity
    /// </summary>
    public class Climate : Entity
    {
        /// <summary>
        /// Creates a climate entity
        /// </summary>
        public Climate() : base(DomainConstants.Climate) 
        {
        }

        public double CurrentHumidity => GetAttributeValue<double>(AttributeConstants.CurrentHumidity);
        public double CurrentTemperature => GetAttributeValue<double>(AttributeConstants.CurrentTemperature);
        public string HvacAction => GetAttributeValue<string>(AttributeConstants.HvacAction);
        public string[] HvacModes => GetAttributeArray<string>(AttributeConstants.HvacModes);
        public double MaxTemp => GetAttributeValue<double>(AttributeConstants.MaxTemp);
        public double MinTemp => GetAttributeValue<double>(AttributeConstants.MinTemp);
        public double OffsetCelsius => GetAttributeValue<double>(AttributeConstants.OffsetCelsius);
        public double OffsetFahrenheit => GetAttributeValue<double>(AttributeConstants.OffsetFahrenheit);
        public string PresetMode => GetAttributeValue<string>(AttributeConstants.PresetMode);
        public string[] PresetModes => GetAttributeArray<string>(AttributeConstants.PresetModes);
        public double TargetTempStep => GetAttributeValue<double>(AttributeConstants.TargetTempStep);
        public double Temperature => GetAttributeValue<double>(AttributeConstants.Temperature);

        /// <summary>
        /// Turn on the climate entity
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> TurnOn()
        {
            return CallService(ServiceConstants.TurnOn);
        }

        /// <summary>
        /// Turn off the climate entity
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> TurnOff()
        {
            return CallService(ServiceConstants.TurnOff);
        }

        /// <summary>
        /// Sets the temperature of the climate entity
        /// </summary>
        /// <param name="temperature">The temperature to set to</param>
        /// <returns></returns>
        public Task<List<StateObject>> SetTemperature(float temperature)
        {
            var data = new Dictionary<string, object>
            {
                { AttributeConstants .Temperature, temperature }
            };

            return CallService(ServiceConstants.SetTemperature, data);
        }

        /// <summary>
        /// Sets the HVAC mode of the climate entity
        /// </summary>
        /// <param name="hvacMode"></param>
        /// <returns></returns>
        public Task<List<StateObject>> SetHvacMode(string hvacMode)
        {
            var data = new Dictionary<string, object>
            {
                { AttributeConstants .HvacMode, hvacMode }
            };

            return CallService(ServiceConstants.SetHvacMode, data);
        }
    }
}
