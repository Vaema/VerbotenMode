using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace VerbotenMode.Common.Globals.Systems;

public class WorldSyncSystem : ModSystem
{
    public override void NetSend(BinaryWriter writer)
    {
        BitsByte flags = new();
        flags[0] = WorldSaveSystem.VerbotenMode;
    }

    public override void NetReceive(BinaryReader reader)
    {
        BitsByte flags = reader.ReadByte();
        WorldSaveSystem.VerbotenMode = flags[0];
    }
}