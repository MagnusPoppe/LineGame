namespace Game.Levels
{
    public class Level
    {

        /// <summary>
        /// Total points in level
        /// </summary>
        public int Pkts
        {
            get { return pkts; }
        }
        private int pkts;

        /// <summary>
        /// Total connections in level
        /// </summary>
        public int Connections
        {
            get { return connections; }
        }
        private int connections;

        /// <summary>
        /// Maximum connections allowed to be attached to a single pkt.
        /// </summary>
        public int MaxConnectionsPerPkt
        {
            get { return maxConnectionsPerPkt; }
        }
        private int maxConnectionsPerPkt;

        /// <summary>
        /// Timelimit of the current level in seconds.
        /// </summary>
        public int TimeLimit
        {
            get { return timeLimit; }
        }
        private int timeLimit;



        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pkts">Number of points/circles.</param>
        /// <param name="connections">Number of connections total</param>
        /// <param name="maxConnectionsPerPkt">Maximum number of connections allowed per point/circle</param>
        /// <param name="timeInSeconds">Time limit in seconds for the given level</param>
        public Level(int pkts, int connections, int maxConnectionsPerPkt, int timeInSeconds)
        {
            this.pkts = pkts;
            this.connections = connections;
            this.maxConnectionsPerPkt = maxConnectionsPerPkt;
            this.timeLimit = timeInSeconds;
        }
    }
}