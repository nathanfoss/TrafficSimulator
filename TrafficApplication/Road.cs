using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{
    class Road
    {
        private int lanes;
        private int speedLimit;

        //TODO add road conditions, turns, construction, etc.
        public Road(int lanes, int speedLimit)
        {
            this.lanes = lanes;
            this.speedLimit = speedLimit;
        }

        public int getLanes()
        {
            return lanes;
        }

        public int getSpeedLimit()
        {
            return speedLimit;
        }
    }
}
