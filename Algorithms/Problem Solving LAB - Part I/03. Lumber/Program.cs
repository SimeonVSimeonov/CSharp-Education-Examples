using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Lumber
{
    public class Program
    {
        //4 3
        //-10 30 60 10
        //-50 20 -30 -20
        //-35 60 -20 15
        //-40 -10 50 -30
        //4 2
        //3 4
        //4 1

        static int count = 0;

        static void Main()
        {
            int[] args = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var logsCount = args[0];
            var queriesCount = args[1];

            List<Log> logs = new List<Log>();
            List<int>[] graph = new List<int>[logsCount + 1];

            for (int i = 1; i <= logsCount; i++)
            {
                args = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Log log = new Log(i, args[0], args[1], args[2], args[3]);

                graph[i] = new List<int>();

                foreach (var logElement in logs)
                {
                    if (logElement.Intersects(log))
                    {
                        graph[logElement.Id].Add(i);
                        graph[i].Add(logElement.Id);
                    }
                }

                logs.Add(log);
            }

            bool[] marked = new bool[logsCount + 1];
            int[] id = new int[logsCount + 1];
            for (int v = 1; v <= logsCount; v++)
            {
                if (!marked[v])
                {
                    DFS(v, marked, id, graph);
                    count++;
                }
            }

            for (int i = 0; i < queriesCount; i++)
            {
                args = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int from = args[0];
                int to = args[1];

                Console.WriteLine("{0}", id[from] == id[to] ? "YES" : "NO");
            }
        }

        private static void DFS(int vertex, bool[] marked, int[] id, List<int>[] graph)
        {
            marked[vertex] = true;
            id[vertex] = count;
            foreach (var child in graph[vertex])
            {
                if (!marked[child])
                {
                    DFS(child, marked, id, graph);
                }
            }
        }
    }

    public class Log
    {
        public Log(int id, int x1, int y1, int x2, int y2)
        {
            this.Id = id;
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        public int Id { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public bool Intersects(Log other)
        {
            bool horizontalIntersect = this.X1 <= other.X2 && this.X2 >= other.X1;
            bool verticalIntersect = this.Y1 >= other.Y2 && this.Y2 <= other.Y1;

            return horizontalIntersect && verticalIntersect;
        }

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}
