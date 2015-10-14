using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
https://sites.google.com/site/tddproblems/all-problems-1/Console-interaction
+ KataConsole
   Console und Testing war interessant
   ObjectOrientierung (Collaborators)
   State machine
   Erweiterung zu unterschiedliche Shapes möglich

+ häufiger Wechsel bei Dojo selber super
*/


namespace Tests
{
    using System;

    using ConsoleApplication;

    // *** TODO LIST
    // Richtige Berechnung von Rectangle
    // Richtige Berechnung von Circle
    // Berechnungsklassen für Shapes
    // Shape fragt was es braucht? (Questions Answers model)
    // Error Input values

    [TestClass]
    public class UiSpecifications
    {
        [TestMethod]
        public void WriteOnAdapter_SetsCurrentLine()
        {
            var adapter = new ConsoleAdapter();
            adapter.Write("Shape: (C)ircle or (R)ectangle?");
            Assert.AreEqual("Shape: (C)ircle or (R)ectangle?", adapter.CurrentLine); 
        }

        [TestMethod]
        public void ForTheFirstTime_PrintsInitialQuestion()
        {
            var consoleAdapter = new ConsoleAdapter();
            var ui = new UI(consoleAdapter);
            ui.Process();
            Assert.AreEqual("Shape: (C)ircle or (R)ectangle?", consoleAdapter.CurrentLine);
        }

        [TestMethod]
        public void AfterUserHasAnsweredR_PrintsFirstRectangleQuestion()
        {
            var consoleAdapter = new ConsoleAdapter();
            var ui = new UI(consoleAdapter);
            ui.Process();
            consoleAdapter.UserInput = "R";
            ui.Process();
            Assert.AreEqual("Rectangle side A length?", consoleAdapter.CurrentLine);
        }

        [TestMethod]
        public void AfterUserHasAnsweredC_PrintsCircleQuestion()
        {
            var consoleAdapter = new ConsoleAdapter();
            var ui = new UI(consoleAdapter);
            ui.Process();
            consoleAdapter.UserInput = "C";
            ui.Process();
            Assert.AreEqual("Circle radius?", consoleAdapter.CurrentLine);
        }

        [TestMethod]
        public void ForTheFirstTime_ReturnsTrue()
        {
            var consoleAdapter = new ConsoleAdapter();
            var ui = new UI(consoleAdapter);
            var result = ui.Process();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AfterUserHasAnsweredCAndThen1_PrintsPi()
        {
            var consoleAdapter = new ConsoleAdapter();
            var ui = new UI(consoleAdapter);
            ui.Process();
            consoleAdapter.UserInput = "C";
            ui.Process();
            consoleAdapter.UserInput = "1";
            ui.Process();
            Assert.AreEqual($"{Math.PI}", consoleAdapter.CurrentLine);
        }

        [TestMethod]
        public void AfterUserHasAnsweredRAndThen1_PrintsNextRectangleQuestion()
        {
            var consoleAdapter = new ConsoleAdapter();
            var ui = new UI(consoleAdapter);
            ui.Process();
            consoleAdapter.UserInput = "R";
            ui.Process();
            consoleAdapter.UserInput = "1";
            ui.Process();
            Assert.AreEqual("Rectangle side B length?", consoleAdapter.CurrentLine);
        }

        [TestMethod]
        public void AfterUserHasAnsweredRAndThen1_aPrintsNextRectangleQuestion()
        {
            var consoleAdapter = new ConsoleAdapter();
            var ui = new UI(consoleAdapter);
            ui.Process();
            consoleAdapter.UserInput = "R";
            ui.Process();
            consoleAdapter.UserInput = "1";
            ui.Process();
            consoleAdapter.UserInput = "1";
            ui.Process();
            Assert.AreEqual("1", consoleAdapter.CurrentLine);
        }

    }

}
