using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLife.Data.ActionsKeys
{
    class GainPet
    {
        public ObservableCollection<Pet> NewPet(ObservableCollection<Pet> pets)
        {
            pets.Add(new Pet());
            return pets;

        }
    }
}
