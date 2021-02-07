using System.Threading.Tasks;
using System.Collections.Generic;
using HADotNet.Core.Constants;
using HADotNet.Core.Models;

namespace HADotNet.Entities.Models
{
    /// <summary>
    /// Represents a media player entity
    /// </summary>
    public class MediaPlayer : Entity
    {
        public MediaPlayer() : base(DomainConstants.MediaPlayer)
        {
        }

        /// <summary>
        /// Turn on the media player
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> TurnOn()
        {
            return CallService(ServiceConstants.TurnOn);
        }

        /// <summary>
        /// Turn off the media player
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> TurnOff()
        {
            return CallService(ServiceConstants.TurnOff);
        }

        /// <summary>
        /// Toggle the media player
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> Toggle()
        {
            return CallService(ServiceConstants.Toggle);
        }

        /// <summary>
        /// Select a source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Task<List<StateObject>> SelectSource(string source)
        {
            var fields = new Dictionary<string, object>
            {
                { AttributeConstants.Source, source }
            };

            return CallService(ServiceConstants.SelectSource, fields);
        }

        /// <summary>
        /// Play
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> Play()
        {
            return CallService(ServiceConstants.MediaPlay);
        }

        /// <summary>
        /// Pause
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> Pause()
        {
            return CallService(ServiceConstants.MediaPause);
        }

        /// <summary>
        /// Stop
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> Stop()
        {
            return CallService(ServiceConstants.MediaStop);
        }

        /// <summary>
        /// Mute
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> Mute()
        {
            return CallService(ServiceConstants.Mute);
        }

        /// <summary>
        /// Volume up
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> VolumeUp()
        {
            return CallService(ServiceConstants.VolumeUp);
        }

        /// <summary>
        /// Volume down
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> VolumeDown()
        {
            return CallService(ServiceConstants.VolumeDown);
        }

        /// <summary>
        /// Volume set
        /// </summary>
        /// <param name="volume">The volume to set to</param>
        /// <returns></returns>
        public Task<List<StateObject>> VolumeSet(float volume)
        {
            var fields = new Dictionary<string, object>
            {
                { AttributeConstants.VolumeLevel, volume }
            };

            return CallService(ServiceConstants.VolumeSet, fields);
        }
    }
}
