using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Refactoring.Session07;
internal class DeconstructDemp
{
    [TestMethod]
    public void DeconstructTest()
    {
        Person p = new("Ali", "Alavi") { First = "" };
        //x p.First = "";
        var (f, l) = p;
        //.. 
        Person p1 = new("Ali", "Alavi");
        (f, l, int age) = p1;
    }
}

public class Person
{
    public Person(string first, string last) 
        => (this.First, this.Last) = (first, last);

    public string First { get; init; }
    public string Last { get; set; }
    public int Age { get; set; }

    public void Deconstruct(out string first, out string last) 
        => (first, last) = (this.First, this.Last);

    public void Deconstruct(out string first, out string last, out int age)
        => (first, last, age) = (this.First, this.Last, this.Age);

    //public void Deconstruct(out string first, out int age)
    //    => (first, age) = (this.First, this.Age);
}

file static class Extensions
{
    //public static void Deconstruct(this Person p, out string first, out string last) => (first, last) = (p.First, p.Last);
}
