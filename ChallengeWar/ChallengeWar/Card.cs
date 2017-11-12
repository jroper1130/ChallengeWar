using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeWar
{
    public class Card
    {
        public string Suit { get; set; }
        public string Kind { get; set; }

        //set card values from strings to int for game logic
        public int CardValue()
        {
            int value = 0;
            switch(this.Kind)
            {
                //special cards
                case "Jack":
                    value = 11;
                    break;
                case "Queen":
                    value = 12;
                break;
                case "King":
                    value = 13;
                break;
                case "Ace":
                    value = 14;
                break;
                    //deals with all normal numbers
                default:
                    value = int.Parse(this.Kind);
                    break;
            }
            return value;
        }

    }
}