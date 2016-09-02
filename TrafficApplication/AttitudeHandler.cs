using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{
    class AttitudeHandler
    {
        private int speedAdjust;
        private int personalityAdjust;
        //Positive emotions make people better drivers, negative emotions make people more dangerous
        //Adverse traffic conditions make people angrier

        public AttitudeHandler(Attitude attitude)
        {
            setAdjustments(attitude);
        }

        public int getSpeedAdjust()
        {
            return speedAdjust;
        }

        public int getPersonalityAdjust()
        {
            return personalityAdjust;
        }

        private void setAdjustments(Attitude attitude)
        {
            switch (attitude)
            {
                case Attitude.HAPPY:
                    {
                        speedAdjust = -2;
                        personalityAdjust = -2;
                        break;
                    }
                case Attitude.CALM:
                    {
                        speedAdjust = -1;
                        personalityAdjust = -1;
                        break;
                    }
                case Attitude.AVERAGE:
                    {
                        speedAdjust = 0;
                        personalityAdjust = 0;
                        break;
                    }
                case Attitude.NERVOUS:
                    {
                        speedAdjust = 1;
                        personalityAdjust = 1;
                        break;
                    }
                case Attitude.RUSHED:
                    {
                        speedAdjust = 2;
                        personalityAdjust = 2;
                        break;
                    }
                case Attitude.ROAD_RAGE:
                    {
                        speedAdjust = 3;
                        personalityAdjust = 3;
                        break;
                    }
            }
        }
    }
}
