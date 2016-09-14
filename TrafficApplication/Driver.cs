namespace TrafficApplication
{
    /// <summary>
    /// Driver class allowing for human variable in traffic conditions. Supports small subset of
    /// different human personalities, attitudes, and driving styles.
    /// </summary>
    class Driver
    {
        private PassingPersonality Personality;
        private Speed Speed;
        private Attitude Attitude;
        private bool LeftLaneOnly;
        private bool SpeedFluctuates;
        private int AttitudeCount = 0;

        /// <summary>
        /// Constructor for the Driver class. Creates a new Driver object with the specified values
        /// </summary>
        /// <param name="personality">Enum value indicating the defensiveness/ aggressiveness of a Driver</param>
        /// <param name="speed">Enum value indicating the speed preference of a Driver</param>
        /// <param name="attitude">Enum value indicating whether a Driver is calmer or angrier</param>
        /// <param name="leftLaneOnly">Boolean value whether the Driver only drives in the left lane</param>
        /// <param name="speedFluctuates">Boolean value whether the Driver's speed fluctuates</param>
        public Driver(PassingPersonality personality, Speed speed, Attitude attitude, bool leftLaneOnly = false, bool speedFluctuates = false)
        {
            Personality = personality;
            Speed = speed;
            Attitude = attitude;
            LeftLaneOnly = leftLaneOnly;
            SpeedFluctuates = speedFluctuates;
        }

        /// <summary>
        /// Retrieves the Driver's speed preference
        /// </summary>
        /// <returns>Enumerated value for the Driver's speed preference</returns>
        public Speed GetSpeed()
        {
            return Speed;
        }

        /// <summary>
        /// Retrieves the Driver's level of aggressiveness
        /// </summary>
        /// <returns>Enumerated value indicating Driver's aggressiveness</returns>
        public PassingPersonality GetPersonality()
        {
            return Personality;
        }

        /// <summary>
        /// Retrieves the Driver's attitude
        /// </summary>
        /// <returns>Enumerated value indicating the Driver's attitude</returns>
        public Attitude GetAttitude()
        {
            return Attitude;
        }

        /// <summary>
        /// Assigns a new level of aggressiveness to a Driver--usually due to an attitude change
        /// </summary>
        /// <param name="personality">New level of aggressiveness for the Driver</param>
        public void SetPersonality(PassingPersonality personality)
        {
            Personality = personality;
        }

        /// <summary>
        /// Assigns a new speed preference for the Driver--usually due to an attitude change
        /// </summary>
        /// <param name="speed"></param>
        public void SetSpeed(Speed speed)
        {
            Speed = speed;
        }

        /// <summary>
        /// Assigns a new attitude to the Driver--usually because of traffic conditions
        /// </summary>
        /// <param name="attitude">The new attitude of the Driver</param>
        public void SetAttitude(Attitude attitude)
        {
            Attitude = attitude;
        }

        /// <summary>
        /// Sets a driver's attitude adjustment based on traffic conditions
        /// </summary>
        /// <returns>The positive or negative value indicating more or less frustration
        /// due to traffic conditions</returns>
        public int SetAttitudeAdjust()
        {
            int attitudeAdjust = 0;
            if (AttitudeCount < -240)
            {
                attitudeAdjust = -3;
            }
            else if (AttitudeCount < -150) //Vast majority of uninhibited driving
            {
                attitudeAdjust = -2;
            }
            else if (AttitudeCount < -30) //driving uninhibited for the most part
            {
                attitudeAdjust = -1;
            }
            else if (AttitudeCount < 60) //traffic slight affect on driver
            {
                attitudeAdjust = 0;
            }
            else if (AttitudeCount < 120) //traffic has noticable affect on driver
            {
                attitudeAdjust = 1;
            }
            else if (AttitudeCount < 200) //traffic has significant effect on driver
            {
                attitudeAdjust = 2;
            }
            else if (AttitudeCount < 270)
            {
                attitudeAdjust = 3;
            }
            return attitudeAdjust;
        }



        /// <summary>
        /// AttitudeCount measures how frustrated a driver is based on traffic conditions.
        /// If traffic is slowing them down, the AttitudeCount is incremented. If not, AttitudeCount
        /// is decremented. This will be run every second.
        /// </summary>
        /// <param name="velocityDifference">The difference between a driver's desired velocity and actual velocity</param>
        public void IncrementAttitudeCount(int velocityDifference)
        {
            //adjusted on 5mph increments
            if (velocityDifference == 0) //traffic is not impacting the driver, their attitude is slightly decremented
            {
                AttitudeCount--;
            }
            else if (velocityDifference >= -5) //going only 5mph slower than the driver wants to, slight attitude increment
            {
                AttitudeCount++;
            }
            else if (velocityDifference >= -10) //going 10mph slower, slightly more of an increment
            {
                AttitudeCount += 3;
            }
            else if (velocityDifference >= -15) //15mph slower, significant increment
            {
                AttitudeCount += 6;
            }
            else if (velocityDifference >= -20) //20 mph slower, large increment
            {
                AttitudeCount += 12;
            }
        }
    }
}
