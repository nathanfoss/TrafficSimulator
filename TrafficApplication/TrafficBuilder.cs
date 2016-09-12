using System;
using System.Collections.Generic;

namespace TrafficApplication
{
    class TrafficBuilder
    {
        private Road Road;
        private List<Vehicle> Vehicles = new List<Vehicle>();
        private TypeAssigner TypeAssigner = new TypeAssigner();
        private AttitudeAssigner AttitudeAssigner = new AttitudeAssigner();
        private PersonalityAssigner PersonalityAssigner = new PersonalityAssigner();
        private SpeedAssigner SpeedAssigner = new SpeedAssigner();
        private Random Random = new Random();

        /// <summary>
        /// Constructor for the TrafficBuilder class. Randomly assigns drivers to cars and places
        /// them on the road in order of increasing position.
        /// </summary>
        /// <param name="lanes">Number of lanes on the road</param>
        /// <param name="speedLimit">Speed limit of the road</param>
        /// <param name="trafficLevel">Number of cars per lane per mile</param>
        public TrafficBuilder(int lanes, int speedLimit, int trafficLevel)
        {
            PassingPersonality personality;
            Speed speed;
            Attitude attitude;
            Type type;
            int drivingLane = 0;
            int nextAvailablePosition = 0;
            Road = new Road(lanes, speedLimit);
            int totalVehicles = trafficLevel * lanes * 2; //in this case we're creating 2 miles' worth of cars
            for(int i = 0; i < totalVehicles; i++) //create new vehicle
            {
                personality = PersonalityAssigner.AssignPersonality();
                speed = SpeedAssigner.AssignSpeed();
                attitude = AttitudeAssigner.AssignAttitude(); //assign random vlues
                type = TypeAssigner.AssignType();

                Driver tempDriver = new Driver(personality, speed, attitude);

                drivingLane = Random.Next(0, 2); //randomly assign spot on the road
                nextAvailablePosition = NextAvailablePosition(Vehicles, type, drivingLane);

                Vehicle tempVehicle = new Vehicle(type, drivingLane , Random.Next(nextAvailablePosition, 
                    nextAvailablePosition + 150), tempDriver, Road);

                Vehicles.Add(tempVehicle);
            }
            
        }

        /// <summary>
        /// Accessor method for the sorted List of Vehicles created by the TrafficBuilder Constructor
        /// </summary>
        /// <returns>The sorted list of vehicles</returns>
        public List<Vehicle> GetVehicles()
        {
            return Vehicles;
        }

        /// <summary>
        /// Computes the next available position the specified vehicle type could be placed in the specified lane
        /// </summary>
        /// <param name="vehicles">List of Vehicles Sorted by Increasing Position</param>
        /// <param name="type">Type of Vehicle to be created</param>
        /// <param name="drivingLane">Lane of the Vehicle to be created</param>
        /// <returns>Integer value of the first available position for a vehicle in the specified lane</returns>
        private int NextAvailablePosition(List<Vehicle> vehicles, Type type,  int drivingLane)
        {
            TypeHandler handler = new TypeHandler();
            int nextAvailablePosition;
            int vehiclePosition = 0;
            PersonalityHandler personalityHandler;
            int drivingGap = 0;
            Vehicle tempVehicle;
            int vehicleSize = handler.GetSize(type);
            int count = 0;
            for(int i = vehicles.Count - 1; i >= 0; i--)
            {
                tempVehicle = vehicles[i];
                if(tempVehicle.GetLane() == drivingLane)
                {
                    count++;
                    vehiclePosition = tempVehicle.GetPosition(); 
                    personalityHandler = new PersonalityHandler(tempVehicle.GetDriver().GetPersonality());
                    drivingGap = personalityHandler.GetDrivingGap(); //Get driving gap of the car behind
                    break;
                }
            }

            if(count == 0) //no vehicles in the specified lane
            {
                return nextAvailablePosition = 0;
            }
            else
            {
                return nextAvailablePosition = vehiclePosition + drivingGap;
            }
        }
    }
}
