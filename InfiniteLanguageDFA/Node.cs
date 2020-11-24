using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace InfiniteLanguageDFA
{
    public class Node
    {
        //This contains all of the information a definite state needs.
        private String name;
        private bool accepting;
        private Node transitionA;
        private Node transitionB;
        private bool marked;
        private bool markedA;
        private bool markedB;

        //Default constructor
        public Node(String Name, bool a, Node tA, Node tB, bool mA, bool mB)
        {
            this.name = Name;
            this.accepting = a;
            this.transitionA = tA;
            this.transitionB = tB;
            this.marked = false;
            this.markedA = mA;
            this.markedB = mB;
        }

        //Getters
        public String getName()
        {
            return this.name;
        }
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

        public bool isMarked()
        {
            return this.marked;
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
        public void setName(String s)
        {
            this.name = s;
        }
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

        public void setMarked(bool b)
        {
            this.marked = b;
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
