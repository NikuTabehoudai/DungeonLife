using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLife.Data
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Text { get; set; }
        public string AgeGroup { get; set; }
        public List<string> Keywords { get; set; }
        public List<string> ActionKeys { get; set; }

        public Event(int id, string name, int weight, List<string> keywords, List<string> actionsKeys, string text, string ageGroup)
        {
            ID = id;
            Name = name;
            Weight = weight;
            Keywords = keywords;
            ActionKeys = actionsKeys;
            Text = text;
            AgeGroup = ageGroup;
        }
    }
}
