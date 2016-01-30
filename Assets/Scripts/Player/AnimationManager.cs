namespace Assets.Scripts.Player
{
    using UnityEngine;
    public class AnimationManager : MonoBehaviour
    {
        public string EnterBigAttack;

        public string AttackSmall;

        public string BeingHurt;

        public string ExitBigAttack;

        public Animator m_Animator;

        public void StartBigAttack()
        {
            this.m_Animator.SetTrigger(this.EnterBigAttack);
        }

        public void EndBigAttack()
        {
            this.m_Animator.SetTrigger(this.ExitBigAttack);
        }

        public void SmallAttack()
        {
            this.m_Animator.SetTrigger(this.AttackSmall);
        }

        public void Hurt()
        {
            this.m_Animator.SetTrigger(this.BeingHurt);
        }
    }
}