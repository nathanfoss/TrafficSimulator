using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{
    class AttitudeAssigner
    {
        public AttitudeAssigner()
        {

        }

        public Attitude AssignAttitude()
        {
            Normal normalDistribution = new Normal();
            double value = normalDistribution.Sample();
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
