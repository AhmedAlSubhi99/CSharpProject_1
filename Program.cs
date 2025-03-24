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
            // For Buildind Menu of Choices.
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n Student Management System");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Find Student By Name");
                Console.WriteLine("4. Calculate Class Average");
                Console.WriteLine("5. Find Top Performing Student");
                Console.WriteLine("6. Sort Students By Marks Descending");
                Console.WriteLine("7. Delete Student");
                Console.WriteLine("8. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                // To perform the operation based on the choice.
                switch (choice)
                {
                    case 1: AddNewStudent(); break;
                    case 2: ViewAllStudents(); break;
                    case 3: FindStudentByName(); break;
                    case 4: CalculateClassAverage(); break;
                    case 5: FindTopPerformingStudent(); break;
                    case 6: SortStudentsByMarksDescending(); break;
                    case 7: DeleteStudent(); break;
                    case 8: return;
                    default: Console.WriteLine("Invalid choice! Try again."); break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
            //======== Add New Student ==========
            static void AddNewStudent()
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Hello For Adding New Student cheers!!(-_-) ");
                Console.WriteLine("=======================================");

                while (true) // To add more than one student( Multiplie Students ).
                {
                    // To check the array is full or not.
                    if (count == 10)
                    {
                        Console.WriteLine("Student Array is full!");
                        return;
                    }
                    // To add the new student details.
                    else
                    {
                        Console.Write("Enter student name: "); // To take the student name.
                        string name = Console.ReadLine(); // To read the student name.
                        Console.Write("Enter student age: "); // To take the student age.
                        int age = int.Parse(Console.ReadLine()); // To read the student age.
                        Console.Write("Enter student marks: "); // To take the student marks.
                        double mark = double.Parse(Console.ReadLine()); // To read the student marks.
                        // To check the (Age / Mark) details are valid or not.
                        if (age <= 21) // To check the age is greater than 21.
                        {
                            Console.WriteLine("Age must be greater than 21!");
                            return;
                        }
                        if (mark < 0 || mark > 100) // To check the marks are between 0 and 100.
                        {
                            Console.WriteLine("Marks must be between 0 and 100!");
                            return;
                        }
                        names[count] = name; // To store the student name.
                        ages[count] = age; // To store the student age.
                        marks[count] = mark; // To store the student marks.
                        dates[count] = DateTime.Now; // To store the student enrollment date.
                        count++; // To increment the count by 1 .
                        Console.WriteLine("Student added successfully!");
                    }
                    Console.Write("Do you want to add another student? (yes/no): ");
                    string choice = Console.ReadLine().ToLower(); // To read the choice.
                    if (choice != "yes") // To check the choice is not equal to "yes".
                    {
                        break;
                    }
                }



            }
            //======== View All Students ==========
            static void ViewAllStudents()
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Hello For Viewing All Students");
                Console.WriteLine("=======================================");

                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Name\tAge\tMarks\tEnrollment Date"); // To display the student details.
                Console.WriteLine("-------------------------------------------------");
                // To display the student details.
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"{names[i]}\t{ages[i]}\t{marks[i]}\t{dates[i]}");
                }
                Console.WriteLine("-------------------------------------------------");

            }
            //======== Find Student By Name ==========
            static void FindStudentByName()
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Hello For Find Student By Name");
                Console.WriteLine("=======================================");

                Console.Write("Enter student name to search: ");
                string searchName = Console.ReadLine().ToLower();
                bool found = false; // To check the student is found or not.

                for (int i = 0; i < count; i++) // To search the student by name.
                {
                    if (names[i].ToLower() == searchName) // To check the student name is equal to search name.
                    {
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Name\tAge\tMarks\tEnrollment Date");
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine($"{names[i]}\t{ages[i]}\t{marks[i]}\t{dates[i]}");
                        Console.WriteLine("-------------------------------------------------");
                        found = true; // To set the found as true.
                        break; // To break the loop.
                    }
                }
                if (!found) // To check the student is not found.
                {
                    Console.WriteLine("Student not found!");
                }
            }
            //======== Calculate Class Average ==========
            static void CalculateClassAverage()
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Hello For Calculate Class Average");
                Console.WriteLine("=======================================");

                double sum = 0; // To store the sum of marks.
                for (int i = 0; i < count; i++) // To calculate the sum of marks.
                {
                    sum += marks[i]; // To add the marks to sum. Or sum = sum + marks[i];
                }
                double average = Math.Round(sum / count, 2); // To calculate the average of marks.
                Console.WriteLine($"Class Average: {average}"); // To display the class average.

            }
            //======== Find Top Performing Student ==========
            static void FindTopPerformingStudent()
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Hello For Finding Top Performing Student");
                Console.WriteLine("=======================================");

                double max = 0; // To store the maximum marks.
                int index = -1; // To store the index of top performing student.
                for (int i = 0; i < count; i++) // To find the top performing student.
                {
                    if (marks[i] > max) // To check the marks is greater than max.
                    {
                        max = marks[i]; // To store the marks to max.
                        index = i; // To store the index to i.
                    }
                }
                if (index != -1) // To check the index is not equal to -1.
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Name\tAge\tMarks\tEnrollment Date");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine($"{names[index]}\t{ages[index]}\t{marks[index]}\t{dates[index]}");
                    Console.WriteLine("-------------------------------------------------");
                }
            }
            //======== Sort Students By Marks Descending ==========
            static void SortStudentsByMarksDescending()
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Hello For Sorting Students By Marks Descending");
                Console.WriteLine("=======================================");

                // To sort the students by marks descending.
                for (int i = 0; i < count - 1; i++) // For loop to sort the students.
                {
                    for (int j = i + 1; j < count; j++) // To make loop for sorting.
                    {
                        if (marks[i] < marks[j]) // To check the marks is less than marks.
                        {
                            double mark = marks[i]; // To store the marks to mark.
                            marks[i] = marks[j]; // To Store the marks[j] to marks[i].
                            marks[j] = mark; // To store the mark to marks[j].
                            string name = names[i]; // To store the name to name[i].
                            names[i] = names[j]; // To store the names[j] to names[i].
                            names[j] = name; // To store the name to names[j].
                            int age = ages[i]; // To store the age to age[i].
                            ages[i] = ages[j]; // To store the ages[j] to ages[i].
                            ages[j] = age; // To store the age to ages[j].
                            DateTime date = dates[i]; // To store the date to date[i].
                            dates[i] = dates[j]; // To store the dates[j] to dates[i].
                            dates[j] = date; // To store the date to dates[j].
                        }
                    }
                }

                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Name\tAge\tMarks\tEnrollment Date");
                Console.WriteLine("-------------------------------------------------");
                for (int i = 0; i < count; i++) // To display the sorted students.
                {
                    Console.WriteLine($"{names[i]}\t{ages[i]}\t{marks[i]}\t{dates[i]}");
                }
                Console.WriteLine("-------------------------------------------------");


            }
            //======== Delete Student ==========
            static void DeleteStudent()
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Hello For Delete Student");
                Console.WriteLine("=======================================");

                // To delete the student by name.
                Console.Write("Enter student name to delete: ");
                string deleteName = Console.ReadLine().ToLower();
                bool found = false; // To check the student is found or not.

                for (int i = 0; i < count; i++) // To loop through the students.
                {
                    if (names[i].ToLower() == deleteName) // To check the student name is equal to delete name.
                    {
                        for (int j = i; j < count - 1; j++) // to loop for shift the students.
                        {
                            names[j] = names[j + 1]; // To shift the names to left.
                            ages[j] = ages[j + 1]; // To shift the ages to left.
                            marks[j] = marks[j + 1]; // To shift the marks to left.
                            dates[j] = dates[j + 1]; // To shift the dates to left.
                        }
                        count--; // To decrement the count by 1.
                        Console.WriteLine("Student deleted successfully!");
                        found = true; // To set the found as true.
                        break; // To break the loop.
                    }
                }
                if (!found) // To check the student is not found.
                {
                    Console.WriteLine("Student not found!");
                }
            }

        }
    }
}
