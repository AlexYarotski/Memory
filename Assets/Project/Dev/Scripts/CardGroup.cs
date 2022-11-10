using UnityEngine;

namespace Project
{
    public class CardGroup
    {
        private readonly Card[] Cards = null;

        public bool IsSolved
        {
            get;
            private set;
        } = false;
        
        public CardGroup(params Card[] cards)
        {
            Cards = cards;
        }

        public bool IsEquals(Card[] cards)
        {
            var counter = 0;
            
            for (int i = 0; i < cards.Length; i++)
            {
                var card = cards[i];

                for (int j = 0; j < Cards.Length; j++)
                {
                    if (Cards[j] == card)
                    {
                        counter++;
                    }
                }
            }

            return counter == Cards.Length;
        }

        public Card[] GetCards()
        {
            return Cards;
        }

        public void SetColor(Color color)
        {
            for (int i = 0; i < Cards.Length; i++)
            {
                Cards[i].SetColor(color);
            }
        }

        public void SetSolved()
        {
            IsSolved = true;
        }

        public void ResetCards(Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].SetColorMaterial(Color.white);
            }
        }
    }
}