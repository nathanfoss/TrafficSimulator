namespace TrafficApplication
{
    /// <summary>
    /// Turns attitude values into adjustments for each Driver's speed and personality
    /// </summary>
    class AttitudeHandler
    {
        private int SpeedAdjust;
        private int PersonalityAdjust;
        //Positive emotions make people better drivers, negative emotions make people more dangerous
        //Adverse traffic conditions make people angrier

        /// <summary>
        /// Constructor for the AttitudeHandler class. Uses the SetAdjustments method
        /// </summary>
        /// <param name="attitude">Enumerated attitude value for a specified Driver</param>
        public AttitudeHandler(Attitude attitude)
        {
            SetAdjustments(attitude);
        }

        /// <summary>
        /// Retrieves adjustments for a Driver's speed based on their attitude
        /// </summary>
        /// <returns>The effect of a Driver's speed on their attitude, negative is slower, positive is faster</returns>
        public int GetSpeedAdjust()
        {
            return SpeedAdjust;
        }

        /// <summary>
        /// Retrieves adjustments for a Driver's personality based on their attitude
        /// </summary>
        /// <returns>The effect of a Driver's personality on their attitude,
        /// negative is calmer, positive is more aggressive</returns>
        public int GetPersonalityAdjust()
        {
            return PersonalityAdjust;
        }

        /// <summary>
        /// Assigns personality and speed adjustments based on a Driver's attitude
        /// </summary>
        /// <param name="attitude">Enumerated attitude value of a specific Driver</param>
        private void SetAdjustments(Attitude attitude)
        {
            switch (attitude)
            {
                case Attitude.HAPPY:
                    {
                        SpeedAdjust = -2;
                        PersonalityAdjust = -2;
                        break;
                    }
                case Attitude.CALM:
                    {
                        SpeedAdjust = -1;
                        PersonalityAdjust = -1;
                        break;
                    }
                case Attitude.AVERAGE:
                    {
                        SpeedAdjust = 0;
                        PersonalityAdjust = 0;
                        break;
                    }
                case Attitude.NERVOUS:
                    {
                        SpeedAdjust = 1;
                        PersonalityAdjust = 1;
                        break;
                    }
                case Attitude.RUSHED:
                    {
                        SpeedAdjust = 2;
                        PersonalityAdjust = 2;
                        break;
                    }
                case Attitude.ROAD_RAGE:
                    {
                        SpeedAdjust = 3;
                        PersonalityAdjust = 3;
                        break;
                    }
            }
        }
    }
}
