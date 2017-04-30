﻿namespace Game.Levels
{
    public class Level
    {

        private int pkts;

        public int Pkts
        {
            get { return pkts; }
        }

        public int Connections
        {
            get { return connections; }
        }

        public int MaxConnectionsPerPkt
        {
            get { return maxConnectionsPerPkt; }
        }

        private int connections;
        private int maxConnectionsPerPkt;

        public Level(int pkts, int connections, int maxConnectionsPerPkt)
        {
            this.pkts = pkts;
            this.connections = connections;
            this.maxConnectionsPerPkt = maxConnectionsPerPkt;
        }
    }
}