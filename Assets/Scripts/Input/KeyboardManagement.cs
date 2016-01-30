namespace Assets.Scripts.Input
{
    using System.Collections.Generic;

    using UnityEngine;
    public class KeyboardManagement : MonoBehaviour
    {
        public List<KeyToIntValue> m_AvailableAxis;
         


        private void Update()
        {
            foreach (var axis in this.m_AvailableAxis)
            {
                if (Input.GetButtonDown(axis.AxisName))
                {
                    Debug.Log(string.Format("Hit: {0}", axis.AxisName));
                }
            }
        }
    }
}