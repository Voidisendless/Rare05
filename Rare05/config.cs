using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using System.ComponentModel;

namespace Rare05
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }
        public bool Debug { get; set; }


        [Description("List of room types where 05 Keycards can spawn.")]
        public List<RoomType> SpawnRooms { get; set; } = new List<RoomType>
    {
        RoomType.HczHid,
        RoomType.Hcz079
    };

        [Description("Maximum number of 05 Keycards that can spawn per round.")]
        public int Max05Spawns { get; set; } = 1;

        [Description("Chance for an 05 Keycard to spawn in each selected room.")]
        public float SpawnChance { get; set; } = 0.25f;
    }
}
