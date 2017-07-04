using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopDetection
{
    class ChainedList
    {
        Node head;

        public class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
            }
        }


        public ChainedList(Node head)
        {
            this.head = head;
        }

        public bool hasLoop()
        {

            Node slow = head;

            Node fast = head.next.next;

            while (fast != null)
            {

                if (slow == slow.next)
                    return true;

                slow = slow.next;
                for (int i = 0; i < 2; i++)
                {

                    if (slow.next == null)
                        return false;

                    slow.next = fast;
                }
            }
            return false;

        }

        public void listNodes()
        {
            Node currentNode = head;
            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
                currentNode.next = head;
            }

        }


        static void Main(string[] args)
        {
            Node head = new Node(1);
            ChainedList chainedList = new ChainedList(head);

            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);

            head.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node5.next = null;

            Console.WriteLine(chainedList.hasLoop());
            Console.ReadKey();
        }
    }
}
