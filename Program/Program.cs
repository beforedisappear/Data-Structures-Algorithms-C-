using System;
using ASID;
namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Basic Algorithms
            Console.WriteLine("Test Basic Algorithms:\n");
            int n = 6, d = 2;
            string str = "123";
            int a = 36, b = 48;
            Console.WriteLine("Fibo({0}) = {1}", n, ASD.Fibo(n));
            Console.WriteLine("Fibo({0}) = {1}", n, ASD.FiboR(n));
            Console.WriteLine("Fibo({0}) = {1}", n, ASD.FiboArray(n));
            Console.WriteLine("{0} convert to {1}'NS'= {2}", n, d, ASD.IntConvert(n, d));
            Console.WriteLine("String to Int = {0}", ASD.ConvertStringToInt(str));
            Console.WriteLine("NOD({0},{1})= {2}", a, b, ASD.NOD(a, b));
            Console.WriteLine("{0} is simple : {1}",n, ASD.BoolTestSimple(n));
            Console.WriteLine("{0} is PolDel:", ASD.PolDel(0.0, 3.0, 0.0001, x => x * x - 1.0));
            Console.WriteLine("GoldMin is {0}", ASD.GoldMin(-4.0, 0.0, 0.0001, x => 2.0 * x * x + 12.0 * x));
            Console.ReadKey();

            #endregion
            #region Sets and Sorting
            // Test Sets
            Console.WriteLine("\nTest Set:\n");

            int[] a01 = { 4, 2, 2, 8, 3, 3, 1 };
            int[] a02 = { 121, 432, 564, 23, 1, 45, 788 };
            double[] a03 = { 0.42, 0.32, 0.23, 0.52, 0.25, 0.47, 0.51 }; // double example
            double[] a04 = { 21, 9, 3, 11, 16 };                         // int example
            int[] a1 = { 5, -3, 4, 1 };
            int[] a2 = { 3, 4, 1, -6, 9 };
            int[] a3 = { 2, 1, 8, 4, 14, 7 };
            int[] a4 = { 44, 55, 12, 42, 94, 18, 6, 67 };
            int[] a5 = { 8, 2, 3, 1, 5, 4, 6, 7 };
            int[] a6 = { 7, -2, 4, 1, 6, 5, 0, -4, 2 };
            int[] a7 = { 8, 7, 1, 3, 5, 2, 4, 6 };
            int[] a8 = { 1, 2, 3 };
            int[] a9 = { 1, 2, 3, 4, 5, 6, 7 };
            int[] a10 = { -2, 7, 15, -14, 0, 15, 0, 7, -7, -4, -13, 5, 8, -14, 12, 4 };
            string[] mas = { "a", "b" , "c" };
            string[] ss = { "Misha", "Kolya", "Vasya" };


            Set<int> s1 = new Set<int>(a1);
            Set<int> s2 = new Set<int>(a2);
            Set<int> s3 = Set<int>.Union(s1, s2); // создание нового множества 
            Set<int> s4 = Set<int>.Intersection(s1, s2);  // пересечение 
            Set<int> s5 = new Set<int>(a8);
            Set<int> s6 = new Set<int>(a9);
            Set<int> s7 = Set<int>.Addition(s6, s5); // дополнение s5 до s6 (s6-s5)
            Set<string> strs = new Set<string>(ss);
            List<Set<string>> lsname = strs.SelectSets();
            Set<string> s8 = new Set<string>(mas);

            Console.WriteLine("s3 : s1 {0} union s2 {1} = {2}", s1, s2, s3);
            Console.WriteLine("s4 : s1 {0} intersection s2 {1} = {2}", s1, s2, s4);
            Console.WriteLine("s7 : s5 {0} addition s6 {1} = {2}", s5, s6, s7);
            Console.WriteLine("s1 contains 1 ? : {0}",s1.Contains(1));
            Console.WriteLine("get index by el 4 from s1 : {0} ", s1.GetIndex(4));
            Console.WriteLine("remove el by index 4 from s2 : {0}", s2.RemoveInd(4));
            Console.WriteLine("remove el 5 from s2 : {0}", s2.RemoveEL(5));
            Console.WriteLine("get el by index 0 from s2 : {0}", s2.GetElementByIndex(0));
            Console.WriteLine("set new el {0} by index 0 : {1} ", s2.SetElementByIndex(0, 2), s2);
            Console.WriteLine("Получение набора множеств из последовательности элементов множества:");
            foreach (Set<string> cors in lsname) Console.WriteLine(cors);
            Console.WriteLine("all subsets of set s6:");
            s8.Allsubsets(mas);
            Console.WriteLine();
            Console.ReadKey();

            // Test Sorting

            Console.WriteLine("\nTest Sort:\n");
            MySort.CountSort(a01);
            Console.Write("CountSort of a01:");
            for (int i = 0; i < a01.Length; i++)
            {
                Console.Write(" {0}", a01[i]);
            }
            Console.WriteLine();
            MySort.RadixSort(a02);
            Console.Write("RadixSort of a02:");
            for (int i = 0; i < a02.Length; i++)
            {
                Console.Write(" {0}", a02[i]);
            }
            Console.WriteLine();
            MySort.BucketSort(a03);
            Console.Write("BucketSort of a03:");
            for (int i = 0; i < a03.Length; i++)
            {
                Console.Write(" {0}", a03[i]);
            }
            Console.WriteLine();
            MySort.BucketSort(a04);
            Console.Write("BucketSort of a04:");
            for (int i = 0; i < a04.Length; i++)
            {
                Console.Write(" {0}", a04[i]);
            }
            Console.WriteLine();
            MySort.BubbleSort(a1);
            Console.Write("BubbleSort of a1:");
            for (int i = 0; i < a1.Length; i++)
            {
                Console.Write(" {0}", a1[i]);
            }
            Console.WriteLine();
            MySort.SelectionSort(a2);
            Console.Write("SelectionSort of a2:");
            for (int i = 0; i < a2.Length; i++)
            {
                Console.Write(" {0}", a2[i]);
            }
            Console.WriteLine();
            MySort.InsertionSort(a3);
            Console.Write("InsertionSort of a3:");
            for (int i = 0; i < a3.Length; i++)
            {
                Console.Write(" {0}", a3[i]);
            }
            Console.WriteLine();
            MySort.ShakerSort(a4);
            Console.Write("ShakerSort of a4:");
            for (int i = 0; i < a4.Length; i++)
            {
                Console.Write(" {0}", a4[i]);
            }
            Console.WriteLine();
            MySort.ShellSort(a5);
            Console.Write("ShellSort of a5:");
            for (int i = 0; i < a5.Length; i++)
            {
                Console.Write(" {0}", a5[i]);
            }
            Console.WriteLine();
            Console.WriteLine("BinSearch '6' of a5: {0}", MySort.BinSearch(a5,6));
            MySort.QuickSort(a6,0,a6.Length-1);
            Console.Write("QuickSort of a6:");
            for (int i = 0; i < a6.Length; i++)
            {
                Console.Write(" {0}", a6[i]);
            }
            Console.WriteLine();
            MySort.MergeSort(a7, 0, a7.Length - 1);
            Console.Write("MergeSort of a7:");
            for (int i = 0; i < a7.Length; i++)
            {
                Console.Write(" {0}", a7[i]);
            }
            Console.WriteLine();
            MySort.TimSort(a10);
            Console.Write("TimSort of a7:");
            for (int i = 0; i < a10.Length; i++)
            {
                Console.Write(" {0}", a10[i]);
            }
            Console.WriteLine();
            Console.ReadKey();
            #endregion
            #region ⠀⠀⠀Collections⠀⠀
            // Test Single Linked list
            Console.WriteLine("\nTest LinkedList:\n");

            SingleList<string> Slist = new SingleList<string>();

            Slist.AddHead(0, "A");
            Slist.AddEnd(1, "B");
            Slist.AddEnd(2, "C");
            Slist.AddEnd(3, "D");
            Slist.AddEnd(4, "E");
            Slist.AddEnd(5, "F");
            Slist.AddEnd(6, "G");
            Slist.AddEnd(7, "X");
            Slist.AddEnd(8, "Y");
            Slist.AddEnd(9, "Z");
            Slist.View();
            Console.WriteLine();


            Console.WriteLine("Поиск D {0}", Slist.FindByValue("D"));
            Console.WriteLine("Поиск E {0}", Slist.FindByKey(4));
            Console.WriteLine("Поиск X {0}", Slist.FindByIndex(7));
            Console.WriteLine("Содержит ли S ? {0}",Slist.IsContainsByValue("S"));
            Console.WriteLine("Содержит ли Y ? {0}\n", Slist.IsContainsByValue("Y"));

            Console.WriteLine("Remove node with index 7, value B, key 6, head, end :");
            Slist.RemoveByIndex(7);
            Slist.RemoveByValue("B");
            Slist.RemoveByKey(6);
            Slist.RemoveHead();
            Slist.RemoveEnd();
            Slist.View();

            Slist.InsertByAfterValue("C", 8,"new");
            Slist.InsertByBeforeValue("Y", 8, "NEW");
            Slist.View();

            Console.WriteLine();
            // Test Double Linked list
            DoubleList<string> Dlist = new DoubleList<string>();

            Dlist.AddHead(0, "A");
            Dlist.AddEnd(1, "B");
            Dlist.AddEnd(2, "C");
            Dlist.AddEnd(3, "D");
            Dlist.AddEnd(4, "E");
            Dlist.AddEnd(5, "F");
            Dlist.AddEnd(6, "G");
            Dlist.AddEnd(7, "X");
            Dlist.AddEnd(8, "Y");
            Dlist.AddEnd(9, "Z");
            Dlist.ViewForward();
            Dlist.ViewBack();
            Console.WriteLine();

            Console.WriteLine("Поиск D {0}", Dlist.FindByValue("D"));
            Console.WriteLine("Поиск E {0}", Dlist.FindByKey(4)); ;
            Console.WriteLine("Поиск X {0}\n", Dlist.FindByIndex(7));

            Console.WriteLine("Remove node with index 7, value E, key 6, head, end :");
            Dlist.RemoveByIndex(7);
            Dlist.RemoveByValue("E");
            Dlist.RemoveByKey(6);
            Dlist.RemoveHead();
            Dlist.RemoveEnd();
            Dlist.ViewForward();
            Dlist.ViewBack();

            Dlist.InsertByAfterValue("Y", 9, "new");
            Dlist.InsertByBeforeValue("Y", 7, "NEW");
            Dlist.ViewForward();

            Console.WriteLine();
            Console.ReadKey();
            #endregion
            #region ⠀⠀⠀HashTables⠀⠀⠀
            Console.WriteLine("\nTest HashTableArray:\n");

            HTArray<string> hashTableArray = new HTArray<string>(6);
            hashTableArray.View();
            Console.WriteLine();

            hashTableArray.Add(32, "fffff33333");
            hashTableArray.Add(3, "vvvver132");
            hashTableArray.Add(17, "cccd");
            hashTableArray.Add(11001, "jhjhjkl");
            hashTableArray.Add(444, "saweadsds");
            hashTableArray.Add(777, "asdsad");
            hashTableArray.Add(770, "asdsad");
            hashTableArray.View();
            Console.WriteLine();

            Console.WriteLine("Search cell by key 32 is : {0}", hashTableArray.SearchByKey(32));
            Console.WriteLine("Search index by key 777 is : {0}\n", hashTableArray.SearchIndex(777));

            hashTableArray.RemoveByKey(777);
            hashTableArray.RemoveByKey(11001);
            hashTableArray.View();
            Console.WriteLine();
            
            Console.ReadKey();

            Console.WriteLine("\nTest HashTableList:\n");
            
            HTList<string> hashTableList = new HTList<string>(6);
            hashTableList.View();
            Console.WriteLine();

            hashTableList.Adds(32, "fffff33333");
            hashTableList.Adds(3, "vvvver132");
            hashTableList.Adds(17, "cccd");
            hashTableList.Adds(202, "jhjhjkl");
            hashTableList.Adds(444, "saweadsds");
            hashTableList.Adds(544, "new");
            hashTableList.Adds(1033, "asdsad");
            hashTableList.View();
            Console.WriteLine();

            Console.WriteLine("Search by key 202 is : {0}\n", hashTableList.SearchByKey(202));
            Console.WriteLine("Remove el by key 202 and resize ht to size 8: ");
            hashTableList.RemoveByKey(202); // удаление 202 и 544 из одной ячейки
            hashTableList.RemoveByKey(544);
            hashTableList.View();
            Console.WriteLine();
            hashTableList.Resize(8);
            hashTableList.View();
            Console.ReadKey();

            #endregion
            #region ⠀⠀⠀Binary Tree⠀⠀
            Console.WriteLine("\nTest Binary Tree:\n");

            BinaryTree<string> BinaryTree = new BinaryTree<string>(); // создание дерева

            BinaryTree.AddNodeInTree(10, "Root"); // создание корня дерева
            BinaryTree.AddNodeInTree(15, "Right");
            BinaryTree.AddNodeInTree(5, "Left");
            BinaryTree.AddNodeInTree(20, "RightRight");
            BinaryTree.AddNodeInTree(25, "RightRightRight");
            BinaryTree.AddNodeInTree(18, "RightRightLeft");
            BinaryTree.AddNodeInTree(19, "RightRIghtLeftRight");
            BinaryTree.AddNodeInTree(14, "RightLeft");
            BinaryTree.AddNodeInTree(1, "LeftLeft");
            BinaryTree.AddNodeInTree(7, "LeftRight");
            BinaryTree.AddNodeInTree(8, "LeftRightRight");
           

            Console.WriteLine("Узлы дерева BinaryTree по возрастанию");
            BinaryTree.ViewAscending(BinaryTree.root);
            Console.WriteLine();

            Console.WriteLine("Узлы дерева BinaryTree по убыванию");
            BinaryTree.ViewDescending(BinaryTree.root);
            Console.WriteLine();

            Console.WriteLine("Узлы дерева BinaryTree в прямом порядке");
            BinaryTree.ViewOrder(BinaryTree.root);
            Console.WriteLine();

            Console.WriteLine("Search Node in BinaryTree by key 7 : {0}", BinaryTree.Search(7));
            Console.WriteLine("Search Node in BinaryTree by key 666 : {0}", BinaryTree.Search(666));
            Console.WriteLine("Minimal Node in BinaryTree is : {0}", BinaryTree.MinNode(BinaryTree.root));
            Console.WriteLine("Maximal Node in BinaryTree is : {0}", BinaryTree.MaxNode(BinaryTree.root));
            Console.WriteLine();

            BinaryTree.DeleteNode(15);
            Console.WriteLine("After delete node with key = 15: ");
            BinaryTree.ViewAscending(BinaryTree.root);
            Console.WriteLine();


            Console.WriteLine("\n___AVL tree___\n");

            // left rotation
            AVLTree<string> AVLtree1 = new AVLTree<string>();
            AVLtree1.AddNode(5, "Root");
            AVLtree1.AddNode(1, "Left");
            AVLtree1.AddNode(9, "Right");
            AVLtree1.AddNode(6, "RightLeft");
            AVLtree1.AddNode(11, "RightRight");
            AVLtree1.AddNode(10, "RightRightLeft");
            AVLtree1.AddNode(12, "RightRightRight");

            Console.WriteLine("unbalanced tree :\n");
            AVLtree1.View(AVLtree1.root);

            Console.WriteLine("\nAVL TREE after balancing (Left rotation) :");
            AVLtree1.root = AVLtree1.balance(AVLtree1.root);
            AVLtree1.View(AVLtree1.root);

            // right rotation 
            AVLTree<string> AVLtree2 = new AVLTree<string>();
            AVLtree2.AddNode(11, "Root");
            AVLtree2.AddNode(12, "Right");
            AVLtree2.AddNode(9, "Left");
            AVLtree2.AddNode(10, "LeftRight");
            AVLtree2.AddNode(5, "LeftLeft");
            AVLtree2.AddNode(6, "LeftLeftRight");
            AVLtree2.AddNode(1, "LeftLeftLeft");

            Console.WriteLine("\n\nunbalanced tree :\n");
            AVLtree2.View(AVLtree2.root);

            Console.WriteLine("\nAVL TREE after balancing (Right rotation) :");
            AVLtree2.root = AVLtree2.balance(AVLtree2.root);
            AVLtree2.View(AVLtree2.root);


            // right left 
            AVLTree<string> AVLtree4 = new AVLTree<string>();
            AVLtree4.AddNode(10, "Root");
            AVLtree4.AddNode(5, "Left");
            AVLtree4.AddNode(14, "Right");
            AVLtree4.AddNode(15, "RightRight");
            AVLtree4.AddNode(12, "RightLeft");
            AVLtree4.AddNode(13, "RightLeftRight");
            AVLtree4.AddNode(11, "RightLeftLeft");

            Console.WriteLine("\n\nunbalanced tree\n");
            AVLtree4.View(AVLtree4.root);

            Console.WriteLine("\nAVL TREE after balancing (Right and Left rotation) :");
            AVLtree4.root = AVLtree4.balance(AVLtree4.root);
            AVLtree4.View(AVLtree4.root);

            // left right 
            AVLTree<string> AVLtree3 = new AVLTree<string>();
            AVLtree3.AddNode(14, "Root");
            AVLtree3.AddNode(15, "Right");
            AVLtree3.AddNode(10, "Left");
            AVLtree3.AddNode(5, "LeftLeft");
            AVLtree3.AddNode(12, "LeftRight");
            AVLtree3.AddNode(13, "LeftRightLeft");
            AVLtree3.AddNode(11, "LeftRightRight");

            Console.WriteLine("\n\nunbalanced tree\n");
            AVLtree3.View(AVLtree3.root);

            Console.WriteLine("\nAVL TREE after balancing (Left and Right rotation) :");
            AVLtree3.root = AVLtree3.balance(AVLtree3.root);
            AVLtree3.View(AVLtree3.root);

            //CREATING AN AVL TREE
            Console.WriteLine("\nnew AVL TREE");
            
            AVLTree<string> AVLtree = new AVLTree<string>();
            AVLtree.AddNodeInAVLtree(33, "root");
            AVLtree.AddNodeInAVLtree(13, "left");
            AVLtree.AddNodeInAVLtree(53, "right");
            AVLtree.AddNodeInAVLtree(11, "leftleft");
            AVLtree.AddNodeInAVLtree(21, "leftright");
            AVLtree.AddNodeInAVLtree(61, "rightright");
            AVLtree.AddNodeInAVLtree(8, "leftleftleft");
            AVLtree.AddNodeInAVLtree(9, "leftleftleftright");

            AVLtree.View(AVLtree.root);

            Console.ReadKey();
            #endregion
            #region ⠀⠀⠀⠀⠀Graph⠀⠀⠀⠀⠀⠀
            Console.WriteLine("\nTest Graphs:\n");

            Graph graph = new Graph();

            Vertex v11 = new Vertex("A");
            Vertex v22 = new Vertex("B");
            Vertex v33 = new Vertex("C");
            Vertex v44 = new Vertex("D");
            Vertex v55 = new Vertex("E");
            Vertex v66 = new Vertex("F");
            Vertex v77 = new Vertex("G");

            Console.Write("Неориентированный граф: \n");

            graph.AddVertex(v11);
            graph.AddVertex(v22);
            graph.AddVertex(v33);
            graph.AddVertex(v44);
            graph.AddVertex(v55);
            graph.AddVertex(v66);
            graph.AddVertex(v77);

            graph.AddEdge(v11, v22); // A -> B
            graph.AddEdge(v22, v11); // B -> A
            graph.AddEdge(v11, v33); // A -> C
            graph.AddEdge(v33, v11); // C -> A
            graph.AddEdge(v33, v44); // C -> D
            graph.AddEdge(v44, v33); // D -> C
            graph.AddEdge(v22, v55); // B -> E
            graph.AddEdge(v55, v22); // E -> B
            graph.AddEdge(v22, v66); // B -> F
            graph.AddEdge(v66, v22); // F -> B
            graph.AddEdge(v55, v66); // E -> F
            graph.AddEdge(v66, v55); // F -> E
            graph.AddEdge(v44, v77); // D -> G
            graph.AddEdge(v77, v44); // G -> D
            graph.AddEdge(v66, v77); // F -> G
            graph.AddEdge(v77, v66); // G -> F

            graph.View();

            Graph orgraph = new Graph();
            Vertex v1 = new Vertex("A");
            Vertex v2 = new Vertex("B");
            Vertex v3 = new Vertex("C");
            Vertex v4 = new Vertex("D");
            Vertex v5 = new Vertex("E");
            Vertex v6 = new Vertex("F");
            Vertex v7 = new Vertex("G");

            Console.WriteLine("\nПростой граф:\n"); // граф без ребер
            orgraph.AddVertex(v1);
            orgraph.AddVertex(v2);
            orgraph.AddVertex(v3);
            orgraph.AddVertex(v4);
            orgraph.AddVertex(v5);
            orgraph.AddVertex(v6);
            orgraph.AddVertex(v7);

            orgraph.View();

            Console.WriteLine("\nОриентированный граф: \n");
            orgraph.AddEdge(v1, v2); // A -> B
            orgraph.AddEdge(v1, v3); // A -> C
            orgraph.AddEdge(v3, v4); // C -> D
            orgraph.AddEdge(v2, v5); // B -> E
            orgraph.AddEdge(v2, v6); // B -> F
            orgraph.AddEdge(v6, v5); // F -> E
            orgraph.AddEdge(v5, v6); // E -> F
            orgraph.AddEdge(v4, v7); // D -> G
            orgraph.AddEdge(v6, v7); // F -> G

            orgraph.View();

            Console.WriteLine("\nFind Vertex v1 in orgraph (with name 'A') : {0} ", orgraph.VertexIsContains(v1));
            Console.WriteLine("Find Vertex v11 in orgraph (with name 'A') : {0} ", orgraph.VertexIsContains(v11));

            graph.BFS(v11);
            graph.DFS(v11);

            // Граф для теста связаности
            Graph sgraph = new Graph();
            Vertex sv1 = new Vertex("A");
            Vertex sv2 = new Vertex("B");
            Vertex sv3 = new Vertex("C");
            Vertex sv4 = new Vertex("D");
            Vertex sv5 = new Vertex("E");
            Vertex sv6 = new Vertex("F");
            Vertex sv7 = new Vertex("G");

            sgraph.AddVertex(sv1);
            sgraph.AddVertex(sv2);
            sgraph.AddVertex(sv3);
            sgraph.AddVertex(sv4);
            sgraph.AddVertex(sv5); // вершина без ребер
            sgraph.AddVertex(sv6);
            sgraph.AddVertex(sv7);

            sgraph.AddEdge(sv1, sv2); // A -> B
            sgraph.AddEdge(sv2, sv3); // B -> C
            sgraph.AddEdge(sv3, sv4); // C -> D
            sgraph.AddEdge(sv6, sv7); // F -> G

            sgraph.View();

            Console.WriteLine("\nconnectivity of orgraph is {0} (компонент связности)", orgraph.GraphConnectivity());
            Console.WriteLine("connectivity of sgraph is {0} (компонент связности)\n", sgraph.GraphConnectivity());


            Graph d_graph = new Graph();
            Vertex ve0 = new Vertex("0");
            Vertex ve1 = new Vertex("1");
            Vertex ve2 = new Vertex("2");
            Vertex ve3 = new Vertex("3");
            Vertex ve4 = new Vertex("4");
            Vertex ve5 = new Vertex("5");

            d_graph.AddVertex(ve0);
            d_graph.AddVertex(ve1);
            d_graph.AddVertex(ve2);
            d_graph.AddVertex(ve3);
            d_graph.AddVertex(ve4);
            d_graph.AddVertex(ve5);

            d_graph.AddEdge(ve0, ve2, 13);
            d_graph.AddEdge(ve2, ve0, 13);
            d_graph.AddEdge(ve0, ve4, 21);
            d_graph.AddEdge(ve4, ve0, 21);
            d_graph.AddEdge(ve0, ve5, 27);
            d_graph.AddEdge(ve5, ve0, 27);
            d_graph.AddEdge(ve2, ve3, 82);
            d_graph.AddEdge(ve3, ve2, 82);
            d_graph.AddEdge(ve2, ve4, 77);
            d_graph.AddEdge(ve4, ve2, 77);
            d_graph.AddEdge(ve4, ve5, 11);
            d_graph.AddEdge(ve5, ve4, 11);
            d_graph.AddEdge(ve1, ve4, 43);
            d_graph.AddEdge(ve4, ve1, 43);
            d_graph.AddEdge(ve1, ve5, 38);
            d_graph.AddEdge(ve5, ve1, 38);

            d_graph.View();

            Console.WriteLine("\nDijkstra test of d_graph: \n");
            d_graph.Dijkstra(ve0);

            Console.ReadKey();

            #endregion
            #region ⠀⠀⠀⠀IndTask⠀⠀⠀⠀⠀
            Console.WriteLine("\nTest Individual Task:\n");

            //quicksort

            int [] qsort = { 9, 12, 9, 2, 17, 1, 6 };
            string[] qsort1 = { "B", "C", "A", "X", "Z", "Y", "D" };

            Console.Write("recursive QuickSort of qsort: ");
            MySort.QuickSort(qsort,0,qsort.Length-1);
            for (int i = 0; i < qsort.Length; i++)
            {
                Console.Write(" {0}", qsort[i]);
            }
            Console.Write("\nrecursive QuickSort of qsort1: ");
            MySort.QuickSort(qsort1, 0, qsort1.Length - 1);
            for (int i = 0; i < qsort1.Length; i++)
            {
                Console.Write(" {0}", qsort1[i]);
            }
            IndTask.QuickSortNR(qsort, 0, qsort.Length-1);
            Console.Write("\nnon-recursive QuickSort of qsort: ");
            for (int i = 0; i < qsort.Length; i++)
            {
                Console.Write(" {0}", qsort[i]);
            }
            IndTask.QuickSortNR(qsort1, 0, qsort1.Length - 1);
            Console.Write("\nnon-recursive QuickSort of qsort1: ");
            for (int i = 0; i < qsort1.Length; i++)
            {
                Console.Write(" {0}", qsort1[i]);
            }
            Console.WriteLine("\n");

            // mergesort
            int[] msort1 = { 11, 1, 12, 2, 13, 3, 14, 0 };
            int[] msort2 = { 8, 7, 1, 3, 5, 2, 4, 6 };
            string[] msort3 = { "B", "A", "D", "C", "W", "Z", "Y", "X" };
            string[] msort4 = { "X", "A", "Y", "B", "Z", "C"};
            int[] msort5 = { 8, 7, 1, 3, 5, 2, 4, 6 };
            string[] msort6 = { "B", "C", "A", "E", "Z" };
            
            // Рекурсивная версия
            MySort.MergeSort(msort1,0,msort1.Length-1);
            Console.Write("recursive Mergesort of msort1: ");
            for (int i = 0; i < msort1.Length; i++)
            {
                Console.Write(" {0}", msort1[i]);
            }
            MySort.MergeSort(msort3, 0, msort3.Length - 1);
            Console.Write("\nrecursive Mergesort of msort3: ");
            for (int i = 0; i < msort3.Length; i++)
            {
                Console.Write(" {0}", msort3[i]);
            }

            // Нерекурсивная версия
            IndTask.MergeSortNR(msort2);
            Console.Write("\nnon-recursive Mergesort of msort2: ");
            for (int i = 0; i < msort2.Length; i++)
            {
                Console.Write(" {0}",msort2[i]);
            }
            IndTask.MergeSortNR(msort4);
            Console.Write("\nnon-recursive Mergesort of msort4: ");
            for (int i = 0; i < msort4.Length; i++)
            {
                Console.Write(" {0}", msort4[i]);
            }

            // Нерекурсивная версия со стеком
            int[] ms1 = IndTask.MergeSortNR2(msort5);
            Console.Write("\nnon-recursive Mergesort (with stack) of msort5: ");
            for (int i = 0; i < ms1.Length; i++)
            {
                Console.Write(" {0}", ms1[i]);
            }
            Console.Write("\nnon-recursive Mergesort (with stack) of msort6: ");
            string[] ms2 = IndTask.MergeSortNR2(msort6);
            for (int i = 0; i < ms2.Length; i++)
            {
                Console.Write(" {0}", ms2[i]);
            }
            Console.WriteLine();

            #endregion

        }
    }
}
