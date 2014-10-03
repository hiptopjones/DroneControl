using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DroneControl;

namespace UnitTests
{
    [TestClass]
    public class CommandTests
    {
        [TestInitialize]
        public void Initialize()
        {
            AtCommandBuilder builder = AtCommandBuilder.Instance;
            builder.ResetSequence();
        }

        [TestMethod]
        public void CreateAtCommand_SingleParameter_Matches()
        {
            AtCommandBuilder builder = AtCommandBuilder.Instance;
            string command = builder.CreateAtCommand("REF", "1234");

            Assert.AreEqual(command, "AT*REF=1,1234");
        }

        [TestMethod]
        public void CreateAtCommand_MultipleParameter_Matches()
        {
            AtCommandBuilder builder = AtCommandBuilder.Instance;
            string command = builder.CreateAtCommand("REF", "1234", "abcd");

            Assert.AreEqual(command, "AT*REF=1,1234,abcd");
        }


        [TestMethod]
        public void CreateAtCommand_MultipleCommands_SequenceIncreases()
        {
            AtCommandBuilder builder = AtCommandBuilder.Instance;
            builder.CreateAtCommand("REF", "1234");
            string command = builder.CreateAtCommand("REF", "1234");

            Assert.AreEqual(command, "AT*REF=2,1234");
        }
    }
}
