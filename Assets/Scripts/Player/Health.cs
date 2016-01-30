namespace Assets.Scripts.Player
{
    using UnityEngine;
    using UnityEngine.Events;

    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int m_CurrentHealth;

        public UnityEvent OnTakeDamEvent;
        public UnityEvent OnDeath;

        public void TakeDamge(int amount)
        {
            this.OnTakeDamEvent.Invoke();
            this.m_CurrentHealth -= amount;

            if(this.m_CurrentHealth <= 0)
            {
                this.OnDeath.Invoke();
            }
        }
    }
}