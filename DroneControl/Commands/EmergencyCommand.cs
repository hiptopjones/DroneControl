using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Commands
{
    class EmergencyCommand : ControlCommand
    {
        public EmergencyCommand(IControlConnection connection)
            : base(connection)
        {
        }

        protected override string GetCommand()
        {
            AtCommandBuilder builder = AtCommandBuilder.Instance;

            int takeOffArgument = builder.GetBlankRefArgument();
            takeOffArgument |= (1 << 8);

            return builder.CreateAtCommand("REF", takeOffArgument.ToString());
        }
    }
}
