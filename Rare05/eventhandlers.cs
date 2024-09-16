using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled;
using Exiled.API.Features;
using Exiled.CustomItems.API.EventArgs;
using Exiled.Events.EventArgs;
using Exiled.Events.Features;
using Unity.Engine;

namespace Rare05
{
    public class EventHandlers
    {

        public static void OnRoundStarted()
        {
            var config = Plugin.Singleton.Config;
            var rooms = Map.Rooms.Where(room => config.SpawnRooms.Contains(room.Type)).ToList();
            int spawnCount = 0;

            foreach (var room in rooms)
            {
                if (spawnCount >= config.Max05Spawns)
                    break;

                if (UnityEngine.Random.Range(0f, 1f) <= config.SpawnChance)
                {
                    var item = room.SpawnItem(ItemType.KeycardO5);
                    spawnCount++;
                }


            }
        }
        public void OnItemUpgraded(UpgradingItemsEventArgs ev)
        {
            if (ev.OutputItem == ItemType.KeycardO5)
            {
                ev.IsAllowed = false;
            }
        }
    }
}

