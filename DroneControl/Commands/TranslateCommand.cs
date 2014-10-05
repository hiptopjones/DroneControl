using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Commands
{
    class TranslateCommand : ControlCommand
    {
        private double Roll { get; set; }
        private double Pitch { get; set; }
        private double Lift { get; set; }

        public TranslateCommand(IControlConnection connection, double roll, double pitch, double lift)
            : base(connection)
        {
            Roll = roll;
            Pitch = pitch;
            Lift = lift;
        }

        protected override string GetCommand()
        {
            AtCommandBuilder builder = AtCommandBuilder.Instance;
            
            int flag = 1;
            int rollValue = (int)(BitConverter.DoubleToInt64Bits(Roll) >> 32);
            int pitchValue = (int)(BitConverter.DoubleToInt64Bits(Pitch) >> 32);
            int gazValue = (int)(BitConverter.DoubleToInt64Bits(Lift) >> 32);
            int yawValue = 0;

            return builder.CreateAtCommand("PCMD", flag.ToString(), rollValue.ToString(), pitchValue.ToString(), gazValue.ToString(), yawValue.ToString());
        }
    }
}
