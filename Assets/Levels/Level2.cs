using System;

namespace Game.Levels
{
	public class Level2 : Level
	{
		public const int circles = Level1.circles + 2; // 12

		public Level2() : base(circles)
		{
			// Base to make all pkts have atleast 2 connections.
			Lines.Add(new Connection(0, 1));
			Lines.Add(new Connection(1, 2));
			Lines.Add(new Connection(2, 3));
			Lines.Add(new Connection(3, 4));
			Lines.Add(new Connection(4, 5));
			Lines.Add(new Connection(5, 6));
			Lines.Add(new Connection(6, 7));
			Lines.Add(new Connection(7, 8));
			Lines.Add(new Connection(8, 9));
			Lines.Add(new Connection(9, 10));
			Lines.Add(new Connection(10, 11));
			Lines.Add(new Connection(11, 0));

			// Adding third connection:
			Lines.Add(new Connection(0, 2));
			Lines.Add(new Connection(3, 5));
		}
	}
}