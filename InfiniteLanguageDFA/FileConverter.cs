using System;
using System.Collections.Generic;
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
        public FileConverter()
        {
            String path;
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    int numLines = 0;
                    while ((s = sr.ReadLine()) != null)
                    {
                        /**
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
                                break;
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            default:
                                break;
                        }

                        numLines++;
                    }
                }
            }
        }

        /**
         * This method parses the first line of the text file.
         */
        private Node[] setOfStates(String s)
        {
            //Count number of commas and add one. That is how many states you have.
            int count = 1;
            foreach (char c in s.ToCharArray())
            {
                if (c.Equals(","))
                {
                    count++;
                }
            }

            Node[] states = new Node[count];

            //First state name
            int comma = s.IndexOf(",");
            states[0].setName(s.Substring(1,comma-2));
            //Parse the string here:
            while (true)
            {
                comma = s.IndexOf(",");

            }

            return states;
        }
    }
}
