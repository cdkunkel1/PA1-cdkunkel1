using System;

namespace PA1_cdkunkel1
{
    public class Post
    {
        public int ID {get; set;}
        public string Text {get; set;}
        public DateTime Datestamp {get; set;}
        
        //Compares by Datestamp for sorting
        public static int CompareByDatestamp(Post x, Post y)
        {
            return y.Datestamp.CompareTo(x.Datestamp);
        }

        //Compares by ID for sorting
        public static int CompareByID(Post x, Post y)
        {
            return x.ID.CompareTo(y.ID);
        }
        
        public override string ToString()
        {
            return "ID: " + this.ID + ", " + this.Text + ", " + this.Datestamp;
        }
        //Writes the post to a file
        public string ToFile()
        {
            return ID + "#" + Text + "#" + Datestamp;
        }
    }
}