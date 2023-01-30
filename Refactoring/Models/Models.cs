using System.Diagnostics;

internal interface IHuman
{
    /// <summary>
    /// Gets the age.
    /// </summary>
    /// <value>
    /// The age.
    /// </value>
    int Age { get; }

    string? Name { get; }

    /// <summary>
    /// Gets the birth year.
    /// </summary>
    /// <returns></returns>
    int GetBirthYear() => DateTime.Now.Year - Age;
}

internal sealed class Circle : Shape
{
    public override double Area => Radius * System.Math.PI;

    /// <summary>
    /// Gets or sets the diameter.
    /// </summary>
    /// <value>
    /// The diameter.
    /// </value>
    public double Diameter { get; set; }

    public double Radius => Diameter / 2;   // شعاع
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

internal sealed class Recatngle : Shape
{
    public override double Area => Width * Height;

    public double Height { get; set; }

    public double Width { get; set; }
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