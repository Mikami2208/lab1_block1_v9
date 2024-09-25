namespace lab1_v9;


/* Реалізувати клас, що представляє рівняння прямої на площині ( Ax + By +  C =  0 ) і
   містить опис індексатора для доступу до коефіцієнтів цього рівняння. Передбачити
   методи введеня/виведення, знаходження точки перетину з іншою прямою та метод
   перевірки належності точки прямій. */
public class Line
{

    private double[] coefficients = new double[3];

    public Line(double a, double b, double c)
    {
        coefficients[0] = a;
        coefficients[1] = b;
        coefficients[2] = c;

    }

    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= coefficients.Length)
                throw new ArgumentException("indecies must be in range 0 to 2");
            return coefficients[index];
        }

        set
        {
            if (index < 0 || index >= coefficients.Length)
                throw new ArgumentException("indecies must be in range 0 to 2");
            coefficients[index] = value;
        }
}
    
    public (double x, double y)? IntersectionWith(Line other)
    {
        double a1 = coefficients[0], b1 = coefficients[1], c1 = coefficients[2];
        double a2 = other[0], b2 = other[1], c2 = other[2];

        double index = a1 * b2 - a2 * b1;

        if (Math.Abs(index) < 1e-10)
        {
            return null;
        }

        double x = (b1 * c2 - b2 * c1) / index;
        double y = (a2 * c1 - a1 * c2) / index;

        return (x, y);
    }
    
    public bool IsPointOnLine(double x, double y)
    {
        return Math.Abs(coefficients[0] * x + coefficients[1] * y + coefficients[2]) < 1e-10;
    }

    public override string ToString()
    {
        if (coefficients[2] != 0)
            return $"{coefficients[0]}x + {coefficients[1]}y + {coefficients[2]} = 0";
        return $"{coefficients[0]}x + {coefficients[1]}y = 0";
        
    }
    public static Line ReadFromConsole()
    {
        Console.Write("Введіть коефіцієнти А, B, C через пробіл для рівняння прямої Ax + By + C = 0:  ");
        double[] coefficients = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        return new Line(coefficients[0], coefficients[1], coefficients[2]);
    }
}

    
    
    
    
    
