namespace TrafficApplication
{
    /// <summary>
    /// Class representing vehicle objects in the Traffic simulator
    /// </summary>
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

        /// <summary>
        /// Constructor for the Vehicle class. Creates a vehicle object with the specified parameters.
        /// </summary>
        /// <param name="type">Enumerated Type of Vehicle. Used to determine the vehicle's size</param>
        /// <param name="drivingLane">The lane on the road the vehicle occupies</param>
        /// <param name="position">The position on the road of the vehicle</param>
        /// <param name="driver">The driver of the vehicle with included personality factors</param>
        /// <param name="road">The road the vehicle is driving on. Used to determine driving velocity</param>
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

        /// <summary>
        /// Returns the size, in feet, of the specified vehicle object
        /// </summary>
        /// <returns>Vehicle size in feet</returns>
        public int GetSize()
        {
            return Size;
        }

        /// <summary>
        /// Retrieves the lane the vehicle occupies
        /// </summary>
        /// <returns>Int value of the lane</returns>
        public int GetLane()
        {
            return DrivingLane;
        }

        /// <summary>
        /// Retrieves the position of the vehicle on the road
        /// </summary>
        /// <returns>Integer value specifying the vehicle's position, in feet</returns>
        public int GetPosition()
        {
            return Position;
        }

        /// <summary>
        /// Retrieves the driver object that determines vehicle behavior
        /// </summary>
        /// <returns>Driver object representing the driver of the vehicle</returns>
        public Driver GetDriver()
        {
            return Driver;
        }

        /// <summary>
        /// Retrieves the Type of Vehicle
        /// </summary>
        /// <returns>The enumerated Type value of the Vehicle</returns>
        public Type GetVehicleType()
        {
            return Type;
        }

        /// <summary>
        /// Retrieves the driving velocity of the vehicle
        /// </summary>
        /// <returns>Integer value of the vehicle's actual velocity in mph</returns>
        public int GetVelocity()
        {
            return ActualVelocity;
        }
        
        /// <summary>
        /// Retrieves the desired velocity based on the Driver's personality
        /// </summary>
        /// <returns>Integer value of the vehicle's desired velocity in mph</returns>
        public int GetDesiredVelocity()
        {
            return DesiredVelocity;
        }

        /// <summary>
        /// Sets the Actual Velocity to a specified velocity value in mph
        /// </summary>
        /// <param name="velocity">The new velocity of a vehicle in mph</param>
        public void SetActualVelocity(int velocity)
        {
            ActualVelocity = velocity;
        }

        /// <summary>
        /// Moves the Vehicle to a new position on the road
        /// </summary>
        /// <param name="newPosition">The new position on the road of the vehicle</param>
        public void SetPosition(int newPosition)
        {
            Position = newPosition;
        }

        /// <summary>
        /// Allows a vehicle to change lanes
        /// </summary>
        /// <param name="newLane">The new lane the vehicle will change to</param>
        public void ChangeLanes(int newLane)
        {
            if (DrivingLane != newLane) //in case something went wrong
            {
                DrivingLane = newLane;
            }
        }


        /// <summary>
        /// Sets the desired velocity of the vehicle based on driver personality and the speed limit
        /// of the road
        /// </summary>
        /// <param name="road">The road the vehicle is driving on</param>
        /// <param name="driver">The driver of the vehicle with specified personality</param>
        /// <returns>The driver's desired velocity if no traffic based on personality in mph</returns>
        public int SetDesiredVelocity(Road road, Driver driver)
        {
            int desiredVelocity = road.GetSpeedLimit(); // initialized to the speedLimit
            SpeedHandler = new SpeedHandler(driver.GetSpeed());
            SpeedAdjust = SpeedHandler.GetSpeedAdjust();
            if (Type == Type.SEMI)
            {
                SpeedAdjust -= 5; //Speed limit for SEMIs is 5mph lower than normal vehicles
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
