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
    }
}