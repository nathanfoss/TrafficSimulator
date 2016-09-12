
namespace TrafficApplication
{
    /// <summary>
    /// Extends Assigner base class. Supports random assignment of Speed preferences based on normal distribution tables
    /// </summary>
    class SpeedAssigner : Assigner
    {
        public SpeedAssigner()
        {

        }

        /// <summary>
        /// Uses normal distribution with mean = 0 and standard deviation of 1 to randomly assign speed values.
        /// More moderate speeds are most common, more extreme values are less likely.
        /// </summary>
        /// <returns>Randomly assigned Enumerated value indicating Driver's speed preference</returns>
        public Speed AssignSpeed()
        {
            double value = NormalDistributionValue();
            if (value < -1.64)
            {
                return Speed.GRANDMA; //5% of drivers
            }
            else if (value < -.63)
            {
                return Speed.CAUTIOUS; //~21% of drivers
            }
            else if (value < .63)
            {
                return Speed.AVERAGE; //~47% of drivers
            }
            else if (value < 1.64)
            {
                return Speed.FAST; //~21% of drivers
            }
            else
            {
                return Speed.RACER; //5% of drivers
            }
        }
    }
}
