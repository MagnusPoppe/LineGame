using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Levels
{
    public class LevelManager
    {
        private int level;

        // Number of Pkts total in level.
        private int pkts;

        // Connections between pkts:
        List<Connection>[] connections;

        private int timelimit;

        public int TimeLimit
        {
            get { return timelimit; }
        }

        // Constants to define each level:
        public const int BASE_NUMBER = 5;

        /// <summary>
        /// Default constructor. Sets level to 1.
        /// </summary>
        /// <param name="pkts">Pkts.</param>
        public LevelManager()
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
        public LevelManager(int level)
        {
            this.No = level - 1;
            clear();
            LevelUP();
        }

        /// <summary>
        /// Clear this instance.
        /// </summary>
        void clear()
        {
            this.pkts = 0;
            this.connections = null;
        }

        /// <summary>
        /// Levels up.
        /// </summary>
        public void LevelUP()
        {
            level++;
            clear();

            // Getting data from next level:
            Level currentLevel = Levels.GetLevel(level);
            timelimit = currentLevel.TimeLimit;
            pkts = currentLevel.Pkts;
            int remainingConnections = currentLevel.Connections;
            int pkt = 0;
            connections = new List<Connection>[pkts];
            for (int i = 0; i < pkts; i++)
                connections[i] = new List<Connection>();

            // Placing all connections for this level:
            while (remainingConnections >= 0)
            {
                pkt++;
                // Starting new round of adding connections:
                if (pkt >= pkts) pkt = 0;

                // No more connections for this pkt.
                if (connections[pkt].Count > currentLevel.MaxConnectionsPerPkt) continue;

                // Finding next pkt to connect to:
                for (int i = 0; i < pkts; i++)
                {
                    // Checking if requirements for new connection has been met
                    if (i != pkt && connections[i].Count <= currentLevel.Connections && !connectionExists(pkt, i))
                    {
                        connections[pkt].Add(new Connection(pkt, i));
                        remainingConnections--;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the current level can be beaten
        /// </summary>
        /// <returns>true if the level can be beaten.</returns>
        public bool CanBeBeaten()
        {
            int tooBig = 0;
            for (int i = 0; i < connections.Length; i++)
            {
                if (connections[i].Count == connections.Length)
                    return false;

                if ((connections[i].Count / (float) pkts) > 0.50f)
                    tooBig++;
            }

            return tooBig > connections.Length * 0.50f;
        }

        /// <summary>
        /// To string default method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "INITIAL PKTS=" + pkts;

            int i = 0;
            for (int j = 0; j < connections.Length; j++)
            {
                foreach (Connection c in connections[j])
                {
                    if (i++ == pkts)
                        output += "\n\n EXTRA PKTS=";

                    output += "\n" + c;
                }
            }

            return output;
        }

        /// <summary>
        /// Gets or sets the pkts.
        /// </summary>
        /// <value>The pkts.</value>
        public int Pkts
        {
            get { return pkts; }
            set { pkts = value; }
        }

        /// <summary>
        /// Gets or sets the lines.
        /// </summary>
        /// <value>The lines.</value>
        public List<Connection>[] Lines
        {
            get { return connections; }
            set { connections = value; }
        }

        /// <summary>
        /// Level number.
        /// </summary>
        public int No
        {
            get { return level; }
            set { level = value; }
        }

        /// <summary>
        /// Checks if a connection exsits in the line List
        /// </summary>
        /// <returns><c>true</c>, if exists was connectioned, <c>false</c> otherwise.</returns>
        /// <param name="pkt1">Pkt1.</param>
        /// <param name="pkt2">Pkt2.</param>
        public bool connectionExists(int pkt1, int pkt2)
        {
            foreach (Connection c in connections[pkt1])
                if (c.Equals(pkt1, pkt2))
                    return true;

            foreach (Connection c in connections[pkt2])
                if (c.Equals(pkt2, pkt1))
                    return true;

            return false;
        }
    }
}