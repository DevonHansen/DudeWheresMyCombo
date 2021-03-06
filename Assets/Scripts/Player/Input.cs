﻿namespace Assets.Scripts.Player
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Assets.Scripts.Input;

    using DWMCGameLogic;

    using DWMCGameLogicDtos;

    using UnityEngine;
    using UnityEngine.Events;

    [Serializable]
    public class AttackEvent : UnityEvent<Attack>{}

    [Serializable]
    public class IntStringEvent : UnityEvent<int, string> {}

    public class Input : MonoBehaviour
    {
        public AttackEvent OnAttack;

        [SerializeField]
        private List<KeyToIntValue> m_KeyMapping;

        private List<int> m_CurrentKeyPresses = new List<int>();

        private Player m_PlayerObject;

        public CurrentRound m_CurrentRound;

        public IntStringEvent OnKeyPressed;

        public float m_WaitTime;

        private float m_CurrentWaitTime = 0.0f;

        private void Start()
        {
            if (this.m_CurrentRound != null)
            {
                this.m_PlayerObject = new Player(100, this.m_CurrentRound.CurrentRoundDetails);
            }
            if (this.m_CurrentRound == null)
            {
                Debug.LogError("Current Round must be assigned");
            }
        }

        private void Update()
        {
            if (this.m_CurrentWaitTime < 0.0f)
            {
                foreach (var keyBind in this.m_KeyMapping.Where(x => UnityEngine.Input.GetButtonDown(x.AxisName)))
                {
                    this.m_CurrentKeyPresses.Add(keyBind.Value);
                    this.OnKeyPressed.Invoke(keyBind.Value, keyBind.AxisName);
                }

                if (this.OnAttack != null && this.m_CurrentKeyPresses.Count == 8)
                {
                    this.OnAttack.Invoke(this.m_PlayerObject.processInput(this.m_CurrentKeyPresses, Modifiers.None));
                    this.m_CurrentKeyPresses.Clear();
                    this.m_CurrentWaitTime = this.m_WaitTime;
                }
            }
            else
            {
                this.m_CurrentWaitTime -= Time.deltaTime;
            }
        }

        
    }
}