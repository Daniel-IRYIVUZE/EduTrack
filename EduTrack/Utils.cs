using System;

public enum GradeCategory
{
    Excellent,  // 90-100
    Good,       // 80-89
    Average,    // 60-79
    Poor         // 0-59
}

public static class Utils
{
    public static GradeCategory GetGradeCategory(int grade)
    {
        return grade switch
        {
            >= 90 => GradeCategory.Excellent,
            >= 80 => GradeCategory.Good,
            >= 60 => GradeCategory.Average,
            _ => GradeCategory.Poor,
        };
    }

    public static void WriteColored(string message, ConsoleColor color)
    {
        var original = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = original;
    }
}
