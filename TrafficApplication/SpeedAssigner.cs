using MathNet.Numerics.Distributions;

namespace TrafficApplication
{
    class SpeedAssigner : Assigner
    {
        public SpeedAssigner()
        {

        }

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
