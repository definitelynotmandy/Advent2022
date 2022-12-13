using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Advent2022
{
    internal class day7
    {
        public static void Run()
        {
            var input = File.ReadAllLines(@$"{Environment.CurrentDirectory}\Inputs\day7.txt");
            List<Node> tree = GetNodeTree(input);

            Console.WriteLine($"\nDay7\ta) {tree.Where(x => x.Size <= 100000).Select(x => x.Size).Sum()}");
        }

        private static List<Node> GetNodeTree(string[] input)
        {
            List<Node> tree = new List<Node>();
            Node currentNode = null;

            foreach (string line in input)
            {
                if (line.StartsWith("$"))
                {
                    if (line.Equals("$ ls"))
                        continue;
                    if (!line.Equals("$ cd .."))
                    {
                        string nodeName = line.Split(' ')[2];
                        if (currentNode == null)
                        {
                            Node node = new Node();
                            node.Name = nodeName;
                            node.Parent = currentNode;
                            currentNode = node;
                            tree.Add(node);
                        }
                        else
                        {
                            Node child = currentNode.Childs.Where(x => x.Name == nodeName).FirstOrDefault();
                            child.Parent = currentNode;
                            currentNode = child;
                        }

                    }
                    else
                    {
                        int size = currentNode.Size;
                        currentNode = currentNode.Parent;

                        if (currentNode.Name != "/")
                            currentNode.Size += size;
                    }
                    continue;
                }
                else if (line.StartsWith("dir"))
                {
                    if (currentNode.Childs == null)
                        currentNode.Childs = new List<Node>();

                    Node child = new Node();
                    child.Name = line.Split(' ')[1];
                    currentNode.Childs.Add(child);
                    tree.Add(child);
                }
                else
                {
                    int values = int.Parse(line.Split(' ')[0]);
                    currentNode.Size += values;
                }
            }

            return tree;
        }
    }

    internal class Node
    {
        public string Name { get; set; }
        public Node Parent { get; set; }
        public List<Node> Childs { get; set; }
        public int Size { get; set; }
    }
}
