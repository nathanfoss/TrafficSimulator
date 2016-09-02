using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{
    class SpeedHandler
    {
        private int speedAdjust;


        public SpeedHandler(Speed speed)
        {
            speedAdjust = setSpeedAdjust(speed);
        }


        public int getSpeedAdjust()
        {
            return speedAdjust;
        }


        private int setSpeedAdjust(Speed speed)
        {
            int speedAdjust = 5; //defaults to drivers driving the speed Limit +5mph

            switch (speed)
            {
                case Speed.GRANDMA:
                    {
                        speedAdjust = -5; //Grandma drives 5mph BELOW the posted speed limit
                        break;
                    }
                case Speed.CAUTIOUS:
                    {
                        speedAdjust = 0; //Cautious drivers drive the speed limit
                        break;
                    }
                case Speed.AVERAGE:
                    {
                        speedAdjust = 5; //Average drivers drive 5mph ABOVE the speed limit
                        break;
                    }
                case Speed.FAST:
                    {
                        speedAdjust = 10; //Fast drivers drive 10mph ABOVE the speed limit
                        break;
                    }
                case Speed.RACER:
                    {
                        speedAdjust = 15; //Crazy drivers drive 15mph ABOVE the speed limit
                        break;
                    }
            }
            return speedAdjust;
        }
    }
}
