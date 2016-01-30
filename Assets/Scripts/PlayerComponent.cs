namespace Assets.Scripts
{
    using System.Collections.Generic;
    using System.Linq;

    using Assets.Scripts.Input;

    using DWMCGameLogic;

    using UnityEngine;
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField]
        private string Name;

        [SerializeField]
        [Range(0, 100)]
        private uint m_StartPercentage;

        private Player m_PlayerLogic;

        [SerializeField]
        private List<KeyToIntValue> m_KeyMapping;

        private List<uint> m_CurrentKeyPresses; 

        private void Start()
        {
            this.m_CurrentKeyPresses = new List<uint>();

            if (m_KeyMapping == null || this.m_KeyMapping.Count == 0)
            {
                Debug.LogError("Key mapping shouldn't be empty");
            }
            
            this.m_PlayerLogic = new Player((byte)this.m_StartPercentage);
        }

        private void Update()
        {
            foreach (var keyBind in this.m_KeyMapping.Where(x => UnityEngine.Input.GetButton(x.AxisName)))
            {
                this.m_CurrentKeyPresses.Add(keyBind.Value);
            }
        }
    }
}