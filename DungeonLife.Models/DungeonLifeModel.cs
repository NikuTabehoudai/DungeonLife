using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DungeonLife.Data;
using DungeonLife.Utilities;
using DungeonLife.WeightedRandomizer;

namespace DungeonLife.Models
{
    public class DungeonLifeModel
    {

        public Player Player { get; set; }
        public ObservableCollection<NPC> Family { get; set; }
        public ObservableCollection<string> History {get; set;}
        public ObservableCollection<Pet> Pets { get; set; }
        
        public DungeonLifeModel()
        {
            Family = new ObservableCollection<NPC>();
            History = new ObservableCollection<string>();
            Pets = new ObservableCollection<Pet>();
            Player = new Player();
            CreateFamily();
        }

        public void EndTurn()
        {
            AgeUp();

        }

        private void CreateFamily()
        {
            IWeightedRandomizer<string> rmarriage = new DynamicWeightedRandomizer<string>();
            rmarriage.Add("FM", 94);
            rmarriage.Add("FF", 3);
            rmarriage.Add("MM", 3);

            IWeightedRandomizer<int> rparents = new DynamicWeightedRandomizer<int>();
            rparents.Add(2, 74);
            rparents.Add(1, 25);
            rparents.Add(0, 1);

            int parents = rparents.NextWithReplacement();
            int siblings = RandomInt.GetRandom(0, 5);
            string mtype;

            if (parents == 2)
                mtype = rmarriage.NextWithReplacement();
            else
                mtype = null;

            if (parents != 0)
                Player.Keywords.Parents = true;

            if (siblings != 0)
                Player.Keywords.Siblings = true;

            switch (parents)
            {
                case 2:
                    if (mtype == "FM")
                    {
                        Family.Add(new NPC(Family.Count, true, 0, null, Player.LastName));
                        if (Family[0].Sex == "Male")
                            Family.Add(new NPC(Family.Count, true, Family[0].Age, "Female", Player.LastName));
                        else
                            Family.Add(new NPC(Family.Count, true, Family[0].Age, "Male", Player.LastName));
                    }
                    else if (mtype == "FF")
                    {
                        Family.Add(new NPC(Family.Count, true, 0, "Female", Player.LastName));
                        Family.Add(new NPC(Family.Count, true, Family[0].Age, "female", Player.LastName));
                    }
                    else
                    {
                        Family.Add(new NPC(Family.Count, true, 0, "Male", Player.LastName));
                        Family.Add(new NPC(Family.Count, true, Family[0].Age, "Male", Player.LastName));
                    }
                    break;
                case 1:
                    Family.Add(new NPC(Family.Count, true, 0, null, Player.LastName));
                    break;
            }

            if (parents != 0)
            {
                for (int i = 0; i < siblings; i++)
                    Family.Add(new NPC(Family.Count, false, Family[Family.Count - 1].Age, null, Player.LastName));
            }
            else
            {
                var age = 10;
                for (int i = 1; i < siblings; i++)
                {
                    Family.Add(new NPC(Family.Count, false, age, null, Player.LastName));
                    age = Family[Family.Count - 1].Age;
                }
            }

            Player.Keywords.TestParents(Family);
            Player.Keywords.TestSiblings(Family);
            Player.Keywords.TestParentsJob(Family);
        }

        public void AddHistory(string add)
        {
            History.Add(add);
        }

        private void AgeUp()
        {
            Player.AgeUp();
            
            foreach (var item in Family)
            {
                item.AgeUp();
            }
        }

        private void CreatePet(string type)
        {
            if (type == null)
                Pets.Add(new Pet());
            else
                Pets.Add(new Pet(type));
        }

    }
}
