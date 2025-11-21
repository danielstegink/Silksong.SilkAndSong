namespace SilkAndSong.Helpers
{
    public class QuestData
    {
        /// <summary>
        /// The difficulty rating of the quest
        /// </summary>
        public enum Difficulty
        {
            None,
            Easy,
            Medium,
            Hard
        };

        /// <summary>
        /// The level of the quest
        /// </summary>
        public enum QuestLevel
        {
            Act1,
            Act2,
            Act3,
        }

        /// <summary>
        /// Difficulty Rating
        /// </summary>
        public Difficulty difficulty { get; set; }

        /// <summary>
        /// Level
        /// </summary>
        public QuestLevel level { get; set; }

        public QuestData(Difficulty difficulty, QuestLevel level)
        {
            this.difficulty = difficulty;
            this.level = level;
        }
    }
}
