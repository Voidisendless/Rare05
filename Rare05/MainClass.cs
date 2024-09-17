using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Scp914;
using System;

namespace Rare05
{
    public class Rare05 : Plugin<Config>
    {
        //setting basic plugin details
        public override string Name => "Rare05";
        public override string Author => "voidis3ndless";
        public override Version Version => new Version(1, 0, 0);

        private EventHandlers eventHandlers;

        public override void OnEnabled()
        {
            Log.Info("Rare05 is now running on your server!");

            eventHandlers = new EventHandlers(Config);

            //Subscribe to events
            Exiled.Events.Handlers.Server.RoundStarted += eventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Scp914.UpgradingPickup += eventHandlers.OnUpgradingPickup;
            Exiled.Events.Handlers.Scp914.UpgradingInventoryItem += eventHandlers.OnUpgradingItem;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Log.Info("Rare05 has been disabled!");
            //Unsubscribe from events
            Exiled.Events.Handlers.Server.RoundStarted -= eventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Scp914.UpgradingPickup -= eventHandlers.OnUpgradingPickup;
            Exiled.Events.Handlers.Scp914.UpgradingInventoryItem -= eventHandlers.OnUpgradingItem;

            base.OnDisabled();
        }
    }
}
