// Class that creates properties of a card

namespace HiLo
{
    class Card
    {
        //--------------------------------------------------------
        // member variables
        //--------------------------------------------------------
        int _number;
        string _suit;

        //--------------------------------------------------------
        // constructor
        //--------------------------------------------------------
        public Card(int number, string suit)
        {
            _number = number;
            _suit = suit;
        }

        //--------------------------------------------------------
        // member functions
        //--------------------------------------------------------
        public int getNumber()
        {
            return _number;
        }
        public void setNumber(int num)
        {
            _number = num;
        }

        public string getSuit()
        {
            return _suit;
        }
        public void setSuit(string suit)
        {
            _suit = suit;
        }
    }
}