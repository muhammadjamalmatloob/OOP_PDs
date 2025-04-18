using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Ship
    {
        private string serialNumber;
        private Angle latitude;
        private Angle longitude;

        
        public Ship(string serial, Angle lat, Angle lon)
        {
            serialNumber = serial;
            latitude = lat;
            longitude = lon;
        }

       
        public void DisplayPosition()
        {
            Console.WriteLine($"Ship is at {latitude.DisplayAngle()} and {longitude.DisplayAngle()}");
        }

        
        public void DisplaySerialNumber()
        {
            Console.WriteLine($"Ship's serial number is {serialNumber}");
        }

        
        public void ChangePosition(Action<string> prompt, Func<string> input)
        {
            prompt("Enter Ship Latitude:");
            int latDeg = int.Parse(input());
            float latMin = float.Parse(input());
            char latDir = char.Parse(input());

            prompt("Enter Ship Longitude:");
            int lonDeg = int.Parse(input());
            float lonMin = float.Parse(input());
            char lonDir = char.Parse(input());

            latitude.SetAngle(latDeg, latMin, latDir);
            longitude.SetAngle(lonDeg, lonMin, lonDir);
        }

        
        public string GetSerialNumber() => serialNumber;
        public Angle GetLatitude() => latitude;
        public Angle GetLongitude() => longitude;
    }
}
