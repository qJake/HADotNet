using System.Collections.Generic;
using System.Threading.Tasks;
using HADotNet.Core.Constants;
using HADotNet.Core.Models;
using HADotNet.Entities.Models.Interfaces;

namespace HADotNet.Entities.Models
{
    /// <summary>
    /// Represents a climate entity
    /// </summary>
    public class Climate : Entity, ITurnOn, ITurnOff
    {
        /// <summary>
        /// Creates a climate entity
        /// </summary>
        public Climate() : base(DomainConstants.Climate) 
        {
        }

        /// <summary>
        /// Current humidity
        /// </summary>
        public double CurrentHumidity => GetAttributeValue<double>(AttributeConstants.CurrentHumidity);

        /// <summary>
        /// Current temperature
        /// </summary>
        public double CurrentTemperature => GetAttributeValue<double>(AttributeConstants.CurrentTemperature);

        /// <summary>
        /// HVAC action
        /// </summary>
        public string HvacAction => GetAttributeValue<string>(AttributeConstants.HvacAction);

        /// <summary>
        /// List of possible HVAC modes
        /// </summary>
        public string[] HvacModes => GetAttributeArray<string>(AttributeConstants.HvacModes);

        /// <summary>
        /// Maximum temperature
        /// </summary>
        public double MaxTemp => GetAttributeValue<double>(AttributeConstants.MaxTemp);

        /// <summary>
        /// Minimum temperature
        /// </summary>
        public double MinTemp => GetAttributeValue<double>(AttributeConstants.MinTemp);

        /// <summary>
        /// Offset in Celsius
        /// </summary>
        public double OffsetCelsius => GetAttributeValue<double>(AttributeConstants.OffsetCelsius);

        /// <summary>
        /// Offset in Fahrenheit
        /// </summary>
        public double OffsetFahrenheit => GetAttributeValue<double>(AttributeConstants.OffsetFahrenheit);

        /// <summary>
        /// Preset mode
        /// </summary>
        public string PresetMode => GetAttributeValue<string>(AttributeConstants.PresetMode);

        /// <summary>
        /// List of possible preset modes
        /// </summary>
        public string[] PresetModes => GetAttributeArray<string>(AttributeConstants.PresetModes);

        /// <summary>
        /// Target temperature step
        /// </summary>
        public double TargetTempStep => GetAttributeValue<double>(AttributeConstants.TargetTempStep);

        /// <summary>
        /// Target temperature
        /// </summary>
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
                { AttributeConstants.Temperature, temperature }
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
                { AttributeConstants.HvacMode, hvacMode }
            };

            return CallService(ServiceConstants.SetHvacMode, data);
        }
    }
}
