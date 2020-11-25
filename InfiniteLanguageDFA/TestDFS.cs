using System;

namespace InfiniteLanguageDFA
{
    /**
     * 
     * 
     * Testing the DFS algorithm
     * 
     * 
     */
    class TestDFS
    {

        Node[] DFA;

        public TestDFS(Node[] d)
        {
            this.DFA = d;
        }

        //Old method used to test DFAs before the File Converter was finished.
        public bool Test()
        {
            bool b;
            Node[] testNodes = new Node[2];
            testNodes[0] = new Node("loopTest", true, true, null, null);

            testNodes[0].SetATransition(testNodes[0]);
            testNodes[0].SetBTransition(testNodes[0]);

            testNodes[1] = new Node("noLoop", false, true, null, null);

            testNodes[1].SetATransition(testNodes[1]);
            testNodes[1].SetBTransition(testNodes[1]);

            b = DFS(testNodes[1]);

            return b;
        }

        //Our algorithm uses a part of the algorithm described here:
        //https://www.geeksforgeeks.org/detect-cycle-in-a-graph/
        public bool DFS(Node n)
        {
            Console.WriteLine("visiting " + n.GetName());

            //We are keeping track of two things:
            //The recursion stack (marked2)
            //And if we have visited the node.

            //If it is on the recursion stack, then we have
            //reached this node from itself
            //And we have found a node in a cycle
            if (n.IsMarked2())
            {

                //Marked3 controls the marking for the accept finding
                //algorithm. We can set these to false here.
                foreach (Node t in DFA)
                {
                    t.SetMarked3(false);
                }

                //We can now look to see if that node
                //Reaches an accepting state.
                Console.WriteLine("Cycle Found, looking for an accept path");
                return FindAccept(n);
            }

            //If we have reached a node that is marked, we do not
            //Return true because it is a node that
            //is not on the recursion stack but we have seen.
            if (n.IsMarked())
            {
                return false;
            }

            //Set both values to true because we have seen them
            n.SetMarked(true);
            n.SetMarked2(true);

            //Recursive calls
            if (DFS(n.GetATransition()))
            {
                return true;
            }
            if (DFS(n.GetBTransition()))
            {
                return true;
            }

            //Base case (all paths have been examined for a
            //particular branch, so we take this node
            //off of the recursive stack and return false.
            n.SetMarked2(false);
            return false;
        }

        //Perform another DFS on n.
        //If it returns true, then we have found an accepting state
        public bool FindAccept(Node n)
        {
            Console.WriteLine("Finding a path to an accept state for " + n.GetName());
            //Base case #1: n is an accepting state
            if (n.IsAccepting())
            {
                Console.WriteLine(n.GetName() + " accepted");
                return true;
            }
            //Base case #2: n is not an accepting state and we have been here before.
            if (n.IsMarked3())
            {
                Console.WriteLine("Did not find an accepting state on this path");
                return false;
            }
            //Recursive case: set marked as true; call findAccept on all neighbors.
            else
            {
                Console.WriteLine("Marking this node, still looking for an accepting node");
                n.SetMarked3(true);
                return FindAccept(n.GetATransition()) 
                    || FindAccept(n.GetBTransition());
            }
        }
    }
}