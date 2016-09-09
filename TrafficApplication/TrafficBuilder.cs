using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //traffic level is the vehicles per mile per lane
        public TrafficBuilder(int lanes, int speedLimit, int trafficLevel)
        {
            PassingPersonality personality;
            Speed speed;
            Attitude attitude;
            Type type;
            TypeHandler typeHandler = new TypeHandler();
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
                nextAvailablePosition = NextAvailablePosition(Vehicles, type, typeHandler, personality, drivingLane);

                Vehicle tempVehicle = new Vehicle(type, drivingLane , Random.Next(nextAvailablePosition, 
                    nextAvailablePosition + 350), tempDriver, Road);

                Vehicles.Add(tempVehicle);
                //position will be anywhere random from 0-2 FOR NOW
            }
            
        }

        public List<Vehicle> GetVehicles()
        {
            return Vehicles;
        }

        private int NextAvailablePosition(List<Vehicle> vehicles, Type type, TypeHandler handler,
            PassingPersonality personality, int drivingLane)
        {
            int nextAvailablePosition;
            int vehiclePosition = 0;
            PersonalityHandler personalityHandler = new PersonalityHandler(personality);
            int drivingGap = personalityHandler.GetDrivingGap();
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
