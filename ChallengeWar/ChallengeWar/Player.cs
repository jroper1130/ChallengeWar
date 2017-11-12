using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeWar
{

    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        // create new list of cards for new player
        public Player()
        {
            Cards = new List<Card>();
        }
    }
}