using System;
using System.IO;
using System.Collections.Generic;

namespace PA1_cdkunkel1
{
    public class PostFile
    {
        public static List<Post> GetPosts()
        {
            List<Post> Posts = new List<Post>();
            StreamReader inFile = null;

            try
            {
                inFile = new StreamReader("input.txt");
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Something went wrong..... returning blank list {0}", e);
                return Posts;
            }

            string line = inFile.ReadLine(); //Priming Read
            while(line != null) 
            {
                string[] temp = line.Split("#");
                int idNumber = int.Parse(temp[0]);
                DateTime datestamp = DateTime.Parse(temp[2]);
                Posts.Add(new Post(){ID = idNumber, Text = temp[1], Datestamp = datestamp});
                line = inFile.ReadLine(); //Update Read
            }
            inFile.Close();
            
            return Posts;
        }
    }
}