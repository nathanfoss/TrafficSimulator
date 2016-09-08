using MathNet.Numerics.Distributions;


namespace TrafficApplication
{
    class PersonalityAssigner : Assigner
    {

        public PersonalityAssigner()
        {

        }

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
