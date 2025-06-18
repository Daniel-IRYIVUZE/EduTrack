using System;
using System.Collections.Generic;
using System.Linq;

public class StudentManager
{
    private Dictionary<string, int> students = new();

    public void AddStudent()
    {
        Console.Write("\n Enter student name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Utils.WriteColored(" Invalid name. Try again. ", ConsoleColor.Red);
            return;
        }

        Console.Write(" Enter grade (0-100):  ");
        string input = Console.ReadLine();

        try
        {
            int grade = int.Parse(input);

            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException();

            students[name] = grade;
            Utils.WriteColored(" Student added successfully.", ConsoleColor.Green);
        }
        catch (FormatException)
        {
            Utils.WriteColored(" Invalid input. Grade must be a number.", ConsoleColor.Red);
        }
        catch (ArgumentOutOfRangeException)
        {
            Utils.WriteColored(" Grade must be between 0 and 100.", ConsoleColor.Red);
        }
    }

    public void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Utils.WriteColored(" No students to display. ", ConsoleColor.Yellow);
            return;
        }

        Console.WriteLine("\n Student List: ");
        foreach (var s in students)
        {
            var category = Utils.GetGradeCategory(s.Value);
            ConsoleColor color = category switch
            {
                GradeCategory.Excellent => ConsoleColor.Green,
                GradeCategory.Good => ConsoleColor.Blue,
                GradeCategory.Average => ConsoleColor.Yellow,
                GradeCategory.Poor => ConsoleColor.Red,
                _ => ConsoleColor.White
            };

            Console.ForegroundColor = color;
            Console.WriteLine($"Name: {s.Key}, Grade: {s.Value}, Category: {category}");
        }
        Console.ResetColor();
    }

    public void SearchStudent()
    {
        Console.Write("\n Enter name to search: ");
        string name = Console.ReadLine();

        if (students.TryGetValue(name, out int grade))
        {
            var category = Utils.GetGradeCategory(grade);
            Utils.WriteColored($"Found: {name}, Grade: {grade} ({category})", ConsoleColor.Cyan);
        }
        else
        {
            Utils.WriteColored(" Student not found. ", ConsoleColor.Red);
        }
    }

    public void CalculateAverage()
    {
        if (students.Count == 0)
        {
            Utils.WriteColored(" No grades available to calculate average. ", ConsoleColor.Yellow);
            return;
        }

        double avg = students.Values.Average();
        Utils.WriteColored($" Average Grade: {avg:F2}", ConsoleColor.Magenta);
    }

    public void ShowHighLowGrades()
    {
        if (students.Count == 0)
        {
            Utils.WriteColored(" No data available. ", ConsoleColor.Yellow);
            return;
        }

        int max = students.Values.Max();
        int min = students.Values.Min();

        Utils.WriteColored($" Highest Grade: {max}", ConsoleColor.Green);
        Utils.WriteColored($" Lowest Grade: {min}", ConsoleColor.Red);
    }
}
