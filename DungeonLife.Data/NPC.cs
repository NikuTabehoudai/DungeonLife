using DungeonLife.Data.Imports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLife.Utilities;

namespace DungeonLife.Data
{
    public class NPC : Person   
    {
        private int ID { get; set; }
        public int Reputation { get; set; }
        public string Relation { get; set; }

        public NPC(int age)
        {
            BasicInfo();


            if (age == 0)
                Age = RandomInt.GetRandom(0, 80);
            else
                Age = RandomInt.GetRandom(age - 5, age + 5);

            if (Age <= 10)
                Occupation = "None";

        }

        public NPC(int id, bool parent, int age, string sex, string lname)
        {
            BasicInfo();
            ID = id;
            var names = new NamesImport();

            if (sex != null)
            {
                Sex = sex;

                if (sex == "Male")
                    FirstName = names.GetRandomMFirst();
                else
                    FirstName = names.GetRandomFFirst();
            }


            if (parent)
            {
                if (Sex == "Male")
                    Relation = "Father";
                else
                    Relation = "Mother";

                DeterminePAge(age);
            }
            else
            {
                Relation = "Sibling";
                DetermineSAge(parent, age) ;
            }

            LastName = lname;
            FullName = FirstName + " " + LastName;
            if (Age <= 10)
                Occupation = "None";


        }

        private void BasicInfo()
        {
            
            var jobs = new OccupationsImport();
            Occupation = jobs.GetRandomJob();
            Reputation = 0;
        }

        //Parent Age
        private void DeterminePAge(int age)
        {
            if (age == 0)
                Age = RandomInt.GetRandom(14, 50);
            else if (age - 10 <= 15)
                Age = RandomInt.GetRandom(14, age);
            else if (age == 14)
                Age = 14;
            else
                Age = RandomInt.GetRandom(age - 10, age);
        }

        //Sibling Age
        private void DetermineSAge(bool parent, int age)
        {
            if (parent == true)
                Age = RandomInt.GetRandom(0, age - 12);
            else
                if (age == 0)
                Age = 0;
            else
                Age = RandomInt.GetRandom(0, age);
        }
    }
}
