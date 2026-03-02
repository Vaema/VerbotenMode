using CalamityMod;
using CalamityMod.Buffs.DamageOverTime;
using CalamityMod.NPCs.SupremeCalamitas;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace VerbotenMode.Common.Globals.Players;

public class DifficultyChangesPlayer : ModPlayer
{
    private bool WorldEnterText;

    public override void OnEnterWorld()
    {
        if (!WorldEnterText)
        {
            Main.NewText("Verboten Mode activated.", Color.DeepPink);
            Main.NewText("Enemies are now ascending to apotheosis while you descend into misery.", Color.DarkRed);
            Main.NewText("God might have mercy on you. However, we will not.", Color.DarkViolet);

            SoundEngine.PlaySound(SupremeCalamitas.SpawnSound, Player.Center);
            WorldEnterText = true;
        }

        if (WorldEnterText)
            WorldEnterText = false;
    }

    public override void UpdateBadLifeRegen()
    {
        for (int i = 0; i < Player.buffType.Length; i++)
        {
            if (Player.Calamity().ZoneCalamity)
            {
                Player.AddBuff(ModContent.BuffType<BrimstoneFlames>(), 2);
                Player.AddBuff(ModContent.BuffType<BurningBlood>(), 2);
                Player.AddBuff(ModContent.BuffType<Dragonfire>(), 2);
                Player.AddBuff(ModContent.BuffType<GodSlayerInferno>(), 2);
                Player.AddBuff(ModContent.BuffType<HolyFlames>(), 2);
                Player.AddBuff(ModContent.BuffType<HolyInferno>(), 2);
                Player.AddBuff(ModContent.BuffType<Plague>(), 2);
                Player.AddBuff(ModContent.BuffType<Shadowflame>(), 2);
                Player.AddBuff(ModContent.BuffType<VulnerabilityHex>(), 2);
                Player.AddBuff(ModContent.BuffType<WeakBrimstoneFlames>(), 2);
                Player.AddBuff(BuffID.OnFire, 2);
                Player.AddBuff(BuffID.CursedInferno, 2);
            }
            else
                Player.ClearBuff(i);
        }
    }
}
