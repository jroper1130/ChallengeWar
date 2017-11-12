using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeWar
{
    public class Game
    {
        //instantiate
        private Player _player1;
        private Player _player2;

        public Game(string player1Name, string player2Name)
        {
            //assign names
            _player1 = new Player() {Name = player1Name };
            _player2 = new Player() {Name = player2Name };
        }
        //starts up game
        public string Play()
        {
            //grabs cards
            Deck deck = new Deck();
            //return string of results of deal to players; who got what cards
            string result = "<h3>Dealing Cards...</h3>";
            result += deck.Deal(_player1, _player2);
            result += "<h3>Begin Battle</h3>";
            //instantiate round
            int round = 0;
            //keep playing until a player has no cards
            while (_player1.Cards.Count != 0 && _player2.Cards.Count != 0 )
            {
                //instiate battle class and start game 
                Battle battle = new Battle();
                result += battle.PerformBattle( _player1, _player2);
                //limit to X amount of rounds; X can be whatever
                round++;
                if (round > 20)
                    break;
            }
            //display winner
            result += determineWinner();
            return result;
        }
        //determine winner
        private string determineWinner()
        {
            string result = "";
            if (_player1.Cards.Count > _player2.Cards.Count)
            {
                result += "<br/>Player 1 Wins";
            }
            else
            {
                result += "<br/>Player 2 Wins";
            }
            result += "<br/>Player 1:" + _player1.Cards.Count + " Player 2: " + _player2.Cards.Count;
            return result;
        }
    }
}