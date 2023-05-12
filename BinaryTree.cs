using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//удаление "висящих" узлов
//type T
namespace BinaryTree
{
    internal class BinaryTree
    {
        public Node? Root { get; set; } = null;
        public int Height { get; set; }
        public BinaryTree() { }
        public BinaryTree(int root)
        {
            Root = new Node(root);
        }
        public void Add(int num)
        {
            if (Root == null)
            {
                Root = new Node(num);
                return;
            }
            Node current = Root;
            bool end = false;
            do
            {
                if (num < current.Value)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(num, current);
                        end = true;
                    }
                    else current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(num, current);
                        end = true;
                    }
                    else current = current.Right;
                }
            } while (!end);
        }
        public Node? Search(int n)
        {
            Node? current = Root;
            while (current != null && current.Value != n)
            {
                if (n < current.Value) current = current.Left;
                else if (n > current.Value) current = current.Right;
            }
            return current;
        }
        public void Delete(Node node)
        {
            if (node == null) return;
            if (node == Root)
            {
                DeleteRoot();
                return;
            }
            Node parent = node.Parent!;
            node.Parent = null;
            if (node.Left == null && node.Right == null)
            {
                if (parent.Left == node)
                {
                    parent.Left = null;
                }
                else if (parent.Right == node)
                {
                    parent.Right = null;
                }
                node.Parent = null;
            }
            else if (node.Left == null)
            {
                if (parent.Left == node)
                {
                    parent.Left = node.Right;
                }
                else if (parent.Right == node)
                {
                    parent.Right = node.Right;
                }
                node.Right!.Parent = parent;
                node.Right = null;
                node.Parent = null;
            }
            else if (node.Right == null)
            {
                if (parent.Left == node)
                {
                    parent.Left = node.Left;
                }
                else if (parent.Right == node)
                {
                    parent.Right = node.Left;
                }
                node.Left.Parent = parent;
                node.Left = null;
                node.Parent = null;
            }
            else
            {
                Node min = node.Right;
                while (min.Left != null)
                {
                    min = min.Left;
                }
                node.Value = min.Value;
                Delete(min);
            }
        }
        private void DeleteRoot()
        {
            if (Root!.Left == null && Root.Right == null)
            {
                Root = null;
            }
            else if (Root.Left == null)
            {
                Root = Root.Right;
                Root!.Parent = null;
            }
            else if (Root.Right == null)
            {
                Root = Root.Left;
                Root.Parent = null;
            }
            else
            {
                Node min = Root.Right;
                while (min.Left != null)
                {
                    min = min.Left;
                }

                Root.Value = min.Value;
                Delete(min);
            }
        }
        public void Preorder()
        {
            if(Root == null) return;

            List<int> preorder = new List<int>();
            Node? current = Root;
            Preorder(current, preorder);

            //Print
            foreach (int node in preorder)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }
        private void Preorder(Node current, List<int> preorder)
        {
            preorder.Add(current.Value);
            if (current.Left != null)
            {
                Preorder(current.Left, preorder);
            }
            if (current.Right != null)
            {
                Preorder(current.Right, preorder);
            }
        }
        public void Inorder()
        {
            if(Root == null) return;

            List<int> inorder = new List<int>();
            Node? current = Root;
            Inorder(current, inorder);

            //Print
            foreach (int node in inorder)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }
        private void Inorder(Node current, List<int> inorder)
        {
            if (current.Left != null)
            {
                Inorder(current.Left, inorder);
            }
            inorder.Add(current.Value);
            if (current.Right != null)
            {
                Inorder(current.Right, inorder);
            }
        }
        public void Postorder()
        {
            if(Root == null) return;

            List<int> postorder = new List<int>();
            Node? current = Root;
            Postorder(current, postorder);

            //Print
            foreach (int node in postorder)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }
        private void Postorder(Node current, List<int> postorder)
        {
            if (current.Left != null)
            {
                Postorder(current.Left, postorder);
            }
            if (current.Right != null)
            {
                Postorder(current.Right, postorder);
            }
            postorder.Add(current.Value);
        }
        public void BFS()
        {
            if(Root == null) return;

            List<List<int?>> tree = new List<List<int?>>();
            tree.Add(new List<int?>());
            Stack<Node> stack = new Stack<Node>();
            CreateTree(stack, Root!, tree);
            List<int> bfs = new List<int>();
            foreach (List<int?> list in tree)
            {
                foreach (int? node in list)
                {
                    if (node != null) bfs.Add((int)node);
                }
            }

            //Print
            foreach (int node in bfs)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();

        }

        public override string ToString()
        {
            if(Root == null) return "";

            List<List<int?>> tree = new List<List<int?>>();
            tree.Add(new List<int?>());
            Stack<Node> stack = new Stack<Node>();
            CreateTree(stack, Root!, tree);
            tree.RemoveAt(tree.Count - 1);
            Height = tree.Count;
            return AddTabs(tree);
        }
        private void CreateTree(Stack<Node> stack, Node current, List<List<int?>> tree)
        {
            stack.Push(current);
            if (tree.Count == stack.Count)
            {
                tree.Add(new List<int?>());
            }
            tree[stack.Count - 1].Add(current.Value);
            if (current.Left != null)
            {
                CreateTree(stack, current.Left, tree);
            }
            else tree[stack.Count].Add(null);
            if (current.Right != null)
            {
                CreateTree(stack, current.Right, tree);
            }
            else tree[stack.Count].Add(null);
            stack.Pop();
        }
        private string AddTabs(List<List<int?>> tree)
        {
            List<StringBuilder> treeForPrint = new List<StringBuilder>();
            for (int i = 0; i < tree.Count; i++)
            {
                treeForPrint.Add(new StringBuilder());
                for (int j = 0; j < tree[i].Count; j++)
                {
                    treeForPrint[i].Append(tree[i][j] + (new string('\t', (int)Math.Pow(2, Height - i))));
                }
            }

            for (int i = 0; i < tree.Count - 1; i++)
            {
                treeForPrint[i].Insert(0, new string('\t', (int)Math.Pow(2, Height - i - 1) - 1));
            }

            string s = "";
            foreach (StringBuilder stringBuilder in treeForPrint)
            {
                s += stringBuilder.ToString() + '\n';
            }
            s=s.Remove(s.Length-1);
            return s;
        }
    }

    internal class Node
    {
        public Node? Parent { get; set; } = null;
        public Node? Left { get; set; } = null;
        public Node? Right { get; set; } = null;
        public int Value { get; set; }
        public Node(int value)
        {
            Value = value;
        }
        public Node(int value, Node parent)
        {
            Value = value;
            Parent = parent;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
