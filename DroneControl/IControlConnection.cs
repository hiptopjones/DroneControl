using System;
using System.Threading.Tasks;

namespace DroneControl
{
    public interface IControlConnection
    {
        bool IsConnected { get; }
        void Close();
        Task Connect();
        Task SendCommand(string command);
    }
}
