using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{
    class PersonalityHandler
    {
        private double RequiredMergingGap;


        public PersonalityHandler(PassingPersonality personality)
        {
            RequiredMergingGap = SetMergingDistance(personality);
        }


        public double GetMergingDistance()
        {
            return RequiredMergingGap;
        }


        private double SetMergingDistance(PassingPersonality personality)
        {
            double mergingGap = 0.0416667; //in case it doesn't get reassigned properly, assign it to the average distance

            switch (personality)
            {
                case PassingPersonality.TIMID:
                    {
                        mergingGap = 0.0719697; //Gap of 380 feet in miles
                        break;
                    }
                case PassingPersonality.CAUTIOUS:
                    {
                        mergingGap = 0.0568182; //Gap of 300 feet in miles
                        break;
                    }
                case PassingPersonality.DEFENSIVE:
                    {
                        mergingGap = 0.0416667; //Gap of 220 feet in miles
                        break;
                    }
                case PassingPersonality.AGGRESSIVE:
                    {
                        mergingGap = 0.0265152; //Gap of 140 feet in miles
                        break;
                    }
                case PassingPersonality.JERK:
                    {
                        mergingGap = 0.0113636; //Gap of 60 feet in miles
                        break;
                    }

            }

            return mergingGap; ;
        }
        
    }

    
}
