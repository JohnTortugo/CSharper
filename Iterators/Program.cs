using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterators
{
    public static class Program
    {
        public static void Main()
        {
            new TestOne().Run();
        }
    }

    public class DaysOfWeek : IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        public IEnumerator GetEnumerator()
        {
            foreach (var item in days)
            {
                yield return item;
            }
        }
    }

    public class Stack<T> : IEnumerable<T>
    {
        private T[] values = new T[100];
        private int top = 0;

        public void Push(T value)
        {
            values[top] = value;
            top++;
        }

        public T Pop()
        {
            top--;
            return values[top];
        }

        /// <summary>
        /// This method implements the GetEnumerator method. It allows
        /// an instance of the class to be used in a foreach statement.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int index=top-1; index>=0; index--)
            {
                yield return values[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> TopToBottom
        {
            get { return this; }
        }

        public IEnumerable<T> BottomToTop
        {
            get
            {
                for (int index=0; index<=top-1; index++)
                {
                    yield return values[index];
                }
            }
        }

        public IEnumerable<T> TopN(int itemsFromTop)
        {
            // Return less than itemsFromTop if necessary
            int endIndex = itemsFromTop >= top ? 0 : top - itemsFromTop;

            for (int index = top-1; index>=endIndex; index--)
            {
                yield return values[index];
            }
        }
    }

    public class TestOne {
        private IEnumerable BasicOne()
        {
            Console.Write("Next one: ");
            yield return 1;
            Console.Write("Next one: ");
            yield return 3;
            Console.Write("Next one: ");
            yield return 5;
            Console.Write("Next one: ");
            yield return 7;
            yield break;
        }

        public void Run()
        {
            foreach (var item in BasicOne())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------");

            DaysOfWeek dow = new DaysOfWeek();

            foreach (var item in dow)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
