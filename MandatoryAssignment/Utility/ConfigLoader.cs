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
    /// <summary>
    /// An abstract class representing a configuration file loader, with a file path to where the config file should be loaded from
    /// </summary>
    public abstract class ConfigLoader
    {
        protected ConfigLoader(string path)
        {
            _path = path;
        }
        protected string _path;
        /// <summary>
        /// Reads the config file one node at a time, and applies it to the given IWorld object.
        /// The implementation of how each node is processed is left for sublcasses to implement.
        /// </summary>
        /// <param name="state">The IWorld object to apply the configurations to</param>
        public void LoadConfig(IGameState state)
        {
            if (!File.Exists(_path))
            {
                GameState.CurrentState.Logger.TraceEvent(TraceEventType.Error, 0, $"File at path {_path} not found, skipping loading config");
                return;
            }
            XmlDocument config = new XmlDocument();
            config.Load(_path);
            XmlNodeList? nodes = config.DocumentElement.ChildNodes;
            if(nodes is null)
            {
                GameState.CurrentState.Logger.TraceEvent(TraceEventType.Warning, 0, $"File at path {_path} had no config entries found");
                return;
            }
            foreach(XmlNode node in nodes)
            {
                ProcessConfigItem(node, state);
            }
        }
        /// <summary>
        /// Processes a single Xml node into the IWorld object. Needs to be implemented in conrete derived classes
        /// </summary>
        /// <param name="node">The node being processed</param>
        /// <param name="world">The IWorld object to apply changes to</param>
        protected abstract void ProcessConfigItem(XmlNode node, IGameState state);
    }
}
