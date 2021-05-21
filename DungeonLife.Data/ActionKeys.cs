using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLife.Data
{
    public class ActionKeys
    {

        public void ExecuteActionKeys(List<string> keys, Player player, ObservableCollection<NPC> family, ObservableCollection<Pet> pets)
        {
            foreach (var key in keys)
                switch (key)
                {
                    case "LoseHappy":
                        LoseHappy();
                        break;
                    case "GainHappy":
                        Gainhappy();
                        break;
                    case "GainPet":
                        GainPet();
                        break;
                    case "LosePet":
                        LosePet();
                        break;
                    case "GainSiblilng":
                        GainSiblilng();
                        break;
                    case "LoseSibling":
                        LoseSibling();
                        break;
                    case "ParentsGetJob":
                        ParentsGetJob();
                        break;
                    case "ParentsLoseJob":
                        ParentsLoseJob();
                        break;
                }
        }
        

        
        public void LoseHappy()
        {
            //lose happiness by X amount
        }

        public void Gainhappy ()
        {
            //gain happiness by x mount
        }
     
        public void GainPet ()
        {
            //Gain new pet
        }

        public void LosePet()
        {
            // Lose pet by Identifier
        }

        public void GainSiblilng()
        {
            // New NPC with Sibling constructor
        }

        public void LoseSibling ()
        {
            // Kill off sibling by Identifier.
        }

        public void ParentsLoseJob()
        {
            // A parents losses a job
        }

        public void ParentsGetJob()
        {
            // A parents gets a job.
        }

    }
}
