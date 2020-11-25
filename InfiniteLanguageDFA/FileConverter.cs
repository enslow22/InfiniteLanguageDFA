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
        public FileConverter()
        {
            
        }

        /*
         * This method parses the file given by the user.
         * https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-5.0
         */
        public void ParseFile(String path)
        {
            Console.WriteLine("Parsing the file located at: " + path + "\n");
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    int numLines = 0;
                    while ((s = sr.ReadLine()) != null)
                    {
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
                        switch (numLines)
                        {
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
                        Console.WriteLine();
                    }
                    Console.WriteLine("File was successfully converted! \n");
                }
            }
            else
            {
                Console.WriteLine("Failed, could not find file.");
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


            //Here, we are converting the state names into strings
            //Then we add those names to the nodes in the Node[] object.
            //We find the start and end index of the state by looking at 
            //'[', ' ', ']', and ','.
            //Assuming the file is formatted correctly, these will produce aa valid result.
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

            //We find an individual transition and then add that transition
            //to the Node object.
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

                    //At this point, we have parsed a transition and we have 3 things:
                    //The start, transition variable, and destination
                    //With these three things, we can set the transition in the Node properly.

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

            //Uses the same parsing technique as Set of States
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
