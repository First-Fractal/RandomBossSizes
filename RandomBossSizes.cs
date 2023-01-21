using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomBossSizes
{
	public class RandomBossSizes : Mod
	{
	}
	
	public class ModifyNPCS : GlobalNPC
    {

       static int[] BossParts = {NPCID.SlimeSpiked, NPCID.ServantofCthulhu, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail, NPCID.Creeper, NPCID.SkeletronHand, NPCID.SkeletronHead, NPCID.WallofFleshEye, NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail, NPCID.Probe, NPCID.PrimeCannon, NPCID.PrimeLaser, NPCID.PrimeSaw, NPCID.PrimeVice, NPCID.PlanterasHook, NPCID.PlanterasTentacle, NPCID.GolemFistLeft, NPCID.GolemFistRight, NPCID.GolemHead, NPCID.GolemHeadFree, NPCID.CultistTablet, NPCID.CultistBossClone, NPCID.LunarTowerNebula, NPCID.LunarTowerSolar, NPCID.LunarTowerVortex, NPCID.LunarTowerStardust, NPCID.MoonLordCore, NPCID.MoonLordHand, NPCID.MoonLordHead, NPCID.MoonLordFreeEye, NPCID.MoonLordLeechBlob };
        public override void SetDefaults(NPC npc)
        {
            float randomSize = Main.rand.NextFloat(0.1f, 1.9f);
            if (npc.boss)
            {
                npc.scale = randomSize;
            } else
            {
                foreach (int bosspart in BossParts)
                {
                    if (npc.type == bosspart)
                    {
                        npc.scale = randomSize;
                    }
                }
            }
            base.SetDefaults(npc);
        }
    }
}