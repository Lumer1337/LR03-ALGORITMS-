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
            Node it = head;
            int count = 0;
            for (int i = 0; i < Size; i++) //O(n^3)
            {
                if (it != null && count != i)
                {
                    it = it.next;
                    count++;
                }
                int size = Size;
                Node iterator2 = it;
                int count2 = count;
                for (int j = i + 1; j < size; j++)       //O(n^2)
                {
                    if (iterator2 != null && count2 != j)    //O(n)
                    {
                        if (iterator2.next != null)      //O(n)
                        {
                            iterator2 = iterator2.next;
                            if (it.value == iterator2.value)      //O(n)
                            {
                                UdalenieCKonca(count2 + 1);  //O(n)
                                count2--;
                            }
                            count2++;
                        }
                    }
                }
            }
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
