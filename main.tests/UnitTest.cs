using NUnit.Framework;
using System;
using System.Linq;

namespace main.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(69, true)]
    [TestCase(1336, false)]
    [TestCase(69420, true)]
    [TestCase(69421, false)]
    [TestCase(1, true)]
    [TestCase(0, false)]
    public void LinearSearchTest(int value, bool value1)
    {
        int[] result = { 1, 3, 4, 69, 71, 81, 90, 99, 420, 1337, 69420 };
        Assert.AreEqual(Search.linearSearch(result, value), value1);
    }

    [Test]
    [TestCase(69, true)]
    [TestCase(1336, false)]
    [TestCase(69420, true)]
    [TestCase(69421, false)]
    [TestCase(1, true)]
    [TestCase(0, false)]
    public void BinarySearchTest(int value, bool value1)
    {
        int[] result = { 1, 3, 4, 69, 71, 81, 90, 99, 420, 1337, 69420 };
        Assert.AreEqual(Search.binarySearch(result, value), value1);
    }

    [Test]
    public void TwoCrystalBallsTestEqual()
    {
        var rand = new Random();
        int idx = (int)rand.NextDouble() * 10000;

        var data = Enumerable.Repeat(false, 10000).ToArray();


        for (var i = idx; i < 10000; ++i)
        {
            data[i] = true;
        }

        Assert.AreEqual(Search.twoCrystalBalls(data), idx);
    }

    [Test]
    public void TwoCrystalBallsTestNegative()
    {
        var rand = new Random();
        int idx = (int)rand.NextDouble() * 10000;

        var data = Enumerable.Repeat(false, 10000).ToArray();


        for (var i = idx; i < 10000; ++i)
        {
            data[i] = true;
        }

        Assert.AreEqual(Search.twoCrystalBalls(Enumerable.Repeat(false, 821).ToArray()), -1);
    }
}
