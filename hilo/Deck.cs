using System;

// Class that create properties of a deck of cards

namespace HiLo
{
    class Deck
    {
        //--------------------------------------------------------
        // member variables
        //--------------------------------------------------------
        List<Card> _deck;
        int _count;

        //--------------------------------------------------------
        // constructor
        //--------------------------------------------------------
        // creates a deck of 52 cards
        public Deck()
        {            
            _deck = new List<Card>();
            
            for (int s = 1; s <= 4; s++)
            {
                string suit = "";
                if (s == 1){suit = "club";}
                else if (s == 2){suit = "diamond";}
                else if (s == 3){suit = "heart";}
                else {suit = "spade";}
                for (int n = 1; n <= 13; n++)
                {
                    Card card = new Card(n, suit);
                    _deck.Add(card);
                    _count++;
                }
            }
            
        }

        //--------------------------------------------------------
        // member functions
        //--------------------------------------------------------
        // print whole deck
        public void printDeck()
        {
            foreach (Card card in _deck)
            {
                Console.WriteLine($"Suit: {card.getSuit()}");
                Console.WriteLine($"Number: {card.getNumber()}");
            }
        }

        // get a random card
        public Card getRandomCard()
        {
            Random rnd = new Random();
            int index = rnd.Next(52);
            return _deck[index];
        }
    }
}