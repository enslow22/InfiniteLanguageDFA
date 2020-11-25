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

            yuh = DFS(testNodes[0]);

            return yuh;
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
    }
}