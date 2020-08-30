using System;
using System.Collections.Generic;

namespace PA1_cdkunkel1
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuChoice = 0;
            List<Post> posts = PostFile.GetPosts(); //Reads the posts from a file
            while (menuChoice != 4) //Runs until the user inputs 4 to exit
            {
                DisplayMenu();
                try 
                {
                    menuChoice = GetInt(); //User selects an option from the menu
                    CheckChoice(menuChoice);
                }
                catch(Exception e) //Occurs if user choice is invalid
                {
                    System.Console.WriteLine(e.Message);
                }
                finally //Checks the menu options regardless
                {
                    SelectMenuOption(menuChoice, posts);
                }
        }

        //Displays a menu of options to the user
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
            return int.Parse(Console.ReadLine()); //Parses user input to an integer
        }
        
        //Checks to see if the user selected 1-3
        static void CheckChoice(int menuChoice)
        {
            if (menuChoice < 1 || menuChoice > 4)
            {
                throw new Exception("Not a valid menu choice"); //Throws an error if the user did not input a valid menu choice
            }
            else 
            {
                Console.Clear();
            }             
        }

        //Selects a function based on the user's menu choice
        static void SelectMenuOption(int menuChoice, List<Post> posts)
        {
            if (menuChoice == 1) //Prints all posts for the user
            {
                posts.Sort(Post.CompareByDatestamp); //Sorts the posts by datestamp
                PostUtils.PrintAllPosts(posts); //Prints all posts
                AskToContinue();
            }
            else if (menuChoice == 2) //User adds a new post
            {
                System.Console.WriteLine("What message would you like to post?\n");
                AddMessage(posts); //Gets and adds the user's message
                AskToContinue();
            }
            else if (menuChoice == 3) //User deletes a post
            {
                posts.Sort(Post.CompareByDatestamp); //Sorts posts by datestamp
                PostUtils.PrintAllPosts(posts); //Prints all posts for user to pick from
                DeleteMessage(posts); //User selects and deletes a message
                AskToContinue();
            }
        }

        //Used to add a post
        static void AddMessage(List<Post> posts)
        {
            string message = "";
            try 
            {
                message = Console.ReadLine(); //Message is input from the user
                posts.Add(new Post(){ID = (posts.Count + 1), Text = message, Datestamp = DateTime.Now}); //ID is based on the count of current messages, datetime takes the current time
                Console.Clear();
                System.Console.WriteLine("Your message has been added"); //Confirm to the user that the message has been added
            }
            catch(Exception e) //Error handling
            {
                System.Console.WriteLine(e.Message);
            }
        }

        //Used to delete one of the posts based on ID
        static void DeleteMessage(List<Post> posts)
        {
            Boolean exists = false; //Changes to true if the ID is found
            int userChoice = 0;
            System.Console.WriteLine("\nPlease enter the post ID of the message you would like to delete\n"); //Ask the user for input
            try
            {
                userChoice = GetInt(); //Get the user's choice
                exists = LoopThroughPosts(userChoice, posts); //Checks to see if the ID exists
                if (exists == true) //Exits the function if a value is found and deleted
                {
                    Console.Clear();
                    System.Console.WriteLine("The post has been deleted");
                }
                else //Occurs if a matching ID is not found
                {
                    Console.Clear();
                    System.Console.WriteLine("That ID does not exist");
                } 
            }
            catch(Exception e) //Error handling
            {
                Console.Clear();
                System.Console.WriteLine(e.Message);
            }
        }

        //Loops through the posts to find a matching ID, and deletes if found
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
            return exists; //Returns false if the value is not found
        }

        //Useful for clearing the screen
        static void AskToContinue()
        {
            System.Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
}
