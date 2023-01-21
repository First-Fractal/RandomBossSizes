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

       public override void PostAI(NPC npc)
        {
            if (npc.boss)
            {
                npc.scale = 1.9f;
            }
            base.PostAI(npc);
        }
    }
}