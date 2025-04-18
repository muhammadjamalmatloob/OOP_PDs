using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    class MountainBike : Bicycle
    {
        private int seatHeight;
        MountainBike(int seatHeight,int cadence, int gear, int speed) : base(cadence, gear, speed)
        {
            this.seatHeight = seatHeight;
            this.cadence = cadence;
            this.gear = gear;
            this.speed = speed;
        }
        public void setSeatHeight(int seatHeight)
        {
            this.seatHeight = seatHeight;
        }
    }
}
