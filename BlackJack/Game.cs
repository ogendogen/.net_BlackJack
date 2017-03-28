using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BlackJack
{
    public class Game
    {
        private static Game instance;
        private List<Card> player_cards = new List<Card>(6);
        private List<Card> croupier_cards = new List<Card>(6);
        private CardsDeck cardsdeck = CardsDeck.Instance;
        private MainWindow parent;
        public enum Person : int { Player, Croupier}
        public static Game Instance
        {
            get
            {
                if (instance == null) instance = new Game();
                return instance;
            }
        }

        public List<Card> PlayerCards
        {
            get
            {
                return player_cards;
            }
        }

        public List<Card> CroupierCards
        {
            get
            {
                return croupier_cards;
            }
        }

        public MainWindow Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        private Game()
        {

        }

        public void start()
        {
            //parent.clearControls();
            if (cardsdeck.isHalfUsed()) cardsdeck.reFillDeck();

            //cardsdeck.fillDeck();
            //cardsdeck.shuffle();

            player_cards.Clear();
            croupier_cards.Clear();

            player_cards.Add(cardsdeck.getTop());
            croupier_cards.Add(cardsdeck.getTop());
            player_cards.Add(cardsdeck.getTop());
        }

        public void hit()
        {
            player_cards.Add(cardsdeck.getTop());
        }

        public int stand() // rozgrywa scenariusz w pamięci, później tylko trzeba zwizualizować to
        {
            while(true) // dokładaj karty dopóki ktoś wygra lub zremisuje
            {
                croupier_cards.Add(cardsdeck.getTop());
                if (isPlayerWin()) return 0;
                else if (isCroupierWin()) return 1;
                else if (isDraw()) return 2;
            }
        }

        public bool isPlayerWin()
        {
            int player_points = getPoints(Person.Player);
            int croupier_points = getPoints(Person.Croupier);

            if (isBlackJack(Person.Player) && !isBlackJack(Person.Croupier)) return true;
            if ((player_points > croupier_points && player_points <= 21 && croupier_points >= 17) || (croupier_points > 21)) return true;
            return false;
        }

        public bool isCroupierWin()
        {
            int player_points = getPoints(Person.Player);
            int croupier_points = getPoints(Person.Croupier);

            if (!isBlackJack(Person.Player) && isBlackJack(Person.Croupier)) return true;
            if ((player_points < croupier_points && croupier_points >= 17 && croupier_points <= 21) || (player_points > 21)) return true;
            return false;
        }

        public bool isDraw()
        {
            int player_points = getPoints(Person.Player);
            int croupier_points = getPoints(Person.Croupier);

            if (isBlackJack(Person.Player) && isBlackJack(Person.Croupier)) return true;
            if (player_points == croupier_points && croupier_points >= 17 && croupier_points <= 21) return true;
            return false;
        }

        public bool isBlackJack(Person person)
        {
            int player_points = getPoints(Person.Player);
            int croupier_points = getPoints(Person.Croupier);

            if (person == Person.Croupier && croupier_points == 21 && croupier_cards.Count() == 2)
            {
                if (croupier_cards[0].IsAce && croupier_cards[1].Points == 10) return true;
                if (croupier_cards[1].IsAce && croupier_cards[0].Points == 10) return true;
            }
            else if (person == Person.Player && player_points == 21 && player_cards.Count() == 2)
            {
                if (player_cards[0].IsAce && player_cards[1].Points == 10) return true;
                if (player_cards[1].IsAce && player_cards[0].Points == 10) return true;
            }
            return false;
        }

        public int getPoints(Person person) // true = player, false = croupier
        {
            int sum = 0;
            if (person == Person.Player)
            {
                if (player_cards.Count() == 0) return 0;
                else
                {
                    foreach (Card card in player_cards) sum += card.Points;
                    int aces = countAces(Person.Player);
                    while (aces > 0)
                    {
                        sum += 11;
                        if (sum > 21) sum -= 10;
                        aces--;
                    }
                    return sum;
                }
            }
            else
            {
                if (croupier_cards.Count() == 0) return 0;
                else
                {
                    foreach (Card card in croupier_cards) sum += card.Points;
                    int aces = countAces(Person.Croupier);
                    while (aces > 0)
                    {
                        sum += 11;
                        if (sum > 21) sum -= 10;
                        aces--;
                    }
                    return sum;
                }
            }
        }

        public int countAces(Person person)
        {
            int sum = 0;
            if (person == Person.Player)
            {
                foreach (Card card in player_cards) if (card.IsAce) sum++;
                return sum;
            }
            else
            {
                foreach(Card card in croupier_cards) if (card.IsAce) sum++;
                return sum;
            }
        }
    }
}
