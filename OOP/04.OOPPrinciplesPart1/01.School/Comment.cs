using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Comment
    {
        private List<string> comments;

        public Comment()
        {
            this.comments = new List<string>();
        }
        public List<string> Comments
        {
            get { return this.comments; }
        }
        public void AddComment(string comment)
        {
            bool exist = this.comments.Contains(comment);

            if (!exist)
            {
                this.comments.Add(comment);
            }
        }
        public void RemoveComment(string comment)
        {
            bool exist = this.comments.Contains(comment);

            if (exist)
            {
                this.comments.Remove(comment);
            }
        }
        public void RemoveFirstComment()
        {
            if (this.comments.Count > 0)
            {
                this.comments.RemoveAt(0);
            }
            else
            {
                throw new IndexOutOfRangeException("There is no comment to remove at first position!");
            }
        }
        public void RemoveLastComment()
        {
            if (this.comments.Count > 0)
            {
                this.comments.RemoveAt(this.comments.Count - 1);
            }
            else
            {
                throw new IndexOutOfRangeException("There is no comment to remove at last position!");
            }
        }
        public void RemoveCommentAt(int position)
        {
            if (position >= 0 && position < this.comments.Count)
            {
                this.comments.RemoveAt(position);
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid position for removing comment!");
            }
        }
        public void ClearAllComments()
        {
            this.comments.Clear();
        }
        public void ShowComments()
        {
            foreach (string comment in this.comments)
            {
                Console.WriteLine(comment);
            }
        }
    }
}
