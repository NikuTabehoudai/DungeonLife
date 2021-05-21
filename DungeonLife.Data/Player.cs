using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLife.Utilities;

namespace DungeonLife.Data
{
    public class Player : Person
    {

        public int Energie { get; set; }
        public int Health { get; set; }
        public List<string> Skills { get; set; }
        public int Gold { get; set; }
        public int Strenght { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Willpower { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public Keywords Keywords { get; set; }

        public Player()
        {
            Age = 0;
            Gold = 0;
            Energie = 100;
            Health = 100;

            Strenght = GenerateStat();
            Agility = GenerateStat();
            Constitution = GenerateStat();
            Willpower = GenerateStat();
            Intelligence = GenerateStat();
            Charisma = GenerateStat();

            Keywords = new Keywords();
        }

        public void ChangeEnergie(int amount, bool increase)
        {
            if (increase)
                Energie += amount;
            else
                Energie -= amount;
        }

        public void ChangeHealth(int amount, bool increase)
        {
            if (increase)
                Health += amount;
            else
                Health -= amount;
        }

        private int GenerateStat()
        {
            return RandomInt.GetRandom(1, 6) + RandomInt.GetRandom(1, 6) + RandomInt.GetRandom(1, 6);
        }


    }
}
