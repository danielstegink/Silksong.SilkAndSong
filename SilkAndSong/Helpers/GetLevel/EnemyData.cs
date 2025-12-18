namespace SilkAndSong.Helpers.GetLevel
{
    public class EnemyData
    {
        /// <summary>
        /// The difficulty rating of the enemy
        /// </summary>
        public enum EnemyType
        {
            None,
            Enemy,
            Miniboss,
            Boss
        };

        /// <summary>
        /// The level of the enemy
        /// </summary>
        public enum EnemyLevel
        {
            Act1,
            Act2,
            Act3,
        }

        /// <summary>
        /// Enemy Difficulty Rating
        /// </summary>
        public EnemyType type { get; set; }

        /// <summary>
        /// Enemy Level
        /// </summary>
        public EnemyLevel level { get; set; }

        public EnemyData(EnemyType type, EnemyLevel level)
        {
            this.type = type;
            this.level = level;
        }
    }
}