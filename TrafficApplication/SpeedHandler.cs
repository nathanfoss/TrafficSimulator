
namespace TrafficApplication
{
    /// <summary>
    /// SpeedHandler class reads Enumerated Speed value and sets an Driver velocity adjustment.
    /// </summary>
    class SpeedHandler
    {
        private int SpeedAdjust;

        /// <summary>
        /// SpeedHandler Constructor that uses SetSpeedAdjust method to assign a velocity adjustment
        /// </summary>
        /// <param name="speed">Enumerated Speed value indicating Driver speed preference</param>
        public SpeedHandler(Speed speed)
        {
            SpeedAdjust = SetSpeedAdjust(speed);
        }

        /// <summary>
        /// Retrieves the velocity adjustment assigned by Driver speed preference
        /// </summary>
        /// <returns>The positive or negative adjustment from the posted speed limit in mph</returns>
        public int GetSpeedAdjust()
        {
            return SpeedAdjust;
        }

        /// <summary>
        /// Sets the Speed Adjustment compared to posted speed limit based off Enumerated Speed values.
        /// </summary>
        /// <param name="speed">Enumerated Speed value indicating Driver speed preference</param>
        /// <returns>The positive or negative speed adjustment in mph compared to posted speed limit</returns>
        private int SetSpeedAdjust(Speed speed)
        {
            int speedAdjust = 5; //defaults to drivers driving the speed Limit +5mph

            switch (speed)
            {
                case Speed.GRANDMA:
                    {
                        speedAdjust = -5; //Grandma drives 5mph BELOW the posted speed limit
                        break;
                    }
                case Speed.CAUTIOUS:
                    {
                        speedAdjust = 0; //Cautious drivers drive the speed limit
                        break;
                    }
                case Speed.AVERAGE:
                    {
                        speedAdjust = 5; //Average drivers drive 5mph ABOVE the speed limit
                        break;
                    }
                case Speed.FAST:
                    {
                        speedAdjust = 10; //Fast drivers drive 10mph ABOVE the speed limit
                        break;
                    }
                case Speed.RACER:
                    {
                        speedAdjust = 15; //Crazy drivers drive 15mph ABOVE the speed limit
                        break;
                    }
            }
            return speedAdjust;
        }
    }
}
