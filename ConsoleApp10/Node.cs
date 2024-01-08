using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class Node<T>
    {
        private T value;
        private Node<T> next;
        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }


        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }


        public T GetValue()
        {
            return this.value;
        }
        public Node<T> GetNext()
        {
            return next;
        }
        public void SetValue(T value)
        {
            this.value = value;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        public bool HasNext()
        {
            return this.next != null;
        }


        public override string ToString()
        {
            string str = string.Empty;
            if (this.next == null)
                return $"[{this.value}, next]=>null";
            else
                return $"[{this.value}, next]=>{this.next}";
        }

    }
}
