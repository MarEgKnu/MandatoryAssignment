using Microsoft.VisualStudio.TestTools.UnitTesting;
using MandatoryAssignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryAssignment.TestModels;
using MandatoryAssignment.AbstractModels;

namespace MandatoryAssignment.Utility.Tests
{
    [TestClass()]
    public class ConfigLoaderTests
    {
        private Logger logger;
        private ConfigLoader loader;
        private World testWorld;
        private GameState testGameState;
        [TestInitialize]
        public void SetUp()
        {
            logger = new Logger(new System.Diagnostics.TraceSource("[GAME]"));
            loader = new TestConfigLoader("/.testConfig.xml");
            testWorld = new TestWorld(0, 0);
            testGameState = new TestGameState(testWorld, loader, logger);

        }
        [TestMethod()]
        public void LoadConfigTest()
        {
            ConfigLoader loader = new TestConfigLoader(@"..\..\..\Utility\testConfig.xml");
            loader.LoadConfig(new TestWorld(0, 0));
        }
    }
}