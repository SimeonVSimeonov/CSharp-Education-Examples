using System;
using System.Collections.Generic;
using System.Linq;


public class StartUp
{
    static Dictionary<int, Tree<int>> nodeByVale = new Dictionary<int, Tree<int>>();

    public static void Main(string[] args)
    {
        ReadTree();

        /* 0.1 Root Node
        var root = GetRootNode();
        Console.WriteLine($"Root node: {root.Value}");
        */

        /* 0.2 PrintTreeIndented
        var root = GetRootNode();
        PrintTreeIndented(root);
        */

        /* 0.3 Leaf Nodes
        PrintLeafNodes(); 
        */

        /* 0.4 Middle Nodes
        PrintMiddleNodes();
        */

        /* 0.5 Deepest Node
        PrintDeepestNode();
        */

        /* 0.6 Longest Path 
        PrintLongestPath();
        */


        /*0.7 Paths With Given Sum
        PrintPathsByGivenSum();
        */


        /* 0.8 PrintSubtreesByGivenSum
        */

        PrintSubtreesByGivenSum();

    }

    static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByVale.ContainsKey(value))
        {
            nodeByVale[value] = new Tree<int>(value);
        }

        return nodeByVale[value];
    }

    static void AddEdge(int parent, int child)
    {
        Tree<int> parentNode = GetTreeNodeByValue(parent);
        Tree<int> childNode = GetTreeNodeByValue(child);

        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }

    static void ReadTree()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        for (int i = 1; i < nodeCount; i++)
        {
            string[] edge = Console.ReadLine().Split(' ');
            AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
        }
    }

    static Tree<int> GetRootNode()
    {
        return nodeByVale.Values
            .FirstOrDefault(x => x.Parent == null);
    }

    static void PrintTreeIndented(Tree<int> node, int indent = 0)
    {
        Console.WriteLine(new string(' ', indent * 2) + node.Value);

        foreach (var child in node.Children)
        {
            PrintTreeIndented(child, indent + 1);
        }
    }

    private static void PrintLeafNodes()
    {
        List<int> leaves = nodeByVale.Values
            .Where(n => n.Children.Count == 0)
            .Select(n => n.Value)
            .OrderBy(n => n)
            .ToList();

        Console.WriteLine($"Leaf nodes: {string.Join(" ", leaves)}");
    }

    private static void PrintMiddleNodes()
    {
        List<int> middleNodes = nodeByVale.Values
            .Where(x => x.Parent != null && x.Children.Count > 0)
            .Select(n => n.Value)
            .OrderBy(n => n)
            .ToList();

        Console.WriteLine($"Middle nodes: {String.Join(" ", middleNodes)}");
    }

    private static void PrintDeepestNode()
    {
        List<int> leaves = nodeByVale.Values
            .Where(n => n.Children.Count == 0)
            .Select(n => n.Value)
            .ToList();

        int maxDepth = 0;
        int deepestNode = GetRootNode().Value;

        foreach (var node in leaves)
        {
            Tree<int> currentNode = GetTreeNodeByValue(node);

            int currentDepth = 1;

            while (currentNode.Parent != null)
            {
                currentDepth++;
                currentNode = currentNode.Parent;
            }

            if (currentDepth > maxDepth)
            {
                deepestNode = node;
                maxDepth = currentDepth;
            }
        }

        Console.WriteLine($"Deepest node: {deepestNode}");
    }

    private static void PrintLongestPath()
    {
        List<int> leaves = nodeByVale.Values
            .Where(n => n.Children.Count == 0)
            .Select(n => n.Value)
            .ToList();

        int maxDepth = 0;
        int deepestNode = GetRootNode().Value;

        foreach (var node in leaves)
        {
            Tree<int> currentNode = GetTreeNodeByValue(node);

            int currentDepth = 1;

            while (currentNode.Parent != null)
            {
                currentDepth++;
                currentNode = currentNode.Parent;
            }

            if (currentDepth > maxDepth)
            {
                deepestNode = node;
                maxDepth = currentDepth;
            }
        }

        Tree<int> current = GetTreeNodeByValue(deepestNode);

        Stack<int> path = new Stack<int>();

        while (current != null)
        {
            path.Push(current.Value);
            current = current.Parent;
        }

        Console.WriteLine($"Longest path: {String.Join(" ", path)}");
    }

    private static void PrintPathsByGivenSum()
    {
        int targetSum = int.Parse(Console.ReadLine());

        List<Tree<int>> nodes = new List<Tree<int>>();
        var root = GetRootNode();
        DFS(root, nodes);

        Console.WriteLine($"Paths of sum {targetSum}:");

        foreach (var tree in nodes)
        {
            int sum = CalculatePathSum(tree);
            if (sum == targetSum)
            {
                PrintPath(tree);
            }
        }

    }

    private static void PrintSubtreesByGivenSum()
    {
        int targetSum = int.Parse(Console.ReadLine());

        List<Tree<int>> nodes = new List<Tree<int>>();
        var root = GetRootNode();
        DFS(root, nodes);

        Console.WriteLine($"Subtrees of sum {targetSum}:");

        foreach (var tree in nodes)
        {
            int sum = CalculateSubtreeSum(tree);
            if (sum == targetSum)
            {
                List<int> subtree = new List<int>();
                GetSubtreePreOrder(tree, subtree);
                Console.WriteLine(string.Join(" ", subtree));
            }
        }
    }

    private static void GetSubtreePreOrder(Tree<int> tree, List<int> subtree)
    {
        subtree.Add(tree.Value);

        foreach (var child in tree.Children)
        {
            GetSubtreePreOrder(child, subtree);
        }
    }

    private static int CalculateSubtreeSum(Tree<int> node)
    {
        int sum = node.Value;
        foreach (var child in node.Children)
        {
            sum += CalculateSubtreeSum(child);
        }

        return sum;
    }

    private static void PrintPath(Tree<int> current)
    {
        Stack<int> path = new Stack<int>();

        while (current != null)
        {
            path.Push(current.Value);
            current = current.Parent;
        }

        Console.WriteLine($"{String.Join(" ", path)}");
    }

    private static int CalculatePathSum(Tree<int> tree)
    {
        int sum = 0;

        while (tree != null)
        {
            sum += tree.Value;
            tree = tree.Parent;
        }

        return sum;
    }

    private static void DFS(Tree<int> node, List<Tree<int>> nodes)
    {
        foreach (var child in node.Children)
        {
            DFS(child, nodes);
        }

        nodes.Add(node);
    }
}

