using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LinkedListVector
    {
        private Node head = null;          
        public class Node
        {
            public int value = 0;       
            public Node next = null;    

            public Node(int value)
            {
                this.value = value;      
            }
        }
        public int Size      
        {
            get
            {
                Node it = head;       
                int count = 0;          
                while (it != null)  
                {
                    it = it.next;       
                    count++;                
                }
                return count;
            }
        }
        public void DobavlenieKonec(int value)        //O(n)
        {
            if (head == null)
            {
                head = new Node(value);
                return;
            }
            Node it = head;
            while (it.next != null)
            {
                it = it.next;
            }
            Node end = new Node(value);
            it.next = end;
        }
        public void DeleteCopies()
        {
            head = МergeSort(head);
            Node iterator = head;
            Node next_next;
            if (head == null)
            {
                return;
            }
            while (iterator.next != null)
            {
                if (iterator.value == iterator.next.value)
                {
                    next_next = iterator.next.next;
                    iterator.next = null;
                    iterator.next = next_next;
                }
                else
                {
                    iterator = iterator.next;
                }
            }
        }
        static Node МergeSort(Node head)
        {
            if (head.next == null)
                return head;

            Node mid = FindMid(head);
            Node head2 = mid.next;
            mid.next = null;
            Node newHead1 = МergeSort(head);
            Node newHead2 = МergeSort(head2);
            Node finalHead = Merge(newHead1, newHead2);

            return finalHead;
        }

        static Node Merge(Node head1, Node head2)
        {
            Node merged = new Node(0);
            Node temp = merged;

            while (head1 != null && head2 != null)
            {
                if (head1.value < head2.value)
                {
                    temp.next = head1;
                    head1 = head1.next;
                }
                else
                {
                    temp.next = head2;
                    head2 = head2.next;
                }
                temp = temp.next;
            }

            while (head1 != null)
            {
                temp.next = head1;
                head1 = head1.next;
                temp = temp.next;
            }

            while (head2 != null)
            {
                temp.next = head2;
                head2 = head2.next;
                temp = temp.next;
            }
            return merged.next;
        }

        static Node FindMid(Node head)
        {
            Node slow = head, fast = head.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        public void UdalenieCKonca(int index)        //O(n)
        {
            if (index == 0)
            {
                if (head == null)
                {
                    return;
                }
                head = head.next;
            }
            else
            {
                Node predelem = PerehodKElement(index - 1);       //O(n)
                if (predelem.next == null)
                {
                    try
                    {
                        throw new IndexOutOfRangeException("Неверный индекс: " + index);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    predelem.next = predelem.next.next;
                }
            }
        }
        private Node PerehodKElement(int index)           //O(n)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Индекс не может быть меньше 0");
            }
            else if (head == null)
            {
                throw new IndexOutOfRangeException("Неверный индекс: " + index);
            }
            Node it = head;
            int count = 0;
            while (it != null && count != index)
            {
                it = it.next;
                count++;
            }

            if (it == null || count != index)
            {
                throw new IndexOutOfRangeException("Неверный индекс, выход за рамки массива");
            }
            return it;
        }

        public Node PerehodKElementFromTheEnd(int index)
        {
            return PerehodKElement(Size - index);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            Node iterator = head;
            while (iterator.next != null)
            {
                sb.Append(iterator.value).Append(", ");
                iterator = iterator.next;
            }
            sb.Append(iterator.value);
            sb.Append("]");
            return sb.ToString();
        }
    }
}
