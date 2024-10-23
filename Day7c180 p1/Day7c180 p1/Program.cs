using System;
using System.IO;

public class Point3D
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public Point3D() : this(0, 0, 0) { }

    public Point3D(int x) : this(x, 0, 0) { }

    public Point3D(int x, int y) : this(x, y, 0) { }

    public Point3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return $"Point3D({X}, {Y}, {Z})";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Point3D))
            return false;

        Point3D other = (Point3D)obj;
        return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
    }

    public override int GetHashCode()
    {
        return X ^ Y ^ Z;
    }

    public static bool operator ==(Point3D p1, Point3D p2)
    {
        if (ReferenceEquals(p1, p2))
            return true;

        if ((object)p1 == null || (object)p2 == null)
            return false;

        return p1.Equals(p2);
    }

    public static bool operator !=(Point3D p1, Point3D p2)
    {
        return !(p1 == p2);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Point3D P1 = ReadPointFromUserWithErrorHandling("P1");
            Point3D P2 = ReadPointFromUserWithErrorHandling("P2");

            Console.WriteLine($"P1: {P1.ToString()}");
            Console.WriteLine($"P2: {P2.ToString()}");

            if (P1 == P2)
            {
                Console.WriteLine("P1 is equal to P2");
            }
            else
            {
                Console.WriteLine("P1 is not equal to P2");
            }
        }
        catch (Exception ex)
        {
            LogError(ex);
            Console.WriteLine("An unexpected error occurred. Please check the log file for details.");
        }
    }

    private static Point3D ReadPointFromUserWithErrorHandling(string pointName)
    {
        try
        {
            return ReadPointFromUser(pointName);
        }
        catch (Exception ex)
        {
            LogError(ex);
            Console.WriteLine($"An error occurred while reading {pointName}. Defaulting to (0, 0, 0).");
            return new Point3D(); 
        }
    }

    private static Point3D ReadPointFromUser(string pointName)
    {
        int x, y, z;
        Console.WriteLine($"Enter coordinates for {pointName}:");

        Console.Write("X: ");
        while (!int.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for X.");
        }

        Console.Write("Y: ");
        while (!int.TryParse(Console.ReadLine(), out y))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for Y.");
        }

        Console.Write("Z: ");
        while (!int.TryParse(Console.ReadLine(), out z))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for Z.");
        }

        return new Point3D(x, y, z);
    }

    private static void LogError(Exception ex)
    {
        using (StreamWriter writer = new StreamWriter("error_log.txt", true))
        {
            writer.WriteLine($"[{DateTime.Now}] - Error: {ex.Message}");
            writer.WriteLine(ex.StackTrace);
        }
    }
}
