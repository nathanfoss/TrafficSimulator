using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{

    class Vehicle
    {
        private Type type;
        private double size;
        private int drivingLane;
        private double position;
        private Driver driver;
        private int desiredVelocity;
        private int actualVelocity;

        //Somehow assign vehicle size based on the vehicle type
        public Vehicle(Type type, int drivingLane, double position, Driver driver, int desiredVelocity, int actualVelocity)
        {
            this.type = type;
            this.drivingLane = drivingLane;
            this.position = position;
            this.driver = driver;
            this.desiredVelocity = desiredVelocity;
            this.actualVelocity = actualVelocity;
            assignSize(type);      
        }

       

        //Somehow figure out where all the other cars are
        public void changeLanes(int newLane)
        {
            if (drivingLane != newLane) //in case something went wrong
            {
                if(canChangeLanes(newLane))
                {
                    drivingLane = newLane;
                }
            }
        }
         private void assignSize(Type type)
                {
                    switch(type)
                    {
                        case Type.COMPACT:
                            {
                                size = 0.00254104; //161 inches in miles
                                break;
                            }
                        case Type.MINIVAN:
                            {
                                size = 0.00315657; //200 inches in miles
                                break;
                            }
                        case Type.MOTORCYCLE:
                            {
                                size = 0.001488321; //94 inches in miles
                                break;
                            }
                        case Type.PICKUP:
                            {
                                size = 0.00347222; //220 inches in miles
                                break;
                            }
                        case Type.SEDAN:
                            {
                                size = 0.00276199; //175 inches in miles
                                break;
                            }
                        case Type.SEMI:
                            {
                                size = 0.0113636; //60 feet in miles
                                break;
                            }
                    }
            
                }
        private bool canChangeLanes(int newLane)
        {
            //if the gap is big enough for this driver's personality, change lanes
            //uses: driver's personality (PersonalityHandler), car behind in other lane, car ahead in other lane
            return true;
        }

        //write a method to handle passing and changing back to original lane when finished
        
        //When cars in the same lane are close together, compare velocities and check canChangeLanes
    }
}
