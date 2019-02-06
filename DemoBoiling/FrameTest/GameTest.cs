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

        [Test]
        public void TestTwoThrowsNoMark()
        {
            Game game = new Game();
            game.Add(5);
            game.Add(4);
            Assert.AreEqual(9, game.Score);
        }

        [Test]
        public void TestFourThrowsNoMark()
        {
            Game game = new Game();
            game.Add(5);
            game.Add(4);
            game.Add(7);
            game.Add(2);
            Assert.AreEqual(18, game.Score);
            Assert.AreEqual(9, game.ScoreForFrame(1));
            Assert.AreEqual(18, game.ScoreForFrame(2));
        }
    }
}