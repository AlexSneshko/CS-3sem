using _053506_Snetko_Lab5.Entities;
using _053506_Snetko_Lab5.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Snetko_Lab5.Collections
{
    public class MyCustomCollection<T> : ICustomCollection<T> where T : class
    {
        private class Node
        {
            public T data;
            public Node pNext;
            public Node(T data) => this.data = data;
        }

        private Node head;
        private Node tail;
        private Node current;
        private int _count;
        public int Count { get => _count; }

        public MyCustomCollection()
        {
            head = null;
            tail = null;
            current = null;
            _count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index > Count || index < 0) throw new IndexOutOfRangeException();

                Node temp = head;
                for (int i = 0; i < index; i++)
                    temp = temp.pNext;
                return temp.data;
            }
            set
            {
                if (index > Count || index < 0) throw new IndexOutOfRangeException();

                Node temp = head;
                for (int i = 0; i < index; i++)
                    temp = temp.pNext;
                temp.data = value;
            }
        }


        public void Add(T item)
        {
            if (head == null)
            {
                head = new Node(item);
                tail = head;
                current = head;
            }
            else
            {
                tail.pNext = new Node(item);
                tail = tail.pNext;
            }
            _count++;
        }

        public T Current() => current.data;

        public void Next()
        {
            if (current.pNext != null) current = current.pNext;
        }

        public void Remove(T item)
        {
            if (!Contains(item)) throw new NoItemsException(item.ToString());

            Node temp = head;
            while (temp.pNext.data.Equals(item))
                temp = temp.pNext;

            temp.pNext = temp.pNext.pNext;
            _count--;
        }

        public T RemoveCurrent()
        {
            if (current != null)
            {
                Node temp = head;

                while (temp.pNext != current)
                    temp = temp.pNext;

                T result = temp.data;
                Next();
                temp.pNext = temp.pNext.pNext;
                _count--;
                return result;
            }
            else throw new NullReferenceException();
        }

        public bool Contains(T item)
        {
            Node temp = head;
            while(temp != null)
            {
                if (temp.data == item) return true;
                temp = temp.pNext;
            }
            return false;
        }

        public void Reset() => current = head;
    }
}
