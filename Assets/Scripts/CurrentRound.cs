namespace Assets.Scripts
{
    using DWMCGameLogic;

    using UnityEngine;
    public class CurrentRound : MonoBehaviour
    {
        public GameLogic m_CurrentRound;

        public GameLogic CurrentRoundDetails
        {
            get
            {
                if (this.m_CurrentRound == null)
                {
                    this.m_CurrentRound = new GameLogic();
                }
                return this.m_CurrentRound;
            }
        }

        
        private void Awake()
        {
            this.NewRound();
        }
        
        public void NewRound()
        {
            this.m_CurrentRound = new GameLogic();
        }
    }
}