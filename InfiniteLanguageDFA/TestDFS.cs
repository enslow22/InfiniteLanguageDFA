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
        Node[] testNodes;

        public TestDFS()
        {

        }

        public bool Test()
        {
            bool yuh;
            Node[] testNodes = new Node[2];
            testNodes[0] = new Node("loopTest", true, null, null, false, false);

            testNodes[0].SetATransition(testNodes[0]);
            testNodes[0].SetBTransition(testNodes[0]);

            testNodes[1] = new Node("noLoop", false, null, null, false, false);

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
    }
}