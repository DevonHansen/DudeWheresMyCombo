/// <summary>
/// Attack dto for transferring attack value and any modifiers. Left as a DTO 
/// </summary>
namespace DWMCGameLogicDtos
{
    public class Attack
    {
        public double Value { get; set; }

        public Modifiers Modifier { get; set; }

        public bool isStun { get; set; }
    }
}
