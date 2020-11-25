using System;
using System.IO;

namespace InfiniteLanguageDFA
{
    /**
     * TODO:
     * 
     * Complete FileConverter
     * Complete The DFA structure (ideas?) I think a Node[] could work fine. I'm not sure. 
     * Complete DFS cycle search algorithm
     * Complete The Diagram or something IDK
     * 
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {

            FileConverter f = new FileConverter("fu");
            Node[] DFA = f.GetDFA();

            TestDFS Algorithm = new TestDFS(DFA);

            bool b;

            foreach (Node n in DFA)
            {
                if (n.IsStarting())
                {
                    b = Algorithm.DFSTakeTwo(n);
                    Console.WriteLine(b);
                }
            }
        }
    }
}