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
        /// Integrates with UI to set the initial XP requirement
        /// </summary>
        public static ConfigEntry<int> xpRequirement;

        /// <summary>
        /// Integrates with UI to set the XP multiplier
        /// </summary>
        public static ConfigEntry<float> xpMultiplier;

        /// <summary>
        /// Initializes the settings
        /// </summary>
        /// <param name="config"></param>
        public static void Initialize(ConfigFile config)
        {
            // Bind set methods to Config
            xpRequirement = config.Bind("Modifier", "XP Requirement", 20, "XP required to reach level 1");
            xpMultiplier = config.Bind("Modifier", "XP Multiplier", 1.8f, "How much to increase XP requirement per level");
        }
    }
}
