using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{
    class TrafficBuilder
    {
        private Road road;
        private List<Vehicle> vehicles = new List<Vehicle>();
        private TypeAssigner typeAssigner = new TypeAssigner();
        private AttitudeAssigner attitudeAssigner = new AttitudeAssigner();
        private PersonalityAssigner personalityAssigner = new PersonalityAssigner();
        private SpeedAssigner speedAssigner = new SpeedAssigner();
        private Random random = new Random();

        //traffic level is the vehicles per mile per lane
        public TrafficBuilder(int lanes, int speedLimit, int trafficLevel)
        {
            road = new Road(lanes, speedLimit);
            int totalVehicles = trafficLevel * lanes * 2; //in this case we're creating 2 miles' worth of cars
            for(int i = 0; i < totalVehicles; i++) //create new vehicle
            {
                Driver tempDriver = new Driver(personalityAssigner.AssignPersonality(), 
                    speedAssigner.AssignSpeed(),attitudeAssigner.AssignAttitude());
                
                Vehicle tempVehicle = new Vehicle(typeAssigner.assignType(), random.Next(0, 2), random.NextDouble() * 2, 
                    tempDriver, road);
                vehicles.Add(tempVehicle);
                //position will be anywhere random from 0-2 FOR NOW
                //if I create vehicles in order of position, the array will already be pre-sorted
            }
            
        }

        public List<Vehicle> getVehicles()
        {
            return vehicles;
        }
    }
}
