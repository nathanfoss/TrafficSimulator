
namespace TrafficApplication
{
    /// <summary>
    /// Translates Driver Personality values into numerical values for driving behavior
    /// </summary>
    class PersonalityHandler
    {
        private int DrivingGap;

        /// <summary>
        /// Constructor for the PersonalityHandler class. Uses SetDrivingGap to assign a driving gap
        /// based on the Driver's personality
        /// </summary>
        /// <param name="personality">Enumerated PassingPersonality value indicating level of aggression</param>
        public PersonalityHandler(PassingPersonality personality)
        {
            SetDrivingGap(personality);
        }

        /// <summary>
        /// Retrieves the driving gap assigned by a Driver's Personality
        /// </summary>
        /// <returns>A Driver's comfortable following distance and required gap to change lanes in feet</returns>
        public int GetDrivingGap()
        {
            return DrivingGap;
        }

        /// <summary>
        /// Assigns the DrivingGap data member a value in feet based on the specified PassingPersonality
        /// </summary>
        /// <param name="personality">Enumerated PassingPersonality value indicating level of aggression</param>
        private void SetDrivingGap(PassingPersonality personality)
        {
            DrivingGap = 165; //in case it doesn't get reassigned properly, assign it to the average distance

            switch (personality)
            {
                case PassingPersonality.TIMID:
                    {
                        DrivingGap = 350; //Gap of 350 feet
                        break;
                    }
                case PassingPersonality.CAUTIOUS:
                    {
                        DrivingGap = 250; //Gap of 250 feet
                        break;
                    }
                case PassingPersonality.DEFENSIVE:
                    {
                        DrivingGap = 165; //Gap of 165 feet
                        break;
                    }
                case PassingPersonality.AGGRESSIVE:
                    {
                        DrivingGap = 90; //Gap of 90 feet
                        break;
                    }
                case PassingPersonality.JERK:
                    {
                        DrivingGap = 25; //Gap of 25 feet
                        break;
                    }
            }
        }
        
    }

    
}
