using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{
    class PersonalityHandler
    {
        private int DrivingGap;


        public PersonalityHandler(PassingPersonality personality)
        {
            DrivingGap = SetDrivingGap(personality);
        }


        public int GetDrivingGap()
        {
            return DrivingGap;
        }


        private int SetDrivingGap(PassingPersonality personality)
        {
            int drivingGap = 350; //in case it doesn't get reassigned properly, assign it to the average distance

            switch (personality)
            {
                case PassingPersonality.TIMID:
                    {
                        drivingGap = 350; //Gap of 350
                        break;
                    }
                case PassingPersonality.CAUTIOUS:
                    {
                        drivingGap = 250; //Gap of 250 feet
                        break;
                    }
                case PassingPersonality.DEFENSIVE:
                    {
                        drivingGap = 165; //Gap of 165 feet
                        break;
                    }
                case PassingPersonality.AGGRESSIVE:
                    {
                        drivingGap = 90; //Gap of 90 feet
                        break;
                    }
                case PassingPersonality.JERK:
                    {
                        drivingGap = 25; //Gap of 25 feet
                        break;
                    }

            }

            return drivingGap;
        }
        
    }

    
}
