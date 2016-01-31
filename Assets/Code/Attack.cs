

using System.Collections.Generic;
/// <summary>
/// Attack dto for transferring attack value and any modifiers. Left as a DTO 
/// </summary>
namespace DWMCGameLogicDtos
{
    public class Attack
    {
        public int Value { get; set; }

        public Modifiers Modifier { get; set; }

        public bool isStun { get; set; }

        public double Damage { get; set; }

        public List<int> biggestCombination { get; set; }
    }
}
