using Exiled.API.Features;
using System;
using Exiled.Events.EventArgs;

namespace Rare05
{
    public class Rare05 : Plugin<Config>
    {
        public override string Name => "Rare05";
        public override string Author => "voidis3ndless";
        public override Version Version => new Version(1, 0, 0);

        public override void OnEnabled()
        {
            Log.Info("Rare05 is now running on your server!");
            Exiled.Events.Handlers.Server.RoundStarted += eventHandlers.OnRoundStarted;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Log.Info("Rare05 has been disabled!");
            Exiled.Events.Handlers.Server.RoundStarted -= eventHandlers.OnRoundStarted;
            base.OnDisabled();
        }
    }
}
