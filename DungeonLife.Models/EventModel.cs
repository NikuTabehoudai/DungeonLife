using DungeonLife.Data;
using DungeonLife.WeightedRandomizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonLife.Models
{
    public class EventModel
    {
        public EventsImports Events { get; set; }
        public ActionKeys ActionKey { get; set; }
        private IWeightedRandomizer<int> _AGoodEvents { get; set; } 
        private IWeightedRandomizer<int> _ABadEvents { get; set; } 
        private IWeightedRandomizer<string> _EventType { get; set; }

        public EventModel(List<string> keywords)
        {
            Events = new EventsImports();
            ActionKey = new ActionKeys();
            _AGoodEvents = new DynamicWeightedRandomizer<int>();
            _ABadEvents = new DynamicWeightedRandomizer<int>();
            _EventType = new DynamicWeightedRandomizer<string>();
            PopulateEvents(keywords);
            SetEventType();
        }

        public DungeonLifeModel SelectEvent(DungeonLifeModel dungeonLifeModel)
        {
            var type = _EventType.NextWithReplacement();

            switch (type)
            {
                case "Good":
                    dungeonLifeModel = ExecuteEvent(_AGoodEvents.NextWithReplacement(), type, dungeonLifeModel);
                    break;
                case "Bad":
                    dungeonLifeModel = ExecuteEvent(_ABadEvents.NextWithReplacement(), type, dungeonLifeModel);
                    break;
            }
            return dungeonLifeModel;
        }

        private DungeonLifeModel ExecuteEvent(int ID, string type, DungeonLifeModel dungeonLifeModel)
        {
            List<string> actionKeys = new List<string>();
            string text = null;

            switch (type)
            {
                case "Good":
                    actionKeys = Events.GoodEvents[ID - 1].ActionKeys;
                    text = Events.GoodEvents[ID - 1].Text;
                    break;
                case "Bad":
                    actionKeys = Events.BadEvents[ID - 1].ActionKeys;
                    text = Events.BadEvents[ID - 1].Text;
                    break;
            }

           var actionKeysReturn =  new ActionKeys().ExecuteActionKeys(actionKeys, dungeonLifeModel.Player, dungeonLifeModel.Family, dungeonLifeModel.Pets);
            dungeonLifeModel.History.Add(text);
            dungeonLifeModel.Player = actionKeysReturn.Item1;
            dungeonLifeModel.Family = actionKeysReturn.Item2;
            dungeonLifeModel.Pets = actionKeysReturn.Item3;
            return dungeonLifeModel;
        }

        public void PopulateEvents(List<string> keywords)
        {
            var eventID = Getevents(keywords, Events.GoodEvents).Distinct().ToList();

            foreach (var i in eventID)
            {
                foreach (var ii in Events.GoodEvents)
                {
                    if (ii.ID == i)
                        _AGoodEvents.Add(ii.ID, ii.Weight);
                }
            }

            eventID = Getevents(keywords, Events.BadEvents).Distinct().ToList();

            foreach (var i in eventID)
            {
                foreach (var ii in Events.GoodEvents)
                {
                    if (ii.ID == i)
                        _ABadEvents.Add(ii.ID, ii.Weight);
                }
            }

        }

        private void SetEventType()
        {
            _EventType.Add("Good", 10);
            _EventType.Add("Bad", 10);
        }

        private List<int> Getevents(List<string> keywords, List<Event> eventslist)
        {
            List<int> output = new List<int>();

            foreach (var keyword in keywords)
            {
                foreach (var events in eventslist)
                {
                    foreach (var ikeyword in events.Keywords)
                    {
                        if (ikeyword == keyword)
                            output.Add(events.ID);
                    }
                }
            }

            return output;
        }

    }
}
