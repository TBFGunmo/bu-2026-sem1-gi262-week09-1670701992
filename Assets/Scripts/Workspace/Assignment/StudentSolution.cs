using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment
{
    public class StudentSolution
    {
        class Action
        {
            public string Name;
            public int Value;
        }

        #region Lecture

        public (int Count, int Popped, int Peek, int CountAfterPeek) LCT01_StackSyntax()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int count = stack.Count;
            Debug.Log($"Count : {count}");

            int popped = stack.Pop();
            Debug.Log($"Pop : {popped}");

            int peek = stack.Peek();
            Debug.Log($"Peek : {peek}");

            int afterCount = stack.Count;

            return (count, popped, peek, afterCount);

        }

        public (int Count, int Dequeued, int Peek, int CountAfterPeek) LCT02_QueueSyntax()
        {
            Queue<int> quene = new Queue<int>();
            quene.Enqueue(1);
            quene.Enqueue(2);
            quene.Enqueue(3);

            int count = quene.Count;
            Debug.Log($"Count : {count}");

            int deQuene = quene.Dequeue();
            Debug.Log($"Dequene : {deQuene}");

            int peek = quene.Peek();
            Debug.Log($"Peek : {peek}");

            int afterCount = quene.Count;

            return (count, deQuene, peek, afterCount);

        }

        public string[] LCT03_ActionStack()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            
            Stack<Action> undoStack = new Stack<Action>();
            undoStack.Push(action1);
            undoStack.Push(action2);
            undoStack.Push(action3);

            int c = undoStack.Count;
            string[] history = new string[c];
            for (int i = 0; i < c; i++) 
            {
                var popped = undoStack.Pop();
                history[i] = popped.Name;
            }

            return history;
        }

        public string[] LCT04_ActionQueue()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            
            Queue<Action> quene = new Queue<Action>();
            quene.Enqueue(action1);
            quene.Enqueue(action2);
            quene.Enqueue(action3);

            int c = quene.Count;
            string[] history = new string[c];
            for (int i = 0; i < c; i++) 
            {
                var dequeue = quene.Dequeue();
                history[i] = dequeue.Name;
            }

            return history;

        }

        #endregion

        #region Assignment

        public string ASN01_ReverseString(string str)
        {
            Stack<char> letters = new Stack<char>();
            foreach(char letter in str) 
            {
                letters.Push(letter);
            };

            int c = letters.Count;
            string newstring = "";

            for (int i = 0; i < c; i++) 
            {
                newstring += letters.Pop();
            }

            return newstring;

        }

        public bool ASN02_StackPalindrome(string str)
        {
            Stack<char> stackLetters = new Stack<char>();
            Queue<char> queneLetter = new Queue<char>();
            foreach (char letter in str)
            {
                stackLetters.Push(letter);
                queneLetter.Enqueue(letter);
            };



            int c = stackLetters.Count;
            int c2 = queneLetter.Count;

            bool isPalindrome = false;

            if (c == c2) 
            {
                if (c == 0) 
                {
                    return true;
                }

                for (int i = 0; i < c; i++) 
                {
                    if (stackLetters.Pop() == queneLetter.Dequeue())
                    {
                        isPalindrome = true;
                    }
                    else 
                    { 
                        isPalindrome = false; 
                        break;
                    };
                }
            }

            return isPalindrome;

        }

        #endregion

        #region Extra

        public bool EX01_ParenthesesChecker(string str)
        {
            Stack<char> stackLetters = new Stack<char>();
            Queue<char> queneLetter = new Queue<char>();
            foreach (char letter in str)
            {
                stackLetters.Push(letter);
                queneLetter.Enqueue(letter);
            }
            ;

            int c = stackLetters.Count;
            int c2 = queneLetter.Count;

            bool isParentheses = false;

            if (c == c2)
            {
                if (c == 0)
                {
                    return true;
                }
                else if (c%2 != 0) 
                {
                    return false;
                }

                for (int i = 0; i < c / 2; i++)
                {
                    switch (queneLetter.Dequeue())
                    {
                        case '(':
                            if (stackLetters.Pop() == ')') 
                            {
                                isParentheses = true;
                            }
                            break;
                        case '[':
                            if (stackLetters.Pop() == ']')
                            {
                                isParentheses = true;
                            }
                            break;
                        case '{':
                            if (stackLetters.Pop() == '}')
                            {
                                isParentheses = true;
                            }
                            break;
                    }

                    if (isParentheses) 
                    {
                        break;
                    }
                    
                }
            }

            return isParentheses;
        }

        #endregion
    }
}
