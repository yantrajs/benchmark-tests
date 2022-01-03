using System;

namespace LowLevelBenchamarks.ListVsSequence
{
    public class Sequence<T>
    {
        private const int DefaultCapacity = 4;

        class Node
        {
            internal T[] items;
            internal Node next;
        }
        private int count;
        private Node head;
        private Node tail;
        private T[] tailArray = Array.Empty<T>();
        private int tailCount;

        public int Count => count;

        public void Add(T item)
        {
            if (tailCount < tailArray.Length)
            {
                tailArray[tailCount++] = item;
                count++;
                return;
            }

            if (head == null)
            {
                tailArray = new T[DefaultCapacity];
                tailArray[0] = item;
                tailCount = 1;
                var t = new Node
                {
                    items = tailArray,
                };
                head = t;
                tail = t;
            }
            else
            {
                tailArray = new T[count];
                tailArray[0] = item;
                tailCount = 1;
                var t = new Node
                {
                    items = tailArray,
                };
                tail.next = t;
                tail = t;
            }
            count++;
        }


    }
}
