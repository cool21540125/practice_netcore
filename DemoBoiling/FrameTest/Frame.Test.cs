using NUnit.Framework;
using Boiling;

namespace Boiling.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestScoreNoThrows()
        {
            Frame f = new Frame();
            Assert.AreEqual(0, f.Score);
        }

        [Test]
        public void TestAddOneThrow()
        {
            Frame f = new Frame();
            f.Add(5);
            Assert.AreEqual(5, f.Score);
        }
    }
}