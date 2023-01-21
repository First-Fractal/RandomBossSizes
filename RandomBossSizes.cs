using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace RandomBossSizes
{
	public class RandomBossSizes : Mod
	{
	}

    public class ModifyNPCS : GlobalNPC
    {

        static int[] BossParts = { NPCID.SlimeSpiked, NPCID.ServantofCthulhu, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail, NPCID.Creeper, NPCID.SkeletronHand, NPCID.SkeletronHead, NPCID.WallofFleshEye, NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail, NPCID.Probe, NPCID.PrimeCannon, NPCID.PrimeLaser, NPCID.PrimeSaw, NPCID.PrimeVice, NPCID.PlanterasHook, NPCID.PlanterasTentacle, NPCID.GolemFistLeft, NPCID.GolemFistRight, NPCID.GolemHead, NPCID.GolemHeadFree, NPCID.CultistTablet, NPCID.CultistBossClone, NPCID.LunarTowerNebula, NPCID.LunarTowerSolar, NPCID.LunarTowerVortex, NPCID.LunarTowerStardust, NPCID.MoonLordCore, NPCID.MoonLordHand, NPCID.MoonLordHead, NPCID.MoonLordFreeEye, NPCID.MoonLordLeechBlob };
        public override void SetDefaults(NPC npc)
        {
            float randomSize = Main.rand.NextFloat(Config.Instance.minScale, Config.Instance.maxScale);
            bool scale = false;
            if (npc.boss)
            {
                scale = true;
            }

            if (Config.Instance.IncludeBossParts)
            {
                foreach (int bosspart in BossParts)
                {
                    if (npc.type == bosspart)
                    {
                        scale = true;
                    }
                }
            }

            if (Config.Instance.IncludeAllEnemies && npc.friendly == false)
            {
                scale = true;
            }

            if (Config.Instance.IncludeAllFriendlyNPCs && (npc.friendly || npc.CountsAsACritter))
            {
                scale = true;
            }

            if (scale)
            {
                npc.scale = randomSize;
            }
            base.SetDefaults(npc);
        }
    }

    [Label("$Mods.RandomBossSizes.Config.Label")]
    public class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static Config Instance;

        [Header("$Mods.RandomBossSizes.Config.Header.GeneralOptions")]

        [Label("$Mods.RandomBossSizes.Config.MinScale.Label")]
        [Tooltip("$Mods.RandomBossSizes.Config.MinScale.Tooltip")]
        [DefaultValue(0.1f)]
        [Range(0.1f, 1.9f)]
        public float minScale;

        [Label("$Mods.RandomBossSizes.Config.MaxScale.Label")]
        [Tooltip("$Mods.RandomBossSizes.Config.MaxScale.Tooltip")]
        [DefaultValue(1.9f)]
        [Range(0.1f, 1.9f)]
        public float maxScale;

        [Label("$Mods.RandomBossSizes.Config.IncludeBossParts.Label")]
        [Tooltip("$Mods.RandomBossSizes.Config.IncludeBossParts.Tooltip")]
        [DefaultValue(true)]
        public bool IncludeBossParts;

        [Label("$Mods.RandomBossSizes.Config.IncludeAllEnemies.Label")]
        [Tooltip("$Mods.RandomBossSizes.Config.IncludeAllEnemies.Tooltip")]
        [DefaultValue(false)]
        public bool IncludeAllEnemies;

        [Label("$Mods.RandomBossSizes.Config.IncludeAllFriendlyNPCs.Label")]
        [Tooltip("$Mods.RandomBossSizes.Config.IncludeAllFriendlyNPCs.Tooltip")]
        [DefaultValue(false)]
        public bool IncludeAllFriendlyNPCs;
    }
}