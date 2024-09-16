using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Scp914;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using UnityEngine;
using System.Linq;

namespace Rare05
{
    public class EventHandlers
    {
        private readonly Config _config;

        public EventHandlers(Config config)
        {
            _config = config;
        }

        public void OnRoundStarted()
        {
            var config = _config;
            var rooms = Room.List.Where(room => config.SpawnRooms.Contains(room.Type)).ToList();
            int spawnCount = 0;

            foreach (var room in rooms)
            {
                if (spawnCount >= config.Max05Spawns)
                    break;

                if (UnityEngine.Random.Range(0f, 1f) <= config.SpawnChance)
                {
                    Pickup.CreateAndSpawn(ItemType.KeycardO5, room.Transform.position + Vector3.up, Quaternion.identity, null);
                    spawnCount++;
                }
            }
        }

        public void OnUpgradingPickup(UpgradingPickupEventArgs ev)
        {
            if (ev.Pickup.Type == ItemType.KeycardO5)
            {
                ev.IsAllowed = false;
            }
        }

        public void OnUpgradingItem(UpgradingInventoryItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.KeycardO5)
            {
                ev.IsAllowed = false;
            }
        }
    }
}
