using NUnit.Framework;

namespace main.tests;

public class Tests
{
    private Search _search;
    [SetUp]
    public void Setup()
    {
        _search = new Search();
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
        Assert.AreEqual(_search.linearSearch(result, value), value1);
    }
}
