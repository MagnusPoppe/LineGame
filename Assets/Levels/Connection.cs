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

		public bool Equals(int otherfrom, int otherto)
		{
			if (From == otherfrom && To == otherto)
				return true;
			if (From == otherto && To == otherfrom)
				return true;

		    return false; // No Simularities.
	    }

		public override string ToString()
		{
			return "( "+From + " -> " + To+" )";
		}
	}
}
