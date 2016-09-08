using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{
    class TrafficHandler
    {
        private List<Vehicle> Vehicles; //Sorted array of vehicles
        private Road Highway; //I think I need this just for the lanes

        public TrafficHandler(Road highway, List<Vehicle> vehicles) 
        {
            Highway = highway;
            Vehicles = vehicles;
            
        }

        public bool IsCarAhead(List<Vehicle> vehicles)
        {
            return false; //Compare each car to the car ahead of it
        }
    }
}
