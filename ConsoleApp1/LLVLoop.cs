using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LLVLoop
    {
        public class Node
        {
            public int value = 0;       
            public Node next = null;        

            public Node(int value)
            {
                this.value = value;        
            }
        }

        private Node head = null;          
        public Node Loop()      //O(n)
        {
            Node last = PerehodKElement(Size - 1);  //O(n)
            Random random = new Random();     
            int a = random.Next(0, Size - 1);  
            last.next = PerehodKElement(a);   //O(n)
            return last;
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

        private Node PerehodKElement(int index)    //O(n)
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
        public void DobavlenieKonec(int value)   //O(n)
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
            Node tail = new Node(value);
            it.next = tail;
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
