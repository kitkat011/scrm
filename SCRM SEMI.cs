using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Xml.Linq;

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
            Console.WriteLine("Student Clinic Record Manager");
            Console.WriteLine("1. Add Record");
            Console.WriteLine("2. View All Records");
            Console.WriteLine("3. Search Record by Name");
            Console.WriteLine("4. Edit Record by Name");
            Console.WriteLine("5. Delete Record by Name");
            Console.WriteLine("6. Sort Records by Name");
            Console.WriteLine("7. Filter Records by Name");
            Console.WriteLine("8. Save Records to File");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");
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
        static void AddRecord()
        {
            StudentRecord r = new StudentRecord();
            Console.WriteLine("Enter name: "); r.Name = Console.ReadLine();
            Console.WriteLine("Enter age: "); r.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter grade & course: "); r.Grade = Console.ReadLine();
            Console.WriteLine("Enter complaint: "); r.Complaint = Console.ReadLine();
            Console.WriteLine("Enter treatment: "); r.Treatment = Console.ReadLine();


            records.Add(r);
            Console.WriteLine("Record Added: ");
        }
        static void ViewRecords()
        {
            Console.WriteLine("All Records");
            if (records.Count > 0)
            {
                Console.WriteLine("No Records Found");
                return;
                foreach (var record in records)
                {
                    DisplayRecord(record);
                }
            }
        }
        static void SearchRecord()
        {

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

        }
        static void DisplayRecord(StudentRecord r)
        {

        }
    }
}

