using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Commands
{
    class RotateCommand : ControlCommand
    {
        private double AngularSpeed { get; set; }
        public RotateCommand(IControlConnection connection, double angularSpeed)
            : base(connection)
        {
            AngularSpeed = angularSpeed;
        }

        protected override string GetCommand()
        {
            AtCommandBuilder builder = AtCommandBuilder.Instance;
            
            int flag = 1;
            int rollValue = 0;
            int pitchValue = 0;
            int gazValue = 0;
            int yawValue = (int)(BitConverter.DoubleToInt64Bits(AngularSpeed) >> 32);

            return builder.CreateAtCommand("PCMD", flag.ToString(), rollValue.ToString(), pitchValue.ToString(), gazValue.ToString(), yawValue.ToString());
        }
    }
}
