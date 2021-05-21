using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLife.Utilities;

namespace DungeonLife.Data
{
    abstract public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string Status { get; set; }
        public string Occupation { get; set; }

        public Person()
        {
            var names = new NamesImport();

            Sex = RandomSex();
            Race = "Human";

            if (Sex == "Male")
                FirstName = names.GetRandomMFirst();
            else
                FirstName = names.GetRandomFFirst();

            LastName = names.GetRandomLast();
            FullName = FirstName + " " + LastName;

            Status = "Alive";
            Occupation = "Unemplyed";
        }

        private string RandomSex()
        {
            int r = RandomInt.GetRandom(0,1);

            if (r == 0)
            {
                return "Male";
            }

            return "Female";

        }

        public void AgeUp()
        {
            Age++;
        }

        private void SetName()
        {

        }
    }
}
