using Oxide.Core.Libraries.Covalence;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Oxide.Plugins
{
    // A basic /spawngift command that allows a player to periodically spawn a gift directly in front of themselves.
    [Info("SpawnGift", "open_mailbox", "0.0.1")]
    class SpawnGift : CovalencePlugin
    {
        private const int    ALLOWED_INTERVAL_SECONDS = 10;
        private const string GIFT                     = "assets/prefabs/misc/xmas/giftbox/giftbox_loot.prefab";

        private Dictionary<string, DateTime> spawnTimes = new Dictionary<string, DateTime>();

        [Command("spawngift")]
        private void CommandSpawnGift(IPlayer player, string cmd, string[] args)
        {
            if (spawnTimes.ContainsKey(player.Id))
            {
                var lastGiftTime     = spawnTimes[player.Id];
                var secondsSinceGift = (DateTime.Now - lastGiftTime).Seconds;

                if (secondsSinceGift < ALLOWED_INTERVAL_SECONDS)
                {
                    player.Reply($"You must wait {ALLOWED_INTERVAL_SECONDS - secondsSinceGift} more seconds.");
                    return;
                }
            }

            var spawnPosition = new Vector3(player.Position().X + 1.5f, player.Position().Y, player.Position().Z);
            var entity        = GameManager.server.CreateEntity(GIFT, spawnPosition);

            entity.Spawn();
            spawnTimes[player.Id] = DateTime.Now;

            Log($"{player.Name} spawned a gift at {spawnPosition}.");
        }
    }
}
