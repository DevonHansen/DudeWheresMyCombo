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
            GenerateAttackAndDefenseCombosForRound();
        }

        public void GenerateAttackAndDefenseCombosForRound()
        {
            List<int> seededList = new List<int>();
            List<int> reversedList = new List<int>();
            
            // Get a random
            var randomInt = new Random();

            // Build the random list of integers up.
            seededList.Add(randomInt.Next(0, 3));
            seededList.Add(randomInt.Next(0, 3));
            seededList.Add(randomInt.Next(0, 3));
            seededList.Add(randomInt.Next(0, 3));
            seededList.Add(randomInt.Next(0, 3));
            seededList.Add(randomInt.Next(0, 3));
            seededList.Add(randomInt.Next(0, 3));
            seededList.Add(randomInt.Next(0, 3));

            // Add to the rest of the attack dictionary
            determinedAttackCombos = new Dictionary<int, List<int>>();

            determinedAttackCombos.Add(0, seededList.GetRange(0, 1));
            determinedAttackCombos.Add(1, seededList.GetRange(0, 2));
            determinedAttackCombos.Add(3, seededList.GetRange(0, 3));
            determinedAttackCombos.Add(4, seededList.GetRange(0, 4));
            determinedAttackCombos.Add(5, seededList.GetRange(0, 5));
            determinedAttackCombos.Add(6, seededList.GetRange(0, 6));
            determinedAttackCombos.Add(7, seededList.GetRange(0, 7));

            // reverse the attack list
            for(int i = (seededList.Count - 1); i > 0; i--)
            {
                reversedList.Add(seededList[i]);
            }

            // Add to the defense dictionary
            determinedDefenseCombos = new Dictionary<int, List<int>>();

            determinedDefenseCombos.Add(0, seededList.GetRange(0, 1));
            determinedDefenseCombos.Add(1, seededList.GetRange(0, 2));
            determinedDefenseCombos.Add(3, seededList.GetRange(0, 3));
            determinedDefenseCombos.Add(4, seededList.GetRange(0, 4));
            determinedDefenseCombos.Add(5, seededList.GetRange(0, 5));
            determinedDefenseCombos.Add(6, seededList.GetRange(0, 6));
            determinedDefenseCombos.Add(7, seededList.GetRange(0, 7));
        }

    }
}