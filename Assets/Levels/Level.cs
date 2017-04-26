using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Levels
{
	public class Level
	{
		int level;

		// Number of Pkts total in level.
		int pkts;

		// Connections between pkts:
		List<Connection> connections;

		// Constants to define each level: 
		const int BASE_NUMBER = 5;
		const int TENTH_LEVEL_MODIFIER = 5;
		const int DIGIT_MODIFIER = 2;

		/// <summary>
		/// Default constructor. Sets level to 1.
		/// </summary>
		/// <param name="pkts">Pkts.</param>
		public Level()
		{
			No = 0;
			clear();
			LevelUP();
		}

		/// <summary>
		/// Secondary constructor. Sets level to custom value.
		/// Initializes a new instance of the <see cref="T:Game.Levels.Level"/> class.
		/// </summary>
		/// <param name="pkts">Pkts.</param>
		/// <param name="level">Custom level start.</param>
		public Level(int level)
		{
			this.No = level-1;
			clear();
			LevelUP();
		}

		/// <summary>
		/// Clear this instance.
		/// </summary>
		void clear()
		{
			this.pkts = 0;
			this.Lines = new List<Connection>();
		}

		/// <summary>
		/// Levels up.
		/// </summary>
		public void LevelUP()
		{
			level++;

			clear();

			int secondDigit = (level / 10); // |2| in 9821
			int firstDigit = (level % 10); // |1| in 9421

			// Pkts should be numbered after this system: 
			pkts = BASE_NUMBER                                  // BASE
				+ ((int)secondDigit * TENTH_LEVEL_MODIFIER) // 10th level modifier
				+ (int)((float)firstDigit / DIGIT_MODIFIER);   // First scifer modifier


			// Creatig the connections:
			InitializeConnections();

			int numConnections = secondDigit * 2 + pkts + firstDigit;

			for (int i = 0; i < numConnections; i++)
				if (numConnections - pkts > 5)
					connections.Add(addNthConnection(5));

			Debug.Log(DebugPrintPkts());
		}

		public override string ToString()
		{
			string output = "INITIAL PKTS=" + pkts;

			int i = 0;
			foreach (Connection c in connections)
			{
				if (i++ == pkts)
					output += "\n\n EXTRA PKTS=";
						
				output += "\n" + c;
			}
			return output;
		}

		public string DebugPrintPkts()
		{
			int[] pktCounter = CountConnections();
			string output = "DEBUG PRINT PKTS:";

			for (int i = 0; i < pktCounter.Length; i++)
			{
				output += " \n#" + i + "=" + pktCounter[i];  
			}
			return output;
		}

		/// <summary>
		/// Gets or sets the pkts.
		/// </summary>
		/// <value>The pkts.</value>
		public int Pkts
		{
			get
			{
				return pkts;
			}

			set
			{
				pkts = value;
			}
		}

		/// <summary>
		/// Gets or sets the lines.
		/// </summary>
		/// <value>The lines.</value>
		public List<Connection> Lines
		{
			get
			{
				return connections;
			}

			set
			{
				connections = value;
			}
		}

		public int No
		{
			get
			{
				return level;
			}

			set
			{
				level = value;
			}
		}

		private void InitializeConnections()
		{
			for (int i = 1; i <= pkts; i++)
			{
				int other = (i == pkts) ? 0 : i;
				connections.Add(new Connection(i - 1, other));
			}
		}

		/// <summary>
		/// Adds a connection to the first available pkt that
		/// holds one less connection that N. 
		/// </summary>
		/// <returns>The param name="n'th connection.</returns>
		/// <param name="n">Number of connections for a given pkt. </param>
		private Connection addNthConnection(int n)
		{
			int[] count = CountConnections();

			// Checking to find a sutible connection:
			for (int first = 0; first < count.Length; first++) 
			{
				if (count[first] < n)
				{
					for (int second = 0; second < count.Length; second++) 
					{
						if (first == second || first+1 == second) continue; // Edge case. Never possible.

						if (count[second] < n) 
						{
							if (!connectionExists(first, second))
							{
								Debug.Log("(" + first + "->" + second + ")");
								return new Connection(first, second);
							}
						} // Too many connections on second.
					}
				} // Too many connections on first.
			}
			return null;
 		}

		/// <summary>
		/// Checks if a connection exsits in the line List
		/// </summary>
		/// <returns><c>true</c>, if exists was connectioned, <c>false</c> otherwise.</returns>
		/// <param name="pkt1">Pkt1.</param>
		/// <param name="pkt2">Pkt2.</param>
		public bool connectionExists(int pkt1, int pkt2)
		{
			foreach (Connection c in connections)
				if (c.isSame(pkt1, pkt2))
					return true;

			return false;
		}

		/// <summary>
		/// Counts the connections for each pkt
		/// </summary>
		/// <returns>Counted connections as histogram</returns>
		private int[] CountConnections()
		{
			int[] pkt = new int[pkts];

			foreach (Connection c in connections)
			{
				pkt[c.From]++;
				pkt[c.To]++;
			}

			return pkt;
		}
	}
}
