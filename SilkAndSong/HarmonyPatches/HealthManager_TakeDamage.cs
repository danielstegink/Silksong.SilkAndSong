using HarmonyLib;

namespace SilkAndSong.HarmonyPatches
{
    [HarmonyPatch(typeof(HealthManager), "TakeDamage")]
    public static class HealthManager_TakeDamage
    {
        [HarmonyPrefix]
        public static void Prefix(ref HitInstance hitInstance)
        {
            string sourceName = "PLACEHOLDER";
            if (hitInstance.Source != null)
            {
                sourceName = hitInstance.Source.name;
            }
            //SilkAndSong.instance.Log($"Enemy taking {hitInstance.DamageDealt} damage (Type {hitInstance.AttackType.ToString()}) from {sourceName}");

            if (hitInstance.AttackType == AttackTypes.Nail ||
                hitInstance.AttackType == AttackTypes.NailBeam)
            {
                float modifier = SharedData.Level * DanielSteginkUtils.Utilities.NotchCosts.NailDamagePerNotch() / 4;
                int bonusDamage = (int)(modifier * hitInstance.DamageDealt);
                hitInstance.DamageDealt += bonusDamage;
                //SilkAndSong.instance.Log($"Needle damage increased by {bonusDamage}");
            }
            else // If its not a needle, then it should be either a spell or a tool
            {
                float modifier = SharedData.Level * DanielSteginkUtils.Utilities.NotchCosts.SpellDamagePerNotch() / 4;
                int bonusDamage = (int)(modifier * hitInstance.DamageDealt);
                hitInstance.DamageDealt += bonusDamage;
                //SilkAndSong.instance.Log($"Spell/Tool damage increased by {bonusDamage}");
            }
        }
    }
}