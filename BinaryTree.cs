using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//type T
//Dispose()?
namespace BinaryTree
{
    internal class BinaryTree<T> where T : IComparable<T>
    {
        public Node<T>? Root { get; set; } = null;
        public int Height { get; set; }
        public BinaryTree() { }
        public BinaryTree(T root)
        {
            // var list = new List<Nullable<T>>();
            // list.Add(null);
            Root = new Node<T>(root);
        }
        public void Add(T num)
        {
            if (Root == null)
            {
                Root = new Node<T>(num);
                return;
            }
            Node<T> current = Root;
            bool end = false;
            do
            {
                if (num.CompareTo(current.Value) < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node<T>(num, current);
                        end = true;
                    }
                    else current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node<T>(num, current);
                        end = true;
                    }
                    else current = current.Right;
                }
            } while (!end);
        }
        public Node<T>? Search(T n)
        {
            Node<T>? current = Root;
            while (current != null && current.Value.CompareTo(n) != 0)
            {
                if (n.CompareTo(current.Value) < 0) current = current.Left;
                else if (n.CompareTo(current.Value) > 0) current = current.Right;
            }
            return current;
        }
        public void Delete(Node<T> node)
        {
            if (node == null) return;
            if (node == Root)
            {
                DeleteRoot();
                return;
            }
            Node<T> parent = node.Parent!;
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
                Node<T> min = node.Right;
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
                Node<T> min = Root.Right;
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
            if (Root == null) return;

            List<T> preorder = new List<T>();
            Node<T>? current = Root;
            Preorder(current, preorder);

            //Print
            foreach (T node in preorder)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }
        private void Preorder(Node<T> current, List<T> preorder)
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
            if (Root == null) return;

            List<T> inorder = new List<T>();
            Node<T>? current = Root;
            Inorder(current, inorder);

            //Print
            foreach (T node in inorder)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }
        private void Inorder(Node<T> current, List<T> inorder)
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
            if (Root == null) return;

            List<T> postorder = new List<T>();
            Node<T>? current = Root;
            Postorder(current, postorder);

            //Print
            foreach (T node in postorder)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }
        private void Postorder(Node<T> current, List<T> postorder)
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
            if (Root == null) return;

            List<List<object?>> tree = new List<List<object?>>();
            tree.Add(new List<object?>());
            Stack<Node<T>> stack = new Stack<Node<T>>();
            CreateTree(stack, Root!, tree);
            List<T> bfs = new List<T>();
            foreach (List<object?> list in tree)
            {
                foreach (object? node in list)
                {
                    if (node != null) bfs.Add((T)node);
                }
            }

            //Print
            foreach (T node in bfs)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();

        }

        public override string ToString() //Uncorrect work
        {
            if (Root == null) return "";

            List<List<object?>> tree = new List<List<object?>>();
            tree.Add(new List<object?>());
            Stack<Node<T>> stack = new Stack<Node<T>>();
            CreateTree(stack, Root!, tree);
            tree.RemoveAt(tree.Count - 1);
            Height = tree.Count;
            return AddTabs(tree);
        }
        private void CreateTree(Stack<Node<T>> stack, Node<T> current, List<List<object?>> tree)
        {
            stack.Push(current);
            if (tree.Count == stack.Count)
            {
                tree.Add(new List<object?>());
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
        private string AddTabs(List<List<object?>> tree) //Uncorrect work
        {
            List<StringBuilder> treeForPrint = new List<StringBuilder>();
            for (int i = 0; i < tree.Count; i++)
            {
                treeForPrint.Add(new StringBuilder());
                int tabCount = (int)Math.Pow(2, Height - i);
                for (int j = 0; j < tree[i].Count; j++)
                {
                    treeForPrint[i].Append(tree[i][j] + (new string('\t', tabCount)));
                }
                treeForPrint[i].Insert(0, new string('\t', (int)Math.Pow(2, Height)+ tabCount/2-1- tree[i].Count*tabCount));
            }

            // for (int i = 0; i < tree.Count - 1; i++)
            // {
            // }

            string s = "";
            foreach (StringBuilder stringBuilder in treeForPrint)
            {
                s += stringBuilder.ToString() + '\n';
            }
            s = s.Remove(s.Length - 1);
            return s;
        }
    }

    internal class Node<T> where T : IComparable<T>
    {
        public Node<T>? Parent { get; set; } = null;
        public Node<T>? Left { get; set; } = null;
        public Node<T>? Right { get; set; } = null;
        public T Value { get; set; }
        public Node(T value)
        {
            Value = value;
        }
        public Node(T value, Node<T> parent)
        {
            Value = value;
            Parent = parent;
        }
        public override string ToString()
        {
            return Value.ToString()!;
        }
        public int CompareTo(object? o)
        {
            if (o is Node<T> node) return Value.CompareTo(node.Value);
            else throw new Exception("object's types are not the same");
        }
        public void Info()
        {
            Console.WriteLine($"{Parent}\n{Value}\n{Left} {Right}");
        }

    }
}
