using DanielSteginkUtils.Utilities;
using HarmonyLib;

namespace SilkAndSong.HarmonyPatches
{
    [HarmonyPatch(typeof(HeroController), "Update")]
    public static class HeroController_Update
    {
        [HarmonyPostfix]
        public static void Postfix(HeroController __instance)
        {
            if (SharedData.Level > 0)
            {
                // Each level is worth 1/4 of a notch
                float levelModifier = SharedData.Level / 4;
                float healthTime = NotchCosts.PassiveHealTime() / levelModifier;
                if (healthTime <= SharedData.healthTimer.ElapsedMilliseconds / 1000)
                {
                    //SilkAndSong.instance.Log($"Health time reached: {healthTime}");
                    __instance.AddHealth(1);
                    SharedData.healthTimer.Restart();
                }

                float silkTime = NotchCosts.PassiveSilkTime() / levelModifier;
                if (silkTime <= SharedData.silkTimer.ElapsedMilliseconds / 1000)
                {
                    //SilkAndSong.instance.Log($"Silk time reached: {silkTime}");
                    __instance.SilkGain();
                    SharedData.silkTimer.Restart();
                }
            }
        }
    }
}