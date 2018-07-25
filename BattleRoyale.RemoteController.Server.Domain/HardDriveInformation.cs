using System;
using System.Collections.Generic;
using System.Text;

namespace BattleRoyale.RemoteController.Server.Domain
{
    public class HardDriveInformation
    {
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
