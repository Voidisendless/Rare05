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
            if (_config.Debug)
                Log.Debug("Round started event triggered.");

            var config = _config;
            var rooms = Room.List.Where(room => config.SpawnRooms.Contains(room.Type)).ToList();
            int spawnCount = 0;

            foreach (var room in rooms)
            {
                if (spawnCount >= config.Max05Spawns)
                    break;

                if (UnityEngine.Random.Range(0f, 1f) <= config.SpawnChance)
                {
                    if (_config.Debug)
                        Log.Debug($"Spawning O5 Keycard in room {room.Type}");

                    Pickup.CreateAndSpawn(ItemType.KeycardO5, room.Transform.position + Vector3.up, Quaternion.identity, null);
                    if (_config.Debug)
                        Log.Debug($"Spawned O5 Keycard in room {room.Type}");
                    spawnCount++;
                }
            }
        }

        public void OnUpgradingPickup(UpgradingPickupEventArgs ev)
        {
            if (_config.Debug)
                Log.Debug($"UpgradingPickup event triggered for item: {ev.Pickup.Type}");

            if (ev.Pickup.Type == ItemType.KeycardO5)
            {
                ev.IsAllowed = false;
                if (_config.Debug)
                    Log.Debug("O5 Keycard upgrade blocked.");
            }
            else
            {
                if (_config.Debug)
                    Log.Debug($"Item is not Keycard O5. Actual type: {ev.Pickup.Type}");
            }
        }

        public void OnUpgradingItem(UpgradingInventoryItemEventArgs ev)
        {
            if (_config.Debug)
                Log.Debug($"UpgradingItem event triggered for item: {ev.Item.Type}");

            if (ev.Item.Type == ItemType.KeycardO5)
            {
                ev.IsAllowed = false;
                if (_config.Debug)
                    Log.Debug("O5 Keycard upgrade blocked.");
            }
            else
            {
                if (_config.Debug)
                    Log.Debug($"Item is not Keycard O5. Actual type: {ev.Item.Type}");
            }
        }


        public void OnScp914Activating(ActivatingEventArgs ev)
        {
            if (_config.Debug)
                Log.Debug("SCP-914 Activating event triggered.");
        }

    }
}
