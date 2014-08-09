namespace _01.Tree
{
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public TreeNode()
        {
            this.Children = new List<TreeNode<T>>();
        }

        public TreeNode(T value)
            :this()
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public List<TreeNode<T>> Children { get; private set; }

        public bool HasParent { get; set; }

        public void AddChild(TreeNode<T> child)
        {
            this.Children.Add(child);
            child.HasParent = true;
        }
    }
}
