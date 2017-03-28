using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;

namespace BlackJack
{
    public class CardsDeck
    {
        private static List<Card> cardsdeck = new List<Card>(52);
        private static CardsDeck instance;
        private static bool is_filled = false;
        //private bool[] is_on_deck = new bool[52];
        public static CardsDeck Instance
        {
            get
            {
                if (instance == null) instance = new CardsDeck();
                return instance;
            }
        }
        private CardsDeck()
        {
            fillDeck();
            shuffle();
        }

        public void fillDeck()
        {
            if (!is_filled)
            {
                cardsdeck.Clear();

                // 2
                cardsdeck.Add(new Card(new Bitmap("cards\\2_of_clubs.png"), "2 clubs", '2', 2, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\2_of_diamonds.png"), "2 diamonds", '2', 2, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\2_of_hearts.png"), "2 hearts", '2', 2, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\2_of_spades.png"), "2 spades", '2', 2, Card.Colours.Spade, false));

                // 3
                cardsdeck.Add(new Card(new Bitmap("cards\\3_of_clubs.png"), "3 clubs", '3', 3, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\3_of_diamonds.png"), "3 diamonds", '3', 3, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\3_of_hearts.png"), "3 hearts", '3', 3, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\3_of_spades.png"), "3 spades", '3', 3, Card.Colours.Spade, false));

                // 4
                cardsdeck.Add(new Card(new Bitmap("cards\\4_of_clubs.png"), "4 clubs", '4', 4, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\4_of_diamonds.png"), "4 diamonds", '4', 4, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\4_of_hearts.png"), "4 hearts", '4', 4, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\4_of_spades.png"), "4 spades", '4', 4, Card.Colours.Spade, false));

                // 5
                cardsdeck.Add(new Card(new Bitmap("cards\\5_of_clubs.png"), "5 clubs", '5', 5, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\5_of_diamonds.png"), "5 diamonds", '5', 5, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\5_of_hearts.png"), "5 hearts", '5', 5, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\5_of_spades.png"), "5 spades", '5', 5, Card.Colours.Spade, false));

                // 6
                cardsdeck.Add(new Card(new Bitmap("cards\\6_of_clubs.png"), "6 clubs", '6', 6, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\6_of_diamonds.png"), "6 diamonds", '6', 6, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\6_of_hearts.png"), "6 hearts", '6', 6, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\6_of_spades.png"), "6 spades", '6', 6, Card.Colours.Spade, false));

                // 7
                cardsdeck.Add(new Card(new Bitmap("cards\\7_of_clubs.png"), "7 clubs", '7', 7, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\7_of_diamonds.png"), "7 diamonds", '7', 7, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\7_of_hearts.png"), "7 hearts", '7', 7, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\7_of_spades.png"), "7 spades", '7', 7, Card.Colours.Spade, false));

                // 8
                cardsdeck.Add(new Card(new Bitmap("cards\\8_of_clubs.png"), "8 clubs", '8', 8, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\8_of_diamonds.png"), "8 diamonds", '8', 8, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\8_of_hearts.png"), "8 hearts", '8', 8, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\8_of_spades.png"), "8 spades", '8', 8, Card.Colours.Spade, false));

                // 9
                cardsdeck.Add(new Card(new Bitmap("cards\\9_of_clubs.png"), "9 clubs", '9', 9, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\9_of_diamonds.png"), "9 diamonds", '9', 9, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\9_of_hearts.png"), "9 hearts", '9', 9, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\9_of_spades.png"), "9 spades", '9', 9, Card.Colours.Spade, false));

                // 10
                cardsdeck.Add(new Card(new Bitmap("cards\\10_of_clubs.png"), "10 clubs", '1', 10, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\10_of_diamonds.png"), "10 diamonds", '1', 10, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\10_of_hearts.png"), "10 hearts", '1', 10, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\10_of_spades.png"), "10 spades", '1', 10, Card.Colours.Spade, false));

                // J
                cardsdeck.Add(new Card(new Bitmap("cards\\jack_of_clubs.png"), "jack clubs", 'J', 10, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\jack_of_diamonds.png"), "jack diamonds", 'J', 10, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\jack_of_hearts.png"), "jack hearts", 'J', 10, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\jack_of_spades.png"), "jack spades", 'J', 10, Card.Colours.Spade, false));

                // Q
                cardsdeck.Add(new Card(new Bitmap("cards\\queen_of_clubs.png"), "queen clubs", 'Q', 10, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\queen_of_diamonds.png"), "queen diamonds", 'Q', 10, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\queen_of_hearts.png"), "queen hearts", 'Q', 10, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\queen_of_spades.png"), "queen spades", 'Q', 10, Card.Colours.Spade, false));

                // K
                cardsdeck.Add(new Card(new Bitmap("cards\\king_of_clubs.png"), "king clubs", 'K', 10, Card.Colours.Club, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\king_of_diamonds.png"), "king diamonds", 'K', 10, Card.Colours.Diamond, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\king_of_hearts.png"), "king hearts", 'K', 10, Card.Colours.Heart, false));
                cardsdeck.Add(new Card(new Bitmap("cards\\king_of_spades.png"), "king spades", 'K', 10, Card.Colours.Spade, false));

                // A
                cardsdeck.Add(new Card(new Bitmap("cards\\ace_of_clubs.png"), "ace clubs", 'A', 0, Card.Colours.Club, true)); // 0 => 1 lub 11 tzn. AS
                cardsdeck.Add(new Card(new Bitmap("cards\\ace_of_diamonds.png"), "ace diamonds", 'A', 0, Card.Colours.Diamond, true));
                cardsdeck.Add(new Card(new Bitmap("cards\\ace_of_hearts.png"), "ace hearts", 'A', 0, Card.Colours.Heart, true));
                cardsdeck.Add(new Card(new Bitmap("cards\\ace_of_spades.png"), "ace spades", 'A', 0, Card.Colours.Spade, true));

                //for (int i = 0; i < is_on_deck.Count(); i++) is_on_deck[i] = true;
                //cardsdeck_copy = new List<Card>(52);
                //foreach(Card card in cardsdeck) cardsdeck_copy.Add((Card)card.Clone());

                //cardsdeck_copy = cardsdeck.ConvertAll(card => new Card(card.Image, card.Name, card.Figure, card.Points, card.Colour, card.IsAce));

                is_filled = true;
                this.shuffle();
            }
            else reFillDeck();
        }

        public void reFillDeck() // przywróć wszystkie karty
        {
            for (int i = 0; i < cardsdeck.Count(); i++) cardsdeck[i].IsUsed = false;
            this.shuffle();
        }

        private void shuffle() // tasowanie
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = cardsdeck.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Card value = cardsdeck[k];
                cardsdeck[k] = cardsdeck[n];
                cardsdeck[n] = value;
            }
        }

        public Card getTop() // weź kartę z góry talii - null = brak kart
        {
            if (isHalfUsed()) reFillDeck();
            Card card = cardsdeck.Find(x => x.IsUsed == false);
            //if (card == null) 
            card.IsUsed = true;
            return card;
        }

        public bool isEmpty() // czy talia pusta ?
        {
            if (cardsdeck.Count() == 0) return true;
            return false;
        }

        public bool isHalfUsed() // czy połowa użyta ?
        {
            if (cardsdeck.Count(x => x.IsUsed == false) <= 26)
            {
                Debug.WriteLine("polowa");
                return true;
            }
            return false;
        }

        public string toString()
        {
            StringBuilder builder = new StringBuilder();
            foreach(Card card in cardsdeck) builder.Append(card.Name);
            return builder.ToString();
        }
    }
}
