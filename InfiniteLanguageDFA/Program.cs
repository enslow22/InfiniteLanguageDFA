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
        Node[] DFA;
        Node cycle;
        bool accepts;
        static void Main(string[] args)
        {
            TestDFS test = new TestDFS();
            //test.Test();

            Console.WriteLine(test.Test());
        }


        //Parses a .txt file and returns the DFA encoded in it
        public Node[] ParseFile(FileStream f)
        {
            return null;
        }
    }
}