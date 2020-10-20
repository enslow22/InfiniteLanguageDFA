using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace InfiniteLanguageDFA
{
    public class Node
    {
        //This contains all of the information a definite state needs.
        private bool accepting;
        private Node transition0;
        private Node transition1;
        private bool marked0;
        private bool marked1;

        //Default constructor
        public Node(bool a, Node t0, Node t1, bool m0, bool m1)
        {
            this.accepting = a;
            this.transition0 = t0;
            this.transition1 = t1;
            this.marked0 = m0;
            this.marked1 = m1;
        }


        //Getters
        public bool isAccepting()
        {
            return this.accepting;
        }

        public Node get0Transition()
        {
            return this.transition0;
        }

        public Node get1Transition()
        {
            return this.transition1;
        }

        public bool is0Marked()
        {
            return this.marked0;
        }
        
        public bool is1Marked()
        {
            return this.marked1;
        }

        //Setters
        public void setAccepting(bool b)
        {
            this.accepting = b;
        }

        public void set0Transition(Node n)
        {
            this.transition0 = n;
        }

        public void set1Transition(Node n)
        {
            this.transition1 = n;
        }

        public void set0Marked(bool b)
        {
            this.marked0 = b;
        }

        public void set1Marked(bool b)
        {
            this.marked1 = b;
        }
    }
}
