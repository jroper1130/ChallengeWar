using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ChallengeWar
{
    public class Battle
    {
        //instantiated
        private List<Card> _bounty;
        private StringBuilder _sb;
        public Battle()
        {
            _bounty = new List<Card>();
            _sb = new StringBuilder();
        }
        //single round of game
        public string PerformBattle(Player player1, Player player2)
        {
            //get card for player1 & 2 from getCard
            Card player1Card = getCard(player1);
            Card player2Card = getCard(player2);
            //determine who win round
            performEvaluation(player1, player2, player1Card, player2Card);
            return _sb.ToString();
        }
        //card logic for what happens to cards during game
        private Card getCard(Player player)
        {
            //takes card off top of deck
            Card card = player.Cards.ElementAt(0);
            //remove card from player
            player.Cards.Remove(card);
            //add card to bounty
            _bounty.Add(card);
            return card;
        }
        //determine winner and who gets bounty
        private void performEvaluation(Player player1, Player player2, Card card1, Card card2)
        {
            displayBattleCards(card1, card2);
            //if tie then WAR!!
            if (card1.CardValue() == card2.CardValue())
                war(player1, player2);
            //if no tie   
            if (card1.CardValue() > card2.CardValue())
                awardWinner(player1);
            else
                awardWinner(player2);
                //player2.Cards.AddRange(_bounty);
           
        }
        //
        private void awardWinner(Player player)
        {
            //if no value then dont return anything; used to fix minor error
            if (_bounty.Count == 0) return;
            //show all cards won and reset
            displayBountyCards();
            player.Cards.AddRange(_bounty);
            _bounty.Clear();

            _sb.Append("<br/>");
            _sb.Append(player.Name);
            _sb.Append(" is the winner!!!<br/>");
        }
        //make sure to change to my own rules=========================================
        private void war(Player player1, Player player2)
        {
            _sb.Append("<br/>*******This Means War*******</br>");
            //ante for war
            getCard(player1);
            Card warCard1 = getCard(player1);
            getCard(player1);

            getCard(player2);
            Card warCard2 = getCard(player2);
            getCard(player2);
            //if another tie then war again!
            performEvaluation(player1, player2, warCard1, warCard2);
            
        }
        //display cards used in battle in stringbuilder
        private void displayBattleCards(Card card1, Card card2)
        {
            _sb.Append("<br/>Battle Cards:");
            _sb.Append(card1.Kind);
            _sb.Append(" of ");
            _sb.Append(card1.Suit);
            _sb.Append(" versus ");
            _sb.Append(card2.Kind);
            _sb.Append(" of ");
            _sb.Append(card2.Suit);
        }
        //display cards won in battle in stringbuilder
        private void displayBountyCards()
        {
            _sb.Append("<br/>Bounty: ");
            foreach (var card in _bounty)
            {
                _sb.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;");
                _sb.Append(card.Kind);
                _sb.Append(" of ");
                _sb.Append(card.Suit);
            }
           
        }
    }
}