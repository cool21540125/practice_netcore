using System;

namespace Prime.Services
{
    public class PrimeService
    {
        public bool IsPrime(int candidate)
        {
            if (candidate > 1)
            {
                int cnt = 0;

                for (int i = 2; i <= Math.Sqrt(candidate); i++)
                {
                    if (candidate % i == 0)
                    {
                        cnt++;
                    }
                }

                if (cnt == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}