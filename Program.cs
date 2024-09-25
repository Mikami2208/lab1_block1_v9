using lab1_v9;
using System;

class lab1
{
    static void Main(string[] args)
    {
        Line line1 = Line.ReadFromConsole();
        Line line2 = Line.ReadFromConsole();
        Console.WriteLine("Рівняння першої прямої: " + line1.ToString());
        Console.WriteLine("Рівняння другої прямої: " + line2.ToString());
        IsPointOnLine(line1, line2);
        var intersection = line1.IntersectionWith(line2);
        if (intersection.HasValue)
            Console.WriteLine($"Пряма {line1.ToString()} перетинається з {line2.ToString()}");
        else
            Console.WriteLine("Прямі не перетинаються!");

    }

    static void IsPointOnLine(Line line1, Line line2)
    {
        Console.Write("Введіть точку [x, y] для перевірки належності прямій: ");
        double[] points = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        Console.WriteLine("Оберіть для якої прямої хочете перевірити: \n" +
                          "1. Для першої.\n" +
                          "2. Для другої.\n" +
                          "3. Для обох.\n");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                IsExist(line1, points[0], points[1]);
                break;
            case 2:
                IsExist(line2, points[0], points[1]);
                break;
            case 3:
                IsExist(line1, points[0], points[1]);
                IsExist(line2, points[0], points[1]);
                break;
            default: Console.WriteLine("Введіть число від 1 до 3");
                break;
        }
        
        static void IsExist(Line line, double x, double y)
        {
            if (line.IsPointOnLine(x, y))
            {
                Console.WriteLine($"Точка [{x}, {y}] належить прямій {line.ToString()}");
            }
            else
            {
                Console.WriteLine($"Точка [{x}, {y}] не належить прямій {line.ToString()}");
            }
            
            
        }
    }

   
}