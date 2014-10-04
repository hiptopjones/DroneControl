using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Commands
{
    class ConfigCommand : ControlCommand
    {
        public ConfigCommand(IControlConnection connection)
            : base(connection)
        {
        }

        protected override string GetCommand()
        {
            //AtCommandBuilder builder = AtCommandBuilder.Instance;

            // https://projects.ardrone.org/boards/1/topics/show/3479
            //string sessionId = "ad1efdac";
            //string profileId = "992f7f4f";
            //string appId = "510acf97";

            //return
            //    builder.CreateAtCommand("CONFIG", Quote("custom:session_id"), Quote(sessionId)) +
            //    builder.CreateAtCommand("CONFIG_IDS", Quote(sessionId), Quote(profileId), Quote(appId)) +
            //    builder.CreateAtCommand("CONFIG", Quote("custom:session_id"), Quote(sessionId)) +
            //    builder.CreateAtCommand("CONFIG_IDS", Quote(sessionId), Quote(profileId), Quote(appId)) +
            //    builder.CreateAtCommand("CONFIG", Quote("custom:profile_id"), Quote(profileId)) +
            //    builder.CreateAtCommand("CONFIG_IDS", Quote(sessionId), Quote(profileId), Quote(appId)) +
            //    builder.CreateAtCommand("CONFIG", Quote("custom:application_id"), Quote(appId)) +
            //    builder.CreateAtCommand("CONFIG_IDS", Quote(sessionId), Quote(profileId), Quote(appId)) +
            //    builder.CreateAtCommand("CONFIG", Quote("leds:leds_anim"), Quote("3,1073741824,2"));

            return string.Empty;
        }

        private static string Quote(string text)
        {
            return "\"" + text + "\"";
        }
    }
}
