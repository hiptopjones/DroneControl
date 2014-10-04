using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl.Commands
{
    // http://www.robotappstore.com/Knowledge-Base/How-to-Control-ARDrone-LEDs/100.html
    // https://projects.ardrone.org/boards/1/topics/show/2393
    public class LedCommand : ControlCommand
    {
        public enum AnimationType
        {
            BlinkGreenRed,
            BlinkGreen,
            BlinkRed,
            BlinkOrange,
            SnakeGreenRed,
            Fire,
            Standard,
            Red,
            Green,
            RedSnake,
            Blank,
            RightMissile,
            LeftMissile,
            DoubleMissile,
            FrontLeftGreenOthersRed,
            FrontRightGreenOthersRed,
            RearRightGreenOthersRed,
            RearLeftGreenOthersRed,
            LeftGreenRightRed,
            LeftRedRightGreen,
            BlinkStandard,
        }

        private AnimationType Type { get; set; }
        private TimeSpan Duration { get; set; }
        private double FrequencyHz { get; set; }

        public LedCommand(IControlConnection connection, AnimationType type, TimeSpan duration, double frequencyHz)
            : base(connection)
        {
            Type = type;
            Duration = duration;
            FrequencyHz = frequencyHz;
        }

        protected override string GetCommand()
        {
            AtCommandBuilder builder = AtCommandBuilder.Instance;

            int frequencyValue = (int)(BitConverter.DoubleToInt64Bits(FrequencyHz) >> 32);
            int typeValue = (int)Type;
            int durationValue = (int)Duration.TotalSeconds;

            return builder.CreateAtCommand("LED", typeValue.ToString(), frequencyValue.ToString(), durationValue.ToString());
        }
    }
}
