using BatteRoyale.RemoteController.Server.Services.Interface;
using BattleRoyale.RemoteController.Server.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BatteRoyale.RemoteController.Server.Services
{
    public class RemoteControlService : IRemoteControlService
    {
        private List<Client> _clientConnections;

        public RemoteControlService()
        {
            _clientConnections = new List<Client>();
        }

        public IList<Client> ConnectedClients()
        {
            return _clientConnections;
        }

        public void OnClientConnected(Client client)
        {
            bool clientExists = _clientConnections.Any(
                c => c.MachineName.ToLower() == client.MachineName.ToLower() &&
                     c.LocalIPAddress == client.LocalIPAddress);

            if (!clientExists)
            {
                // verify if client has some required properties
                // bool clientOk = this.VerifyClient(client);
                //if(clientOk) {
                _clientConnections.Add(client);
                //}
            }

        }

        public void OnClientDisconnected(string clientMachineName)
        {
            try
            {
                //remove from the list
                var client = _clientConnections.FirstOrDefault(c => c.MachineName == clientMachineName);
                if(client != null)
                {
                    _clientConnections.Remove(client);
                }

            }
            catch (Exception ex)
            {
                // not treating exceptions right now for debug propouse
                throw ex;
            }

        }

        public CommandResponse SendCommand(Command fullCommand, string clientMachineName)
        {
            throw new NotImplementedException();
        }

        public IList<CommandResponse> SendCommandAll(Command fullCommand)
        {
            List<CommandResponse> responses = new List<CommandResponse>();

            foreach (var clientConnection in _clientConnections)
            {
                responses.Add(this.SendCommand(fullCommand, clientConnection.MachineName));
            }

            return responses;
        }

        public bool ValidateCommand(Command fullCommand)
        {
            throw new NotImplementedException();
        }
    }
}
