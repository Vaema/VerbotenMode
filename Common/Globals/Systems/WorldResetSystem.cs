using Terraria.ModLoader;

namespace VerbotenMode.Common.Globals.Systems;

public class WorldResetSystem : ModSystem
{
    public override void OnWorldLoad()
    {
        WorldSaveSystem.VerbotenMode = false;
    }

    public override void OnWorldUnload()
    {
        WorldSaveSystem.VerbotenMode = false;
    }
}