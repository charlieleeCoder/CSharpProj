using System.Collections;

namespace poker
{
    internal class Program
    {
        static void Main()
        {
            // Creat ordered deck
            var deck = CreateDeck();

            // Shuffle cards
            var shuffled = ShuffleDeck(deck);

            // Return tuple
            var returnVal = PopCard(shuffled);

            // Not using the rest of the deck
            // shuffled = returnVal.Item1;

            // Random card
            var card = returnVal.Item2;

            Console.WriteLine(card);
        }
        static List<String> CreateDeck()
        {
            // Create empty collection
            var ranks = new List<String>();

            // Add the numeric cards
            for (int i = 2; i <= 10; i++)
            {
                ranks.Add(i.ToString());
            }

            // Better
            ranks.AddRange(new List<String> { "Ace", "Jack", "Queen", "King" });

            // Suits
            var suits = new List<String> { "Clubs", "Hearts", "Diamonds", "Spades" };

            // Empty deck
            var deck = new List<String>();

            // Append all suits of each rank
            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    deck.Add($"{rank} of {suit}");
                }
            }

            return deck;
        }

        static List<String> ShuffleDeck(List<String> deck)
        {
            int length = deck.Count;
            var randGenerator = new Random();

            for (int i = 0; i < length; i++)
            {
                int j = randGenerator.Next(0, length);
                string wordI = deck[i]!.ToString()!;
                string wordJ = deck[j]!.ToString()!;
                deck[i] = wordJ;
                deck[j] = wordI;
            }
            return deck;
        }

        static (List<String>, String) PopCard(List<String> deck) 
        {
            string card = "";
            if (deck.Count > 0)
            {
                card = deck[0]!.ToString()!;
            }

            return (deck, card);
        }
    }
}
