using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApplication
{

    class Driver
    {
        private PassingPersonality personality;
        private Speed speed;
        private Attitude attitude;
        private bool leftLaneOnly;
        private bool speedFluctuates;

        public Driver(PassingPersonality personality, Speed speed, Attitude attitude, bool leftLaneOnly = false, bool speedFluctuates = false)
        {
            this.personality = personality;
            this.speed = speed;
            this.attitude = attitude;
            this.leftLaneOnly = leftLaneOnly;
            this.speedFluctuates = speedFluctuates;
        }

        public Speed getSpeed()
        {
            return speed;
        }

        public PassingPersonality getPersonality()
        {
            return personality;
        }

        public Attitude getAttitude()
        {
            return attitude;
        }

        public void setPersonality(PassingPersonality personality)
        {
            this.personality = personality;
        }

        public void setSpeed(Speed speed)
        {
            this.speed = speed;
        }

        public void setAttitude(Attitude attitude)
        {
            this.attitude = attitude;
        }
    }
}
