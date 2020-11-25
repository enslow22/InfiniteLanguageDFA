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
            //Execute from main. Main will take in a file idk how yet
        }

        //Executes a DFS on a DFA. Returns true if the accept state is reached. Otherwise, false.
        public bool DFS(Node n)
        {
            // check if current node is marked
            if (n.IsMarked())
            {
                // current node is a cycle
                cycle = n;

                if (cycle.IsAccepting())
                {
                    // has a loop and can reach the accepting state
                    return true;
                }
                else
                {
                    // recursively call DFS on current node
                    DFS(n.GetATransition());
                    DFS(n.GetBTransition());
                }
            }
            else
            {
                // if node isn't previously marked mark it
                n.SetMarked(true);
                // recursively call function until a cycle is found.
                DFS(n.GetATransition());
                DFS(n.GetBTransition());
            }

            // return false if language is not infinite
            return false;
        }

        //Parses a .txt file and returns the DFA encoded in it
        public Node[] ParseFile(FileStream f)
        {
            return null;
        }
    }
}