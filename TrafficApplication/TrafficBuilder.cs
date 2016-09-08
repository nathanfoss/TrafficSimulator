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
            Road = new Road(lanes, speedLimit);
            int totalVehicles = trafficLevel * lanes * 2; //in this case we're creating 2 miles' worth of cars
            for(int i = 0; i < totalVehicles; i++) //create new vehicle
            {
                Driver tempDriver = new Driver(PersonalityAssigner.AssignPersonality(), 
                    SpeedAssigner.AssignSpeed(),AttitudeAssigner.AssignAttitude());
                
                Vehicle tempVehicle = new Vehicle(TypeAssigner.AssignType(), Random.Next(0, 2), Random.NextDouble() * 2, 
                    tempDriver, Road);
                Vehicles.Add(tempVehicle);
                //position will be anywhere random from 0-2 FOR NOW
                //if I create vehicles in order of position, the array will already be pre-sorted
            }
            
        }

        public List<Vehicle> GetVehicles()
        {
            return Vehicles;
        }
    }
}
