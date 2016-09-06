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
        private Road road;
        private SpeedHandler speedHandler;
        private int speedAdjust;

        //Somehow assign vehicle size based on the vehicle type
        public Vehicle(Type type, int drivingLane, double position, Driver driver, Road road)
        {
            this.type = type;
            this.drivingLane = drivingLane;
            this.position = position;
            this.driver = driver;
            this.road = road;
            desiredVelocity = setVelocity(road, driver);
            actualVelocity = desiredVelocity; //initially these are the same
            size = assignSize(type);      
        }

       public Type getType()
        {
            return type;
        }

        public double getSize()
        {
            return size;
        }

        public int getLane()
        {
            return drivingLane;
        }

        public double getPosition()
        {
            return position;
        }

        public Driver getDriver()
        {
            return driver;
        }

        public int getVelocity()
        {
            return actualVelocity;
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
         private double assignSize(Type type)
        {
            double size = 0.0;
            size = assignSize(type, size);
            return size;
        }

        private static double assignSize(Type type, double size)
        {
            switch (type)
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

            return size;
        }

        private int setVelocity(Road road, Driver driver)
        {
            int desiredVelocity = road.getSpeedLimit(); // initialized to the speedLimit
            speedHandler = new SpeedHandler(driver.getSpeed());
            speedAdjust = speedHandler.getSpeedAdjust();
            if (type == Type.SEMI)
            {
                speedAdjust -= 5;
            }

            return desiredVelocity += speedAdjust;
                
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
