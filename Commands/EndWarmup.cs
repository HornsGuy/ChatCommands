﻿using NetworkMessages.FromServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.DedicatedCustomServer;



namespace ChatCommands.Commands
{

    class EndWarmup : Command
    {
        public bool CanUse(NetworkCommunicator networkPeer)
        {
            bool isAdmin = false;
            bool isExists = AdminManager.Admins.TryGetValue(networkPeer.VirtualPlayer.Id.ToString(), out isAdmin);
            return isExists && isAdmin;
        }

        public string Command()
        {
            return "!endwarmup";
        }

        public string Description()
        {
            return "Ends warmup mode";
        }

        public bool Execute(NetworkCommunicator networkPeer, string[] args)
        {
            AdminPanel.Instance.EndWarmup();

            return true;
        }
    }
}
