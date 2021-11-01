using System.Text;

namespace InterviewProblems.ReverseLinkedList
{
    public class Node
    {
        public string Value { get; set; }
        public Node Next { get; set; }
    }

    public class SinglyLinkedList
    {
        private Node _head;

        public SinglyLinkedList(params string[] items)
        {
            _head = null;
            for (int i = items.Length-1; i >= 0; i--)
            {
                var current = new Node
                {
                    Value = items[i], 
                    Next = _head
                };
                _head = current;
            }
        }

        public void Reverse()
        {
            // TODO: Ask interviewee to add implementation
            // Node previous = null;
            // Node current = _head;
            // while (current != null) 
            //     (previous, current, current.Next) = (current, current.Next, previous);
            // _head = previous;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var current = _head;
            while (current != null)
            {
                sb.Append(current.Value);
                sb.Append(",");
                current = current.Next;
            }
            sb.Length--;
            return sb.ToString();
        }
    }
}