using System;

namespace TheInternetTests.Utils
{
    public static class RandomInt
    {
        public static int RandomIntValue()
        {
            Random random = new Random();
            return random.Next(0,10);
        }
    }
}
