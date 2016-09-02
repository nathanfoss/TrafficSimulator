using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{
    class TypeAssigner
    {
        public TypeAssigner()
        {

        }

        public Type AssignType()
        {
            Normal normalDistribution = new Normal();
            double value = normalDistribution.Sample();
            if (value < -2.33)
            {
                return Type.MOTORCYCLE; //1% of cars on the road
            }
            else if (value < -1.75)
            {
                return Type.SEMI; //3% of cars on the road
            }
            else if (value < -.84)
            {
                return Type.PICKUP; //~16% of cars on the road
            }
            else if (value < .26)
            {
                return Type.SEDAN; //~40% of cars on the road
            }
            else if (value < .88)
            {
                return Type.COMPACT; //21% of cars on the road
            }
            else
            {
                return Type.MINIVAN; //18% of cars on the road
            }
        }
    }
    
}
