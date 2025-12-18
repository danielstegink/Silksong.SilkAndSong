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
            // Add Silk & Song Wish so player can track their level
            if (SharedData.quest != null)
            {
                QuestCompletionData.Completion completion = new QuestCompletionData.Completion()
                {
                    HasBeenSeen = true,
                    IsAccepted = true,
                    IsCompleted = false,
                    WasEverCompleted = false,
                    CompletedCount = 0,
                };
                PlayerData.instance.QuestCompletionData.SetData(SharedData.quest.name, completion);
            }

            // Initialize level when a save is loaded. No need to trigger the fireworks for this, of course
            SharedData.UpdateLevel(false);

            // This is when a new save gets loaded, so its also the perfect time to reset the timers 
            SharedData.healthTimer = Stopwatch.StartNew();
            SharedData.silkTimer = Stopwatch.StartNew();
        }
    }
}