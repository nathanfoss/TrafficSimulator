
namespace TrafficApplication
{
    /// <summary>
    /// Extends Assigner base class. Supports assigning Driver personalities using normal distributions
    /// </summary>
    class PersonalityAssigner : Assigner
    {

        public PersonalityAssigner()
        {

        }

        /// <summary>
        /// Assigns a personality to a Driver based on a normal distribution with mean = 0 and standard deviation
        /// = 1. More extreme values are less likely while defensive drivers are most likely.
        /// </summary>
        /// <returns></returns>
        public PassingPersonality AssignPersonality()
        {
            double value = NormalDistributionValue();
            if (value < -1.64)
            {
                return PassingPersonality.TIMID; //5% of drivers
            }
            else if (value < -.63)
            {
                return PassingPersonality.CAUTIOUS; //~21% of drivers
            }
            else if (value < .63)
            {
                return PassingPersonality.DEFENSIVE; //~47% of drivers
            }
            else if (value < 1.64)
            {
                return PassingPersonality.AGGRESSIVE; //~21% of drivers
            }
            else
            {
                return PassingPersonality.JERK; //5% of drivers
            }
        }
    }
}
