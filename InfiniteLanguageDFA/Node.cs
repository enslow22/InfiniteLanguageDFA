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
        private Node transitionA;
        private Node transitionB;
        private bool markedA;
        private bool markedB;

        //Default constructor
        public Node(bool a, Node t0, Node t1, bool m0, bool m1)
        {
            this.accepting = a;
            this.transitionA = t0;
            this.transitionB = t1;
            this.markedA = m0;
            this.markedB = m1;
        }

        //Getters
        public bool isAccepting()
        {
            return this.accepting;
        }

        
        public Node getATransition()
        {
            return this.transitionA;
        }

        public Node getBTransition()
        {
            return this.transitionB;
        }

        public bool isAMarked()
        {
            return this.markedA;
        }
        
        public bool isBMarked()
        {
            return this.markedB;
        }

        //Setters
        public void setAccepting(bool b)
        {
            this.accepting = b;
        }

        public void setATransition(Node n)
        {
            this.transitionA = n;
        }

        public void setBTransition(Node n)
        {
            this.transitionB = n;
        }

        public void setAMarked(bool b)
        {
            this.markedA = b;
        }

        public void setBMarked(bool b)
        {
            this.markedB = b;
        }
    }
}
