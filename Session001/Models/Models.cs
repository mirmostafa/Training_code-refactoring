using System.Diagnostics;

namespace Session001.Models;

internal interface IHuman
{
   int Age { get; }

    string? Name { get; }

    int GetBirthYear() => DateTime.Now.Year - Age;
}

internal sealed class Circle : Shape
{
    public override double Area => Radius * Math.PI;

    public double Diameter { get; set; }

    public double Radius => Diameter / 2;
}

internal class Officer : Person
{
    public string? Office { get; set; }
}

[DebuggerDisplay("{Name}")]
internal class Person : IHuman
{
    public int Age { get; set; }

    public string? Name { get; set; }
}

internal abstract class Shape
{
    public abstract double Area { get; }

    public string? Name { get; set; }
}

internal class Student : Person
{
    public string? CourseOfStudy { get; set; }
}

internal class Teacher : Person
{
    public string? CourseOfTeach { get; set; }
}

internal sealed class Recatngle : Shape
{
    public override double Area => Width * Height;

    public double Height { get; set; }

    public double Width { get; set; }
}