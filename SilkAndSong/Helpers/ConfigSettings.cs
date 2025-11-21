using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TeamCherry.Localization;
using UnityEngine;

namespace SilkAndSong.Helpers
{
    public static class ConfigSettings
    {
        /// <summary>
        /// Integrates with UI to set the color of the level-up message
        /// </summary>
        public static ConfigEntry<Color> levelUpColor;

        /// <summary>
        /// Initializes the settings
        /// </summary>
        /// <param name="config"></param>
        public static void Initialize(ConfigFile config)
        {
            // Bind set methods to Config
            LocalisedString name = new LocalisedString($"Mods.{SilkAndSong.Id}", "TXT_NAME");
            LocalisedString description = new LocalisedString($"Mods.{SilkAndSong.Id}", "TXT_DESC");
            UnityEngine.Color defaultColor = new UnityEngine.Color(0.2f, 0.2f, 1f);
            if (name.Exists &&
                description.Exists)
            {
                levelUpColor = config.Bind<UnityEngine.Color>("Modifier", name, defaultColor, description);
            }
            else
            {
                levelUpColor = config.Bind("Modifier", "Text Color", defaultColor, "The color of the level-up message");
            }
        }
    }
}
