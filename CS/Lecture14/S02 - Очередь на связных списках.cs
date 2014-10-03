using System;

namespace Slide02
{
    public class QueueItem
    {
        public string Value { get; set; }
        public QueueItem Next { get; set; }
    }

    public class Queue
    {
        QueueItem head;
        QueueItem tail;

        public void Enqueue(string value)
        {
            if (head == null)
                tail = head = new QueueItem { Value = value, Next = null };
            else
            {
                var item = new QueueItem { Value = value, Next = null };
                tail.Next = item;
                tail = item;
            }
        }

        public string Dequeue()
        {
            if (head == null) throw new InvalidOperationException();
            var result = head.Value;
            head = head.Next;
            if (head == null)
                tail = null;
            return result;
        }
        

    }
}