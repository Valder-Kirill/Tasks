using System.Collections.Generic;

namespace TaskTwo.Utils
{
    public static class ASCCheckUtil
    {
        public static bool ASCCheck(List<Post> posts)
        {
            for (int i = 1; i < posts.Count; i++)
            { 
                if(posts[i-1].Id > posts[i].Id)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
