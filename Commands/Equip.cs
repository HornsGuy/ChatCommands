using NetworkMessages.FromServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Diamond;
using TaleWorlds.ObjectSystem;

namespace ChatCommands.Commands
{
    class Equip : Command
    {
        public bool CanUse(NetworkCommunicator networkPeer)
        {
            bool isAdmin = false;
            bool isExists = AdminManager.Admins.TryGetValue(networkPeer.VirtualPlayer.Id.ToString(), out isAdmin);
            return isExists && isAdmin;
        }

        public string Command()
        {
            return "!equip";
        }

        public string Description()
        {
            return "Command to equip a beefy set of armor";
        }


        public bool Execute(NetworkCommunicator networkPeer, string[] args)
        {
            List<Tuple<EquipmentIndex, string>> equipment = new List<Tuple<EquipmentIndex, string>>();

            equipment.Add(new Tuple<EquipmentIndex,string>(EquipmentIndex.Head,"mp_plumed_lamellar_helmet"));

            AdminPanel.Instance.GivePlayerAgentCosmeticEquipment(networkPeer, equipment);

            return true;
        }
    }
}
