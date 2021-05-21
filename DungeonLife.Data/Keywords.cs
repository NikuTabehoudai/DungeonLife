using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DungeonLife.Data
{
    public class Keywords
    {
        public bool Parents { get; set; }
        public bool Siblings { get; set; }
        public bool Pets { get; set; }
        public bool ParentsJob { get; set; }

        public List<string> RetreiveKeywords()
        {
            var output = new List<string>();

            if (Parents) output.Add("Parents");
            if (Siblings) output.Add("Siblings");
            if (Pets) output.Add("Pets");
            if (ParentsJob) output.Add("ParentsJob");

            return output;
        }

        public void TestParents(ObservableCollection<NPC> fam)
        {
            Parents = false;
            if (fam.Count != 0)
                if (fam[0].Relation == "Father" || fam[0].Relation == "Mother")
                {
                    if (fam[0].Status == "Alive")
                        Parents = true;
                    else if (fam.Count != 1)
                        if (fam[1].Relation == "Father" || fam[1].Relation == "Mother")
                            if (fam[1].Status == "Alive")
                                Parents = true;
                }
        }

        public void TestSiblings(ObservableCollection<NPC> fam)
        {
            Siblings = false;
            if (fam.Count != 0)
                foreach (var item in fam)
                {
                        if (item.Status == "Alive")
                            Siblings = true;
                }
        }

        public void TestPets(ObservableCollection<Pet> pets)
        {
            Pets = false;
            if (pets.Count != 0)
                foreach (var item in pets)
                    if (item.Status == "Alive")
                        Pets = true;
        }


        public void TestParentsJob(ObservableCollection<NPC> fam)
        {
            ParentsJob = false;
            if (fam.Count != 0)
                if (fam[0].Relation == "Father" || fam[0].Relation == "Mother")
                    if (fam[0].Occupation != "None")
                        ParentsJob = true;
                    else if (fam[1].Relation == "Father" || fam[1].Relation == "Mother")
                        if (fam[1].Occupation != "None")
                            ParentsJob = true;
        }
    }
}
