using System;
using System.Collections.Generic;
using System.Text;
using HADotNet.Core.Models;
using HADotNet.Core.Clients;

namespace HADotNet.Core.EntityObjects
{
    /// <summary>
    /// For setting up lights representing HA lights and allowing control of them
    /// </summary>
    public class Light
    {
        private static string Domain => "light";

        /// <summary>
        /// The entity name in HA for the light
        /// </summary>
        public string EntityName { get; }

        /// <summary>
        /// Constructor that takes the entity name of the light to control as a string (Do not prepend light. to the entity name.)
        /// </summary>
        /// <param name="lightEntityName"></param>
        public Light(string lightEntityName)
        {
            EntityName = lightEntityName;
            serviceClient = ClientFactory.GetClient<ServiceClient>();
        }

        /// <summary>
        /// Calls the turn_on service in HA for the light
        /// </summary>
        /// <returns></returns>
        public List<StateObject> TurnOn()
        {
            var resultingState = serviceClient.CallService(Domain, "turn_on", new { entity_id = $"{Domain}.{EntityName}" });

            return resultingState.Result;
        }

        /// <summary>
        /// Calls the turn_off service in HA for the light
        /// </summary>
        /// <returns></returns>
        public List<StateObject> TurnOff()
        {
            var resultingState = serviceClient.CallService(Domain, "turn_off", new { entity_id = $"{Domain}.{EntityName}" });

            return resultingState.Result;
        }

        private ServiceClient serviceClient;
    }
}
