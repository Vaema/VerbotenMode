using CalamityMod.World;
using Terraria;
using VerbotenMode.Common.Globals.Systems;

namespace VerbotenMode.Common.Utilities;

public static partial class VerbotenUtils
{
    public static void SetLifeMaxByMode(this NPC npc, int normalHP, int expertHP, int? revengeanceHP = null, int? deathHP = null, int? verbotenHP = null)
    {
        npc.lifeMax = normalHP;
        if (Main.expertMode)
            npc.lifeMax = expertHP;
        if (CalamityWorld.revenge && revengeanceHP.HasValue)
            npc.lifeMax = revengeanceHP.Value;
        if (CalamityWorld.death && deathHP.HasValue)
            npc.lifeMax = deathHP.Value;
        if (WorldSaveSystem.VerbotenMode && verbotenHP.HasValue)
            npc.lifeMax = verbotenHP.Value;
    }
}