using System.Collections.Generic;

namespace SilkAndSong.Helpers
{
    public static class LevelCalculator
    {
        /// <summary>
        /// Gets the player's level based on their current XP
        /// </summary>
        /// <returns></returns>
        public static int GetLevel()
        {
            float totalXp = GetHuntingXp() + GetWishXp();
            //SilkAndSong.instance.Log($"Total XP: {totalXp}");

            // Player starts at lv 0 (weird, I know)
            // Want to reach lv 1 after beating Moss Mother, so 20 XP is a good place for that
            // Don't want to reach lv 10 until near end of game, so multiply requirement w/ each level
            int level = 0;
            float xpRequirement = 20;
            while (totalXp >= xpRequirement)
            {
                //SilkAndSong.instance.Log($"Next level: {level + 1}");
                //SilkAndSong.instance.Log($"XP required: {xpRequirement}");
                //SilkAndSong.instance.Log($"XP remaining: {totalXp}");

                level++;
                totalXp -= xpRequirement;
                xpRequirement *= 1.8f;
            }
            //SilkAndSong.instance.Log($"New Level: {level}");
            //SilkAndSong.instance.Log($"XP to next Level: {xpRequirement - totalXp}");

            return level;
        }

        #region Hunting
        /// <summary>
        /// Stores the Hunter's Journal entry for each enemy, classified by difficulty type and level
        /// </summary>
        internal static Dictionary<string, EnemyData> enemyData = new Dictionary<string, EnemyData>()
        {
            { "MossBone Crawler", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "MossBone Crawler Fat", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "MossBone Fly", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Mossbone Mother", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) },
            { "Aspid Collector", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Goomba", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Goomba Bounce Fly", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Goomba Large", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Skull King", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) },
            { "Bone Crawler", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Flyer", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Flyer Giant", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) }, // Technically Act 1, but fuck this boss in particular
            { "Bone Circler", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Circler Vicious", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Hopper", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Hopper Giant", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act3) },
            { "Bone Spitter", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Bone Roller", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Thumper", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act1) },
            { "Spine Floater", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Rock Roller", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Rhino", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) }, // You can find in Act 1, but you're more likely to encounter it in Act 2 first
            { "Crypt Worm", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Worm", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Beast", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) },
            { "Pilgrim 03", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Pilgrim 01", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Pilgrim 04", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Pilgrim 02", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Pilgrim Bell Thrower", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Pilgrim Fly", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Pilgrim 05", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Pilgrim Bellthrower Fly", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Pilgrim Hiker", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) }, // The temptation to call this one a miniboss is real lol
            { "Pilgrim StaffWielder", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Pilgrim Moss Spitter", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Rosary Pilgrim", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act1) },
            { "Rosary Thief", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Tar Slug", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Tar Slug Huge", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) },
            { "Dock Worker", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Dock Flyer", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Dock Bomber", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Shield Dock Worker", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Dock Charger", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) },
            { "Dock Guard Thrower", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Small Crab", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Roof Crab", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) }, // Wild to me that the wiki doesn't consider this fucker a boss
            { "Fields Flock Flyers", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act1) }, // No challenge
            { "Fields Goomba", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Fields Flyer", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Song Golem", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) },
            { "Bone Hunter Tiny", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Hunter Buzzer", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Hunter Child", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Hunter", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Hunter Fly", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bone Hunter Throw", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act1) },
            { "Bone Hunter Trapper", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Bone Hunter Chief", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act3) },
            { "Hunter Queen", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Mite", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Mitefly", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Gnat Giant", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act1) },
            { "Farmer Catcher", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Farmer Scissors", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Farmer Centipede", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Vampire Gnat", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) },
            { "Wisp", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Farmer Wisp", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Wisp Pyre Effigy", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Crow", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Crowman", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Crowman Dagger", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Crowman Juror Tiny", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Crowman Juror", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Crowman Dagger Juror", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Crawfather", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Maggots", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act1) }, // Tricky to discover, but again no threat
            { "Dustroach Pollywog", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Dustroach", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bloat Roach", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Roachfeeder Short", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Roachfeeder Tall", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Roachkeeper", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Roachkeeper Chef Tiny", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Roachkeeper Chef", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Wraith", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Swamp Drifter", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Swamp Goomba", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Swamp Mosquito", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Swamp Mosquito Skinny", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Swamp Muckman", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Swamp Muckman Tall", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Swamp Shaman", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Swamp Barnacle", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Swamp Ductsucker", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) },
            { "Pond Skater", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Pilgrim Fisher", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Shellwood Gnat", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Shellwood Wasp", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Stick Insect", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Stick Insect Charger", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Stick Insect Flyer", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Splinter Queen", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) },
            { "Flower Drifter", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bloom Shooter", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bloom Puncher", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Seth", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Flower Queen", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Bell Goomba", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Bell Fly", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Blade Spider", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Blade Spider Hang", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Shell Fossil Mimic", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Sand Centipede", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act1) },
            { "Coral Judge Child", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Coral Judge", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Last Judge", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) },
            { "Coral Spike Goomba", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Coral Conch Shooter", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act1) },
            { "Coral Conch Stabber", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Coral Conch Driller", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Coral Conch Driller Giant", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) },
            { "Coral Goombas", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Coral Goomba Large", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) },
            { "Coral Swimmer Fat", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Poke Swimmer", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Spike Swimmer", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Coral Swimmer Small", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act3) },
            { "Coral Big Jellyfish", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Coral Warrior", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Coral Flyer", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Coral Flyer Throw", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Coral Brawler", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act3) },
            { "Coral Hunter", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Coral Bubble Brute", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Coral King", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Coral Warrior Grey", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Zap Core Enemy", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Citadel Bat", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Citadel Bat Large", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Mite Heavy", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Understore Mite Giant", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) },
            { "Understore Small", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Pilgrim 03 Understore", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Pilgrim Staff Understore", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Understore Poker", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Understore Thrower", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Understore Heavy", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Pilgrim 01", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Pilgrim 01 Song", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Pilgrim 02 Song", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Pilgrim 03 Song", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Pilgrim 04 Song", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Pilgrim Stomper Song", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Pilgrim 03", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Reed", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Reed Grand", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) },
            { "Song Heavy Sentry", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) },
            { "Song Handmaiden", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Arborium Keeper", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Administrator", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Pilgrim Maestro", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Knight", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Song Threaded Husk", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Threaded Husk Spin", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Pilgrim 02", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Creeper", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Conductor Boss", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Understore Automaton", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Understore Automaton EX", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Automaton Goomba", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Automaton Fly", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Automaton Fly Spike", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Automaton 01", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Automaton 02", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Automaton Shield", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Song Automaton Ball", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) },
            { "Clockwork Dancer", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Song Scholar Acolyte", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Lightbearer", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Scrollkeeper", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) },
            { "Scholar", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Trobbio", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Tormented Trobbio", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Slab Prisoner Leaper New", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Slab Prisoner Fly New", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Slab Fly Small Fresh", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Slab Fly Small", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Slab Fly Mid", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Slab Fly Large", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Slab Fly Broodmother", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Peaks Drifter", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act2) },
            { "Crystal Drifter", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act2) },
            { "Crystal Drifter Giant", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act3) },
            { "Weaver Servitor", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act1) },
            { "Weaver Servitor Large", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act2) },
            { "Lifeblood Fly", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act2) },
            { "Bone Worm BlueBlood", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Bone Worm BlueTurret", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Blue Assistant", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Lilypad Fly", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act3) },
            { "Grass Goomba", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Hornet Dragonfly", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Dragonfly Large", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Lilypad Trap", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Cloverstag", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Cloverstag White", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Grasshopper Child", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Grasshopper Slasher", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Grasshopper Fly", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Clover Dancer", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Abyss Crawler", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Abyss Crawler Large", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Gloomfly", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Gloom Beast", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act3) },
            { "Void Tendrils", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act3) },
            { "Black Thread Core", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act3) },
            { "Abyss Mass", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "White Palace Fly", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act3) },
            { "Centipede Trap", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Spike Lazy Flyer", new EnemyData(EnemyData.EnemyType.Enemy, EnemyData.EnemyLevel.Act3) },
            { "Surface Scuttler", new EnemyData(EnemyData.EnemyType.None, EnemyData.EnemyLevel.Act3) },
            { "Giant Centipede", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Giant Flea", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) },
            { "Shakra", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Garmond_Zaza", new EnemyData(EnemyData.EnemyType.Miniboss, EnemyData.EnemyLevel.Act2) },
            { "Garmond", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Pinstress Boss", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
            { "Spinner Boss", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) },
            { "First Weaver", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Phantom", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) },
            { "Lace", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act1) },
            { "Silk Boss", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act2) },
            { "Lost Lace", new EnemyData(EnemyData.EnemyType.Boss, EnemyData.EnemyLevel.Act3) },
        };

        /// <summary>
        /// Gets XP accumulated by defeating enemies
        /// </summary>
        /// <returns></returns>
        public static int GetHuntingXp()
        {
            int enemyXp = 0;
            int enemyCount = 0;
            int minibossXp = 0;
            int minibossCount = 0;
            int bossXp = 0;
            int bossCount = 0;
            foreach (string entryName in enemyData.Keys)
            {
                EnemyJournalKillData.KillData journalEntry = PlayerData.instance.EnemyJournalKillData.GetKillData(entryName);
                int xp = journalEntry.Kills * GetXp(enemyData[entryName]);
                switch (enemyData[entryName].type)
                {
                    case EnemyData.EnemyType.Enemy:
                        enemyXp += xp;
                        enemyCount++;
                        break;
                    case EnemyData.EnemyType.Miniboss:
                        minibossXp += xp;
                        minibossCount++;
                        break;
                    case EnemyData.EnemyType.Boss:
                        bossXp += xp;
                        bossCount++;
                        break;
                    default:
                        break;
                }
            }

            //SilkAndSong.instance.Log($"{enemyXp} XP from {enemyCount} enemies");
            //SilkAndSong.instance.Log($"{minibossXp} XP from {minibossCount} minibosses");
            //SilkAndSong.instance.Log($"{bossXp} XP from {bossCount} bosses");

            int totalXp = enemyXp + minibossXp + bossXp;
            int totalEnemies = enemyCount + minibossCount + bossCount;
            //SilkAndSong.instance.Log($"{totalXp} XP from {totalEnemies} enemies");
            return totalXp;
        }

        /// <summary>
        /// Calculates the XP value of an enemy
        /// </summary>
        /// <param name="enemyData"></param>
        /// <returns></returns>
        private static int GetXp(EnemyData enemyData)
        {
            int xp = enemyData.type switch
            {
                EnemyData.EnemyType.Enemy => 1,
                EnemyData.EnemyType.Miniboss => 5,
                EnemyData.EnemyType.Boss => 10,
                _ => 0
            };

            int multiplier = enemyData.level switch
            {
                EnemyData.EnemyLevel.Act1 => 1,
                EnemyData.EnemyLevel.Act2 => 2,
                EnemyData.EnemyLevel.Act3 => 3,
                _ => 0
            };

            return xp * multiplier;
        }
        #endregion

        #region Quests
        /// <summary>
        /// Stores each Wish, categorized by difficulty and level
        /// </summary>
        private static Dictionary<string, QuestData> questData = new Dictionary<string, QuestData>()
        {
            { "Citadel Seeker", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act1) },
            { "The Threadspun Town", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act1) },
            { "Grand Gate Bellshrines", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Citadel Investigate", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act2) },
            { "Citadel Ascent Lift", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act2) },
            { "Citadel Ascent Silk Defeat", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act2) },
            { "Silk Defeat Snare", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act2) },
            { "Black Thread Pt0", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act3) },
            { "Black Thread Pt1 Shamans", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act3) },
            { "Bellbeast Rescue", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act3) },
            { "Diving Bell Pt3 Descend", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act3) },
            { "Black Thread Pt3 Escape", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act3) },
            { "Black Thread Pt4 Return", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act3) },
            { "Black Thread Pt5 Heart", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act3) },
            { "Black Thread Pt6 Flower", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act3) },
            { "Building Materials", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Building Materials (Bridge)", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Building Materials (Statue)", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Pilgrim Rags", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Mossberry Collection 1", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Save the Fleas", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Rock Rollers", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Skull King", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act1) },
            { "Brolly Get", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Journal", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Belltown House Start", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Belltown House Mid", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act2) },
            { "A Pinsmiths Tools", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act2) },
            { "Shiny Bell Goomba", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Save Courier Short", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Save Courier Tall", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Courier Delivery Bonebottom", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Courier Delivery Pilgrims Rest", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Courier Delivery Songclave", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act2) },
            { "Courier Delivery Fleatopia", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act2) },
            { "Courier Delivery Mask Maker", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act2) },
            { "Courier Delivery Dustpens Slave", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Courier Delivery Fixer", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act3) },
            { "Crow Feathers", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Beastfly Hunt", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act2) },
            { "Shell Flowers", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Wood Witch Curse", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Doctor Curse Cure", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Extractor Blue", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Extractor Blue Worms", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act3) },
            { "Roach Killing", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act1) },
            { "Songclave Donation 1", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Songclave Donation 2", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act2) },
            { "Fine Pins", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Save City Merchant", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Save City Merchant Bridge", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Song Pilgrim Cloaks", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Broodmother Hunt", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act2) },
            { "Great Gourmand", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act2) },
            { "Save Sherma", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Song Knight", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act2) },
            { "Huntress Quest", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Huntress Quest Runt", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Shakra Final Quest", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act2) },
            { "Soul Snare", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act2) },
            { "Pinstress Battle", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act3) },
            { "Sprintmaster Race", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act3) },
            { "Garmond Black Threaded", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act3) },
            { "Anguish and Misery", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act3) },
            { "Ant Trapper", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act3) },
            { "Flea Games", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act3) },
            { "Steel Sentinel Pt2", new QuestData(QuestData.Difficulty.Medium, QuestData.QuestLevel.Act2) },
            { "Mr Mushroom", new QuestData(QuestData.Difficulty.Hard, QuestData.QuestLevel.Act3) },
            { "Destroy Thread Cores", new QuestData(QuestData.Difficulty.Easy, QuestData.QuestLevel.Act3) },
        };

        /// <summary>
        /// Gets XP accumulated by completing Wishes
        /// </summary>
        /// <returns></returns>
        public static int GetWishXp()
        {
            int xp = 0;
            int questCount = 0;

            QuestCompletionData completedQuests = PlayerData.instance.QuestCompletionData;
            foreach (string questName in questData.Keys)
            {
                int count = 0;
                try
                {
                    QuestCompletionData.Completion completedQuest = completedQuests.GetData(questName);
                    if (completedQuest.IsCompleted)
                    {
                        count = 1;

                        // Delivery quests should be counted for each time they were completed
                        if (questName.Contains("Delivery"))
                        {
                            count = completedQuest.CompletedCount;
                        }
                    }
                }
                catch { } // If we haven't done the quest, there won't be any completion data

                xp += count * GetXp(questData[questName]);
                questCount++;
            }

            //SilkAndSong.instance.Log($"{xp} XP from {questCount} Wishes");
            return xp;
        }

        /// <summary>
        /// Gets the XP value of a Wish
        /// </summary>
        /// <param name="questData"></param>
        /// <returns></returns>
        private static int GetXp(QuestData questData)
        {
            int xp = questData.difficulty switch
            {
                QuestData.Difficulty.Easy => 25,
                QuestData.Difficulty.Medium => 50,
                QuestData.Difficulty.Hard => 100,
                _ => 0
            };

            int multiplier = questData.level switch
            {
                QuestData.QuestLevel.Act1 => 1,
                QuestData.QuestLevel.Act2 => 2,
                QuestData.QuestLevel.Act3 => 3,
                _ => 0
            };

            return xp * multiplier;
        }
        #endregion
    }
}