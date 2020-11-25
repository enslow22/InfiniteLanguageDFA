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
        public String GetName()
        {
            return this.name;
        }
        public bool IsAccepting()
        {
            return this.accepting;
        }

        public Node GetATransition()
        {
            return this.transitionA;
        }

        public Node GetBTransition()
        {
            return this.transitionB;
        }

        public bool IsMarked()
        {
            return this.marked;
        }

        public bool IsAMarked()
        {
            return this.markedA;
        }
        
        public bool IsBMarked()
        {
            return this.markedB;
        }

        //Setters
        public void SetName(String s)
        {
            this.name = s;
        }
        public void SetAccepting(bool b)
        {
            this.accepting = b;
        }

        public void SetATransition(Node n)
        {
            this.transitionA = n;
        }

        public void SetBTransition(Node n)
        {
            this.transitionB = n;
        }

        public void SetMarked(bool b)
        {
            this.marked = b;
        }

        public void SetAMarked(bool b)
        {
            this.markedA = b;
        }

        public void SetBMarked(bool b)
        {
            this.markedB = b;
        }
    }
}
