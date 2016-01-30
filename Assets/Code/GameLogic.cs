using System;
using System.Collections.Generic;
using System.Linq;

namespace DWMCGameLogic
{
    public class GameLogic
    {
        public Dictionary<int, List<int>> determinedAttackCombos { get; set; }

        public Dictionary<int, List<int>> determinedDefenseCombos { get; set; }

        public GameLogic()
        {
        }

        public void GenerateAttackAndDefenseCombosForRound()
        {

            var randomInt = new Random();
            
            // Pop this list and add to the rest of the attack dictionary

            // reverse the attack list

            // Pop that list and add to the defense dictionary. 

        }

    }
}