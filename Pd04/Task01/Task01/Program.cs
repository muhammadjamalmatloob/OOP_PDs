using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static List<Ship> ships = new List<Ship>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Ship");
                Console.WriteLine("2. View Ship Position");
                Console.WriteLine("3. View Ship Serial Number");
                Console.WriteLine("4. Change Ship Position");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddShip();
                        break;
                    case "2":
                        ViewShipPosition();
                        break;
                    case "3":
                        ViewShipSerialNumber();
                        break;
                    case "4":
                        ChangeShipPosition();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddShip()
        {
            Console.Write("Enter Ship Number: ");
            string serial = Console.ReadLine();

            Console.WriteLine("Enter Ship Latitude:");
            Console.Write("Enter Latitude's Degree: ");
            int latDeg = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Minute: ");
            float latMin = float.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction: ");
            char latDir = char.Parse(Console.ReadLine().ToUpper());

            Console.WriteLine("Enter Ship Longitude:");
            Console.Write("Enter Longitude's Degree: ");
            int lonDeg = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Minute: ");
            float lonMin = float.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Direction: ");
            char lonDir = char.Parse(Console.ReadLine().ToUpper());

            Angle latitude = new Angle(latDeg, latMin, latDir);
            Angle longitude = new Angle(lonDeg, lonMin, lonDir);

            ships.Add(new Ship(serial, latitude, longitude));
            Console.WriteLine("Ship added successfully.");
        }

        static void ViewShipPosition()
        {
            Console.Write("Enter Ship Serial Number to find its position: ");
            string serial = Console.ReadLine();

            Ship ship = ships.Find(s => s.GetSerialNumber() == serial);
            if (ship != null)
            {
                ship.DisplayPosition();
            }
            else
            {
                Console.WriteLine("Ship not found.");
            }
        }

        static void ViewShipSerialNumber()
        {
            Console.WriteLine("Enter the ship latitude (format: 149°34.8' W): ");
            string latStr = Console.ReadLine();
            Console.WriteLine("Enter the ship longitude (format: 17°31.5' S): ");
            string lonStr = Console.ReadLine();

            
            var latParts = latStr.Split(new[] { '°', '\'', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var lonParts = lonStr.Split(new[] { '°', '\'', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int latDeg = int.Parse(latParts[0]);
            float latMin = float.Parse(latParts[1]);
            char latDir = char.Parse(latParts[2]);

            int lonDeg = int.Parse(lonParts[0]);
            float lonMin = float.Parse(lonParts[1]);
            char lonDir = char.Parse(lonParts[2]);

            Ship ship = ships.Find(s =>
                s.GetLatitude().GetDegrees() == latDeg &&
                s.GetLatitude().GetMinutes() == latMin &&
                s.GetLatitude().GetDirection() == latDir &&
                s.GetLongitude().GetDegrees() == lonDeg &&
                s.GetLongitude().GetMinutes() == lonMin &&
                s.GetLongitude().GetDirection() == lonDir);

            if (ship != null)
            {
                ship.DisplaySerialNumber();
            }
            else
            {
                Console.WriteLine("Ship not found.");
            }
        }

        static void ChangeShipPosition()
        {
            Console.Write("Enter Ship's serial number whose position you want to change: ");
            string serial = Console.ReadLine();

            Ship ship = ships.Find(s => s.GetSerialNumber() == serial);
            if (ship != null)
            {
                ship.ChangePosition(
                    prompt: msg => Console.WriteLine(msg),
                    input: () => Console.ReadLine()
                );
                Console.WriteLine("Position updated successfully.");
            }
            else
            {
                Console.WriteLine("Ship not found.");
            }
        }
    }
}
