using System;
using System.Collections.Generic;
using System.Linq;

public class Subject
{
    public int Code { get; set; }
    public string Name { get; set; }
}

public class Student
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Subject[] Subjects { get; set; }
}

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

        var distinctSortedNumbers = numbers.Distinct().OrderBy(n => n);
        Console.WriteLine("Part 1 - Query 1: Distinct sorted numbers");
        foreach (var num in distinctSortedNumbers)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine("\nPart 1 - Query 2: Numbers and their squares");
        foreach (var num in distinctSortedNumbers)
        {
            Console.WriteLine($"{num} * {num} = {num * num}");
        }

       
        string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

        var namesLength3 = names.Where(name => name.Length == 3);
        Console.WriteLine("\nPart 2 - Query 1: Names with length 3");
        foreach (var name in namesLength3)
        {
            Console.WriteLine(name);
        }

        var namesWithA = names.Where(name => name.ToLower().Contains('a')).OrderBy(name => name.Length);
        Console.WriteLine("\nPart 2 - Query 2: Names with 'a' sorted by length");
        foreach (var name in namesWithA)
        {
            Console.WriteLine(name);
        }

        var firstTwoNames = names.Take(2);
        Console.WriteLine("\nPart 2 - Query 3: First 2 names");
        foreach (var name in firstTwoNames)
        {
            Console.WriteLine(name);
        }

        List<Student> students = new List<Student>()
        {
            new Student { ID = 1, FirstName = "Ali", LastName = "Mohammed", Subjects = new Subject[] { new Subject { Code = 22, Name = "EF" }, new Subject { Code = 33, Name = "UML" } } },
            new Student { ID = 2, FirstName = "Mona", LastName = "Gala", Subjects = new Subject[] { new Subject { Code = 22, Name = "EF" }, new Subject { Code = 34, Name = "XML" }, new Subject { Code = 25, Name = "JS" } } },
            new Student { ID = 3, FirstName = "Yara", LastName = "Yousf", Subjects = new Subject[] { new Subject { Code = 22, Name = "EF" }, new Subject { Code = 25, Name = "JS" } } },
            new Student { ID = 1, FirstName = "Ali", LastName = "Ali", Subjects = new Subject[] { new Subject { Code = 33, Name = "UML" } } }
        };

        var fullNameAndSubjectCount = students.Select(s => new
        {
            FullName = s.FirstName + " " + s.LastName,
            SubjectCount = s.Subjects.Length
        });
        Console.WriteLine("\nPart 3 - Query 1: Full name and number of subjects");
        foreach (var student in fullNameAndSubjectCount)
        {
            Console.WriteLine($"{student.FullName}, Subjects Count: {student.SubjectCount}");
        }

        var orderedStudents = students
            .OrderByDescending(s => s.FirstName)
            .ThenBy(s => s.LastName)
            .Select(s => new { s.FirstName, s.LastName });
        Console.WriteLine("\nPart 3 - Query 2: Ordered first names and last names");
        foreach (var student in orderedStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}
