using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

namespace InfiniteLanguageDFA
{
    /*
     * This class converts .txt files into Node[] objects.
     */
    class FileConverter
    {
        Node[] DFA = null;
        char[] sigma = null;
        public FileConverter(String p)
        {
            String path = "";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    int numLines = 0;
                    while ((s = sr.ReadLine()) != null)
                    {
                        /*
                         * Parse File in this block.
                         * We can format the .txt file however we want.
                         * I think the best way is to have one part of the definition per line.
                         * 
                         * Set of states
                         * Alphabet
                         * Transition Function
                         * Start State
                         * Accept State(s)
                         */
                        switch (numLines){
                            case 0:
                                DFA = SetOfStates(s);
                                break;
                            case 1:
                                sigma = Alphabet(s);
                                break;
                            case 2:
                                Transitions(s);
                                break;
                            case 3:
                                StartState(s);
                                break;
                            case 4:
                                AcceptStates(s);
                                break;
                            default:
                                break;
                        }

                        numLines++;
                    }
                }
            }
        }

        /*
         * This method parses the first line of the text file. 
         * It saves the names of the states.
         */
        private Node[] SetOfStates(String s)
        {
            ArrayList names = new ArrayList();
            char[] cArr = s.ToCharArray();
            int startIndex = -1;
            int endIndex = -1;
            char c;

            //Count number of commas and add one. That is how many states you have.
            int count = 1;
            foreach (char r in s.ToCharArray())
            {
                if (r == ',')
                {
                    count++;
                }
            }

            Node[] states = new Node[count];
            

            for (int i = 0; i <= cArr.Length; i++)
            {
                c = cArr[i];

                if (c == '[' || c == ' ')
                {
                    startIndex = i;
                }

                if (c == ']' || c == ',')
                {
                    endIndex = i;
                }

                if (startIndex != -1 && endIndex != -1)
                {
                    names.Add(s.Substring(startIndex + 1, endIndex - 1));
                    startIndex = -1;
                    endIndex = -1;
                }
            }

            foreach (Node n in states){
                IEnumerator namesEnum = names.GetEnumerator();
                n.setName((String) namesEnum.Current);
                namesEnum.MoveNext();
            }

            return states;
        }

        /*
         * Saves the alphabet which we use for the transition table
         */
        private char[] Alphabet(String s)
        {
            char[] data = s.ToCharArray();
            char[] alpha = new char[2];

            alpha[1] = data[s.IndexOf(",")-1];
            alpha[2] = data[s.IndexOf(",") + 2];

            return alpha;
        }

        /*
         * Sets all of the transitions for the Nodes.
         */
        private void Transitions(String s)
        {
            StringBuilder stringBuilder = new StringBuilder(s);
            char[] cArr = s.ToCharArray();
            char c;
            int startIndex = -1;
            int endIndex = -1;


            for (int i = 0; i <= cArr.Length; i++)
            {
                c = cArr[i];

                if (c == '(')
                {
                    startIndex = i;
                }

                if (c == ')')
                {
                    endIndex = i;
                }

                if (startIndex != -1 && endIndex != -1)
                {
                    String transition = s.Substring(startIndex, endIndex);


                    String name1 = s.Substring(startIndex + 1, s.IndexOf(" "));
                    String name2 = s.Substring(s.IndexOf(" ", s.IndexOf(" ") + 1), endIndex - 1);


                    Node state1;
                    Node state2;


                    //a transition
                    if (transition.Contains(" " + sigma[0] + " "))
                    {
                        
                    }
                    //b transition
                    else
                    {

                    }
                    startIndex = -1;
                    endIndex = -1;
                }
            }

        }

        /*
         * Sets the start state.
         */
        private void StartState(String s)
        {
            //Search through the Node[] and find the one with the name
            //that equals String s.
            foreach(Node n in DFA){
                if (n.getName().Equals(s))
                {
                    n.setStarting(true);
                }
                return;
            }
        }

        /*
         * Sets the accept states.
         */
        private void AcceptStates(String s)
        {
            ArrayList names = new ArrayList();

            char[] cArr = s.ToCharArray();
            int startIndex = -1;
            int endIndex = -1;
            char c;

            for (int i = 0; i <= cArr.Length; i++)
            {
                c = cArr[i];

                if (c == '[' || c == ' ')
                {
                    startIndex = i;
                }

                if (c == ']' || c == ',')
                {
                    endIndex = i;
                }

                if (startIndex != -1 && endIndex != -1)
                {
                    names.Add(s.Substring(startIndex+1, endIndex-1));
                    startIndex = -1;
                    endIndex = -1;
                }
            }

            foreach (Node n in DFA)
            {
                if (names.Contains(n.getName()))
                {
                    n.setAccepting(true);
                }
            }
        }

        public Node[] GetDFA()
        {
            Node[] arr = new Node[DFA.Length];
            for (int i = 0; i <= DFA.Length; i++)
            {
                arr[i] = new Node(DFA[i]);
            }

            return arr;
        }
    }
}
