using System.Collections;

namespace poker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList deck = CreateDeck();
            ArrayList shuffled = ShuffleDeck(deck);
            ArrayList returnVal = PopCard(shuffled);
            shuffled = (ArrayList)returnVal[0]!;
            var card = (String)returnVal[1]!;
            //foreach (string i in shuffled)
            //{
            //    Console.WriteLine(i);
            //}
            Console.WriteLine(card);
        }
        static ArrayList CreateDeck()
        {
            // Create empty collection
            var ranks = new ArrayList();

            // Add the numeric cards
            for (int i = 2; i <= 10; i++)
            {
                ranks.Add(i.ToString());
            }

            // Better
            ranks.AddRange(new ArrayList() { "Ace", "Jack", "Queen", "King" });

            // Suits
            var suits = new ArrayList() { "Clubs", "Hearts", "Diamonds", "Spades" };

            // Empty deck
            var deck = new ArrayList();

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

        static ArrayList ShuffleDeck(ArrayList deck)
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

        static ArrayList PopCard(ArrayList deck) 
        {
            string card = "";
            if (deck.Count > 0)
            {
                card = deck[0]!.ToString()!;
            }

            return new ArrayList() { deck, card };
        }
    }
}
