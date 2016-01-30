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

        [SerializeField]
        [Range(0, 100)]
        private uint m_StartPercentage;

        [SerializeField]
        private List<KeyToIntValue> m_KeyMapping;

        [SerializeField]
        private CurrentRound m_CurrentGame;

        private List<int> m_CurrentKeyPresses = new List<int>();
        
        private Player m_PlayerObject;

        private uint m_CurrentHighest = 0;

        private void Start()
        {
            if (m_KeyMapping == null || this.m_KeyMapping.Count == 0)
            {
                Debug.LogError("Key mapping shouldn't be empty");
            }
        }

        private void Update()
        {
            foreach (var keyBind in this.m_KeyMapping.Where(x => UnityEngine.Input.GetButton(x.AxisName)))
            {
                
            }

            var attack = this.m_PlayerObject.processInput(this.m_CurrentKeyPresses, Modifiers.None);

            
        }

        public void Reset()
        {
            this.m_PlayerObject = new Player((byte)this.m_StartPercentage, this.m_CurrentGame.m_CurrentRound);
        }
    }
}