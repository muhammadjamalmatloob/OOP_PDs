using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class Stats
    {
        public string Name { get; }
        public double Damage { get; }
        public string Description { get; }
        public double Penetration { get; }
        public double Cost { get; }
        public double Heal { get; }

        public Stats(string name, double damage, double penetration, double heal, double cost, string description)
        {
            Name = name;
            Damage = damage;
            Penetration = penetration;
            Heal = heal;
            Cost = cost;
            Description = description;
        }
    }
}
