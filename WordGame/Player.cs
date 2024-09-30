using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    ///<summary>
    ///E.A.T. 20-September-2024
    ///Player class for creating a player.
    ///The player has a name, number of wins and losses.
    ///</summary>
    internal class Player
    {
        public string Name { get; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public Player(string name, int wins, int losses)
        {
            Name = name;
            Wins = wins;
            Losses = losses;
        }
        public void UpdateWins(int updateWins)
        {
            Wins = updateWins;
        }
        public void UpdateLosses(int updateLosses)
        {
            Losses = updateLosses;
        }
    }
}
