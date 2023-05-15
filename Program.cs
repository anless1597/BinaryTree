namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BinaryTree<int> binaryTree = new BinaryTree<int>();
            //int[] nodes = new int[] { 25, 15, 50, 10, 22, 35, 70, 4, 12, 18, 24, 31, 44, 66, 90 };
            //int[] nodes = new int[] { 25, 15, 50, 22, 35, 70, 18, 24,  31, 44, 66, 90};
             //int[] nodes = new int[] { 25, 15, 50, 35, 70, };
            // int[] nodes = new int[] { 25, 15, 10, 22, 4, 12, 18, 24, };
              BinaryTree<string> binaryTree = new BinaryTree<string>();
              string[] nodes = new string[] {"b", "bb", "bbb", "a", "c", "ba"};
            
            foreach (var i in nodes)
            {
                binaryTree.Add(i);
            }
            Console.WriteLine("start print");
            Console.WriteLine(binaryTree);
            //binaryTree.Search("bc").Info();

            // binaryTree.Inorder();
            // binaryTree.Preorder();
            // binaryTree.Postorder();
            // binaryTree.BFS();
            Console.WriteLine("end");

            
        }
    }
}