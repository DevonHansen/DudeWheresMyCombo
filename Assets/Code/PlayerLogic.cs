using DWMCGameLogicDtos;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DWMCGameLogic
{ 
    public class Player
    {
        GameLogic thisRound;
        State state;
        byte health;

        // Unity Events 
        public UnityEvent isDefendState;
        public UnityEvent isAttackState;
        public UnityEvent isDead;

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
            // Determine the state of the player. 
            var playerCombination = this.setState(inputCombination);

            var attack = this.GetAttack(playerCombination, modifier);

            if (state == State.Attack)
            {
                return attack; 
            }
            else
            {
                var defense = this.GetDefense(playerCombination, modifier);

                if (attack.Value <= defense.Value)
                {
                    attack.isStun = true;
                }

                return attack;
            }      
        }

        /// <summary>
        /// Processes an incoming attack. 
        /// </summary>
        /// <param name="attack"></param>
        public void processAttack(Attack attack)
        {
            throw new NotImplementedException();
        }

        private Attack GetAttack(List<int> inputCombination, Modifiers modifier)
        {
            return new Attack
            {
                Value = this.GetAttackValue(inputCombination),
                Modifier = modifier
            };
        }

        private Defense GetDefense(List<int> inputCombination, Modifiers modifier)
        {
            return new Defense
            {
                Value = this.GetDefenseValue(inputCombination),
                Modifier = modifier
            };
        }

        private double GetAttackValue(List<int> inputCombination)
        {
                double result = 0;

                return result;
        }

        private double GetDefenseValue(List<int> inputCombination)
        {
            double result = 0;

            return result;
        }

        private List<int> setState(List<int> inputCombination)
        {
            //Compare input combination to the gamelogic string.

            for (int i = 0; i < thisRound.determinedAttackCombos.Count; i++ )
            {

            }


            return new List<int>();
        }
    }

    public enum State
    {
        Attack,
        Defense
    }
}