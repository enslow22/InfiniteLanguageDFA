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
            if (n.isMarked())
            {
                // current node is a cycle
                cycle = n;

                if (cycle.isAccepting())
                {
                    // has a loop and 
                    return true;
                }
                else
                {
                    // recursively call 
                    DFS(n.getATransition());
                    DFS(n.getBTransition());
                }
            }
            

            // mark current node as marked
            n.setMarked(true);


            //DFS(n.getATransition());

            //DFS(n.getBTransition());



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
