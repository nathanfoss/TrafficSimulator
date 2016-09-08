using MathNet.Numerics.Distributions;


namespace TrafficApplication
{
    class Assigner
    {

        public Assigner() { }

        public double NormalDistributionValue()
        {
            Normal normalDistribution = new Normal();
            double value = normalDistribution.Sample();
            return value;
        }
        
    }
}
