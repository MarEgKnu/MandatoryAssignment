using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Structs;
using MandatoryAssignment.Utility;
using SampleFrameworkUse.Difficulties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SampleFrameworkUse.Utility
{
    
    public class SampleConfigLoader : ConfigLoader
    {

        private IDifficulty defaultDifficulty = NormalDifficulty.Instance;
        public SampleConfigLoader(string path) : base(path)
        {
        }

        protected override void ProcessConfigItem(XmlNode node, IGameState state)
        {
            switch(node.Name.ToLower())
            {
                case "selected-difficulty":
                    ParseSelectedDifficulty(node, state);
                    break;
                case "tracelisteners":
                    ParseTraceListeners(node, state);
                    break;
                case "maxy":
                    ParseMaxY(node, state);
                    break;
                case "maxx":
                    ParseMaxX(node, state);
                    break;
                default:
                    state.Logger.TraceEvent(TraceEventType.Warning, 0, $"Unknown top level node with name {node.Name}, skipping");
                    break;


            }
        }
        //private void ParseSelectableDifficulties(XmlNode node, IGameState state)
        //{
        //    if (node.ChildNodes.Count > 0)
        //    {
        //        foreach (XmlNode subNode in node.ChildNodes)
        //        {
        //            if (_selectableDifficulties.TryGetValue(subNode.InnerText, out IDifficulty diff))
        //            {
        //                state.World.SelectableDifficulties.Add(diff.Name, diff);
        //            }
        //            else
        //            {
        //                state.Logger.TraceEvent(TraceEventType.Warning, 0, $"Difficulty entry {node.InnerText} is not a valid difficulty, skipping");
        //            }
        //        }
        //    }
        //}
        private void ParseSelectedDifficulty(XmlNode node, IGameState state)
        {
            IDifficulty? selected = state.World.SelectableDifficulties.Read(node.InnerText);
            if (selected != null)
            {
                state.World.SelectedDifficulty = selected;
            }
            else
            {
                state.Logger.TraceEvent(TraceEventType.Warning, 0, $"Selected difficulty entry {node.InnerText} is not a valid difficulty, using default");
            }
        }
        private void ParseTraceListeners(XmlNode node, IGameState state)
        {
            if (node.ChildNodes.Count > 0)
            {
                foreach (XmlNode subNode in node.ChildNodes)
                {
                    if(subNode.Name.ToLower() == "tracelistener" && subNode.ChildNodes.Count > 0)
                    {
                        ParseSingleListener(subNode, state);
                    }
                    else
                    {
                        state.Logger.TraceEvent(TraceEventType.Warning, 0, $"Invalid TraceListener node {subNode.InnerText}, skipping");
                    }
                }
            }
        }
        private void ParseSingleListener(XmlNode listenerNode, IGameState state)
        {
            switch(listenerNode.InnerText.ToLower())
            {
                case "console":
                    state.Logger.AddListener(new ConsoleTraceListener());
                    break;
                case "logfile":
                    Stream file = File.OpenWrite(@".\traceLog.txt");
                    state.Logger.AddListener(new TextWriterTraceListener(file));
                    break;
            }
        }
        private void ParseMaxY(XmlNode node, IGameState state)
        {
            if (int.TryParse( node.InnerText, out int result) && result > 0 )
            {
                state.World.MaxY = result;
            }
            else
            {
                state.Logger.TraceEvent(TraceEventType.Error, 0, $"Max Y node {node.InnerText} was invalid, using defaults");
            }
        }
        private void ParseMaxX(XmlNode node, IGameState state)
        {
            if (int.TryParse(node.InnerText, out int result) && result > 0)
            {
                state.World.MaxX = result;
            }
            else
            {
                state.Logger.TraceEvent(TraceEventType.Error, 0, $"Max X node {node.InnerText} was invalid, using defaults");
            }
        }
    }
}
