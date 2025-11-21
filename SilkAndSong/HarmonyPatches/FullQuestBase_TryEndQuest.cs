using HarmonyLib;

namespace SilkAndSong.HarmonyPatches
{
    [HarmonyPatch(typeof(FullQuestBase), "TryEndQuest")]
    public static class FullQuestBase_TryEndQuest
    {
        [HarmonyPostfix]
        public static void Postfix(FullQuestBase __instance)
        {
            // If the quest is completed, update our level with the new XP
            if (__instance.IsCompleted)
            {
                SharedData.UpdateLevel();
            }
        }
    }
}
