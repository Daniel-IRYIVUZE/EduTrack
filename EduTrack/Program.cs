using System;

class Program
{
    static void Main()
    {
        StudentManager manager = new();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== EduTrack: Student Grade Manager ===");
            Console.WriteLine("1 Add Student");
            Console.WriteLine("2 Display All Students");
            Console.WriteLine("3 Search for a Student");
            Console.WriteLine("4 Calculate Average Grade");
            Console.WriteLine("5 Show Highest and Lowest Grades");
            Console.WriteLine("6 Exit");
            Console.Write(" Choose an option (1-6): ");

            switch (Console.ReadLine())
            {
                case "1":
                    manager.AddStudent();
                    break;
                case "2":
                    manager.DisplayStudents();
                    break;
                case "3":
                    manager.SearchStudent();
                    break;
                case "4":
                    manager.CalculateAverage();
                    break;
                case "5":
                    manager.ShowHighLowGrades();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Utils.WriteColored(" Invalid option. Please choose from 1 to 6. ", ConsoleColor.Red);
                    break;
            }
        }

        Console.WriteLine(" Thanks for using EduTrack! ");
    }
}
