using DanielSteginkUtils.Utilities;
using SilkAndSong.Helpers;
using SilkAndSong.Helpers.GetLevel;
using SilkAndSong.Helpers.UI;
using System.Collections;
using System.Diagnostics;
using TeamCherry.Localization;
using UnityEngine;
using UnityEngine.UI;

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
            int newLevel = LevelCalculator.GetLevel();
            if (quest != null)
            {
                try
                {
                    quest.Get();
                }
                catch (System.Exception ex)
                {
                    SilkAndSong.instance.Log($"Error updating quest: {ex.Message}\n{ex.StackTrace}");
                }
            }

            if (newLevel != Level)
            {
                SilkAndSong.instance.Log($"Level increased from {Level} to {newLevel}");

                if (triggerFlair)
                {
                    //HeroController.instance.StartCoroutine(PopupMessage(newLevel));
                    if (quest != null)
                    {
                        try
                        {
                            // TODO - figure out how to trigger the "progress quest" popup
                            //quest.Get();
                        }
                        catch (System.Exception ex)
                        {
                            SilkAndSong.instance.Log($"Error updating quest: {ex.Message}\n{ex.StackTrace}");
                        }
                    }
                }
                Level = newLevel;
            }
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

        #region Level Up Notification
        /// <summary>
        /// Stores the canvas we use to display the text
        /// </summary>
        private static GameObject? canvas;

        /// <summary>
        /// Handles the celebratory flair when the player's level increases
        /// </summary>
        /// <returns></returns>
        private static IEnumerator PopupMessage(int newLevel)
        {
            // Create the canvas if we haven't already
            if (canvas == null)
            {
                canvas = CanvasUtil.CanvasUtil.CreateCanvas(RenderMode.ScreenSpaceOverlay, new Vector2(1920f, 1080f));
                canvas.name = "SilkAndSong.Canvas";
            }

            // Create a text box in the cavas
            CanvasUtil.RectData dimensions = new CanvasUtil.RectData(new Vector2(0, 50), new Vector2(0, 45),
                                                         new Vector2(0, 0), new Vector2(1, 0),
                                                         new Vector2(0.5f, 0.5f));
            string message = $"LEVEL UP! {Level} -> {newLevel}";
            LocalisedString messageString = new LocalisedString($"Mods.{SilkAndSong.Id}", "TXT_MESSAGE");
            if (messageString.Exists)
            {
                message = messageString.ToString()
                                        .Replace("OLD_LEVEL", Level.ToString())
                                        .Replace("NEW_LEVEL", newLevel.ToString());
            }
            GameObject textPanel = CanvasUtil.CanvasUtil.CreateTextPanel(canvas, message, 
                                                                            42, TextAnchor.MiddleCenter, dimensions);
            Text text = textPanel.GetComponent<Text>();
            text.font = CanvasUtil.Fonts.TrajanBold;
            //text.color = ConfigSettings.levelUpColor.Value;

            // Display the text after a short time
            yield return new WaitForSeconds(0.5f);
            text.CrossFadeAlpha(1f, 0f, false);

            // Shake the camera slightly and play a sound
            SpriteFlash flash = ClassIntegrations.GetField<HeroController, SpriteFlash>(HeroController.instance, "spriteFlash");
            flash.Flash(Color.white, 0.5f, 0.1f, 0.3f, 0.1f);
            GameCameras.instance.cameraShakeFSM.SendEvent("BigShake");
            AudioSource audioSource = ClassIntegrations.GetField<HeroController, AudioSource>(HeroController.instance, "audioSource");
            audioSource.PlayOneShot(HeroController.instance.nailArtChargeComplete, 5f);

            // Fade the message back out
            yield return new WaitForSeconds(1f);
            text.CrossFadeAlpha(0f, 1f, false);

            // Delete the text box so we don't clutter the game
            yield return new WaitForSeconds(1f);
            UnityEngine.GameObject.Destroy(textPanel);
        }
        #endregion
    }
}