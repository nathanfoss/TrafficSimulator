using MathNet.Numerics.Distributions;


namespace TrafficApplication
{
    /// <summary>
    /// Base class for the various assigner classes implementing Standard Normal Distributions for
    /// random assignment
    /// </summary>
    class Assigner
    {

        public Assigner() { }

        /// <summary>
        /// Creates a normal distribution with mean of 0 and standard deviation of 1 and returns a random value
        /// </summary>
        /// <returns>A random value according to the normal distribution table</returns>
        public double NormalDistributionValue()
        {
            Normal normalDistribution = new Normal();
            double value = normalDistribution.Sample();
            return value;
        }
        
    }
}
