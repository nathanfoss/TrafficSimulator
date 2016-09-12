namespace TrafficApplication
{
    /// <summary>
    /// Extends Assigner base class. Randomly assigns vehicle types based off of a normal distribution table
    /// </summary>
    class TypeAssigner : Assigner
    {
        public TypeAssigner()
        {

        }

        /// <summary>
        /// Uses standard normal distribution to assign vehicle types randomly based off percentages of each
        /// type of vehicle registered in the U.S. (source wikipedia)
        /// </summary>
        /// <returns>The randomly assigned Enumerated vehicle Type value</returns>
        public Type AssignType()
        {
            double value = NormalDistributionValue();
            if (value < -2.33)
            {
                return Type.MOTORCYCLE; //1% of cars on the road
            }
            else if (value < -1)
            {
                return Type.SEMI; //15% of cars on the road
            }
            else if (value < -.47)
            {
                return Type.PICKUP; //~16% of cars on the road
            }
            else if (value < .47)
            {
                return Type.SEDAN; //~36% of cars on the road
            }
            else if (value < 1.05)
            {
                return Type.COMPACT; //19% of cars on the road
            }
            else
            {
                return Type.MINIVAN; //14% of cars on the road
            }
        }
    }
    
}
