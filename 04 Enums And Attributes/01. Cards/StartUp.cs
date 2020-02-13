using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cards
{
    public class StartUp
    {
        public static void Main()
        {
            //EX. 1,2

            //var input = Console.ReadLine();
            //Array cards = Enum.GetValues(typeof(CardRank));
            //Console.WriteLine($"{input}:");
            //foreach (var card in cards)
            //{
            //    Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");
            //}

            // EX. 3,4,5
            //var cardRank = (CardRank)Enum.Parse(typeof(CardRank), Console.ReadLine());
            //var cardSuit = (CardSuit)Enum.Parse(typeof(CardSuit), Console.ReadLine());

            //var cardRank1 = (CardRank)Enum.Parse(typeof(CardRank), Console.ReadLine());
            //var cardSuit1 = (CardSuit)Enum.Parse(typeof(CardSuit), Console.ReadLine());

            //var card = new Card(cardRank, cardSuit);
            //var card1 = new Card(cardRank1, cardSuit1);
            //Console.WriteLine(card.CompareTo(card1) < 0 ? card1.ToString() : card.ToString());


            //EX 6 ??? !
            var input = Console.ReadLine();
            
            if (input == "Rank")
            {
               //PrintAttribute(typeof(CardRank));
                var attributes = typeof(CardRank).GetCustomAttributes(false);
                Console.WriteLine(attributes[0]);
            }
            else
            {
                //PrintAttribute(typeof(CardSuit));
                var attributes = typeof(CardSuit).GetCustomAttributes(false);
                Console.WriteLine(attributes[0]);
            }


            //EX. 7
            //var input = Console.ReadLine();

            //Array cardRanks = Enum.GetValues(typeof(CardRank));
            //Array cardSuits = Enum.GetValues(typeof(CardSuit));

            //foreach (var cardSuit in cardSuits)
            //{
            //    foreach (var cardRank in cardRanks)
            //    {
            //        Console.WriteLine($"{cardRank} of {cardSuit}");
            //    }
            //}

            //EX. 8
            var firstPlayer = Console.ReadLine();
            var secondPlayer = Console.ReadLine();

            var firstPlayerCards = new Dictionary<int, Card>();
            var secondPlayerCards = new Dictionary<int, Card>();
            var cardPowers = new List<int>();

            GetEvaluationOfCards(firstPlayerCards, cardPowers);
            GetEvaluationOfCards(secondPlayerCards, cardPowers);
            Console.WriteLine(GetWinner(firstPlayer, secondPlayer, firstPlayerCards, secondPlayerCards));
        }

        private static string GetWinner(string firstPlayer, string secondPlayer, Dictionary<int, Card> firstPlayerCards, Dictionary<int, Card> secondPlayerCards)
        {
            if (firstPlayerCards.Keys.Max() > secondPlayerCards.Keys.Max())
            {
                var firstPlayerCard = firstPlayerCards[firstPlayerCards.Keys.Max()];
                return $"{firstPlayer} wins with {firstPlayerCard.CardRank} of {firstPlayerCard.CardSuit}.";
            }
            else
            {
                var secondPlayerCard = secondPlayerCards[secondPlayerCards.Keys.Max()];
                return $"{secondPlayer} wins with {secondPlayerCard.CardRank} of {secondPlayerCard.CardSuit}.";
            }

        }

        private static void GetEvaluationOfCards(Dictionary<int, Card> playerCards, List<int> cardPowers)
        {
            while (playerCards.Count < 5)
            {
                try
                {
                    var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (!Enum.IsDefined(typeof(CardRank), input[0]) || !Enum.IsDefined(typeof(CardSuit), input[2]))
                    {
                        throw new ArgumentException("No such card exists.");
                    }

                    var cardRank = (CardRank)Enum.Parse(typeof(CardRank), input[0]);
                    var cardSuit = (CardSuit)Enum.Parse(typeof(CardSuit), input[2]);
                    var card = new Card(cardRank, cardSuit);

                    if (!cardPowers.Contains(card.CardPower()))
                    {
                        cardPowers.Add(card.CardPower());
                        playerCards.Add(card.CardPower(), card);
                    }
                    else
                    {
                        throw new ArgumentException($"Card is not in the deck.");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
        //public static void PrintAttribute(Type type)
        //{
        //    var attributes = type.GetCustomAttributes(false);
        //    Console.WriteLine(attributes[0]);
        //}
    }
}
