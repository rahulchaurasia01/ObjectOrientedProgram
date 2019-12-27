/*
 *  Purpose: Logic of queue Linked List.
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   27-12-2019
 */

using System;
using System.Text;

namespace ObjectOrientedProgram.Core
{
    class QueueLinkedList
    {

        public class QueueNode
        {
            public string data;
            public QueueNode next;
        }


        QueueNode front, rear;

        /// <summary>
        /// It Enqueue the data using Linked List
        /// </summary>
        /// <param name="data"></param>
        public void Enqueue(string data)
        {
            QueueNode queueNode = new QueueNode();

            if(rear == null)
            {
                queueNode.data = data;
                queueNode.next = null;
                front = queueNode;
                rear = queueNode;
            }
            else
            {
                queueNode.data = data;
                queueNode.next = null;
                rear.next = queueNode;
                rear = queueNode;
            }
        }

        /// <summary>
        /// It dequeue the data from the Linked List.
        /// </summary>
        public void Dequeue()
        {
            if (front == null && rear == null)
                Console.WriteLine("No Data Present in Queue Linked List");
            else
            {
                Console.Write(front.data+"\t");
                front = front.next;
            }
        }


        public string Search(int position)
        {

            if (rear != null)
            {
                int count = 1;
                for(QueueNode queueNode = front; queueNode != null; queueNode = queueNode.next)
                {
                    if (count == position)
                        return queueNode.data;
                    count++;
                }
            }
           
            return "No Data Present";
        }

    
        /// <summary>
        /// Return true if the queue is empty else its return false
        /// </summary>
        /// <returns></returns>
        public Boolean IsEmpty()
        {
            if (front == null && rear == null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// It Count the number of element is present in the queue.
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            int count = 0;

            if (front == null && rear == null)
                return count;

            for (QueueNode p = front; p != null; p = p.next)
                count++;

            return count;

        }
    
        /// <summary>
        /// It Display the list Present in the Queue Linked List.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            if (front == null && rear == null)
                return "Empty Queue";
            for (QueueNode p = front; p != null; p = p.next)
                str.Append(p.data + " ");

            return str.ToString();
        }
    
    }
}
