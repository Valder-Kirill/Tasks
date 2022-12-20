using System;

namespace TaskOne.Utils
{
    public static class RandomUtil
    {
        private static Random rnd = new Random();

        public static string RndString()
        {
            string str = "";
            for (int i = 0; i < 10; i++)
            {
                str += (char)rnd.Next('A', 'Z');
            }
            return str;
        }
    }
}
