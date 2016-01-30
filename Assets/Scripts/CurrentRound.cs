namespace Assets.Scripts
{
    using DWMCGameLogic;

    using UnityEngine;
    public class CurrentRound : MonoBehaviour
    {
        public GameLogic m_CurrentRound;
        
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