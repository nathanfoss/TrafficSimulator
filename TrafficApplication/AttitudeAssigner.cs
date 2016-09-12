namespace TrafficApplication
{
    /// <summary>
    /// Extends Assigner base class. Supports random assignment of an attitude to a Driver object
    /// </summary>
    class AttitudeAssigner : Assigner
    {
        public AttitudeAssigner()
        {

        }

        /// <summary>
        /// Generates a normal distribution value and assigns an attitude based on the value.
        /// More moderate attitudes are more likely and extremes are less frequent.
        /// </summary>
        /// <returns></returns>
        public Attitude AssignAttitude()
        {
            double value = NormalDistributionValue();
            if (value < -1.64)
            {
                return Attitude.HAPPY; //5% of drivers
            }
            else if (value < -.63)
            {
                return Attitude.CALM; //~21% of drivers
            }
            else if (value < .63)
            {
                return Attitude.AVERAGE; //~47% of drivers
            }
            else if (value < .86)
            {
                return Attitude.NERVOUS; //~7% of drivers
            }
            else if (value < 1.64)
            {
                return Attitude.RUSHED; //15% of drivers
            }
            else
            {
                return Attitude.ROAD_RAGE; //~5% of drivers
            }
        }
    }
}
