using System;

namespace BattleRoyale.RemoteController.Server.Domain
{
    public class Client
    {
        public string MachineName { get; set; }
        public string LocalIPAddress { get; set; }
        public Antivirus InstalledAntivirus { get; set; }
        public bool IsFirewallActivated { get; set; }
        public WindowsSpecs WindowsSpecs { get; set; }
        public string InstalledDotNetVersion { get; set; }
        public HardDriveInformation HardDriveInformation { get; set; }
    }
}
