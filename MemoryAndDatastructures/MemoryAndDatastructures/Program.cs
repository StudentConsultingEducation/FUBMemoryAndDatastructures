using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAndDatastructures
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            Console.WriteLine("Please navigate through the menue by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. CheckParanthesis"
                + "\n0. Exit the application");
            char input = ' '; //Creates the character input to be used with the switch-case below.
            try
            {
                input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }

            switch (input)
            {
                case '1':
                    ExamineList();
                    break;
                case '2':
                    ExamineQueue();
                    break;
                case '3':
                    ReverseText();
                    break;
                case '4':
                    CheckParanthesis();
                    break;
                case '0':
                    return;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
            }
            Main();
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            List<string> theList = new List<string>();
            string input = "";
            char nav = ' ';
            string value = "";
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the list-testing facility.\nPlease use +, - or 0 to navigate \n+value to add value to a list.\n-value to remove value from a list\n0 to return to the main menu");
            try
            {
                input = Console.ReadLine();
                nav = input[0]; //Tries to set input to the first char in an input line
                value = input.Substring(1);
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }

            switch (nav)
            {
                case '+':
                    theList.Add(value);
                    Console.WriteLine("The list now Contains:");
                    WriteList(theList);
                    Console.WriteLine("The count is: " + theList.Count + " And the Capacity is: " + theList.Capacity);
                    Console.WriteLine("Please press any key to continue ...");
                    Console.ReadKey();
                    break;
                case '-':
                    theList.Remove(value);
                    Console.WriteLine("The list now Contains:");
                    WriteList(theList);
                    Console.WriteLine("The count is: " + theList.Count + " And the Capacity is: " + theList.Capacity);
                    Console.WriteLine("Please press any key to continue ...");
                    Console.ReadKey();
                    break;
                case '0':
                    return;
                default:
                    Console.WriteLine("Please enter some valid input (+value or -value)");
                    break;
            }
            }
        }

        static void WriteList(IEnumerable<string> list)
        {
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
        }
        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> theQueue = new Queue<string>();
            string input = "";
            char nav = ' ';
            string value = "";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the queue-testing facility.\nPlease use +, - or 0 to navigate \n+value to enqueue value to a queue.\n- to dequeue the first value\n0 to return to the main menu");
                try
                {
                    input = Console.ReadLine();
                    nav = input[0]; //Tries to set input to the first char in an input line
                    value = input.Substring(1);
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        Console.WriteLine("The list now Contains:");
                        WriteList(theQueue);
                        Console.WriteLine("Please press any key to continue ...");
                        Console.ReadKey();
                        break;
                    case '-':
                        theQueue.Dequeue();
                        Console.WriteLine("The list now Contains:");
                        WriteList(theQueue);
                        Console.WriteLine("Please press any key to continue ...");
                        Console.ReadKey();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter some valid input (+value or -value)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ReverseText()
        {
            /*
             * Use a Stack to reverse the input string from the user
             * Do not use arrays, lists, queues or the reversemethod.
            */
            Console.Clear();
            Console.WriteLine("Enter a string to reverse:");
            string input = Console.ReadLine();
            string reversed = "";
            Stack<char> reverseStack = new Stack<char>();
            for(int i = 0; i < input.Length; i++)
            {
                reverseStack.Push(input[i]);
            }
            while (reverseStack.Count > 0)
            {
                reversed += reverseStack.Pop();
            }
            Console.WriteLine(reversed);
            Console.WriteLine("Please press any key to continue ...");
            Console.ReadKey();
            
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})]
             * Example of incorrect: (()]), [), {[()}]
             */
            Console.WriteLine("Please enter a string, we will then check if it's well formed.\n(a[b{c}]d) is an example of a wellformed string.\n(a{b[c}]) is an example of a ppoorly formed string");
            string input = Console.ReadLine();
            Stack<char> controllStack = new Stack<char>();
            foreach (char c in input)
            {
                switch (c)
                {
                    case '(':
                        controllStack.Push(c);
                        break;
                    case '[':
                        controllStack.Push(c);
                        break;
                    case'{':
                        controllStack.Push(c);
                        break;
                    case'}':
                        try
                        {

                        if(controllStack.Pop() != '{')
                        {
                            Console.WriteLine("The string is not well formed");
                            return;
                        }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The string is not well formed");
                            return;
                        }
                        break;
                    case']':
                        try
                        {
                            if (controllStack.Pop() != '[')
                            {
                                Console.WriteLine("The string is not well formed");
                                return;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The string is not well formed");
                            return;
                        }
                        break;
                    case')':
                        try
                        {
                            if (controllStack.Pop() != '(')
                            {
                                Console.WriteLine("The string is not well formed");
                                return;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The string is not well formed");
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (controllStack.Count == 0)
            {
                Console.WriteLine("The string i well formed!");
            }

        }
    }
}
