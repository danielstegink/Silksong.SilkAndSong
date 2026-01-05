using DanielSteginkUtils.Utilities;
using SilkAndSong.Helpers;
using SilkAndSong.Helpers.GetLevel;
using System.Diagnostics;

namespace SilkAndSong
{
    public static class SharedData
    {
        #region Level Tracking
        /// <summary>
        /// Stores the player's current level
        /// </summary>
        public static int Level { get; set; } = 0;

        /// <summary>
        /// Tracks how much XP until the next level-up
        /// </summary>
        public static int XpToNextLevel { get; set; } = 0;

        /// <summary>
        /// Stores the SNS quest for ease of reference
        /// </summary>
        internal static SnsQuest? quest;

        /// <summary>
        /// Updates the player's level
        /// </summary>
        /// <param name="level"></param>
        /// <param name="triggerFlair"></param>
        /// <returns></returns>
        public static void UpdateLevel(bool triggerFlair = true)
        {
            if (quest == null)
            {
                return;
            }

            bool alreadyAccepted = quest.IsAccepted;
            int newLevel = LevelCalculator.GetLevel();
            if (CanAccept(newLevel))
            {
                try
                {
                    quest.Accept();
                    SilkAndSong.instance.Log($"Quest accepted");
                }
                catch (System.Exception ex)
                {
                    SilkAndSong.instance.Log($"Error accepting quest: {ex.Message}\n{ex.StackTrace}");
                }
            }

            if (newLevel == Level)
            {
                return;
            }

            SilkAndSong.instance.Log($"Level increased from {Level} to {newLevel}");
            Level = newLevel;

            if (triggerFlair &&
                alreadyAccepted)
            {
                try
                {
                    quest.Update();
                    SilkAndSong.instance.Log("Quest updated");
                }
                catch (System.Exception ex)
                {
                    SilkAndSong.instance.Log($"Error updating quest: {ex.Message}\n{ex.StackTrace}");
                }
            }
        }

        /// <summary>
        ///  Whether or not we can accept the SnS quest
        /// </summary>
        /// <param name="newLevel"></param>
        /// <returns></returns>
        private static bool CanAccept(int newLevel)
        {
            // Can't accept if the quest doesn't exist
            if (quest == null)
            {
                return false;
            }

            // Don't accept if its already accepted
            if (quest.IsAccepted)
            {
                return false;
            }

            // Player needs to get at least 1 XP to start the quest
            if (newLevel <= 0 &&
                LevelCalculator.GetXp() == 0)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Perks
        /// <summary>
        /// Percent bonus in needle damage for the given level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        internal static float GetNailBonus(int level)
        {
            return Level * NotchCosts.NailDamagePerNotch() / 4;
        }

        /// <summary>
        /// Percent bonus in spell/tool damage for the given level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        internal static float GetSpellBonus(int level)
        {
            return Level * NotchCosts.SpellDamagePerNotch() / 4;
        }

        /// <summary>
        /// How long (in seconds) to wait before regenerating another mask
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        internal static float GetMaskSeconds(int level)
        {
            return 4 * NotchCosts.PassiveHealTime() / Level;
        }

        /// <summary>
        /// How long (in seconds) to wait before regenerating a notch of Silk
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        internal static float GetSilkSeconds(int level)
        {
            return 4 * NotchCosts.PassiveSilkTime() / Level;
        }

        /// <summary>
        /// Timer for tracking health regen
        /// </summary>
        public static Stopwatch healthTimer { get; set; } = new Stopwatch();

        /// <summary>
        /// Timer for tracking Silk regen
        /// </summary>
        public static Stopwatch silkTimer { get; set; } = new Stopwatch();
        #endregion
    }
}