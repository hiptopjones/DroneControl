using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Commands
{
    class LandCommand : ControlCommand
    {
        public LandCommand(IControlConnection connection)
            : base(connection)
        {
        }

        protected override string GetCommand()
        {
            AtCommandBuilder builder = AtCommandBuilder.Instance;

            int takeOffArgument = builder.GetBlankRefArgument();
            takeOffArgument |= (0 << 9);

            return builder.CreateAtCommand("REF", takeOffArgument.ToString());
        }
    }
}
