using System.Collections.Generic;
using System.Linq;

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
            AdjustVelocity(Vehicles);
            AdvancePosition(Vehicles);
            SortList(Vehicles);
            return Vehicles;
        }

        public List<Vehicle> ResetTraffic()
        {
            int position = 0;
            for(int i = 0; i < Vehicles.Count; i++)
            {
                position = Vehicles[i].GetPosition();
                Vehicles[i].SetPosition(position - 17);
            }
            return Vehicles;
        }

        private void SortList(List<Vehicle> vehicles)
        {
            Vehicles = vehicles.OrderBy(o => o.GetPosition()).ToList();
        }

        /// <summary>
        /// If a vehicle is approaching a vehicle ahead of them, returns the index of the vehicle ahead
        /// </summary>
        /// <param name="index">Index in the list of current vehicle</param>
        /// <param name="vehicles">Sorted list of vehicles on the road</param>
        /// <returns></returns>
        private int CarAheadIndex(int index, List<Vehicle> vehicles)
        {
            int positionDifference = 0;
            int drivingLane = vehicles[index].GetLane();
            int position = vehicles[index].GetPosition();
            PersonalityHandler handler = new PersonalityHandler(vehicles[index].GetDriver().GetPersonality());
            int drivingGap = handler.GetDrivingGap();

            for (int i = 0; i < vehicles.Count; i++) 
            { //look for the next vehicle in the same lane excluding this vehicle
                //is possible that vehicle initially behind passes current vehicle then
                //is slowed by traffic ahead
                
                if(index != i)
                {
                    if(vehicles[i].GetLane() == drivingLane && vehicles[i].GetPosition() > position)
                    {//get the first vehicle that is in the same lane and ahead of current vehicle
                        positionDifference = vehicles[i].GetPosition() - position;
                        if(positionDifference <= drivingGap)
                        {
                            return i;
                        }
                        break;
                    }
                }
                
            }

            return -1; //Compare this car to the car ahead of it
        }

        /// <summary>
        /// Sets the velocity of an approaching vehicle to the velocity of the vehicle ahead of it
        /// </summary>
        /// <param name="carBehind">Index in the list of the current vehicle</param>
        /// <param name="carAhead">Index in the list of the next vehicle ahead in the same lane</param>
        /// <param name="vehicles">Sorted list of vehicles on the road</param>
        private void SlowDown(int carBehind, int carAhead, List<Vehicle> vehicles)
        {
            vehicles[carBehind].SetActualVelocity(vehicles[carAhead].GetVelocity());
        }
        
        /// <summary>
        /// Uses CarAheadIndex method to check for approaching vehicles. If found, calls SlowDown method
        /// </summary>
        /// <param name="vehicles">The sorted list of vehicles on the road</param>
        private void AdjustVelocity(List<Vehicle> vehicles)
        {
            int index;
            for(int i = 0; i < vehicles.Count; i++)
            {
                index = CarAheadIndex(i, vehicles);
                if (index != -1)
                    {
                        SlowDown(i, index, vehicles);
                    }
                }
            
        }

        /// <summary>
        /// Increments each vehicle's position based on velocity and 30 frames per second
        /// </summary>
        /// <param name="vehicles">The complete collection of vehicles on the road</param>
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
