namespace TrafficApplication
{
    /// <summary>
    /// Road class allowing for variations in number of lanes, speed limits, road conditions, etc.
    /// </summary>
    class Road
    {
        private int Lanes;
        private int SpeedLimit;

        //TODO add road conditions, turns, construction, etc.
        /// <summary>
        /// Constructor for Road object. Creates a road with the specified number of lanes and speed limit
        /// </summary>
        /// <param name="lanes">Number of lanes going one direction on the road</param>
        /// <param name="speedLimit">Speed Limit in mph</param>
        public Road(int lanes, int speedLimit)
        {
            Lanes = lanes;
            SpeedLimit = speedLimit;
        }

        /// <summary>
        /// Retrieves the number of lanes for the Road object
        /// </summary>
        /// <returns>Number of lanes going one direction for this Road</returns>
        public int GetLanes()
        {
            return Lanes;
        }

        /// <summary>
        /// Retrieves the Speed limit value
        /// </summary>
        /// <returns>Speed Limit in MPH</returns>
        public int GetSpeedLimit()
        {
            return SpeedLimit;
        }
    }
}
