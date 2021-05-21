using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DungeonLife.Utilities;

namespace DungeonLife.Data.Imports
{
    public class OccupationsImport
    {
        public List<string> Jobs { get; set; }

        public OccupationsImport()
        {
            Jobs = XMLLoad("Jobs");
        }


        private List<string> XMLLoad(string group)
        {
            List<string> output = new List<string>();

            XmlDocument xdoc = new XmlDocument();

            xdoc.LoadXml(Properties.Resources.Occupations);


            XmlNodeList input = xdoc.GetElementsByTagName(group);

            foreach (XmlNode i in input)
                foreach (XmlNode ii in i)
                {
                    if (ii.Name == "Occupation")
                    {
                        output.Add(ii.InnerText);
                    }
                }

            return output;
        }

        public string GetRandomJob()
        {
            return Jobs[RandomInt.GetRandom(0, Jobs.Count -1)];
        }
    }
}



