using System;

namespace TaskOne.Utils
{
    public static class RandomUtil
    {
        private static Random rnd = new Random();

        public static string Pass()
        {
            return Convert.ToString(rnd.Next(100000000, 999999999)) + (char)rnd.Next('A', 'Z');
        }

        public static int DomainOne()
        {
            return rnd.Next(2, 12);
        }

        public static int[] MassRundomInt(int count)
        {
            
            int[] rndMass = new int[count];
            for (int i = 0; i < rndMass.Length; i++)
            {
                
                rndMass[i] = rnd.Next(1, 21);
                for (int j = 0; j < i; j++)
                {
                    if(rndMass[j] == rndMass[i] || rndMass[i] == 18)
                        i--;
                }
            }
            return rndMass;
        }
    }
}