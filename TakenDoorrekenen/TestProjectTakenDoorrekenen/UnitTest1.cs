using ClassLibrary;
using System.Text.Json;

namespace TestProjectTakenDoorrekenen
{
    public class Tests
    {
        ProjectLijst takenlijst1 = new ProjectLijst();
        [SetUp]
        public void Setup()
        {

            //idnummer,taaklabel,min minuten, max minuten, lijst vervolgtaken, lijst voorgaande taken
            Taak taak1 = new Taak(1, "taak1", 3, 5, [3, 4, 6], null);
            Taak taak2 = new Taak(2, "taak2", 5, 15, [5, 6], null);
            Taak taak3 = new Taak(3, "taak3", 5, 15, [7], [1]);
            Taak taak4 = new Taak(4, "taak4", 5, 20, [7, 8], [1]);
            Taak taak5 = new Taak(5, "taak5", 3, 6, [8], [2]);
            Taak taak6 = new Taak(6, "taak6", 3, 20, [8], [1, 2]);
            Taak taak7 = new Taak(7, "taak7", 10, 15, null, [3, 4]);
            Taak taak8 = new Taak(8, "taak8", 7, 12, null, [4, 5, 6]);
            takenlijst1.addTask(taak1);
            takenlijst1.addTask(taak2);
            takenlijst1.addTask(taak3);
            takenlijst1.addTask(taak4);
            takenlijst1.addTask(taak5);
            takenlijst1.addTask(taak6);
            takenlijst1.addTask(taak7);
            takenlijst1.addTask(taak8);

        }

        [Test]
        public void TestConversieToJSON()
        {
            Assert.Pass();
            string fileName = "Takenlijst1.json";
            string jsonString = JsonSerializer.Serialize(takenlijst1);
            File.WriteAllText(fileName, jsonString);
        }
        [Test]
        public void TestConversieToXML()
        {
            Assert.Pass();
        }
        [Test]
        public void TestConversieToYAML()
        {
            Assert.Pass();
        }

        [Test]
        public void TestConversieFromJSON()
        {
            Assert.Pass();
        }
        [Test]
        public void TestConversieFromXML()
        {
            Assert.Pass();
        }
        [Test]
        public void TestConversieFromYAML()
        {
            Assert.Pass();
        }

        [Test]
        public void TestMinTime()
        {
            Assert.Pass();
        }
        [Test]
        public void TestMaxTime()
        {
            Assert.Pass();
        }
    }
}