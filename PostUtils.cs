using System;
using System.Collections.Generic;

namespace PA1_cdkunkel1
{
    public class PostUtils
    {
        //Prints all the posts to the user
        public static void PrintAllPosts(List<Post> posts)
        {
            foreach(Post post in posts) 
            {
                Console.WriteLine(post.ToString());
            }
        }
    }
}