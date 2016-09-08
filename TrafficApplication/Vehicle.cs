namespace TrafficApplication
{

    class Vehicle
    {
        private Type Type;
        private double Size;
        private int DrivingLane;
        private double Position;
        private Driver Driver;
        private int DesiredVelocity;
        private int ActualVelocity;
        private Road Road;
        private SpeedHandler SpeedHandler;
        private int SpeedAdjust;

        //Somehow assign vehicle size based on the vehicle type
        public Vehicle(Type type, int drivingLane, double position, Driver driver, Road road)
        {
            Type = type;
            DrivingLane = drivingLane;
            Position = position;
            Driver = driver;
            Road = road;
            DesiredVelocity = SetDesiredVelocity(road, driver);
            ActualVelocity = DesiredVelocity; //initially these are the same
            Size = AssignSize(type);      
        }

       public Type GetVehicleType()
        {
            return Type;
        }

        public double GetSize()
        {
            return Size;
        }

        public int GetLane()
        {
            return DrivingLane;
        }

        public double GetPosition()
        {
            return Position;
        }

        public Driver GetDriver()
        {
            return Driver;
        }

        public int GetVelocity()
        {
            return ActualVelocity;
        }

        //Somehow figure out where all the other cars are
        public void ChangeLanes(int newLane)
        {
            if (DrivingLane != newLane) //in case something went wrong
            {
                if(CanChangeLanes(newLane))
                {
                    DrivingLane = newLane;
                }
            }
        }
         private double AssignSize(Type type)
        {
            double size = 0.0;
            size = AssignSize(type, size);
            return size;
        }

        private static double AssignSize(Type type, double size)
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

        private int SetDesiredVelocity(Road road, Driver driver)
        {
            int desiredVelocity = road.GetSpeedLimit(); // initialized to the speedLimit
            SpeedHandler = new SpeedHandler(driver.GetSpeed());
            SpeedAdjust = SpeedHandler.GetSpeedAdjust();
            if (Type == Type.SEMI)
            {
                SpeedAdjust -= 5;
            }

            return desiredVelocity += SpeedAdjust;
                
        }

        private bool CanChangeLanes(int newLane)
        {
            //if the gap is big enough for this driver's personality, change lanes
            //uses: driver's personality (PersonalityHandler), car behind in other lane, car ahead in other lane
            return true;
        }

        //write a method to handle passing and changing back to original lane when finished
        
        //When cars in the same lane are close together, compare velocities and check canChangeLanes
    }
}
