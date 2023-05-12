namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            int[] nodes = new int[] { 25, 15, 50, 10, 22, 35, 70, 4, 12, 18, 24, 31, 44, 66, 90 };
            //int[] nodes = new int[] { 15, 10, 22, 4, 12, 18, 24, };
            foreach (int i in nodes)
            {
                binaryTree.Add(i);
            }
            Console.WriteLine("start print");
            binaryTree.Print();
            Console.WriteLine("end");
        }
    }
}