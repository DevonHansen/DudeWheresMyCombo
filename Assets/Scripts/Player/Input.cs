namespace Assets.Scripts.Player
{
    using System.Collections.Generic;
    using System.Linq;

    using Assets.Scripts.Input;

    using DWMCGameLogic;

    using DWMCGameLogicDtos;

    using UnityEngine;
    using UnityEngine.Events;

    public class IntEvent : UnityEvent<int>{}

    public class Input : MonoBehaviour
    {
        public IntEvent OnAttack;

        [SerializeField]
        private List<KeyToIntValue> m_KeyMapping;

        private List<int> m_CurrentKeyPresses;

        private Player m_PlayerObject;

        public UnityEvent OnKeyPressed;

        private void Update()
        {
            if (UnityEngine.Input.anyKey)
            {
                this.OnKeyPressed.Invoke();
            }

            foreach (var keyBind in this.m_KeyMapping.Where(x => UnityEngine.Input.GetButton(x.AxisName)))
            {
                this.m_CurrentKeyPresses.Add(keyBind.Value);
            }

            this.OnAttack.Invoke(this.m_PlayerObject.processInput(this.m_CurrentKeyPresses, Modifiers.None).Value);
        }
    }
}