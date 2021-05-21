using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DungeonLife.Data
{
    public class EventsImports
    {
        public List<Event> GoodEvents { get; set; }
        public List<Event> BadEvents { get; set; }


        public EventsImports ()
        {
            GoodEvents = XMLLoad("Good");
            BadEvents = XMLLoad("Bad");
        }


        private List<Event> XMLLoad(string file)
        {
            List<Event> output = new List<Event>();

            XmlDocument xdoc = LoadDocument(file);
            XmlNodeList input = xdoc.GetElementsByTagName("Events");

            foreach (XmlNode i in input)
            {

                string id = null;
                string events = null;
                string weight = null;
                string text = null;
                string ageGroups = null;
                List<string> keywords = new List<string>();
                List<string> actionKeys = new List<string>();

                foreach (XmlNode ii in i)
                {

                    switch (ii.Name)
                    {
                        case "ID":
                            id = ii.InnerText;
                            break;
                        case "Event":
                            events = ii.InnerText;
                            break;
                        case "Weight":
                            weight = ii.InnerText;
                            break;
                        case "Keyword":
                            keywords = ii.InnerText.Split(',').ToList();;
                            break;
                        case "Actionkeys":
                            actionKeys = ii.InnerText.Split(',').ToList(); ;
                            break;
                        case "Text":
                            text = ii.InnerText;
                            break;
                        case "AgeGroups":
                            ageGroups = ii.InnerText;
                            break;

                    }
                }

                if (id != null)
                {
                    output.Add(new Event(Int16.Parse(id), events, Int16.Parse(weight), keywords, actionKeys, text, ageGroups));
                }
            }

            return output;

        }


        private XmlDocument LoadDocument(string file)
        {
            XmlDocument xdoc = new XmlDocument();

            switch (file)
            {
                case "Good":
                    xdoc.LoadXml(Properties.Resources.EventsGood);
                    break;
                case "Bad":
                    xdoc.LoadXml(Properties.Resources.EventsBad);
                    break;
            }

            return xdoc;
        }
    }
}
