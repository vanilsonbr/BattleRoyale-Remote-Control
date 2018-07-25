using BatteRoyale.RemoteController.Server.Services.Interface;
using BattleRoyale.RemoteController.Server.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BatteRoyale.RemoteController.Server.Services
{
    public class RemoteControlService : IRemoteControlService
    {
        private List<Client> _clientsMock = null;

        public RemoteControlService()
        {
            _clientsMock = new List<Client>();

            _clientsMock.Add(new Client
            {
                HardDriveInformation = new HardDriveInformation
                {
                    AvailableSize = "50.000",
                    TotalSize = "100.000"
                },
                InstalledAntivirus = new Antivirus
                {
                    Name = "Norton Antivirus",
                    Vendor = "Norton",
                    Version = "35.4.383"
                },
                InstalledDotNetVersion = "4.6.2",
                IsFirewallActivated = true,
                LocalIPAddress = "192.168.45.25",
                MachineName = "Vanilson's PC",
                WindowsSpecs = new WindowsSpecs
                {
                    Version = "Windows 10",
                    ServicePack = "1"
                }
            });

            _clientsMock.Add(new Client
            {
                HardDriveInformation = new HardDriveInformation
                {
                    AvailableSize = "340.000",
                    TotalSize = "1.024.000"
                },
                InstalledAntivirus = new Antivirus
                {
                    Name = "Symantec Antivirus",
                    Vendor = "Symantec",
                    Version = "25.8.2"
                },
                InstalledDotNetVersion = "4.5",
                IsFirewallActivated = false,
                LocalIPAddress = "192.168.23.78",
                MachineName = "Pedro's PC",
                WindowsSpecs = new WindowsSpecs
                {
                    Version = "Windows 7",
                    ServicePack = "3"
                }
            });

        }

        public IList<Client> ConnectedClients()
        {
            return _clientsMock;
        }

        public CommandResponse SendCommand(string fullCommand, Client client)
        {
            throw new NotImplementedException();
        }

        public IList<CommandResponse> SendCommandAll(string fullCommand)
        {
            throw new NotImplementedException();
        }

        public bool ValidateCommand(string fullCommand)
        {
            throw new NotImplementedException();
        }
    }
}
