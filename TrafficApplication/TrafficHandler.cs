using System.Collections.Generic;

namespace TrafficApplication
{
    /// <summary>
    /// TrafficHandler class supports ongoing traffic behavior --- Still not sure what this will look like
    /// </summary>
    class TrafficHandler
    {
        private List<Vehicle> Vehicles; //Sorted array of vehicles
        private Road Highway; //I think I need this just for the lanes

        public TrafficHandler(Road highway, List<Vehicle> vehicles) 
        {
            Highway = highway;
            Vehicles = vehicles;
        }

        public List<Vehicle> IterateTraffic()
        {
            //AdjustVelocity(Vehicles);
            AdvancePosition(Vehicles);
            return Vehicles;
        }

        public bool IsCarAhead(List<Vehicle> vehicles)
        {
            return false; //Compare each car to the car ahead of it
        }
        
        //if car ahead either slow down or change lanes
        private void AdjustVelocity(List<Vehicle> vehicles)
        {

        }

        //
        private void AdvancePosition(List<Vehicle> vehicles)
        {
            Vehicle tempVehicle;
            double velocity = 0;
            int position = 0;
            int newPosition = 0;
            for(int i = 0; i < vehicles.Count; i++)
            {
                tempVehicle = vehicles[i];
                velocity = tempVehicle.GetVelocity() * 1.466667 / 33; //convert mph to fps then allow for 30 frames per second
                position = tempVehicle.GetPosition();
                newPosition = (int)(velocity + position);
                tempVehicle.SetPosition(newPosition);
            }
        }
    }
}
