using DanielSteginkUtils.Utilities;
using SilkAndSong.Helpers;
using System.Collections;
using System.Diagnostics;
using TeamCherry.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace SilkAndSong
{
    public static class SharedData
    {
        /// <summary>
        /// Stores the player's current level
        /// </summary>
        public static int Level { get; private set; } = 0;

        /// <summary>
        /// Timer for tracking when to increase health
        /// </summary>
        public static Stopwatch healthTimer { get; set; } = new Stopwatch();

        /// <summary>
        /// Timer for tracking when to increase Silk
        /// </summary>
        public static Stopwatch silkTimer { get; set; } = new Stopwatch();

        /// <summary>
        /// Stores the canvas we use to display the text
        /// </summary>
        private static GameObject? canvas;

        /// <summary>
        /// Updates the player's level
        /// </summary>
        /// <param name="level"></param>
        /// <param name="triggerFlair"></param>
        /// <returns></returns>
        public static void UpdateLevel(bool triggerFlair = true)
        {
            int newLevel = LevelCalculator.GetLevel();
            if (newLevel != Level)
            {
                SilkAndSong.instance.Log($"Level increased from {Level} to {newLevel}");
                if (triggerFlair)
                {
                    HeroController.instance.StartCoroutine(PopupMessage(newLevel));
                }
                Level = newLevel;
            }
        }

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
            text.color = ConfigSettings.levelUpColor.Value;

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
    }
}
