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
        private bool starting;
        private bool accepting;
        private Node transitionA;
        private Node transitionB;
        private bool marked;
        private bool marked2;

        //Default constructor

        public Node(String title)
        {
            this.name = title;
            this.starting = false;
            this.accepting = false;
            this.transitionA = null;
            this.transitionB = null;
            this.marked = false;
            this.marked2 = false;
        }


        public Node(String Name, bool s, bool a, Node tA, Node tB)
        {
            this.name = Name;
            this.starting = s;
            this.accepting = a;
            this.transitionA = tA;
            this.transitionB = tB;
            this.marked = false;
        }

        //Getters
        public String GetName()
        {
            return this.name;
        }

        public bool IsStarting()
        {
            return this.starting;
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

        public bool IsMarked2()
        {
            return this.marked2;
        }

        //Setters
        public void SetName(String s)
        {
            this.name = s;
        }

        public void SetStarting(bool b)
        {
            this.starting = b;
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

        public void SetMarked2(bool b)
        {
            this.marked2 = b;
        }
    }
}
