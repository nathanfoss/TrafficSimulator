namespace TrafficApplication
{
    class Road
    {
        private int Lanes;
        private int SpeedLimit;

        //TODO add road conditions, turns, construction, etc.
        public Road(int lanes, int speedLimit)
        {
            Lanes = lanes;
            SpeedLimit = speedLimit;
        }

        public int GetLanes()
        {
            return Lanes;
        }

        public int GetSpeedLimit()
        {
            return SpeedLimit;
        }
    }
}
