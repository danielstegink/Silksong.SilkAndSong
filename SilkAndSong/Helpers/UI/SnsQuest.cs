using DanielSteginkUtils.ExternalFiles;
using TeamCherry.Localization;

namespace SilkAndSong.Helpers.UI
{
    public class SnsQuest : FullQuestBase
    {
        #region Quest Type
        /// <summary>
        /// Name of the Quest Type
        /// </summary>
        private LocalisedString questTypeName = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_TYPE_NAME");

        /// <summary>
        /// Text color for the Quest Type
        /// </summary>
        private UnityEngine.Color textColor = new UnityEngine.Color(1, 0.3f, 0.3f);

        private UnityEngine.Sprite? icon = GetSprite.GetLocalSprite("SilkAndSong.Resources.Icon.png", "SilkAndSong");
        private UnityEngine.Sprite? iconGlow = GetSprite.GetLocalSprite("SilkAndSong.Resources.Icon_Glow.png", "SilkAndSong");
        private UnityEngine.Sprite? iconLarge = GetSprite.GetLocalSprite("SilkAndSong.Resources.Icon_Large.png", "SilkAndSong");
        private UnityEngine.Sprite? iconLargeGlow = GetSprite.GetLocalSprite("SilkAndSong.Resources.Icon_Large_Glow.png", "SilkAndSong");

        /// <summary>
        /// Quest Type
        /// </summary>
        public override QuestType QuestType => QuestType.Create(questTypeName, icon, textColor, iconLarge, iconLargeGlow, iconGlow);
        #endregion

        public SnsQuest()
        {
            name = "SilkAndSong";
            displayName = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_NAME");
            location = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_LOC");
            inventoryDescription = new LocalisedString($"Mods.{SilkAndSong.Id}", "QUEST_DESC");

            overrideFontSize = new TeamCherry.SharedUtils.OverrideFloat()
            {
                IsEnabled = false
            };

            overrideParagraphSpacing = new TeamCherry.SharedUtils.OverrideFloat()
            {
                IsEnabled = false
            };

            targets = new QuestTarget[0];
            //targets = new QuestTarget[1]
            //{
            //    new QuestTarget()
            //    {
            //        Count = 0,

            //    }
            //};

            //customPickupDisplay = new UIMsgDisplay()
            //{
            //    Name = GlobalSettings.UI.QuestContinuePopup,
            //    Icon = QuestType.Icon,
            //    IconScale = 1f,
            //    RepresentingObject = this,
            //};
        }

        public override bool IsHidden => false;

        public override bool CanComplete => false;
    }
}