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
        Node cycle;
        bool cycleCheck = false;
        Node[] DFA;

        public TestDFS(Node[] d)
        {
            this.DFA = d;
        }

        public bool Test()
        {
            bool yuh;
            Node[] testNodes = new Node[2];
            testNodes[0] = new Node("loopTest", true, true, null, null);

            testNodes[0].SetATransition(testNodes[0]);
            testNodes[0].SetBTransition(testNodes[0]);

            testNodes[1] = new Node("noLoop", false, true, null, null);

            testNodes[1].SetATransition(testNodes[1]);
            testNodes[1].SetBTransition(testNodes[1]);

            yuh = DFS(testNodes[1]);

            return yuh;
        }

        //Executes a DFS on a DFA. Returns true if the accept state is reached.
        //Otherwise, false.
        public bool DFS(Node n)
        {
            // check if current node is marked
            if (n.IsMarked())
            {
                // current node is a cycle
                cycle = n;


                if (cycle.IsAccepting())
                {
                    // has a loop and accepts
                    return true;
                }
                else if (!cycle.IsAccepting())
                {
                    // has a loop but not accepting
                    return false;
                }

            }
            else
            {
                // if node isn't previously marked mark it
                n.SetMarked(true);
                // recursively call function until a cycle is found.
                return DFS(n.GetATransition()) ||
                    DFS(n.GetBTransition());
            }

            // return false if language is not infinite
            return false;
        }

        public bool DFSTakeTwo(Node n)
        {
            //We have visited this node before
            if (n.IsMarked())
            {
                cycleCheck = true;

                if (findAccept(n))
                {
                    return true;
                }
                else
                {
                    foreach (Node temp in DFA)
                    {
                        temp.SetMarked2(false);
                    }
                    return false;
                }
            }
            //We have never visited this node
            else
            {
                n.SetMarked(true);
                return DFSTakeTwo(n.GetATransition()) ||
                    DFSTakeTwo(n.GetBTransition());
            }
        }

        public bool findAccept(Node n)
        {
            //Base case #1: n is an accepting state
            if (n.IsAccepting())
            {
                return true;
            }

            //Base case #2: n is marked
            if (n.IsMarked2())
            {
                return false;
            }

            //Recursive case: n is not marked
            else
            {
                n.SetMarked2(true);
                return findAccept(n.GetATransition()) || findAccept(n.GetBTransition());
            }
        }
    }
}