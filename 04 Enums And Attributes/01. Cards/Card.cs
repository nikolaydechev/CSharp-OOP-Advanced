using System;

namespace _01.Cards
{
    public class Card : IComparable<Card>
    {
        private CardRank cardRank;
        private CardSuit cardSuit;

        public Card(CardRank cardRank, CardSuit cardSuit)
        {
            this.CardRank = cardRank;
            this.CardSuit = cardSuit;
        }

        public CardRank CardRank
        {
            get
            {
                return this.cardRank;
            }
            set
            {

                this.cardRank = value;
            }
        }

        public CardSuit CardSuit
        {
            get
            {
                return this.cardSuit;
            }
            set
            {

                this.cardSuit = value;
            }
        }

        public int CardPower()
        {
            return (int)this.CardRank + (int)this.CardSuit;
        }

        public override string ToString()
        {
            return $"Card name: {this.CardRank} of {this.CardSuit}; Card power: {this.CardPower()}";
        }

        public int CompareTo(Card other)
        {
            var cardRankComparison = this.CardPower().CompareTo(other.CardPower());

            return cardRankComparison;
        }
    }
}
