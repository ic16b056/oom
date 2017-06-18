using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task4
{
    class MainProgram
    {
        public static void Main(string[] args)
        {
            int anzMembers = 0;
            var members = new Person[]
            {
                new Abteilung("IT", 84, anzMembers),
                new Mitarbeiter ("Martin Lawrence", 94, "AT50 1200 2470 2481", 2448, 1900),
                new Mitarbeiter ("John Smith", 62, "AT50 1200 3007 4028", 1028, 2700),
            };
            foreach (var i in members)
            {
                anzMembers = i.Value;
                i.printData();
            }
            Abteilung abt = new Abteilung("IT", 92, anzMembers);
            Console.WriteLine($"Die Anzahl der Mitarbeiter in der Abteilung '{abt.Description}' wurde erhöht!\n");

            var MitarbeiterObjects = new[]
            {
                  new Mitarbeiter ("Martin Lawrence", 94, "AT50 1200 2470 2481", 2448, 19000),
                  new Mitarbeiter ("Will Smith", 98, "AT50 1200 1284 2467", 1002, 48900),
                  new Mitarbeiter ("Chris Brown", 82, "AT50 1200 3782 4287 ", 8001, 28000),
            };         

            string ausgabe = JsonConvert.SerializeObject(MitarbeiterObjects, Formatting.Indented);
            Console.WriteLine(ausgabe);

            string datei = @"C:\Users\alekpav1\Desktop\oom\tasks\Task4_Task6_Task7\Task4\CreatedObjects.json";

            File.Exists(datei);
            File.WriteAllText(datei, ausgabe, Encoding.UTF8);

            /* read file */
            string jsonstring = File.ReadAllText(datei);
            var CreatedObject = JsonConvert.DeserializeObject<Mitarbeiter[]>(jsonstring);

            PushExamplesSubject.Run(MitarbeiterObjects);
            AsynchronousProgramming.Run(MitarbeiterObjects);

        }
    }
}