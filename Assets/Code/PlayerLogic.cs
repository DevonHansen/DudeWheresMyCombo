using DWMCGameLogicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
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
                if(attack.Value <= 0 && failedAttack != null)
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
                Damage = 0
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
                if (isStunned != null)
                {
                    isStunned.Invoke();
                }
            }
        } 

        private Attack GetAttack(List<int> playerCombination, Modifiers modifier)
        {
            // Get an attack value from the input length. 
            double attackValue = Math.Pow((double)playerCombination.Count, (double)playerCombination.Count) * ((int)modifier/100);

            return new Attack
            {
                Damage = attackValue,
                Modifier = modifier,
                Value = playerCombination.Count,
                biggestCombination = playerCombination
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
                var subCombo = thisRound.determinedAttackCombos[i];

                if(subCombo.Count == 2 )
                {
                    for (int k = 0; k < 7; k++)
                    {
                        var testSequence = inputCombination.GetRange(k, 2);

                        if (subCombo.SequenceEqual(testSequence))
                        {
                            result = subCombo;
                        }
                    }
                }
                else if (subCombo.Count == 3)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        var sequence = inputCombination.GetRange(k, subCombo.Count);

                        if (subCombo.SequenceEqual(sequence))
                        {
                            result = subCombo;
                        }
                    }
                }
                else if (subCombo.Count > 3 && subCombo.Count < 7)
                {
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            var sequence = inputCombination.GetRange(k, subCombo.Count);

                            if (subCombo.SequenceEqual(sequence))
                            {
                                result = subCombo;
                            }
                        }
                    }
                }
                else if (subCombo.Count == 7)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        var sequence = inputCombination.GetRange(k, subCombo.Count);

                        if (subCombo.SequenceEqual(sequence))
                        {
                            result = subCombo;
                        }
                    }
                }
                else if (subCombo.Count == 8)
                {
                    if (subCombo.SequenceEqual(inputCombination))
                    {
                        result = subCombo;
                    }
                }
            }
            return result;
        }

        private List<int> GetDefenseValue(List<int> inputCombination)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < thisRound.determinedDefenseCombos.Count; i++)
            {
                var subCombo = thisRound.determinedDefenseCombos[i];

                if (subCombo.Count == 2)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        var sequence = inputCombination.GetRange(k, subCombo.Count);

                        if (subCombo.SequenceEqual(sequence))
                        {
                            result = subCombo;
                        }
                    }
                }
                else if (subCombo.Count == 3)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        var sequence = inputCombination.GetRange(k, subCombo.Count);

                        if (subCombo.SequenceEqual(sequence))
                        {
                            result = subCombo;
                        }
                    }
                }
                else if (subCombo.Count > 3 && subCombo.Count < 7)
                {
                    
                    for (int k = 0; k < 3; k++)
                    {
                        var sequence = inputCombination.GetRange(k, subCombo.Count);

                        if (subCombo.SequenceEqual(sequence))
                        {
                            result = subCombo;
                        }
                    }
                    
                }
                else if (subCombo.Count == 7)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        var sequence = inputCombination.GetRange(k, subCombo.Count);

                        if (subCombo.SequenceEqual(sequence))
                        {
                            result = subCombo;
                        }
                    }
                }
                else if (subCombo.Count == 8)
                {
                    if (subCombo.SequenceEqual(inputCombination))
                    {
                        result = subCombo;
                    }
                }
            }
            return result;
        }

        private List<int> SetStateAndGetCombo(List<int> inputCombination)
        {
            //Compare input combination to the round attack combos.
            //var attackValue = this.GetAttackValue(inputCombination);

            ////Compare input combination to the round defense combos.
            //var defenseValue = this.GetDefenseValue(inputCombination);

            //// Determine which of the resulting lists is larger, and set the state depending on that. 
            //if(attackValue.Count <= 0 || attackValue.Count < defenseValue.Count)
            //{
            //    if (isDefendState != null)
            //    {
            //        isDefendState.Invoke();
            //    }
            //    this.state = State.Defense;
            //    return defenseValue;
            //}
            //else
            //{
                if (isAttackState != null)
                {
                    isAttackState.Invoke();
                }
                this.state = State.Attack;
            return this.GetAttackValue(inputCombination);

            // return attackValue;
            // }
        }
        private void CheckIfDead()
        {
            if(this.health <= 0 && isDead != null)
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