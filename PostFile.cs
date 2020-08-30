using System;
using System.IO;
using System.Collections.Generic;

namespace PA1_cdkunkel1
{
    public class PostFile
    {
        public static List<Post> GetPosts()
        {
            List<Post> Posts = new List<Post>(); //Creates a new list of posts
            StreamReader inFile = null;

            try
            {
                inFile = new StreamReader("input.txt"); //Open the input file
            }
            catch(FileNotFoundException e) //Error handling
            {
                Console.WriteLine("Something went wrong..... returning blank list {0}", e);
                return Posts;
            }

            string line = inFile.ReadLine(); //Priming Read
            while(line != null) //Continues until a null line is read
            {
                string[] temp = line.Split("#"); //Splits the file by #
                int idNumber = int.Parse(temp[0]); //Read in the ID
                DateTime datestamp = DateTime.Parse(temp[2]); //Read in the DateTime
                Posts.Add(new Post(){ID = idNumber, Text = temp[1], Datestamp = datestamp}); //Add the post to the list
                line = inFile.ReadLine(); //Update Read
            }
            inFile.Close(); //Close the file
            
            return Posts;
        }
        //Save the posts back to the file
        public static void SaveAllPosts(List<Post> posts)
        {
            StreamWriter outFile = new StreamWriter("input.txt"); //Open the file

            foreach(Post post in posts) //Loop through each post
            {
                outFile.WriteLine(post.ToFile()); //Use the ToFile() function to format
            }

            outFile.Close(); //Close the file
        }
    }
}