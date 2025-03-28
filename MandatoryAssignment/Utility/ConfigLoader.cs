using MandatoryAssignment.AbstractModels;
using MandatoryAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MandatoryAssignment.Utility
{
    public abstract class ConfigLoader
    {
        protected ConfigLoader(string path)
        {
            _path = path;
        }
        protected string _path;
        public void LoadConfig(IWorld world)
        {
            if (!File.Exists(_path))
            {
                GameState.CurrentState.Logger.TraceEvent(TraceEventType.Error, 0, $"File at path {_path} not found, skipping loading config");
                return;
            }
            XmlDocument config = new XmlDocument();
            config.Load(_path);
            XmlNodeList? nodes = config.DocumentElement.SelectNodes("Config");
            if(nodes is null)
            {
                GameState.CurrentState.Logger.TraceEvent(TraceEventType.Warning, 0, $"File at path {_path} had no config entries found");
                return;
            }
            foreach(XmlNode node in nodes)
            {
                ProcessConfigItem(node, world);
            }
        }
        protected abstract void ProcessConfigItem(XmlNode node, IWorld world);
    }
}
