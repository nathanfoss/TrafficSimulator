namespace TrafficApplication
{
    class AttitudeHandler
    {
        private int SpeedAdjust;
        private int PersonalityAdjust;
        //Positive emotions make people better drivers, negative emotions make people more dangerous
        //Adverse traffic conditions make people angrier

        public AttitudeHandler(Attitude attitude)
        {
            setAdjustments(attitude);
        }

        public int GetSpeedAdjust()
        {
            return SpeedAdjust;
        }

        public int GetPersonalityAdjust()
        {
            return PersonalityAdjust;
        }

        private void setAdjustments(Attitude attitude)
        {
            switch (attitude)
            {
                case Attitude.HAPPY:
                    {
                        SpeedAdjust = -2;
                        PersonalityAdjust = -2;
                        break;
                    }
                case Attitude.CALM:
                    {
                        SpeedAdjust = -1;
                        PersonalityAdjust = -1;
                        break;
                    }
                case Attitude.AVERAGE:
                    {
                        SpeedAdjust = 0;
                        PersonalityAdjust = 0;
                        break;
                    }
                case Attitude.NERVOUS:
                    {
                        SpeedAdjust = 1;
                        PersonalityAdjust = 1;
                        break;
                    }
                case Attitude.RUSHED:
                    {
                        SpeedAdjust = 2;
                        PersonalityAdjust = 2;
                        break;
                    }
                case Attitude.ROAD_RAGE:
                    {
                        SpeedAdjust = 3;
                        PersonalityAdjust = 3;
                        break;
                    }
            }
        }
    }
}
