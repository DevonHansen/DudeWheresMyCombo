using DWMCGameLogicDtos;
using UnityEngine;

namespace Assets.Scripts.Player
{
    using Input = Assets.Scripts.Player.Input;

    public class AnimationManager : UnityEngine.MonoBehaviour
    {
        public string EnterBigAttack;

        public string AttackSmall;

        public string BeingHurt;

        public string ExitBigAttack;

        public Animator m_Animator;
        public Animator other;
        public float hurtDelay =2.5f;

        void Start()
        {
            var inp = GetComponent<Assets.Scripts.Player.Input>();
            inp.OnAttack.AddListener(SmallAttack);
        }

        public void StartBigAttack()
        {
            this.m_Animator.SetTrigger(this.EnterBigAttack);
        }

        public void EndBigAttack()
        {
            this.m_Animator.SetTrigger(this.ExitBigAttack);
        }

        public void SmallAttack(Attack atk)
        {
            if(atk.Value >0)
            {
                this.m_Animator.SetTrigger(this.AttackSmall);
                Invoke("Hurt", hurtDelay);
            }
        }

        public void Hurt()
        {
            this.other.SetTrigger(this.BeingHurt);
        }
    }
}