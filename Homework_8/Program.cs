using System;
using System.Collections.Generic;


public abstract class Shape
{
    public string Name { get; set; }

    public Shape(string name)
    {
        Name = name;
    }

    public abstract double Area();
    public abstract double Perimeter();
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(string name, double radius) : base(name)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}


public class Square : Shape
{
    public double Side { get; set; }


    public Square(string name, double side) : base(name)
    {
        Side = side;
    }

    public override double Area()
    {
        return Side * Side;
    }

    public override double Perimeter()
    {
        return 4 * Side;
    }
}

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();

        
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Введiть данi для фiгури {i}");
            Console.Write("Назва фiгури: ");
            string name = Console.ReadLine();
            Console.Write("Тип фiгури (Circle або Square): ");
            string type = Console.ReadLine();

            if (type.ToLower() == "circle")
            {
                Console.Write("Радiус: ");
                double radius = double.Parse(Console.ReadLine());
                shapes.Add(new Circle(name, radius));
            }
            else if (type.ToLower() == "square")
            {
                Console.Write("Сторона: ");
                double side = double.Parse(Console.ReadLine());
                shapes.Add(new Square(name, side));
            }
        }

       
        Console.WriteLine("Iнформацiя про фiгури:");
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Назва: {shape.Name}, Площа: {shape.Area()}, Периметр: {shape.Perimeter()}");
        }


        double maxPerimeter = 0;
        string maxPerimeterShape = "";
        foreach (var shape in shapes)
        {
            if (shape.Perimeter() > maxPerimeter)
            {
                maxPerimeter = shape.Perimeter();
                maxPerimeterShape = shape.Name;
            }
        }
        Console.WriteLine($"Фiгура з найбiльшим периметром: {maxPerimeterShape}");

  
        shapes.Sort((a, b) => a.Area().CompareTo(b.Area()));
        Console.WriteLine("Вiдсортованi фiгури за площею:");
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Назва: {shape.Name}, Площа: {shape.Area()}");
        }
    }
}

