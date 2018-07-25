using System;
using System.Collections.Generic;
using System.Text;

namespace BattleRoyale.RemoteController.Server.Domain
{
    public class CommandResponse
    {
        public string CommandSent { get; set; }
        public Client Client { get; set; }
        public string Response { get; set; }
    }
}
