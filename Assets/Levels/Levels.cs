namespace Game.Levels
{
    public static class Levels
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="level"> level starting at 1. </param>
        public static BaseLevel GetLevel(int level)
        {
            return levels[level - 1];
        }

        /// <summary>
        /// Gets the level name.
        /// </summary>
        /// <param name="level"></param>
        /// <returns>level name.</returns>
        public static string LevelName(int level)
        {
            int name = level % 10;
            switch (name)
            {
                case 0: return "Easy";
                case 1: return "Intermediate";
                case 2: return "Hard";
                case 3: return "Super Hard";
                case 4: return "Insane";
                default: return "unknown.";
            }
        }

        /// <summary>
        /// Table of all level values.
        /// </summary>
        private static BaseLevel[] levels = new BaseLevel[]
        {
            // Level 1 - 10, Easy levels:
                new BaseLevel(5, 5, 2),     // LEVEL 1
                new BaseLevel(6, 6, 3),     // LEVEL 2
                new BaseLevel(7, 7, 3),     // LEVEL 3
                new BaseLevel(8, 8, 3),     // LEVEL 4
                new BaseLevel(6, 8, 3),     // LEVEL 5
                new BaseLevel(7, 8, 3),     // LEVEL 6
                new BaseLevel(8, 8, 3),     // LEVEL 7
                new BaseLevel(9, 10, 3),    // LEVEL 8
                new BaseLevel(10, 10, 3),   // LEVEL 9
                new BaseLevel(13, 13, 3),   // LEVEL 10

            // Level 10 - 20, Intermediate levels:
                new BaseLevel(5, 5, 2),     // LEVEL 11
                new BaseLevel(5, 6, 3),     // LEVEL 12
                new BaseLevel(6, 6, 3),     // LEVEL 13
                new BaseLevel(6, 7, 3),     // LEVEL 14
                new BaseLevel(6, 8, 3),     // LEVEL 15
                new BaseLevel(7, 8, 3),     // LEVEL 16
                new BaseLevel(8, 8, 3),     // LEVEL 17
                new BaseLevel(9, 10, 3),    // LEVEL 18
                new BaseLevel(10, 10, 3),   // LEVEL 19
                new BaseLevel(13, 13, 3),   // LEVEL 20

            // Level 20 - 30, Hard levels:
                new BaseLevel(5, 5, 2),     // LEVEL 21
                new BaseLevel(5, 6, 3),     // LEVEL 22
                new BaseLevel(6, 6, 3),     // LEVEL 23
                new BaseLevel(6, 7, 3),     // LEVEL 24
                new BaseLevel(6, 8, 3),     // LEVEL 25
                new BaseLevel(7, 8, 3),     // LEVEL 26
                new BaseLevel(8, 8, 3),     // LEVEL 27
                new BaseLevel(9, 10, 3),    // LEVEL 28
                new BaseLevel(10, 10, 3),   // LEVEL 29
                new BaseLevel(13, 13, 3),   // LEVEL 30

            // Level 30 - 40, Super Hard levels:
                new BaseLevel(5, 5, 2),     // LEVEL 31
                new BaseLevel(5, 6, 3),     // LEVEL 32
                new BaseLevel(6, 6, 3),     // LEVEL 33
                new BaseLevel(6, 7, 3),     // LEVEL 34
                new BaseLevel(6, 8, 3),     // LEVEL 35
                new BaseLevel(7, 8, 3),     // LEVEL 36
                new BaseLevel(8, 8, 3),     // LEVEL 37
                new BaseLevel(9, 10, 3),    // LEVEL 38
                new BaseLevel(10, 10, 3),   // LEVEL 39
                new BaseLevel(13, 13, 3),   // LEVEL 40

            // Level 40 - 50, Insane Levels levels:
                new BaseLevel(5, 5, 2),     // LEVEL 41
                new BaseLevel(5, 6, 3),     // LEVEL 42
                new BaseLevel(6, 6, 3),     // LEVEL 43
                new BaseLevel(6, 7, 3),     // LEVEL 44
                new BaseLevel(6, 8, 3),     // LEVEL 45
                new BaseLevel(7, 8, 3),     // LEVEL 46
                new BaseLevel(8, 8, 3),     // LEVEL 47
                new BaseLevel(9, 10, 3),    // LEVEL 48
                new BaseLevel(10, 10, 3),   // LEVEL 49
                new BaseLevel(13, 13, 3)    // LEVEL 50
        };
    }
}