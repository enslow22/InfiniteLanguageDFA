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
            String path = @"C:\Users\Ryan\Desktop\testcase2.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    int numLines = 0;
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine(s);
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
                                SetOfStates(s);
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
        private void SetOfStates(String s)
        {
            ArrayList names = new ArrayList();
            char[] cArr = s.ToCharArray();
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

            DFA = new Node[count];

            String temp;
            int startIndex = -1;
            int endIndex = -1;
            for (int i = 0; i < cArr.Length; i++)
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
                    int l = s.Length;
                    temp = s.Substring(startIndex + 1, endIndex - startIndex - 1);
                    names.Add(temp);
                    Console.WriteLine(temp);
                    temp = null;
                    startIndex = -1;
                    endIndex = -1;
                }
            }

            IEnumerator namesEnum = names.GetEnumerator();
            for (int i = 0; i < DFA.Length; i++) {
                namesEnum.MoveNext();
                Node tempN = new Node((String)namesEnum.Current);
                DFA[i] = tempN;
            }
        }

        /*
         * Saves the alphabet which we use for the transition table
         */
        private char[] Alphabet(String s)
        {
            char[] data = s.ToCharArray();
            char[] alpha = new char[2];

            int comma = s.IndexOf(",");
            alpha[0] = data[comma - 1];
            alpha[1] = data[comma + 1];
            Console.WriteLine("a,b");
            return alpha;
        }

        /*
         * Sets all of the transitions for the Nodes.
         */
        private void Transitions(String s)
        {
            char[] cArr = s.ToCharArray();
            char c;
            int startIndex = -1;
            int endIndex = -1;

            for (int i = 0; i < cArr.Length; i++)
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
                    String transition = s.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(transition);

                    //String name1 = s.Substring(startIndex + 1, transition.IndexOf(" ")-1);
                    String name1 = transition.Substring(1,transition.IndexOf(' ')-1);
                    //String name2 = s.Substring(transition.IndexOf(" ") + 4, 2);
                    String name2 = transition.Substring(transition.IndexOf(' ') + 3, 2);
         

                    Console.WriteLine(name1 + " state 1");
                    Console.WriteLine(name2 + " state 2");

                    Node state1 = null;
                    Node state2 = null;

                    for (int n = 0; n < DFA.Length; n++)
                    {
                        if (DFA[n].GetName().Equals(name1))
                        {
                            state1 = DFA[n];
                        }
                        if (DFA[n].GetName().Equals(name2))
                        {
                            state2 = DFA[n];
                        }
                    }

                    //a transition
                    if (transition.Contains(" " + sigma[0] + " "))
                    {
                        state1.SetATransition(state2);
                    }
                    //b transition
                    else
                    {
                        state1.SetBTransition(state2);
                    }

                    transition = null;
                    name1 = null;
                    name2 = null;
                    startIndex = -1;
                    endIndex = -1;
                }
            }

            /*
            //set all the transitions
            for (int i = DFA.Length-1; i >= 0; i--)
            {
                for (int j = 0; j < DFA.Length; j++)
                {
                    if (DFA[j].GetName() == DFA[i].GetATransition().GetName())
                    {
                        DFA[i].SetATransition(DFA[j]);
                    }
                    if (DFA[j].GetName() == DFA[i].GetBTransition().GetName())
                    {
                        DFA[i].SetBTransition(DFA[j]);
                    }
                }
            }
            */

        }

        /*
         * Sets the start state.
         */
        private void StartState(String s)
        {
            //Search through the Node[] and find the one with the name
            //that equals String s.
            foreach(Node n in DFA){
                if (n.GetName().Equals(s))
                {
                    Console.WriteLine(n.GetName());
                    n.SetStarting(true);
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

            for (int i = 0; i < cArr.Length; i++)
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
                    names.Add(s.Substring(startIndex + 1, endIndex - startIndex - 1));
                    startIndex = -1;
                    endIndex = -1;
                }
            }

            foreach (Node n in DFA)
            {
                if (names.Contains(n.GetName()))
                {
                    Console.WriteLine(n.GetName());
                    n.SetAccepting(true);
                }
            }
        }

        public Node[] GetDFA()
        {
            /*
            Node[] arr = new Node[DFA.Length];
            for (int i = 0; i < DFA.Length; i++)
            {
                arr[i] = new Node(DFA[i]);
            }

            return arr;
            */
            return this.DFA;
        }
    }
}
