using Microsoft.VisualBasic.FileIO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleStudentManagementProject
{
    internal class Program
    {
        
        static string[] names = new string[10];
        static int[] ages = new int[10];
        static double[] marks = new double[10];
        static DateTime[] dates = new DateTime[10];
        static int count = 0;

        static void Main(string[] args)
        {

            //The program should support the following operations:
            //1.Add a new student record(Name, Age, Marks)
            //2.View all students with formatted output and subject - wise marks.
            //3.Find a student by name(case -insensitive search)
            //4.Calculate the class average(rounded to 2 decimals).
            //5. Find the top-performing student
            //6. Sort students by marks(highest to lowest)
            //7. Delete a student record(handle shifting logic).
            //8. Exit the system

            Console.WriteLine("Cheers!!!.. Student Management System!..");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n Student Management System");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Find Student By Name");
                Console.WriteLine("4. Calculate Class Average");
                Console.WriteLine("5. Find Top Performing Student");
                Console.WriteLine("6. Sort Students By Marks");
                Console.WriteLine("7. Delete Student");
                Console.WriteLine("8. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddNewStudent(); break;
                    case 2: ViewAllStudents(); break;
                    case 3: FindStudentByName(); break;
                    case 4: CalculateClassAverage(); break;
                    case 5: FindTopPerformingStudent(); break;
                    case 6: SortStudentsByMarks(); break;
                    case 7: DeleteStudent(); break;
                    case 8: return;
                    default: Console.WriteLine("Invalid choice! Try again."); break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }

            static void AddNewStudent()
            {
                if (count == 10)
                {
                    Console.WriteLine("Student database is full!");
                    return;
                }
                else
                {
                    Console.Write("Enter student name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter student age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter student marks: ");
                    double mark = double.Parse(Console.ReadLine());
                    if (age <= 21)
                    {
                        Console.WriteLine("Age must be greater than 21!");
                        return;
                    }
                    if (mark < 0 || mark > 100)
                    {
                        Console.WriteLine("Marks must be between 0 and 100!");
                        return;
                    }
                    names[count] = name;
                    ages[count] = age;
                    marks[count] = mark;
                    dates[count] = DateTime.Now;
                    count++;
                    Console.WriteLine("Student added successfully!");
                    return;
                }
            static void ViewAllStudents()
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Name\tAge\tMarks\tEnrollment Date");
                Console.WriteLine("-------------------------------------------------");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"{names[i]}\t{ages[i]}\t{marks[i]}\t{dates[i]}");
                }
                Console.WriteLine("-------------------------------------------------");

            }
            static void FindStudentByName()
            {
                Console.Write("Enter student name to search: ");
                string searchName = Console.ReadLine().ToLower();
                bool found = false;

                for (int i = 0; i < count; i++)
                {
                    if (names[i].ToLower() == searchName)
                    {
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Name\tAge\tMarks\tEnrollment Date");
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine($"{names[i].ToLower()}\t{ages[i]}\t{marks[i]}\t{dates[i]}");
                        Console.WriteLine("-------------------------------------------------");
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Student not found!");
                }
            }
            static void CalculateClassAverage()
            {

                double sum = 0;
                for (int i = 0; i < count; i++)
                {
                    sum += marks[i];
                }
                double average = Math.Round(sum / count, 2);
                Console.WriteLine($"Class Average: {average}");

            }
            static void FindTopPerformingStudent()
            {

                double max = 0;
                int index = -1;
                for (int i = 0; i < count; i++)
                {
                    if (marks[i] > max)
                    {
                        max = marks[i];
                        index = i;
                    }
                }
                if (index != -1)
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Name\tAge\tMarks\tEnrollment Date");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine($"{names[index]}\t{ages[index]}\t{marks[index]}\t{dates[index]}");
                    Console.WriteLine("-------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("No students found!");
                }
            }
            static void SortStudentsByMarks()
            {
                
                for (int i = 0; i < count - 1; i++)
                {
                    for (int j = i + 1; j < count; j++)
                    {
                        if (marks[i] < marks[j])
                        {
                            double mark = marks[i];
                            marks[i] = marks[j];
                            marks[j] = mark;
                            string name = names[i];
                            names[i] = names[j];
                            names[j] = name;
                            int age = ages[i];
                            ages[i] = ages[j];
                            ages[j] = age;
                            DateTime date = dates[i];
                            dates[i] = dates[j];
                            dates[j] = date;
                        }
                    }
                }

                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Name\tAge\tMarks\tEnrollment Date");
                Console.WriteLine("-------------------------------------------------");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"{names[i]}\t{ages[i]}\t{marks[i]}\t{dates[i]}");
                }
                Console.WriteLine("-------------------------------------------------");


            }
            static void DeleteStudent()
            {
                Console.Write("Enter student name to delete: ");
                string delete = Console.ReadLine().ToLower();
                bool found = false;

                for (int i = 0; i < count; i++)
                {
                    if (names[i].ToLower() == delete)
                    {
                        for (int j = i; j < count - 1; j++)
                        {
                            names[j] = names[j + 1];
                            ages[j] = ages[j + 1];
                            marks[j] = marks[j + 1];
                            dates[j] = dates[j + 1];
                        }
                        count--;
                        Console.WriteLine("Student deleted successfully!");
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Student not found!");
                }
            }

        }
    }
}
