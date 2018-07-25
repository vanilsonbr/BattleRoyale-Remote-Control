using BattleRoyale.RemoteController.Server.Domain;
using System;
using System.Collections.Generic;

namespace BatteRoyale.RemoteController.Server.Services.Interface
{
    public interface IRemoteControlService
    {
        /// <summary>
        /// Verify all the clients connected to the server
        /// </summary>
        /// <returns>A list of connected clients with all the details given when registered</returns>
        IList<Client> ConnectedClients();

        /// <summary>
        /// Send a command to the connected client. The command must be a valid CMD or PoweShell command
        /// </summary>
        /// <param name="fullCommand">The command to be sent</param>
        /// <param name="client">The cliente where the command will be runned</param>
        /// <returns>The response sent back by the Client</returns>
        CommandResponse SendCommand(string fullCommand, Client client);

        /// <summary>
        /// Send a command to all the connected clients. The command must be a valid CMD or PowerShell command
        /// </summary>
        /// <param name="fullCommand">The command to be sent</param>
        /// <returns>The response sent back by each of the connected Clients</returns>
        IList<CommandResponse> SendCommandAll(string fullCommand);

        /// <summary>
        /// Tests if the CMD/PowerShell command is valid. 
        /// </summary>
        /// <param name="fullCommand">The command to be tested</param>
        /// <returns>Tue if the command is valid, false otherwise</returns>
        bool ValidateCommand(string fullCommand);

    }
}
