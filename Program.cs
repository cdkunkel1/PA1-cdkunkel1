using System;
using System.Collections.Generic;

namespace PA1_cdkunkel1
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuChoice = 0;
            List<Post> posts = PostFile.GetPosts();
            while (menuChoice != 4)
            {
                DisplayMenu();
                try 
                {
                    menuChoice = GetInt();
                    CheckChoice(menuChoice);
                }
                catch(Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
                finally
                {
                    SelectMenuOption(menuChoice, posts);
                }
        }

        static void DisplayMenu()
        {
            System.Console.WriteLine("Please enter a number from the menu\n");
            System.Console.WriteLine("1. Display All Posts");
            System.Console.WriteLine("2. Add a Post");
            System.Console.WriteLine("3. Delete a Post");
            System.Console.WriteLine("4. Exit\n");
        }

        static int GetInt() 
        {
            return int.Parse(Console.ReadLine());
        }
        
        static void CheckChoice(int menuChoice)
        {
            if (menuChoice < 1 || menuChoice > 4)
            {
                throw new Exception("Not a valid menu choice");
            }
            else 
            {
                Console.Clear();
            }             
        }

        static void SelectMenuOption(int menuChoice, List<Post> posts)
        {
            if (menuChoice == 1) //Prints all posts for the user
            {
                posts.Sort(Post.CompareByDatestamp);
                PostUtils.PrintAllPosts(posts);
                AskToContinue();
            }
            else if (menuChoice == 2) //User adds a new post
            {
                System.Console.WriteLine("What message would you like to post?\n");
                AddMessage(posts);
                AskToContinue();
            }
            else if (menuChoice == 3)
            {
                posts.Sort(Post.CompareByDatestamp);
                PostUtils.PrintAllPosts(posts);
                DeleteMessage(posts);
                AskToContinue();
            }
        }

        static void AddMessage(List<Post> posts)
        {
            string message = "";
            try 
            {
                message = Console.ReadLine(); //Message is input
                posts.Add(new Post(){ID = (posts.Count + 1), Text = message, Datestamp = DateTime.Now}); //ID is based on the count of current messages, datetime takes the current time
                Console.Clear();
                System.Console.WriteLine("Your message has been added"); //Confirm to the user that the message has been added
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        static void DeleteMessage(List<Post> posts)
        {
            Boolean exists = false; //Changes to true if the ID is found
            int userChoice = 0;
            System.Console.WriteLine("\nPlease enter the post ID of the message you would like to delete\n"); //Ask the user for input
            try
            {
                userChoice = GetInt(); //Get the user's choice
                exists = LoopThroughPosts(userChoice, posts);
                if (exists == true) //Exits the function if exists is true
                {
                    Console.Clear();
                    System.Console.WriteLine("The post has been deleted");
                }
                else
                {
                    Console.Clear();
                    System.Console.WriteLine("That ID does not exist");
                } 
            }
            catch(Exception e)
            {
                Console.Clear();
                System.Console.WriteLine(e.Message);
            }
        }

        static Boolean LoopThroughPosts(int userChoice, List<Post> posts)
        {
            Boolean exists = false;
            foreach(Post post in posts) //Loop through each post
            {
                if (userChoice == post.ID) //Checks to see if the ID matches any of the posts
                {
                    posts.Remove(post); //Removes the post and exists becomes true
                    exists = true;
                    return exists; //Exits the loop if the value is found
                }
            }
            return exists;
        }

        static void AskToContinue()
        {
            System.Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
}
