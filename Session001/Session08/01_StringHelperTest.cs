using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Refactoring.Session08;
[TestClass]
public class StringHelperTest
{
    [TestMethod]
    public void IsNullOrEmpty_Null()
    {
        string? s = null;
        var actual = s.IsNullOrEmpty();
        var expected = true;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsNullOrEmpty_StringEmpty()
    {
        string s = string.Empty;
        var actual = s.IsNullOrEmpty();
        var expected = true;
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void IsNullOrEmpty_EmptyString()
    {
        string s = "";
        var actual = s.IsNullOrEmpty();
        var expected = true;
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void IsNullOrEmpty_NotNull()
    {
        string s = "Ali";
        var actual = s.IsNullOrEmpty();
        var expected = false;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void StringIsAliTrue()
    {
        string s = "Ali";
        var actual = StringHelper.IsAli(s);
        var expected = true;
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void StringIsAliFalse()
    {
        string s = "Mohammad";
        var actual = StringHelper.IsAli(s);
        var expected = false;
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void StringIsAliNull()
    {
        string? s = null;
        var actual = StringHelper.IsAli(s);
        var expected = false;
        Assert.AreEqual(expected, actual);
    }
}