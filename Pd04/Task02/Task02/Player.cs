using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class Player
    {
        public string Name { get; private set; }
        public double Hp { get; private set; }
        public double MaxHp { get; }
        public double Energy { get; private set; }
        public double MaxEnergy { get; }
        public double Armor { get; private set; }
        private Stats SkillStatistics { get; set; }

        public Player(string name, double health, double energy, double armor)
        {
            Name = name;
            MaxHp = health;
            Hp = health;
            MaxEnergy = energy;
            Energy = energy;
            Armor = armor;
        }

        public void UpdateHealth(double amount)
        {
            Hp += amount;

            if (Hp < 0)
                Hp = 0;
            else if (Hp > MaxHp)
                Hp = MaxHp;
        }

        public void UpdateEnergy(double amount)
        {
            Energy += amount;

            if (Energy < 0)
                Energy = 0;
            else if (Energy > MaxEnergy)
                Energy = MaxEnergy;
        }

        public void UpdateArmor(double amount)
        {
            Armor = Math.Max(0, amount); 
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void LearnSkill(Stats skillStats)
        {
            SkillStatistics = skillStats;
        }

        public string Attack(Player target)
        {
            if (SkillStatistics == null)
                return $"{Name} doesn't know any skills yet!";

            if (Energy < SkillStatistics.Cost)
            {
                return $"{Name} attempted to use {SkillStatistics.Name}, but didn't have enough energy!";
            }

           
            UpdateEnergy(-SkillStatistics.Cost);


            double effectiveArmor = target.Armor - SkillStatistics.Penetration;
            if (effectiveArmor < 0)
                effectiveArmor = 0;
            else if (effectiveArmor > 100)
                effectiveArmor = 100;

            
            double damageMultiplier = (100 - effectiveArmor) / 100;
            double damageDealt = SkillStatistics.Damage * damageMultiplier;

            
            target.UpdateHealth(-damageDealt);

            
            string result = $"{Name} used {SkillStatistics.Name}, {SkillStatistics.Description}, against {target.Name}, doing {damageDealt:F2} damage!";

            
            if (SkillStatistics.Heal > 0)
            {
                UpdateHealth(SkillStatistics.Heal);
                result += $" {Name} healed for {SkillStatistics.Heal} health!";
            }

            
            if (target.Hp <= 0)
            {
                result += $" {target.Name} died.";
            }
            else
            {
                double healthPercentage = (target.Hp / target.MaxHp) * 100;
                result += $" {target.Name} is at {healthPercentage:F2}% health.";
            }

            return result;
        }
    }
}
