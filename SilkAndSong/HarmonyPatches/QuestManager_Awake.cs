using HarmonyLib;
using SilkAndSong.Helpers.UI;
using UnityEngine;

namespace SilkAndSong.HarmonyPatches
{
    [HarmonyPatch(typeof(QuestManager), "Awake")]
    public static class QuestManager_Awake
    {
        [HarmonyPostfix]
        public static void Postfix(QuestManager __instance)
        {
            SharedData.quest = ScriptableObject.CreateInstance<SnsQuest>();
            __instance.masterList.Add(SharedData.quest);
        }
    }
}