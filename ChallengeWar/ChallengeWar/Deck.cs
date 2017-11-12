using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ChallengeWar
{
    //create deck of cards and deal cards out then show results in a string 
    public class Deck
    {
        //private classes instantiations
        private List<Card> _deck;
        private Random _random;
        private StringBuilder _sb;
        //create deck of 52 cards
        public Deck()
        {
            //instantiate list and random
            _deck = new List<Card>();
            _random = new Random();
            _sb = new StringBuilder();
            //arrays of card traits to combine and make cards
            string[] suits = new string[] {"Spades","Diamonds","Clubs","Hearts"};
            string[] kinds = new string[] {"2","3","4","5","6","7","8","9","10","Jack","Queen","King","Ace"};
            //iterate through arrays to create 52 cards
            foreach (var suit in suits)
            {
                foreach (var kind in kinds)
                {
                    _deck.Add( new Card() {Suit = suit, Kind = kind});
                }
            }
        }

        public String Deal(Player player1, Player player2)
        {
            //deal until no more cards
            while (_deck.Count > 0)
            {
                //deal a card to each player randomly
                dealCard(player1);
                dealCard(player2);
            }
            return _sb.ToString();
        }

        private void dealCard(Player player)
        {
            //deal random card
            Card card = _deck.ElementAt(_random.Next(_deck.Count));
            //give card to player
            player.Cards.Add(card);
            //remove card from deck
            _deck.Remove(card);
            //append to stringbuilder
            _sb.Append("<br/>");
            _sb.Append(player.Name);
            _sb.Append(" is dealt the ");
            _sb.Append(card.Kind);
            _sb.Append(" of ");
            _sb.Append(card.Suit);
        }
    }
}