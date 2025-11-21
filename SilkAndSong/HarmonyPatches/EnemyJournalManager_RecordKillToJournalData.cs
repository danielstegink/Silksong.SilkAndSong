using HarmonyLib;

namespace SilkAndSong.HarmonyPatches
{
    [HarmonyPatch(typeof(EnemyJournalManager), "RecordKillToJournalData")]
    public static class EnemyJournalManager_RecordKillToJournalData
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            // If an enemy is defeated, update our level with the new XP
            SharedData.UpdateLevel();
        }
    }
}