using System;
using System.Collections.Generic;
using System.Linq;

namespace DWMCGameLogic
{
    public class GameLogic
    {
        public Dictionary<byte, byte[]> determinedAttackCombos { get; set; }

        public Dictionary<byte, byte[]> determinedDefenseCombos { get; set; }

        public void GenerateAttackAndDefenseCombosForRound()
        {

            var randomInt = new Random();
            Byte[] seedList = new Byte[8];

       ////     seedList = randomInt.NextBytes(seedList);

            // Pop this list and add to the rest of the attack dictionary

            this.determinedAttackCombos.Add(8, seedList);

            // reverse the attack list

            // Pop that list and add to the defense dictionary. 


        }

    }
}