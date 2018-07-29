using BattleRoyale.RemoteController.Server.Domain;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BatteRoyale.RemoteController.Server.Services.Interface
{
    public interface IClient
    {
        /// <summary>
        /// Represents the client information for this instance
        /// </summary>
        Client Client { get; set; }

        /// <summary>
        /// Sends a command to the client
        /// </summary>
        /// <param name="command">The command arguments and shell type</param>
        /// <returns>Response from the client, after the command is completely executed</returns>
        CommandResponse SendCommand(Command command);

        /// <summary>
        /// occurs when the client shutdown it's machine and asks the server to disable the connection
        /// </summary>
        bool DisconnectClient();

        /// <summary>
        /// Checks if the client is still connected to the server
        /// </summary>
        /// <returns>true if connected, false otherwise</returns>
        bool IsConnected();
    }
}
