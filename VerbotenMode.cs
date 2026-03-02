using Terraria.ModLoader;

namespace VerbotenMode;

public class VerbotenMode : Mod
{
    internal static VerbotenMode Instance;

    internal static Mod Calamity;

    public override void Load()
    {
        Instance = this;

        Calamity = ModLoader.GetMod("CalamityMod");
    }

    public override void Unload()
    {
        Calamity = null;

        Instance = null;
    }
}