namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Assets.Scripts.Input;

    using DWMCGameLogic;

    using DWMCGameLogicDtos;

    using UnityEngine;
    using UnityEngine.Events;

    public class PlayerComponent : MonoBehaviour
    {
        public UnityEvent isDefenceState;

        public UnityEvent isAttackState;

        public UnityEvent isDead;

        public UnityEvent failedAttack;

        public UnityEvent isStunned;

        [SerializeField]
        [Range(0, 100)]
        private uint m_StartPercentage;

        [SerializeField]
        private List<KeyToIntValue> m_KeyMapping;

        [SerializeField]
        private CurrentRound m_CurrentGame;

        private List<int> m_CurrentKeyPresses = new List<int>();
        
        private DWMCGameLogic.Player m_PlayerObject;

        private DWMCGameLogic.Player m_OtherPlayerObject;

        public double m_HighestAttack;

        private void Start()
        {
            this.m_PlayerObject.failedAttack = this.failedAttack;
            this.m_PlayerObject.isAttackState = this.isAttackState;
            this.m_PlayerObject.isDead = this.isDead;
            this.m_PlayerObject.isDefendState = this.isDefenceState;
            this.m_PlayerObject.isStunned = this.isStunned;

            if (m_KeyMapping == null || this.m_KeyMapping.Count == 0)
            {
                Debug.LogError("Key mapping shouldn't be empty");
            }
        }

        private void Update()
        {
            foreach (var keyBind in this.m_KeyMapping.Where(x => UnityEngine.Input.GetButton(x.AxisName)))
            {
                // Input audio event here
                this.m_CurrentKeyPresses.Add(keyBind.Value);
            }

            var attack = this.m_PlayerObject.processInput(this.m_CurrentKeyPresses, Modifiers.None);
            this.m_HighestAttack = attack.Value;
            

            if (this.m_KeyMapping.Count == 8)
            {
                this.m_OtherPlayerObject.processIncomingAttack(attack);
            }
        }

        public void Reset()
        {
            this.m_PlayerObject = new DWMCGameLogic.Player((byte)this.m_StartPercentage, this.m_CurrentGame.m_CurrentRound);
        }
    }
}