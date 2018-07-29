using System;
using System.Collections.Generic;
using System.Text;

namespace BattleRoyale.RemoteController.Server.Domain
{
    public enum ShellType
    {
        Cmd = 0,
        PowerShell = 1
    }

    public class Command
    {
        public string Arguments { get; set; }
        public ShellType ShellType { get; set; }
    }
}
