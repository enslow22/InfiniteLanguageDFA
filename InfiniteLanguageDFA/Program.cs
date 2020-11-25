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
        //Run the program from here:
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path of the DFA you would like to analyze.");

            string path = Console.ReadLine();

            FileConverter f = new FileConverter();
            //f.ParseFile(@"C:\Users\Ryan\Desktop\testcase3.txt");
            f.ParseFile(path);
            Node[] DFA = f.GetDFA();

            TestDFS Algorithm = new TestDFS(DFA);

            bool b;

            foreach (Node n in DFA)
            {
                if (n.IsStarting())
                {
                    b = Algorithm.DFS(n);
                    if (b)
                    {
                        Console.WriteLine("\n" + b + "\n The DFA you selected has an infinitely sized language");
                    }
                    else
                    {
                        Console.WriteLine("\n" + b + "\n The DFA you selected does not have an infinitely sized language");
                    }
                }
            }
        }
    }
}