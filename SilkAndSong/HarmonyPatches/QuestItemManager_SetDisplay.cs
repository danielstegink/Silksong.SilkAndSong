using DanielSteginkUtils.ExternalFiles;
using DanielSteginkUtils.Utilities;
using HarmonyLib;
using SilkAndSong.Helpers.UI;
using System.Xml.Linq;
using TeamCherry.Localization;
using TeamCherry.NestedFadeGroup;
using TeamCherry.SharedUtils;
using TMProOld;
using UnityEngine;

namespace SilkAndSong.HarmonyPatches
{
    [HarmonyPatch(typeof(QuestItemManager), "SetDisplay", new System.Type[] { typeof(InventoryItemSelectable) })]
    public static class QuestItemManager_SetDisplay
    {
        [HarmonyPrefix]
        public static void Prefix(QuestItemManager __instance, InventoryItemSelectable selectable)
        {
            //SilkAndSong.instance.Log($"Selectable: {selectable.name}, {selectable.DisplayName}, {selectable.Description}");

            //try
            //{
            //    SetDisplay(__instance, selectable);
            //}
            //catch (System.Exception ex)
            //{
            //    SilkAndSong.instance.Log($"Error setting display: {ex.Message}\n{ex.StackTrace}");
            //}
        }

        private static void SetDisplay(QuestItemManager __instance, InventoryItemSelectable selectable)
        {
            InventoryItemManager_SetDisplay(__instance, selectable);
            InventoryItemQuest inventoryItemQuest = selectable as InventoryItemQuest;
            if ((bool)inventoryItemQuest)
            {
                BasicQuestBase quest = inventoryItemQuest.Quest;
                if (!quest)
                {
                    return;
                }

                if (quest is FullQuestBase fullQuestBase)
                {
                    if (fullQuestBase.overrideFontSize == null)
                    {
                        SilkAndSong.instance.Log("overrideFontSize is null");
                    }
                    else if (fullQuestBase.OverrideFontSize == null)
                    {
                        SilkAndSong.instance.Log("OverrideFontSize is null");
                    }

                    if (((OverrideValue<float>)(object)fullQuestBase.OverrideFontSize).IsEnabled)
                    {
                        __instance.descriptionText.fontSize = ((OverrideValue<float>)(object)fullQuestBase.OverrideFontSize).Value;
                    }

                    if (((OverrideValue<float>)(object)fullQuestBase.OverrideParagraphSpacing).IsEnabled)
                    {
                        __instance.descriptionText.paragraphSpacing = ((OverrideValue<float>)(object)fullQuestBase.OverrideParagraphSpacing).Value;
                    }
                }

                if ((bool)(UnityEngine.Object)(object)__instance.descriptionGroup)
                {
                    ((NestedFadeGroupBase)__instance.descriptionGroup).AlphaSelf = 1f;
                }

                if ((bool)__instance.typeText)
                {
                    if ((bool)quest.QuestType)
                    {
                        __instance.typeText.text = quest.QuestType.DisplayName;
                        __instance.typeText.color = quest.QuestType.TextColor;
                    }
                    else
                    {
                        __instance.typeText.text = "NO TYPE ASSIGNED";
                        __instance.typeText.color = Color.magenta;
                    }
                }

                if ((bool)__instance.questItemDescription)
                {
                    __instance.questItemDescription.SetDisplay(quest);
                }

                if ((bool)__instance.locationText)
                {
                    string location = quest.Location;
                    __instance.locationText.text = location;
                    __instance.locationText.gameObject.SetActive(!string.IsNullOrWhiteSpace(location));
                }
            }
            else if ((bool)(Object)(object)__instance.descriptionGroup)
            {
                ((NestedFadeGroupBase)__instance.descriptionGroup).AlphaSelf = 1f;
            }
        }

        private static void InventoryItemManager_SetDisplay(QuestItemManager __instance, InventoryItemSelectable selectable)
        {
            SetDisplay_GameObject(__instance, selectable.gameObject);
            if ((bool)__instance.nameText)
            {
                __instance.nameText.text = selectable.DisplayName;
            }

            if ((bool)__instance.descriptionText)
            {
                __instance.descriptionText.text = selectable.Description;
            }
        }

        private static void SetDisplay_GameObject(QuestItemManager __instance, GameObject selectedGameObject)
        {
            if ((bool)__instance.nameText)
            {
                __instance.nameText.text = string.Empty;
            }

            if ((bool)__instance.descriptionText)
            {
                __instance.descriptionText.text = string.Empty;
            }
        }
    }
}
