namespace CodingProblems
{
    public class Node
    {
        public int Value { get; set; }

        public Node Next { get; set; }

        public void AddToTail(Node newNode)
        {
            var current = this;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        public bool Contains(int value)
        {
            var current = this;

            while (current != null)
            {
                if (current.Value == value)
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }
    }
}
