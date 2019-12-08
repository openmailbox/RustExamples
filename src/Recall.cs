using Oxide.Core.Libraries.Covalence;
using System.Collections.Generic;

namespace Oxide.Plugins
{
    // A simple teleportation script that allows players to set a "home"
    // with the /sethome command then instantly teleport to it from anywhere
    // on the map using the /recall command.
    [Info("Recall", "open_mailbox", "0.0.1")]
    class Recall : CovalencePlugin
    {
        private Dictionary<string, GenericPosition> homes = new Dictionary<string, GenericPosition>();

        private void Init()
        {
            Puts("Recall mod initialized.");
        }

        [Command("sethome")]
        private void CommandSetHome(IPlayer player, string cmd, string[] args)
        {
            homes[player.Id] = player.Position();
            player.Reply("Your home has been set to your current location.");
        }

        [Command("recall")]
        private void CommandRecall(IPlayer player, string cmd, string[] args)
        {
            if (!homes.ContainsKey(player.Id))
            {
                player.Reply("You do not have a home set.");
                return;
            }

            player.Teleport(homes[player.Id]);
            player.Reply("Sending you home!");
        }
    }
}
