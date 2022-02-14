using System;
using System.Collections.Generic;
using System.IO;

namespace SingleResponsibilityPrinciple
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private int count = 0;
        //action
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
        //violate Single Responsibility
        //public void Save(string filename)
        //{
        //    File.WriteAllText(filename, this.ToString());
        //}
    }
    public class Persistence
    {
        public void SaveToFIle(Journal journal, string filename)
        {
            File.WriteAllText(filename, journal.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("Design Pattern class");
            j.AddEntry("Lecture 1");

            var p = new Persistence();
            p.SaveToFIle(j, "journal.txt");
        }
    }
}
