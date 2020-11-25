using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace InfiniteLanguageDFA
{
    public class Node : ICloneable
    {
        //This contains all of the information a definite state needs.
        private String name;
        private bool starting;
        private bool accepting;
        private Node transitionA;
        private Node transitionB;
        private bool marked;
        private bool marked2;
        private bool marked3;

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
            this.marked3 = false;
        }

        public Node(Node n)
        {
            this.name = n.name;
            this.starting = n.starting;
            this.accepting = n.accepting;
            this.transitionA = null;
            this.transitionB = null;
            this.marked = false;
            this.marked2 = false;
            this.marked3 = false;
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

        public bool IsMarked3()
        {
            return this.marked3;
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

        public void SetMarked3(bool b)
        {
            this.marked3 = b;
        }

        public object Clone()
        {
            Node t = new Node(this.name);
            t.accepting = this.accepting;
            t.starting = this.starting;
            t.transitionA = new Node(this.transitionA);
            t.transitionB = new Node(this.transitionB);
            t.marked = this.marked;
            t.marked2 = this.marked2;

            return t;
        }
    }
}
