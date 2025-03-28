using MandatoryAssignment.Interfaces;
using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MandatoryAssignment.TestModels
{
    public class TestConfigLoader : ConfigLoader
    {
        public TestConfigLoader(string path) : base(path)
        {
        }

        protected override void ProcessConfigItem(XmlNode node, IWorld world)
        {
            Console.WriteLine(node.Name + " " + node.Value);
        }
    }
}
