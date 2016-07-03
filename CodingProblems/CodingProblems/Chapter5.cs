namespace CodingProblems
{
    public class Chapter5
    {
        public static uint SwapOddEvenBits(uint x)
        {
            var first = ((x & 0xaaaaaaaa) >> 1);
            var second = ((x & 0x55555555) << 1);

            return (first | second);
        }

        public static int SwapRequired(int a, int b)
        {
            int count = 0;
            for (int c = a ^ b; c != 0; c = c >> 1)
            {
                count += c & 1;
            }

            return count;
        }
    }
}
