namespace Assets.Scripts
{
    using DWMCGameLogic;

    using UnityEngine;
    public class CurrentRound : MonoBehaviour
    {
        public GameLogic m_CurrentRound;

        [SerializeField]
        private PlayerComponent m_Player1;

        [SerializeField]
        private PlayerComponent m_Player2;

        private void Awake()
        {
            this.NewRound();
        }

        private void Update()
        {
            
        }

        public void NewRound()
        {
            this.m_CurrentRound = new GameLogic();

            this.m_Player1.Reset();
            this.m_Player2.Reset();
        }
    }
}