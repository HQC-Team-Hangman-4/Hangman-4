namespace HangMan.Helpers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;

    public static class DataSerialization
    {
        public static ICollection<string> ReadFromFile(FileNames fileName)
        {
            ICollection<string> textLines = File.ReadAllLines("../../Files/" + fileName + ".txt");

            //foreach (var line in textLines)
            //{
            //    Console.WriteLine(line);
            //}

            return textLines;
        }

        public static void WriteToFile()
        {

        }
    }
}
