using NUnit.Framework;

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
}
