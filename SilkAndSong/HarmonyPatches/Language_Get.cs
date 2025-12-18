using HarmonyLib;
using TeamCherry.Localization;

namespace SilkAndSong.HarmonyPatches
{
    [HarmonyPatch(typeof(Language), "Get", new System.Type[] { typeof(string), typeof(string) })]
    public static class Language_Get
    {
        [HarmonyPostfix]
        public static void Postfix(ref string key, ref string sheetTitle, ref string __result)
        {
            if (sheetTitle.Contains(SilkAndSong.Id) &&
                key.Equals("QUEST_DESC"))
            {
                string desc1 = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_DESC_1");

                string desc2 = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_DESC_2");
                desc2 = desc2.Replace("CURRENT_LEVEL", SharedData.Level.ToString());

                string desc3 = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_DESC_3");
                desc3 = desc3.Replace("XP_TO_NEXT_LEVEL", SharedData.XpToNextLevel.ToString());

                string desc4 = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_DESC_4");

                string desc5 = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_DESC_5");
                float nailModifier = 100 * SharedData.GetNailBonus(SharedData.Level);
                desc5 = desc5.Replace("NAIL_BONUS", nailModifier.ToString("0.0"));

                string desc6 = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_DESC_6");
                float spellModifier = 100 * SharedData.GetSpellBonus(SharedData.Level);
                desc6 = desc6.Replace("SPELL_BONUS", spellModifier.ToString("0.0"));

                string desc7 = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_DESC_7");
                float maskSeconds = SharedData.GetMaskSeconds(SharedData.Level);
                desc7 = desc7.Replace("MASK_SECONDS", maskSeconds.ToString("0"));

                string desc8 = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_DESC_8");
                float silkSeconds = SharedData.GetSilkSeconds(SharedData.Level);
                desc8 = desc8.Replace("SILK_SECONDS", silkSeconds.ToString("0"));

                __result = $"{desc1}\n\n{desc2}\n{desc3}\n\n{desc4}\n{desc5}\n{desc6}\n{desc7}\n{desc8}";
            }
        }
    }
}