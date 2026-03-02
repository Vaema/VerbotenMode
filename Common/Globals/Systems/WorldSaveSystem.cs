using System.Collections.Generic;
using System.IO;

using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace VerbotenMode.Common.Globals.Systems;

public class WorldSaveSystem : ModSystem
{
    public static bool VerbotenMode { get; set; }

    public override void OnWorldLoad()
    {
        VerbotenMode = false;
    }

    public override void OnWorldUnload()
    {
        VerbotenMode = false;
    }

    public override void SaveWorldData(TagCompound tag)
    {
        if (WorldGen.generatingWorld)
            return;

        var downed = new List<string>();
        if (VerbotenMode)
            downed.Add("VerbotenModeEnabled");

        tag["downed"] = downed;
    }

    public override void LoadWorldData(TagCompound tag)
    {
        var downed = tag.GetList<string>("downed");
        VerbotenMode = downed.Contains("VerbotenModeEnabled");
    }

    public override void NetSend(BinaryWriter writer)
    {
        BitsByte flags = new();
        flags[0] = VerbotenMode;
    }

    public override void NetReceive(BinaryReader reader)
    {
        BitsByte flags = reader.ReadByte();
        VerbotenMode = flags[0];
    }
}
