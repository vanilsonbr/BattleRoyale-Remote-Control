using System;
using System.Collections.Generic;
using System.Text;

namespace BattleRoyale.RemoteController.Server.Domain
{
    public class HardDriveInformation
    {
        /// <summary>
        /// The name of the hard drive
        /// </summary>
        public string HardDriveName { get; set; }
        /// <summary>
        /// Total hard drive size in MBs
        /// </summary>
        public string TotalSize { get; set; }
        /// <summary>
        /// Avaiable size in MBs
        /// </summary>
        public string AvailableSize { get; set; }
    }
}
