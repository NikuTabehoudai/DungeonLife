using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DungeonLife.Utilities;


namespace DungeonLife.Data
{
    public class NamesImport
    {
        private List<string> _maleNames { get; set; }
        private List<string> _femaleNames { get; set; }
        private List<string> _lastNames { get; set; }
        private List<string> _petNames { get; set; }

        public NamesImport()
        {
            _maleNames = XMLLoad("Male");
            _femaleNames = XMLLoad("Female");
            _lastNames = XMLLoad("Last");
            _petNames = XMLLoad("Pets");
        }

        private List<string> XMLLoad(string group)
        {
            List<string> output = new List<string>();

            XmlDocument xdoc = new XmlDocument();

            xdoc.LoadXml(Properties.Resources.Names);


            XmlNodeList input = xdoc.GetElementsByTagName(group);

            foreach (XmlNode i in input)
                foreach (XmlNode ii in i)
                {
                if (ii.Name == "Name")
                {
                    output.Add(ii.InnerText);
                }
                }

            return output;
        }

        public string GetRandomMFirst ()
        {
            return _maleNames[RandomInt.GetRandom(0, _maleNames.Count -1)];
        }

        public string GetRandomFFirst()
        {
            return _femaleNames[RandomInt.GetRandom(0, _femaleNames.Count - 1)];
        }

        public string GetRandomLast()
        {

            return _lastNames[RandomInt.GetRandom(0, _lastNames.Count - 1)];
        }

        public string GetRandomPet()
        {
            return _petNames[RandomInt.GetRandom(0, _petNames.Count - 1)];
        }

    }
}
