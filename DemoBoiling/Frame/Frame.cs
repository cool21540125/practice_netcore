using System;

namespace Boiling
{
    public class Frame
    {
        private int score;

        public int Score
        {
            get { return score; }
        }

        public void Add(int pins)
        {
            score += pins;
        }
    }

    public class Game
    {
        private int score;

        public int Score
        {
            get { return score; }
        }

        public void Add(int pins)
        {
            score += pins;
        }
    }
}
