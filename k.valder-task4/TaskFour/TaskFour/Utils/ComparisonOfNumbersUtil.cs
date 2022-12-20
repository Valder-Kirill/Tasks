using System;

namespace TaskFour.Utils
{
    public static class ComparisonOfNumbersUtil
    {
        public static string[] Get(string[] id)
        {
            string[] rez = new string[Convert.ToInt32(GetDataUtil.Get(@"ComparisonOfNumbers", "count"))];
            int n = 0;
            for (int i = 0; i < id.Length; i++)
            {
                if(n < rez.Length && id[i] != null)
                for (int j = 1; j < id[i].Length; j++)
                {
                    if (id[i][j] == id[i][j - 1])
                    {
                        rez[n] = id[i];
                        n++;
                        j = id[i].Length;
                    }
                }
            }
            return rez;
        }
    }
}
