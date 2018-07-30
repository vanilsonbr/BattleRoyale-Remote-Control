using BattleRoyale.RemoteController.Server.Domain;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;

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
        /// Adds the client to the list of connected clients
        /// </summary>
        /// <param name="webSocket">webSocket information that will be added to the list</param>
        void OnClientConnected(Client client);

        /// <summary>
        /// Removes the client to the list of connected clients
        /// </summary>
        /// <param name="webSocket">webSocket information that will be removed from the list</param>
        void OnClientDisconnected(string clientMachineName);

        /// <summary>
        /// retrieves the client by its Local IP Address
        /// </summary>
        /// <param name="ipAddress">The client's local ip address</param>
        /// <returns></returns>
        Client GetClient(string ipAddress);

        /// <summary>
        /// Send a command to the connected client. The command must be a valid CMD or PoweShell command
        /// </summary>
        /// <param name="fullCommand">The command to be sent</param>
        /// <param name="client">The cliente where the command will be runned</param>
        /// <returns>The response sent back by the Client</returns>
        CommandResponse SendCommand(Command fullCommand, string clientMachineName);

        /// <summary>
        /// Send a command to all the connected clients. The command must be a valid CMD or PowerShell command
        /// </summary>
        /// <param name="fullCommand">The command to be sent</param>
        /// <returns>The response sent back by each of the connected Clients</returns>
        IList<CommandResponse> SendCommandAll(Command fullCommand);

        /// <summary>
        /// Tests if the CMD/PowerShell command is valid. 
        /// </summary>
        /// <param name="fullCommand">The command to be tested</param>
        /// <returns>Tue if the command is valid, false otherwise</returns>
        bool ValidateCommand(Command fullCommand);

    }
}
