namespace TrafficApplication
{

    class Vehicle
    {
        private Type Type;
        private int Size;
        private int DrivingLane;
        private int Position;
        private Driver Driver;
        private int DesiredVelocity;
        private int ActualVelocity;
        private Road Road;
        private SpeedHandler SpeedHandler;
        private int SpeedAdjust;
        private TypeHandler TypeHandler = new TypeHandler();

        //Somehow assign vehicle size based on the vehicle type
        public Vehicle(Type type, int drivingLane, int position, Driver driver, Road road)
        {
            Type = type;
            DrivingLane = drivingLane;
            Position = position;
            Driver = driver;
            Road = road;
            DesiredVelocity = SetDesiredVelocity(road, driver);
            ActualVelocity = DesiredVelocity; //initially these are the same
            Size = TypeHandler.GetSize(type);      
        }

       public Type GetVehicleType()
        {
            return Type;
        }

        public int GetSize()
        {
            return Size;
        }

        public int GetLane()
        {
            return DrivingLane;
        }

        public int GetPosition()
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
