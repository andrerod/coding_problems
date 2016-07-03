using System;

namespace CodingProblems
{
    public class Chapter20
    {
        public static void Shuffle(int[] deck)
        {
            var random = new Random();
            for (int i = 0; i < deck.Length; i++)
            {
                var selected = random.Next(deck.Length - i) - 1;
                var tmp = deck[i];
                deck[i] = deck[selected];
                deck[selected] = tmp;
            }
        }
    }
}
