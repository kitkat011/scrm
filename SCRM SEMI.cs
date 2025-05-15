using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace StudentClinicRecordManager
{
    struct StudentRecord
    {
        public string Name;
        public int Age;
        public string Grade;
        public string Complaint;
        public string Treatment;
    }
    class Program
    {
        static List<StudentRecord> records = new List<StudentRecord>();
        static void Main(string[] args)
        {
            LoadRecords();

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                         STUDENT CLINIC RECORD MANAGER                                                 ");
                Console.ResetColor();
                //Console.BackgroundColor = ConsoleColor.White;
                //Console.ForegroundColor = ConsoleColor.Black;


                Console.WriteLine("                              +-------------------------------------------------+                                      ");
                Console.WriteLine("                              |1. Add Record                                    |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |2. View All Records                              |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |3. Search Record by Name                         |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |4. Edit Record by Name                           |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |5. Delete Record by Name                         |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |6. Sort Records by Name                          |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |7. Filter Records by Name                        |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |8. Save Records to File                          |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |9. Exit                                          |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------------------------------------–—---------------------------------------------------------------------");
                Console.Write("Enter your choice:");
                Console.WriteLine();
                Console.ResetColor();
                String choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRecord();
                        break;
                    case "2":
                        ViewRecords();
                        break;
                    case "3":
                        SearchRecord();
                        break;
                    case "4":
                        EditRecord();
                        break;
                    case "5":
                        DeleteRecord();
                        break;
                    case "6":
                        SortRecordbyName();
                        break;
                    case "7":
                        FilterRecordsbyGrade();
                        break;
                    case "8":
                        SaveRecord();
                        break;
                    case "9":
                        SaveRecord();
                        Console.WriteLine("Thank you!");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }

        }
        static void AddRecord()
        {
            StudentRecord r = new StudentRecord();
            Console.WriteLine("Enter name: "); r.Name = Console.ReadLine();
            Console.WriteLine("Enter age: "); r.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter grade & course: "); r.Grade = Console.ReadLine();
            Console.WriteLine("Enter complaint: "); r.Complaint = Console.ReadLine();
            Console.WriteLine("Enter treatment: "); r.Treatment = Console.ReadLine();


            records.Add(r);
            Console.WriteLine("Record Added Successfully!");
        }
        static void ViewRecords()
        {
            Console.WriteLine("\n--- All Records ---");
            if (records.Count == 0)
            {
                Console.WriteLine("No Records Found");
                return;
            }
            foreach (var r in records)
            {
                DisplayRecord(r);
            }
        }
        static void SearchRecord()
        {
            Console.WriteLine("Search Name: ");
            string name = Console.ReadLine();
            bool found = false;

            Console.WriteLine("\n--- Search Results ---");
            foreach (var r in records)
            {
                if (r.Name.ToLower().Contains(name))
                {
                    DisplayRecord(r);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No Records Found");
            }
        }
            static void EditRecord()
        {

        }
        static void DeleteRecord()
        {

        }
        static void SortRecordbyName()
        {

        }
        static void FilterRecordsbyGrade()
        {

        }
        static void SaveRecord()
        {
            using (StreamWriter writer = new StreamWriter("clinic_records.txt"))
            {
                foreach (var r in records)
                {
                    writer.WriteLine($"{r.Name}, {r.Age}, {r.Grade}, {r.Complaint}, {r.Treatment}");
                }
            }
            Console.WriteLine("Records saved to file");

        }

        static void LoadRecords() 
        {
            if (!File.Exists("clinic_records.txt"))
                return;

                string[] lines= File.ReadAllLines("clinic_records.txt");
                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 5) 
                    {
                        StudentRecord r = new StudentRecord
                        {
                            Name = parts[0],
                            Age = int.Parse (parts[1]),
                            Grade = parts[2],
                            Complaint = parts[3],
                            Treatment = parts[4]
                        };
                        records.Add(r);
                    }
                }
        }
        static void DisplayRecord(StudentRecord r)
        {
            Console.WriteLine ($"Name:{r.Name},Age:{r.Age}, Grade: {r.Grade}");
            Console.WriteLine($"Complaint: {r.Complaint}");
            Console.WriteLine($"Treatment: {r.Treatment}");
        }
    }
}

