using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{
    class TrafficHandler
    {
        private Vehicle[] vehicles; //Sorted array of vehicles
        private Road highway; //I think I need this just for the lanes

        public TrafficHandler(int lanes, int speedLimit, int trafficLevel) //traffic level tells system how many vehicles to create
        {

        }

        public bool isCarAhead()
        {
            return false; //Compare each car to the car ahead of it
        }
    }
}
