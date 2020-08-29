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
                    menuChoice = GetMenuChoice();
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

        static int GetMenuChoice() 
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
            if (menuChoice == 1)
            {
                PostUtils.PrintAllPosts(posts);
            }
            else if (menuChoice == 2)
            {
               System.Console.WriteLine("Howdy");
            }
            else if (menuChoice == 3)
            {
                System.Console.WriteLine("Esketit");
            }
        }
    }
}
}
