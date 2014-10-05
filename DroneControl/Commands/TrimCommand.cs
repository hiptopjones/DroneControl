using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Commands
{
    class TrimCommand : ControlCommand
    {
        public TrimCommand(IControlConnection connection)
            : base(connection)
        {
        }

        protected override string GetCommand()
        {
            AtCommandBuilder builder = AtCommandBuilder.Instance;
            return builder.CreateAtCommand("FTRIM");
        }
    }
}
