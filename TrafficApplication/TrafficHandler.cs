using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{
    class TrafficHandler
    {
        private List<Vehicle> vehicles; //Sorted array of vehicles
        private Road highway; //I think I need this just for the lanes

        public TrafficHandler(Road highway, List<Vehicle> vehicles) 
        {
            this.highway = highway;
            this.vehicles = vehicles;
            
        }

        public bool isCarAhead()
        {
            return false; //Compare each car to the car ahead of it
        }
    }
}
