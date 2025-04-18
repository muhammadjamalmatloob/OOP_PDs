using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Angle
    {
        private int degrees;
        private float minutes;
        private char direction;

        
        public Angle(int deg, float min, char dir)
        {
            degrees = deg;
            minutes = min;
            direction = char.ToUpper(dir);
        }

        
        public void SetAngle(int deg, float min, char dir)
        {
            degrees = deg;
            minutes = min;
            direction = char.ToUpper(dir);
        }

        
        public string DisplayAngle()
        {
            return $"{degrees}\u00b0{minutes:0.0}' {direction}";
        }

        
        public int GetDegrees() => degrees;
        public float GetMinutes() => minutes;
        public char GetDirection() => direction;
    }
}
