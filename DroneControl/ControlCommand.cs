using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DroneControl
{
    public abstract class ControlCommand
    {
        private IControlConnection Connection { get; set; }

        public ControlCommand(IControlConnection connection)
        {
            Connection = connection;
        }

        public async Task Execute()
        {
            string command = GetCommand();
            await Connection.SendCommand(command);

            // TODO: Should send every 30ms until the navdata indicates the drone is off the ground
        }

        protected abstract string GetCommand();
    }
}
