using System;
using System.Collections.Generic;
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
        public string Date;
    }
    class Program
    {
        static List<StudentRecord> records = new List<StudentRecord>();

        static string path = "C:\\Users\\vivobook r5\\source\\repos\\SCRM\\SCRM\\bin\\Debug\\net9.0\\clinic_records.txt";
        static string filePath = "clinic_records.txt";

        static void Main(string[] args)
        {
            LoadRecords();

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                         STUDENT CLINIC RECORD MANAGER                                                 ");
                Console.ResetColor();


                Console.WriteLine("                              +-------------------------------------------------+                                      ");
                Console.WriteLine("                              |1. Add Record                                    |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |2. View All Records                              |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |3. Search Record                                 |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |4. Edit Record                                   |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |5. Delete Record                                 |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |6. Sort Records                                  |                                      ");
                Console.WriteLine("                              |-------------------------------------------------+                                      ");
                Console.WriteLine("                              |7. Filter Records                                |                                      ");
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
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Add a new record? yes/no");
                string add = Console.ReadLine().ToLower();

                if (add == "n" || add == "no")
                {
                    break;

                }
                else if (add != "yes")
                {
                    continue;
                }

                StudentRecord r = new StudentRecord();

                Console.Write("Enter full name: "); r.Name = Console.ReadLine();
                Console.Write("Enter age: "); r.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter grade & course: "); r.Grade = Console.ReadLine();
                Console.Write("Enter complaint: "); r.Complaint = Console.ReadLine();
                Console.Write("Enter treatment: "); r.Treatment = Console.ReadLine();
                Console.Write("Date visited: "); r.Date = Console.ReadLine();

                records.Add(r);
                Console.WriteLine("\n Record Added Successfully!");
                SaveRecord();

            }

            Console.WriteLine("enter to exit.");
            Console.ReadLine(); return;
        }

        static void ViewRecords()
        {
            Console.Clear();

            Console.WriteLine("--- All Records ---");
            if (records.Count == 0)
            {
                Console.WriteLine("No Records Found");
                return;
            }
            foreach (var r in records)
            {
                DisplayRecord(r);
            }
            Console.WriteLine("enter to exit.");
            Console.ReadLine(); return;

        }
        static void SearchRecord()
        {
            Console.Clear();

            Console.WriteLine("--- Search Record ---");
            Console.WriteLine("enter 'x' to exit.");
            Console.Write("Search name: ");
            string name = Console.ReadLine().ToLower();

            if (name == "x")
            {
                return;
            }

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

            Console.WriteLine("enter to exit.");
            Console.ReadLine(); return;

        }
        static void EditRecord()
        {
            Console.Clear();

            Console.WriteLine("--- Edit Record ---");
            Console.WriteLine("enter 'x' to exit.");
            Console.Write("Enter name to edit: ");
            string name = Console.ReadLine().ToLower();

            bool found = false;

            if (name == "x")
            {
                return;
            }

            for (int i = 0; i < records.Count; i++)
            {
                if (records[i].Name.ToLower().Contains(name))
                {
                    Console.WriteLine("Editing this record: ");
                    DisplayRecord(records[i]);

                    StudentRecord temp = records[i];

                    Console.Write("Enter new name: ");
                    temp.Name = Console.ReadLine();
                    Console.Write("Enter new age: ");
                    temp.Age = int.Parse(Console.ReadLine());
                    Console.Write("Enter new grade & course: ");
                    temp.Grade = Console.ReadLine();
                    Console.Write("Enter new complaint: ");
                    temp.Complaint = Console.ReadLine();
                    Console.Write("Enter new treatment: ");
                    temp.Treatment = Console.ReadLine();

                    records[i] = temp;
                    found = true;

                    Console.WriteLine("Updated successfully!");

                }

            }
            if (!found)
            {
                Console.WriteLine("No Records Found");
            }
            Console.WriteLine("enter to exit.");
            Console.ReadLine(); return;


        }

        static void DeleteRecord()
        {
            Console.Clear();

            Console.Write("Enter name to delete: ");
            string name = Console.ReadLine().ToLower();


            List<StudentRecord> matches = new List<StudentRecord>();
            foreach (var r in records)
            {
                if (r.Name.ToLower().Contains(name))
                {
                    matches.Add(r);
                }
            }

            if (matches.Count == 0)
            {
                Console.WriteLine("No matching records found.");
                return;
            }


            Console.WriteLine("Matches found:");
            for (int i = 0; i < matches.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {matches[i].Name}");
            }

            Console.Write("Enter number of record to delete: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice < 1 || choice > matches.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            StudentRecord selected = matches[choice - 1];
            DisplayRecord(selected);

            Console.Write("Are you sure you want to delete this record? (yes/no): ");
            string confirm = Console.ReadLine().ToLower();

            if (confirm == "yes")
            {
                records.Remove(selected);
                Console.WriteLine("Record Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Deletion Cancelled.");
            }
        }
        static void SortRecordbyName()
        {
            Console.Clear();

            records.Sort((record1, record2) => record1.Name.CompareTo(record2.Name));
            Console.WriteLine("Sorted Records by Name:");
            ViewRecords();

        }

        static void FilterRecordsbyGrade()
        {
            Console.Clear();

            Console.WriteLine("--- Filter by Grade & Course ---");
            Console.WriteLine("enter 'x' to cancel.");
            Console.WriteLine("Enter a grade/course: ");
            string grade = Console.ReadLine().ToLower();

            if (grade == "x")
            {
                return;
            }

            bool found = false;

            foreach (var r in records)
            {
                if (r.Grade.ToLower().Contains(grade))
                {
                    DisplayRecord(r);
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("No records found for that grade or course.");

            Console.WriteLine("enter to exit.");
            Console.ReadLine(); return;
        }

        static void SaveRecord()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var r in records)
                {
                    writer.WriteLine($"{r.Name}, {r.Age}, {r.Grade}, {r.Complaint}, {r.Treatment}, {r.Date}");
                }
            }
            Console.WriteLine("Record saved to file");

        }

        static void LoadRecords()
        {
            if (!File.Exists(filePath))
                return;

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 6)
                {
                    StudentRecord r = new StudentRecord
                    {
                        Name = parts[0].Trim(),
                        Age = int.Parse(parts[1]),
                        Grade = parts[2].Trim(),
                        Complaint = parts[3].Trim(),
                        Treatment = parts[4].Trim(),
                        Date = parts[5].Trim()
                    };
                    records.Add(r);
                }
            }
        }
        static void DisplayRecord(StudentRecord r)
        {
            Console.WriteLine($"Name: {r.Name}");
            Console.WriteLine($"Age: {r.Age}");
            Console.WriteLine($"Grade: {r.Grade}");
            Console.WriteLine($"Complaint: {r.Complaint}");
            Console.WriteLine($"Treatment: {r.Treatment}");
            Console.WriteLine($"Date: {r.Date} \n");
        }
    }
}
