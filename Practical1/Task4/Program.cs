namespace Task4;

public class Program
{
    public static bool IsValidTriangle(double a, double b, double c)
    {
        return a > 0 && b > 0 && c > 0 &&
               (a + b > c) && (a + c > b) && (b + c > a);
    }

    public static double GetPerimeter(double a, double b, double c)
    {
        return a + b + c;
    }

    public static double GetArea(double a, double b, double c)
    {
        double p = GetPerimeter(a, b, c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public static string GetTriangleType(double a, double b, double c)
    {
        if (!IsValidTriangle(a, b, c)) return "не є трикутником";

        if (a == b && b == c) return "рівносторонній";
        if (a == b || b == c || a == c) return "рівнобедрений";

        double[] sides = { a, b, c };
        Array.Sort(sides);
        if (Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1e-6)
            return "прямокутний";

        return "довільний";
    }

    public static void Main()
    {
        Console.Write("Введіть сторони трикутника (a b c): ");
        string[] parts = Console.ReadLine().Split();
        double a = double.Parse(parts[0]);
        double b = double.Parse(parts[1]);
        double c = double.Parse(parts[2]);

        if (IsValidTriangle(a, b, c))
        {
            Console.WriteLine($"Периметр = {GetPerimeter(a, b, c)}");
            Console.WriteLine($"Площа = {GetArea(a, b, c):F2}");
            Console.WriteLine($"Тип = {GetTriangleType(a, b, c)}");
        }
        else
        {
            Console.WriteLine("такого трикутника не існує!");
        }
    }
}
