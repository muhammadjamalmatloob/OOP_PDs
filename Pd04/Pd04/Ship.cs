using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pd04
{
    class Ship
    {
        public string SerialNumber;
        public Angle Latitude;
        public Angle Longitude;

        public Ship(string SerialNumber = null, Angle Latitude = null, Angle Longitude = null)
        {
            this.SerialNumber = SerialNumber;
            this.Latitude = new Angle(Latitude);
            this.Longitude = new Angle(Longitude);
        }

        public Ship(Ship ship)
        {
            ship.SerialNumber = SerialNumber;
            ship.Latitude = new Angle(Latitude);
            ship.Longitude = new Angle(Longitude);
        }

        public void PrintPosition()
        {
            Console.WriteLine("Longitude: " + this.Longitude);
            Console.WriteLine("Latitude: " + this.Latitude);
        }

        public void PrintSerialNumber()
        {
            Console.WriteLine("Serial Number: " + SerialNumber);
        }
    }
}
