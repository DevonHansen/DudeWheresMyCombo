namespace Assets.Scripts.Input
{
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.Events;

    public class KeyboardManagement : MonoBehaviour
    {
        public List<KeyToIntValue> m_AvailableAxis;
        
        public UnityEvent OnSuccessKeyboard;
        public UnityEvent OnFailedKeyboard;

        private List<int> FoundKeys = new List<int>();

        private void Update()
        {
            this.FoundKeys.Clear();
            foreach (var axis in this.m_AvailableAxis)
            {
                if (Input.GetButtonDown(axis.AxisName))
                {
                    this.FoundKeys.Add(axis.Value);
                }
            }
        }
    }
}