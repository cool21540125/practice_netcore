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
        private int[] throws = new int[21];
        private int currentThrow;
        private int currentFrame;
        private bool isFirstThrow = true;

        public int Score
        {
            get { return score; }
        }

        public int CurrentFrame
        {
            get { return currentFrame; }
        }

        public void Add(int pins)
        {
            throws[currentThrow++] = pins;
            score += pins;

            if (isFirstThrow)
            {
                isFirstThrow = false;
                currentFrame++;
            }
            else
            {
                isFirstThrow = true;
            }
        }

        public int ScoreForFrame(int theFrame)
        {
            int ball = 0;
            int score = 0;
            for (int currentFrame = 0; 
                currentFrame < theFrame; 
                currentFrame++)
            {
                int firstThrow = throws[ball++];
                int secondThrow = throws[ball++];
                
                int frameScore = firstThrow + secondThrow;

                // Spare 需要知道下一球的狀況
                if (frameScore == 10)
                    score += frameScore + throws[ball];
                else
                    score += frameScore;
            }

            return score;
        }
    }
}
