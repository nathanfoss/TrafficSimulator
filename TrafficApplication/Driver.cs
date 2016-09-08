using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{

    class Driver
    {
        private PassingPersonality Personality;
        private Speed Speed;
        private Attitude Attitude;
        private bool LeftLaneOnly;
        private bool SpeedFluctuates;

        public Driver(PassingPersonality personality, Speed speed, Attitude attitude, bool leftLaneOnly = false, bool speedFluctuates = false)
        {
            Personality = personality;
            Speed = speed;
            Attitude = attitude;
            LeftLaneOnly = leftLaneOnly;
            SpeedFluctuates = speedFluctuates;
        }

        public Speed GetSpeed()
        {
            return Speed;
        }

        public PassingPersonality GetPersonality()
        {
            return Personality;
        }

        public Attitude GetAttitude()
        {
            return Attitude;
        }

        public void SetPersonality(PassingPersonality personality)
        {
            Personality = personality;
        }

        public void SetSpeed(Speed speed)
        {
            Speed = speed;
        }

        public void SetAttitude(Attitude attitude)
        {
            Attitude = attitude;
        }
    }
}
