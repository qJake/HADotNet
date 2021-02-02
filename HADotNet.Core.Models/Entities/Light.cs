using System.Collections.Generic;
using System.Threading.Tasks;

namespace HADotNet.Core.Models.Entities
{
    public class Light : Entity
    {
        public Light() : base("light")
        {
        }

        public Task<List<StateObject>> TurnOn()
        {
            return CallService("turn_on");
        }

        public Task<List<StateObject>> TurnOff()
        {
            return CallService("turn_off");
        }
    }
}
