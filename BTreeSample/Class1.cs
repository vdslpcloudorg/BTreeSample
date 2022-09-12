//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;
// Commented class 
//namespace BTreeSample
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //BinarySearchTree nums = new BinarySearchTree();
//            //nums.Insert(50);
//            //nums.Insert(17);
//            //nums.Insert(23);
//            //nums.Insert(12);
//            //nums.Insert(19);
//            //nums.Insert(54);
//            //nums.Insert(9);
//            //nums.Insert(14);
//            //nums.Insert(67);
//            //nums.Insert(76);
//            //nums.Insert(72);

//            BinaryTree binaryTree = new BinaryTree();

//            binaryTree.Add(1);
//            binaryTree.Add(2);
//            binaryTree.Add(7);
//            binaryTree.Add(7);
//            binaryTree.Add(3);
//            binaryTree.Add(10);
//            binaryTree.Add(5);
//            binaryTree.Add(8);
//            binaryTree.Add(-10);
//            binaryTree.Add(-1);
//            binaryTree.Add(-100);
//            binaryTree.Add(100);
//            binaryTree.Add(0);


//            Node node = binaryTree.Find(5);
//            int depth = binaryTree.GetTreeDepth();

//            Console.WriteLine("PreOrder Traversal:");
//            binaryTree.TraversePreOrder(binaryTree.Root);
//            Console.WriteLine();

//            Console.WriteLine("InOrder Traversal:");
//            binaryTree.TraverseInOrder(binaryTree.Root);
//            Console.WriteLine();

//            Console.WriteLine("PostOrder Traversal:");
//            binaryTree.TraversePostOrder(binaryTree.Root);
//            Console.WriteLine();

//            binaryTree.Remove(7);
//            binaryTree.Remove(8);

//            Console.WriteLine("PreOrder Traversal After Removing Operation:");
//            binaryTree.TraversePreOrder(binaryTree.Root);
//            Console.WriteLine();

//            Console.WriteLine("Min value in BTree:");
//            Console.WriteLine(binaryTree.GetMinValue());

//            Console.WriteLine("Max value in BTree:");
//            Console.WriteLine(binaryTree.GetMaxValue());


//            Console.ReadLine();
//        }


//    }

//    //public class BinarySearchTree
//    //{

//    //    public class Node
//    //    {
//    //        public int Data;
//    //        public Node Left;
//    //        public Node Right;
//    //        public void DisplayNode()
//    //        {
//    //            Console.Write(Data + " ");
//    //        }
//    //    }
//    //    public Node root;
//    //    public BinarySearchTree()
//    //    {
//    //        root = null;
//    //    }
//    //    public void Insert(int i)
//    //    {
//    //        Node newNode = new Node();
//    //        newNode.Data = i;
//    //        if (root == null)
//    //            root = newNode;
//    //        else
//    //        {
//    //            Node current = root;
//    //            Node parent;
//    //            while (true)
//    //            {
//    //                parent = current;
//    //                if (i < current.Data)
//    //                {
//    //                    current = current.Left;
//    //                    if (current == null)
//    //                    {
//    //                        parent.Left = newNode;
//    //                        break;
//    //                    }

//    //                    else
//    //                    {
//    //                        current = current.Right;
//    //                        if (current == null)
//    //                        {
//    //                            parent.Right = newNode;
//    //                            break;
//    //                        }
//    //                    }
//    //                }
//    //            }
//    //        }
//    //    }
//    //}


//    public class Node
//    {
//        public Node LeftNode { get; set; }
//        public Node RightNode { get; set; }
//        public int Data { get; set; }
//        public int Count { get; set; }
//    }

//    public class BinaryTree
//    {
//        public Node Root { get; set; }

//        public bool Add(int value)
//        {
//            Node before = null, after = this.Root;

//            while (after != null)
//            {
//                before = after;
//                if (value < after.Data) //Is new node in left tree? 
//                    after = after.LeftNode;
//                else if (value > after.Data) //Is new node in right tree?
//                    after = after.RightNode;
//                else
//                {
//                    //Exist same value
//                    after.Count++;
//                    return false;
//                }
//            }

//            Node newNode = new Node();
//            newNode.Data = value;
//            newNode.Count = 1;

//            if (this.Root == null)//Tree ise empty
//                this.Root = newNode;
//            else
//            {
//                if (value < before.Data)
//                    before.LeftNode = newNode;
//                else
//                    before.RightNode = newNode;
//            }

//            return true;
//        }

//        public Node Find(int value)
//        {
//            return this.Find(value, this.Root);
//        }

//        public void Remove(int value)
//        {
//            this.Root = Remove(this.Root, value);
//        }

//        private Node Remove(Node parent, int key)
//        {
//            if (parent == null) return parent;

//            if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
//            else if (key > parent.Data)
//                parent.RightNode = Remove(parent.RightNode, key);

//            // if value is same as parent's value, then this is the node to be deleted  
//            else
//            {
//                // node with only one child or no child  
//                if (parent.LeftNode == null)
//                    return parent.RightNode;
//                else if (parent.RightNode == null)
//                    return parent.LeftNode;

//                // node with two children: Get the inorder successor (smallest in the right subtree)  
//                parent.Data = MinValue(parent.RightNode);

//                // Delete the inorder successor  
//                parent.RightNode = Remove(parent.RightNode, parent.Data);
//            }

//            return parent;
//        }

//        public int GetMinValue()
//        {
//            Node node = this.Root;
//            int minv = node.Data;

//            while (node.LeftNode != null)
//            {
//                minv = node.LeftNode.Data;
//                node = node.LeftNode;
//            }

//            return minv;
//        }

//        public int GetMaxValue()
//        {
//            Node node = this.Root;
//            int maxv = node.Data;

//            while (node.RightNode != null)
//            {
//                maxv = node.RightNode.Data;
//                node = node.RightNode;
//            }

//            return maxv;
//        }

//        private int MinValue(Node node)
//        {
//            int minv = node.Data;

//            while (node.LeftNode != null)
//            {
//                minv = node.LeftNode.Data;
//                node = node.LeftNode;
//            }

//            return minv;
//        }

//        private int MaxValue(Node node)
//        {
//            int maxv = node.Data;

//            while (node.RightNode != null)
//            {
//                maxv = node.RightNode.Data;
//                node = node.RightNode;
//            }

//            return maxv;
//        }

//        private Node Find(int value, Node parent)
//        {
//            if (parent != null)
//            {
//                if (value == parent.Data) return parent;
//                if (value < parent.Data)
//                    return Find(value, parent.LeftNode);
//                else
//                    return Find(value, parent.RightNode);
//            }

//            return null;
//        }

//        public int GetTreeDepth()
//        {
//            return this.GetTreeDepth(this.Root);
//        }

//        private int GetTreeDepth(Node parent)
//        {
//            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
//        }

//        public void TraversePreOrder(Node parent)
//        {
//            if (parent != null)
//            {
//                Console.Write(parent.Data + " ");
//                TraversePreOrder(parent.LeftNode);
//                TraversePreOrder(parent.RightNode);
//            }
//        }

//        public void TraverseInOrder(Node parent)
//        {
//            if (parent != null)
//            {
//                TraverseInOrder(parent.LeftNode);
//                Console.Write(parent.Data + " ");
//                TraverseInOrder(parent.RightNode);
//            }
//        }

//        public void TraversePostOrder(Node parent)
//        {
//            if (parent != null)
//            {
//                TraversePostOrder(parent.LeftNode);
//                TraversePostOrder(parent.RightNode);
//                Console.Write(parent.Data + " ");
//            }
//        }
//    }
//}
