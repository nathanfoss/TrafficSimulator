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


        private bool CanMerge(Vehicle vehicle, List<Vehicle> vehicles)
        {
            int gapBehind = 0;
            int gapAhead = 0;
            int vehicleBehindPosition = 0;
            int vehicleAheadPosition = 0;
            int vehicleBehindSize = 0;
            int vehicleAheadSize = 0;
            Vehicle vehicleBehind;
            Vehicle vehicleAhead;
            int position = vehicle.GetPosition();
            PersonalityHandler handler = new PersonalityHandler(vehicle.GetDriver().GetPersonality());
            int drivingGap = handler.GetDrivingGap();
            int size = vehicle.GetSize();


            if(vehicles[0].GetPosition() <= position) //first vehicle is behind our current car
            {
                vehicleBehind = vehicles[0];
                vehicleBehindPosition = vehicleBehind.GetPosition();
                vehicleBehindSize = vehicleBehind.GetSize();
                gapBehind = position - size - drivingGap - vehicleBehindPosition;
            }
            else //there is no vehicle behind our current vehicle
            {
                vehicleAhead = vehicles[0];
                vehicleAheadPosition = vehicleAhead.GetPosition();
                vehicleAheadSize = vehicleAhead.GetSize();
                gapAhead = vehicleAheadPosition - vehicleAheadSize - drivingGap - position;
                gapBehind = 1;
            }

            if(vehicles.Count == 2) //there is a vehicle ahead of and behind our current vehicle
            {
                vehicleAhead = vehicles[1];
                vehicleAheadPosition = vehicleAhead.GetPosition();
                vehicleAheadSize = vehicleAhead.GetSize();
                gapAhead = vehicleAheadPosition - vehicleAheadSize - drivingGap - position;
            }
            

            if(gapAhead > 0 && gapBehind > 0)
            {
                return true;
            }
            return false;
        }
        

        private bool CanMergeDirection(Vehicle vehicle, string direction)
        {
            switch (direction)
            {
                case "Left":
                    {
                        int lane = vehicle.GetLane();
                        if (lane == 0)
                        {
                            return false;
                        }
                        return true;
                    }
                case "Right":
                    {
                        int lane = vehicle.GetLane();
                        if (lane == Highway.GetLanes() - 1)
                        {
                            return false;
                        }
                        return true;
                    }
}
            
            return false;
            
        }

        private bool CanChangeLanes(int index, List<Vehicle> vehicles)
        {
            Vehicle vehicle = vehicles[index];
            List<Vehicle> closestLeftVehicles = new List<Vehicle>();
            List<Vehicle> closestRightVehicles = new List<Vehicle>();
            bool left = false;
            bool right = false;

            if (CanMergeDirection(vehicle, "Left"))
            {
                left = true;
                closestLeftVehicles = FindClosestVehicles(vehicle, vehicles, left);
                if(CanMerge(vehicle, closestLeftVehicles))
                {
                    return true;
                }
            }
            if (CanMergeDirection(vehicle, "Right"))
            {
                right = true;
                closestRightVehicles = FindClosestVehicles(vehicle, vehicles, false, right);
                if (CanMerge(vehicle, closestRightVehicles))
                {
                    return true;
                }
            }

            return false;
        }

        private List<Vehicle> FindClosestVehicles(Vehicle vehicle, List<Vehicle> vehicles, bool left = false, bool right = false)
        {
            int position = vehicle.GetPosition();
            int drivingLane = vehicle.GetLane();
            Vehicle tempVehicle;

            List<Vehicle> closestVehicles = new List<Vehicle>();
            for (int i = 0; i < vehicles.Count; i++)
            {
                tempVehicle = vehicles[i];
                if (left && tempVehicle.GetLane() == drivingLane - 1) //only care about vehicles in other lanes
                     //3 cases: left lane merge right, right lane merge left, middle lane merge either
                {
                    if (tempVehicle.GetPosition() <= position)
                    {
                        if (closestVehicles.Count != 0)
                        { //keep removing until the closest vehicle is found
                            closestVehicles.RemoveAt(0);
                        }
                        closestVehicles.Add(tempVehicle);
                    }
                    else if (tempVehicle.GetPosition() >= position)
                    {
                        closestVehicles.Add(tempVehicle);
                        break; //break after finding the first vehicle in specified lane ahead of current vehicle
                    } 
                }
                else if (right && tempVehicle.GetLane() == drivingLane + 1) //
                {
                    if (tempVehicle.GetPosition() <= position)
                    {
                        if (closestVehicles.Count != 0)
                        { //keep removing until the closest vehicle is found
                            closestVehicles.RemoveAt(0);
                        }
                        closestVehicles.Add(tempVehicle);
                    }
                    else if (tempVehicle.GetPosition() >= position)
                    {
                        closestVehicles.Add(tempVehicle);
                        break; //break after finding the first vehicle in specified lane ahead of current vehicle
                    }
                }
            }

            return closestVehicles;
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
        /// Uses CarAheadIndex method to check for approaching vehicles. If found, looks to change lanes 
        /// and if not possible calls SlowDown method
        /// </summary>
        /// <param name="vehicles">The sorted list of vehicles on the road</param>
        private void AdjustVelocity(List<Vehicle> vehicles)
        {
            int index;
            Vehicle tempVehicle;
            int lane = 0;
            for(int i = 0; i < vehicles.Count; i++)
            {
                tempVehicle = vehicles[i];
                lane = tempVehicle.GetLane();
                index = CarAheadIndex(i, vehicles);
                if (index != -1 && vehicles[i].GetDesiredVelocity() > vehicles[index].GetVelocity())
                { //Only look if there is a car ahead that's slowing a driver down
                   if(CanChangeLanes(i, vehicles) && CanMergeDirection(tempVehicle, "Left")) 
                    {//Attempt to Merge Left first
                        tempVehicle.ChangeLanes(lane - 1); 
                    }
                   else if (CanChangeLanes(i, vehicles) && CanMergeDirection(tempVehicle, "Right"))
                    {//If not able to merge left, then looks to merge right
                        tempVehicle.ChangeLanes(lane + 1);
                    }
                   else
                    {
                        SlowDown(i, index, vehicles);
                    }
                    
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
            for(int i = vehicles.Count - 1; i >= 0; i--) //starting with forward vehicles first
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
