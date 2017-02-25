using System;

namespace Game
{
	public class Level
	{

		int level;

		int lineCount;
		int circleCount;

		public Level(int level)
		{
			this.level = level;
		}

		public void nextLevel()
		{
			level++;
		}
	}
}
