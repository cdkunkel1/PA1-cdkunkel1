using System;

namespace PA1_cdkunkel1
{
    public class Post
    {
        public int ID {get; set;}
        public string Text {get; set;}
        public DateTime Datestamp {get; set;}
        
        public static int CompareByDatestamp(Post x, Post y)
        {
            return x.Datestamp.CompareTo(y.Datestamp);
        }
        
        public override string ToString()
        {
            return "ID: " + this.ID + ", " + this.Text + ", " + this.Datestamp;
        }
    }
}