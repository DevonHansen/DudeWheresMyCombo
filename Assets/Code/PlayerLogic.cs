using DWMCGameLogicDtos;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DWMCGameLogic
{ 
    public class Player
    {
        // Class attributes
        private GameLogic thisRound;
        public State state;
        private int health;
        private List<int> currentDefenseCombo;

        // Unity Events 
        public UnityEvent isDefendState;
        public UnityEvent isAttackState;
        public UnityEvent isDead;
        public UnityEvent failedAttack;

        public Player(byte health, GameLogic thisRound)
        {
            this.health = health;
            this.thisRound = thisRound;
        }

        /// <summary>
        /// Processes the input and returns an attack object. 
        /// </summary>
        /// <param name="playerCombination"></param>
        /// <param name="modifier"></param>
        public Attack processInput(List<int> inputCombination, Modifiers modifier)
        {
            // Determine the state of the player and get any valid combos from the input. 
            var playerCombination = this.setStateAndGetCombo(inputCombination);

            // Create the attack object
            var attack = this.GetAttack(playerCombination, modifier);

            //
            if (state == State.Attack)
            {
                return attack; 
            }
            else
            {
                this.currentDefenseCombo = playerCombination;

                return attack;
            }      
        }

        /// <summary>
        /// Processes an incoming attack. 
        /// </summary>
        /// <param name="attack"></param>
        public Attack processIncomingAttack(Attack attack)
        {
            // Check whether in defense mode, and whether defense is greater than attack. If it is, return an attack object
            //  with isStun set to true. 
            if (state == State.Defense)
            {
                var defense = this.GetAttack(currentDefenseCombo, Modifiers.None);
                if(defense == attack)
                {
                    return new Attack();
                }
                else if (defense.Value > attack.Value)
                {
                    return new Attack
                    {
                        Value = 0,
                        Modifier = Modifiers.None,                       
                        isStun = true
                    };
                }
            }
            return new Attack();            
        }

        private Attack GetAttack(List<int> inputCombination, Modifiers modifier)
        {
            // Get an attack value from the input length. 
            double attackValue = Math.Pow((double)inputCombination.Count, (double)inputCombination.Count) * ((int)modifier/100);

            return new Attack
            {
                Value = attackValue,
                Modifier = modifier
            };
        }

        private List<int> GetAttackValue(List<int> inputCombination)
        {
            for (int i = 0; i < thisRound.determinedAttackCombos.Count; i++)
            {
                if (thisRound.determinedAttackCombos[i].Equals(inputCombination))
                {
                    return thisRound.determinedAttackCombos[i];
                }
            }
            return new List<int>();
        }

        private List<int> GetDefenseValue(List<int> inputCombination)
        {
            for (int i = 0; i < thisRound.determinedDefenseCombos.Count; i++)
            {
                if (thisRound.determinedAttackCombos[i].Equals(inputCombination))
                {
                    return thisRound.determinedAttackCombos[i];
                }
            }
            return new List<int>();
        }

        private List<int> setStateAndGetCombo(List<int> inputCombination)
        {
            //Compare input combination to the round attack combos.
            var attackValue = this.GetAttackValue(inputCombination);

            //Compare input combination to the round defense combos.
            var defenseValue = this.GetDefenseValue(inputCombination);

            // Determine which of the resulting lists is larger, and set the state depending on that. 
            if(attackValue.Count <= 0 || attackValue.Count < defenseValue.Count)
            {
                isDefendState.Invoke();
                this.state = State.Defense;
                return defenseValue;
            }
            else
            {
                isAttackState.Invoke();
                this.state = State.Attack;
                return attackValue;
            }
        }
    }

    public enum State
    {
        Attack,
        Defense
    }
}