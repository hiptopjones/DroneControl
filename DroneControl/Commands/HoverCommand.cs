using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Commands
{
    class HoverCommand : ControlCommand
    {
        public HoverCommand(IControlConnection connection)
            : base(connection)
        {
        }

        protected override string GetCommand()
        {
            AtCommandBuilder builder = AtCommandBuilder.Instance;

            int flag = 1;
            int roll = 0;
            int pitch = 0;
            int gaz = 0;
            int yaw = 0;

            return builder.CreateAtCommand("PCMD", flag.ToString(), roll.ToString(), pitch.ToString(), gaz.ToString(), yaw.ToString());
        }
    }
}
