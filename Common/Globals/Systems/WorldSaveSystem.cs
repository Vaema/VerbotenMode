using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace VerbotenMode.Common.Globals.Systems;

public class WorldSaveSystem : ModSystem
{
    public static bool VerbotenMode { get; set; }

    public override void SaveWorldData(TagCompound tag)
    {
        if (WorldGen.generatingWorld)
            return;

        var downed = new List<string>();
        if (VerbotenMode)
            downed.Add("VerbotenModeActive");

        tag["downed"] = downed;
    }

    public override void LoadWorldData(TagCompound tag)
    {
        var downed = tag.GetList<string>("downed");
        VerbotenMode = downed.Contains("VerbotenModeActive");
    }
}