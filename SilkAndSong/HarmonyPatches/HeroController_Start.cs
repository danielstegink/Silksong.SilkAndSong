using HarmonyLib;
using System.Diagnostics;

namespace SilkAndSong.HarmonyPatches
{
    [HarmonyPatch(typeof(HeroController), "Start")]
    public static class HeroController_Start
    {
        [HarmonyPostfix]
        public static void Postfix(HeroController __instance)
        {
            // Initialize level when a save is loaded. No need to trigger the fireworks for this, of course
            SharedData.UpdateLevel(false);

            // This is when a new save gets loaded, so its also the perfect time to reset the timers 
            SharedData.healthTimer = Stopwatch.StartNew();
            SharedData.silkTimer = Stopwatch.StartNew();
        }
    }
}