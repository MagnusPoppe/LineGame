namespace Game.Levels
{
    public static class Levels
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="level"> level starting at 1. </param>
        public static Level GetLevel(int level)
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
        private static Level[] levels = new Level[]
        {
            // Level 1 - 10, Easy levels:
                new Level(5, 5, 2, 20),     // LEVEL 1
                new Level(6, 6, 3, 20),     // LEVEL 2
                new Level(7, 7, 3, 20),     // LEVEL 3
                new Level(8, 8, 3, 20),     // LEVEL 4
                new Level(6, 8, 3, 20),     // LEVEL 5
                new Level(7, 8, 3, 20),     // LEVEL 6
                new Level(8, 8, 3, 20),     // LEVEL 7
                new Level(9, 10, 3, 20),    // LEVEL 8
                new Level(10, 10, 3, 20),   // LEVEL 9
                new Level(13, 13, 3, 20),   // LEVEL 10

            // Level 10 - 20, Intermediate levels:
                new Level(5, 5, 2, 15),     // LEVEL 11
                new Level(5, 6, 3, 15),     // LEVEL 12
                new Level(6, 6, 3, 15),     // LEVEL 13
                new Level(6, 7, 3, 15),     // LEVEL 14
                new Level(6, 8, 3, 15),     // LEVEL 15
                new Level(7, 8, 3, 15),     // LEVEL 16
                new Level(8, 8, 3, 15),     // LEVEL 17
                new Level(9, 10, 3, 15),    // LEVEL 18
                new Level(10, 10, 3, 15),   // LEVEL 19
                new Level(13, 13, 3, 15),   // LEVEL 20

            // Level 20 - 30, Hard levels:
                new Level(5, 5, 2, 15),     // LEVEL 21
                new Level(5, 6, 3, 15),     // LEVEL 22
                new Level(6, 6, 3, 15),     // LEVEL 23
                new Level(6, 7, 3, 15),     // LEVEL 24
                new Level(6, 8, 3, 15),     // LEVEL 25
                new Level(7, 8, 3, 15),     // LEVEL 26
                new Level(8, 8, 3, 15),     // LEVEL 27
                new Level(9, 10, 3, 15),    // LEVEL 28
                new Level(10, 10, 3, 15),   // LEVEL 29
                new Level(13, 13, 3, 15),   // LEVEL 30

            // Level 30 - 40, Super Hard levels:
                new Level(5, 5, 2, 10),     // LEVEL 31
                new Level(5, 6, 3, 10),     // LEVEL 32
                new Level(6, 6, 3, 10),     // LEVEL 33
                new Level(6, 7, 3, 10),     // LEVEL 34
                new Level(6, 8, 3, 10),     // LEVEL 35
                new Level(7, 8, 3, 10),     // LEVEL 36
                new Level(8, 8, 3, 10),     // LEVEL 37
                new Level(9, 10, 3, 10),    // LEVEL 38
                new Level(10, 10, 3, 10),   // LEVEL 39
                new Level(13, 13, 3, 10),   // LEVEL 40

            // Level 40 - 50, Insane Levels levels:
                new Level(5, 5, 2, 10),     // LEVEL 41
                new Level(5, 6, 3, 10),     // LEVEL 42
                new Level(6, 6, 3, 10),     // LEVEL 43
                new Level(6, 7, 3, 10),     // LEVEL 44
                new Level(6, 8, 3, 10),     // LEVEL 45
                new Level(7, 8, 3, 10),     // LEVEL 46
                new Level(8, 8, 3, 10),     // LEVEL 47
                new Level(9, 10, 3, 10),    // LEVEL 48
                new Level(10, 10, 3, 10),   // LEVEL 49
                new Level(13, 13, 3, 10)    // LEVEL 50
        };
    }
}