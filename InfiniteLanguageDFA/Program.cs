using System;
using System.IO;

namespace InfiniteLanguageDFA
{
    /**
     * TODO:
     * 
     * -Complete File Parse method to parse the formal definitions of DFAs
     * -Complete the DFA complement method. Given a DFA (Node[]), return the complement of that DFA.
     * -Complete the DFS method to perform a DFS on a state diagram.'
     * 
     * Test for kyle :)
     */
    class Program
    {
        Node[] states;
        static void Main(string[] args)
        {
            //Execute from main. Main will take in a file idk how yet
        }

        //Returns the complement of a given DFA
        public Node[] DFAComplement(Node[] n)
        {
            Node[] comp = null;



            return comp;
        }

        //Executes a DFS on a DFA. Returns true if the accept state is reached. Otherwise, false.
        public bool DFS(Node[] n)
        {
            return false;
        }

        //Parses a .txt file and returns the DFA encoded in it
        public Node[] ParseFile(FileStream f)
        {
            return null;
        }
    }
}
