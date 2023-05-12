using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class BinaryTree
    {
        public Node Root { get; set; }
        public int Height { get; set; }
        public BinaryTree(int root)
        {
            Root = new Node(root);
        }

        public void Add(int num)
        {
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

        public void Preorder()
        {
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


        public void Print()
        {
            List<List<int?>> tree = new List<List<int?>>();
            tree.Add(new List<int?>());
            Stack<Node> stack = new Stack<Node>();
            CreateTree(stack, Root, tree);
            tree.RemoveAt(tree.Count - 1);
            Height = tree.Count;
            AddTabs(tree);
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

        private void AddTabs(List<List<int?>> tree)
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

            foreach (StringBuilder stringBuilder in treeForPrint)
            {
                Console.WriteLine(stringBuilder.ToString());
            }
        }

        private void PrintStack(Stack<Node> stack)
        {
            foreach (Node n in stack)
            {
                Console.Write(n.Value + " ");
            }
            Console.WriteLine();
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
    }
}
