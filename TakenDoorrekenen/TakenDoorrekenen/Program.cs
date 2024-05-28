using ClassLibrary;
using System.Text.Json;

namespace TakenDoorrekenen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ProjectLijst takenlijst1 = new ProjectLijst("takenlijst1");
            ProjectLijst takenlijst2 = new ProjectLijst("takenlijst2");
            //idnummer,taaklabel,min minuten, max minuten, lijst vervolgtaken, lijst voorgaande taken
            Taak taak1 = new Taak(1, "taak1", 3, 5, [3, 4, 6],null);
            Taak taak2 = new Taak(2, "taak2", 5, 15, [5, 6],null);
            Taak taak3 = new Taak(3, "taak3", 5, 15, [7], [1]);
            Taak taak4 = new Taak(4, "taak4", 5, 20, [7, 8], [1]);
            Taak taak5 = new Taak(5, "taak5", 3, 6, [8], [2]);
            Taak taak6 = new Taak(6, "taak6", 3, 20, [8], [1,2]);
            Taak taak7 = new Taak(7, "taak7", 10, 15, null, [3,4]);
            Taak taak8 = new Taak(8, "taak8", 7, 12, null, [4,5,6]);
            takenlijst1.addTask(taak1);
            takenlijst1.addTask(taak2);
            takenlijst1.addTask(taak3);
            takenlijst1.addTask(taak4);
            takenlijst1.addTask(taak5);
            takenlijst1.addTask(taak6);
            takenlijst1.addTask(taak7);
            takenlijst1.addTask(taak8);
            Console.WriteLine(takenlijst1.showName());
            //takenlijst1.writeProjectToJSON();


            //string fileName2 = "takenlijst1document.json";
            //string jsonString2 = JsonSerializer.Serialize(takenlijst1);
            //File.WriteAllText(fileName2, jsonString2);
            //Console.WriteLine(takenlijst2._name);
            Console.WriteLine("1");
            //takenlijst1.WriteProjectToYAML();
            Console.WriteLine("2");
            takenlijst2.ReadProjectFromYAML("takenlijst1");
            //takenlijst2.readProjectFromJSON("takenlijst1");
            Console.WriteLine(takenlijst2.readAllTaakLabel());
            //Console.WriteLine(takenlijst2.showName());
        }
    }
}
