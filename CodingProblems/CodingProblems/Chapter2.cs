namespace CodingProblems
{
    public class Chapter2
    {
        // with a delete twist instead of being just return
        public static Node Problem2(Node node, int indexFromEnd)
        {
            var scout = node;
            Node beforeToDelete = null;

            for (int i = 1; i < indexFromEnd; i++)
            {
                if (scout == null)
                {
                    return node;
                }

                scout = scout.Next;
            }

            while (scout.Next != null)
            {
                scout = scout.Next;

                if (beforeToDelete == null)
                {
                    beforeToDelete = node;
                }
                else
                {
                    beforeToDelete = beforeToDelete.Next;
                }
            }

            if (beforeToDelete == null)
            {
                return node.Next;
            }

            if (beforeToDelete.Next != null)
            {
                beforeToDelete.Next = beforeToDelete.Next.Next;
            }

            return node;
        }

        public static bool DetectLoops(Node node)
        {
            var slowIterator = node;
            var fastIterator = node;

            while (fastIterator != null && fastIterator.Next != null)
            {
                slowIterator = slowIterator.Next;
                fastIterator = fastIterator.Next.Next;

                if (slowIterator == fastIterator)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
