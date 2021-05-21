using DungeonLife.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLife.Data
{
    public class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        private int _maxAge { get; set; }
        private List<string> _types = new List<string>() { "Dog", "Cat", "Crodile", "Aligator", "Squirl", "Chipmunk", "Wolf", "DireWolf", "Phanter", "Lynx", "Fearie Dragon", "Horse"}; 

        public Pet()
        {
            BasicPetInfo();
        }

        public Pet(string type)
        {
            BasicPetInfo();
            Type = type;
        }


        private void BasicPetInfo()
        {
            var names = new NamesImport();
            Name = names.GetRandomPet();
            Type = _types[RandomInt.GetRandom(0, _types.Count -1)];
            _maxAge = RandomInt.GetRandom(10, 20);
            Age = RandomInt.GetRandom(0, _maxAge -1);
            Status = "Alive";
        }

    }
}
