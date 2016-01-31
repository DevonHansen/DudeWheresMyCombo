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
                this.m_Animator.SetTrigger(this.AttackSmall);
        }

        public void Hurt()
        {
            this.m_Animator.SetTrigger(this.BeingHurt);
        }
    }
}