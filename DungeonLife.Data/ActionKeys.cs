using System.Collections.Generic;
using System.Collections.ObjectModel;
using DungeonLife.Data.ActionsKeys;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DungeonLife.Data
{
    public class ActionKeys
    {

        public Tuple<Player,ObservableCollection<NPC>,ObservableCollection<Pet>> ExecuteActionKeys(List<string> keys, Player player, ObservableCollection<NPC> family, ObservableCollection<Pet> pets)
        {
            foreach (var key in keys)
                switch (key)
                {
                    case "LoseHappy":
                        new LoseHappy(player);
                        break;
                    case "GainHappy":
                        new GainHappy(player);
                        break;
                    case "GainPet":
                        pets = new GainPet().NewPet(pets);
                        break;
                    case "LosePet":
                        new LosePet(pets);
                        break;
                    case "GainSiblilng":
                        new GainSibling(family);
                        break;
                    case "LoseSibling":
                        new LoseSibling(family);
                        break;
                    case "ParentsGetJob":
                        new ParentGetJob(family);
                        break;
                    case "ParentsLoseJob":
                        new ParentLoseJob(family);
                        break;
                }

            return Tuple.Create(player, family, pets);
        }
    }
}
