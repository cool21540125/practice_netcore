using NUnit.Framework;
using Boiling;

namespace Boiling.Tests
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void TestOneThrow()
        {
            Game game = new Game();
            game.Add(5);
            Assert.AreEqual(5, game.Score);
        }
    }
}