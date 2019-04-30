using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        protected List<Card> cards = new List<Card>();
        /// <summary>
        /// Constructor and overloaded constructor respectively
        /// </summary>
        public Hand() { }
        public Hand(Deck d, int numCards)
        {
            cards = new List<Card>();
        }

        /// <summary>
        /// How many cards are there?
        /// </summary>
        public int NumCards
        {
            get 
            {
                return cards.Count;
            }
        }

        /// <summary>
        /// Add a card to the hand yo
        /// </summary>
        /// <param name="c"></param>
        public void AddCard(Card c)
        { 
            cards.Add(c);
        }

        /// <summary>
        /// replaces the indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Card GetCard(int index) 
        {
            return null;
        }
        
        public int IndexOf(Card c)
        {
            return -1;
        }
        
        public int IndexOf(int value)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Value == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public int IndexOf(int value, int suit)
        {
            return -1;
        }

        public bool HasCard(Card c)
        {
            return false;
        }

        public bool HasCard(int value)
        {
            return IndexOf(value) != -1;
        }

        public bool HasCard(int value, int suit)
        {
            return false;
        }

        public Card Discard(int index)
        {
            return null;
        }

        public override string ToString()
        {
            string output = "";
            return output;
        }
    }
}
