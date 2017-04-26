using System;
namespace Game.Levels
{
	public class Connection
	{
		int fromID;
		int toID;

		public Connection(int from, int to)
		{
			From = from;
			To = to;
		}

		public int From
		{
			get
			{
				return fromID;
			}

			set
			{
				fromID = value;
			}
		}

		public int To
		{
			get
			{
				return toID;
			}

			set
			{
				toID = value;
			}
		}

		public bool isSame(int otherfrom, int otherto)
		{
			if (From == otherfrom && To == otherto)
				return true;
			else if (From == otherto && To == otherfrom)
				return true;
			else
				return false; // No simmularities.
	    }

		public override string ToString()
		{
			return "( "+From + " -> " + To+" )";
		}
	}
}
