namespace HiLo
{
    class Director
    {
        //--------------------------------------------------------
        // member variables
        //--------------------------------------------------------
        Deck _deckOfCards;
        int _score;

        //--------------------------------------------------------
        // constructors
        //--------------------------------------------------------
        public Director()
        {
            // creates the deck of cards
            _deckOfCards = new Deck();

            // player starting score
            _score = 300;
        }

        //--------------------------------------------------------
        // member functions
        //--------------------------------------------------------
        // if user guessed correctly score +100
        // else -75
        public void calculateScore(int card, int nextCard, string guess)
        {
            bool isCorrectGuess;
            if (guess == "h")
            {isCorrectGuess = nextCard > card;}
            else
            {isCorrectGuess = nextCard < card;}

            if (isCorrectGuess)
            {_score += 100;}
            else
            {_score -= 75;}
        }

        // Run game
        public void RunGame()
        {
            Card card = _deckOfCards.getRandomCard();            
            bool exitGame = false;
            while (!exitGame)
            {
                // INPUT, UPDATE, OUTPUT
                int cardNum = card.getNumber();               
                Console.WriteLine($"The card is: {cardNum}");
                
                Console.Write("Higher or lower? [h/l]: ");
                string guess = Console.ReadLine();
                
                Card nextCard;
                int nextCardNum;
                do
                {
                    nextCard = _deckOfCards.getRandomCard();
                    nextCardNum = nextCard.getNumber();
                }
                while (nextCardNum == cardNum);

                Console.WriteLine($"The next card is: {nextCardNum}");                            
                calculateScore(cardNum, nextCardNum, guess);
                card = nextCard;

                Console.WriteLine($"Your score is: {_score}");
                if (_score < 0)
                {
                    Console.WriteLine("You Lost, Game Over!");
                    exitGame = true;
                }
                else
                {
                    Console.Write("Play again? [y/n]: ");
                    string playAgain = Console.ReadLine();
                    if (playAgain == "n")
                    {exitGame = true;}
                }
                Console.WriteLine();
                //_deckOfCards.printDeck();
            }
        }
    }
}