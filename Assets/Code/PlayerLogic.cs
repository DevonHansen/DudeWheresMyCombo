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
        public int health;
        private List<int> currentDefenseCombo;

        // Unity Events 
        public UnityEvent isDefendState;        // Invoked when player moves to defense state
        public UnityEvent isAttackState;        // Invoked when player changes to attack state
        public UnityEvent isDead;               // Invoked when player dies
        public UnityEvent failedAttack;         // Invoked when player fails to activate any combination from an input sequence
        public UnityEvent isStunned;            // Invoked when player fails to activate any combination from an input sequence


        public Player(byte health, GameLogic thisRound)
        {
            this.health = health;
            this.thisRound = thisRound;
        }

        /// <summary>
        /// Processes the input and returns an attack object. 
        /// </summary>
        /// <param name="inputCombination"></param>
        /// <param name="modifier"></param>
        /// <returns>Attack object</returns>
        public Attack processInput(List<int> inputCombination, Modifiers modifier)
        {
            // Determine the state of the player and get any valid combos from the input. 
            var playerCombination = this.SetStateAndGetCombo(inputCombination);

            // Create the attack object
            var attack = this.GetAttack(playerCombination, modifier);

            // If is in attack state, return the attack
            if (state == State.Attack)
            {
                if(attack.Value <= 0)
                {
                    failedAttack.Invoke();
                }
                return attack; 
            }
            else //Return a valueless attack object and store the input as a defenseCombo
            {
                this.currentDefenseCombo = playerCombination;

                return new Attack { Value = 0, Modifier = Modifiers.None, isStun = false };
            }      
        }

        /// <summary>
        /// Processes an incoming attack. 
        /// </summary>
        /// <param name="attack"></param>
        public Counter processIncomingAttack(Attack attack)
        {
            // Check whether in defense mode, and whether defense is greater than attack. If it is, return an attack object
            //  with isStun set to true. 
            if (state == State.Defense)
            {
                var defense = this.GetAttack(currentDefenseCombo, Modifiers.None);

                if (defense.Value > attack.Value)
                {
                    return new Counter
                    {
                        Value = 0,
                        Modifier = Modifiers.None,                       
                        isStun = true,
                        Damage = 0
                    };
                }
                else
                {
                    this.health -= (int)attack.Value;
                    this.CheckIfDead();                    
                }
            }
            else
            {
                this.health -= (int)attack.Value;
                this.CheckIfDead();
            }
            return new Counter
            {
                Value = 0,
                Modifier = Modifiers.None,
                isStun = false,
                Damage =0
            };            
        }

        /// <summary>
        /// Processes the incoming counter
        /// </summary>
        /// <param name="counter"></param>
        public void processIncomingCounter(Counter counter)
        {
            if(counter.isStun)
            {
                isStunned.Invoke();
            }
        } 

        private Attack GetAttack(List<int> inputCombination, Modifiers modifier)
        {
            // Get an attack value from the input length. 
            double attackValue = Math.Pow((double)inputCombination.Count, (double)inputCombination.Count) * ((int)modifier/100);

            return new Attack
            {
                Damage = attackValue,
                Modifier = modifier,
                Value = inputCombination.Count
            };
        }

        /// <summary>
        /// Returns the largest list match against the attack combos
        /// </summary>
        /// <param name="inputCombination"></param>
        /// <returns></returns>
        private List<int> GetAttackValue(List<int> inputCombination)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < thisRound.determinedAttackCombos.Count; i++)
            {
                if (thisRound.determinedAttackCombos[i].Equals(inputCombination))
                {
                    result = thisRound.determinedAttackCombos[i];
                }
            }
            return result;
        }

        private List<int> GetDefenseValue(List<int> inputCombination)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < thisRound.determinedDefenseCombos.Count; i++)
            {
                if (thisRound.determinedDefenseCombos[i].Equals(inputCombination))
                {
                    result = thisRound.determinedAttackCombos[i];
                }
            }
            return result;
        }

        private List<int> SetStateAndGetCombo(List<int> inputCombination)
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
        private void CheckIfDead()
        {
            if(this.health <= 0)
            {
                isDead.Invoke();
            }
        }
    }

    public enum State
    {
        Attack,
        Defense
    }
}