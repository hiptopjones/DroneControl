using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneControl
{
    public class AtCommandBuilder
    {
        static readonly AtCommandBuilder _instance = new AtCommandBuilder();

        private object _sequenceLock = new object();
        private int SequenceId { get; set; }

        public static AtCommandBuilder Instance
        {
            get
            {
                return _instance;
            }
        }

        private AtCommandBuilder()
        {
        }

        public void ResetSequence()
        {
            lock (_sequenceLock)
            {
                SequenceId = 0;
            }
        }

        public string CreateAtCommand(string commandName, params string[] arguments)
        {
            lock (_sequenceLock)
            {
                SequenceId++;
                return string.Format("AT*{0}={1},{2}\r", commandName, SequenceId, string.Join(",", arguments));
            }
        }

        public int GetBlankRefArgument()
        {
            int takeOffArgument = 0;
            takeOffArgument |= (1 << 18);  // Reserved (required)
            takeOffArgument |= (1 << 20);  // Reserved (required)
            takeOffArgument |= (1 << 22);  // Reserved (required)
            takeOffArgument |= (1 << 24);  // Reserved (required)
            takeOffArgument |= (1 << 28);  // Reserved (required)
            return takeOffArgument;
        }
    }
}
