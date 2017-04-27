using System.Runtime.Remoting.Messaging;
using NUnit.Framework;

namespace Game.Levels
{
    [TestFixture()]
    public class LevelTests
    {
        [Test()]
        public void LevelUp()
        {
            Level level = new Level(); // starts at 0.
            Assert.AreEqual(1, level.No, "Error in constructor. Level numbers are not consistant.");

            // Increasing level to 11:
            for (int i = 1; i <= 10; i++)
                level.LevelUP();

            Assert.AreEqual(11, level.No, "Level numbers are not consistant.");

            // Testing number of pkts:
            int pkts = Level.BASE_NUMBER                      // BASE
                   + ((int)1 * Level.TENTH_LEVEL_MODIFIER)    // 10th level modifier
                   + (int)((float)1 / Level.DIGIT_MODIFIER);  // First scifer modifier

            Assert.AreEqual(pkts, level.Pkts, "Number of Pkts is not correct.");
        }

        [Test()]
        public void IncreaseDifficulty()
        {
            Level level = new Level();
            Level previousLevel = new Level();
            int upperLevelLimit = 1000;

            // Testing for N levels:
            for (int n = 0; n < upperLevelLimit; n++)
            {
                level.LevelUP();

                // Looking at the number of points(pkts) in the level:
                if (level.Pkts < previousLevel.Pkts)
                    Assert.Fail("Game got easier because of pkts @Level "+(n+1));

                // Looking at the number of connections:
                if (level.Lines.Count < previousLevel.Lines.Count)
                    Assert.Fail("Game got easier because of lines @Level "+(n+1));

                // Checking if the level can be beaten:
//                if (!level.CanBeBeaten())
//                    Assert.Fail("Level "+(n+1)+" cannot be beaten...");

                // Checking if the game had a too large bump in difficulty:
//                if (level.Lines.Count - previousLevel.Lines.Count >= 5 )
//                    Assert.Fail("To big bump in difficulty. Lines increased with " +
//                                (level.Lines.Count - previousLevel.Lines.Count) + " @level "+n);
            }
            Assert.Pass("Game always gets more difficult between levels 1 -> " + upperLevelLimit);
        }
    }
}