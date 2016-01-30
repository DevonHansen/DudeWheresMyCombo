using DWMCGameLogicDtos;
using System;
using System.Collections.Generic;

namespace DWMCGameLogic
{
    public class Player
    {
        State state;
        byte health;

        public Player(byte health)
        {
            this.health = health;
        }

        /// <summary>
        /// Processes the input and returns an attack object. 
        /// </summary>
        /// <param name="playerCombination"></param>
        /// <param name="modifier"></param>
        public Attack processInput(Dictionary<int, List<int>> playerCombination, Modifiers modifier)
        {
            if (state == State.Attack)
            {
                //Do something
            }
            else
            {
                //Return a broken attack. 
            }
            return this.GetAttack(playerCombination, modifier);
        }
       
        public void processAttack(Attack attack)
        {
            throw new NotImplementedException();
        }

        private Attack GetAttack(Dictionary<int, List<int>> playerCombination, Modifiers modifier)
        {
            return new Attack
            {
                Value = this.GetAttackValue(playerCombination),
                Modifiers = this.GetModifiers(modifier)
            };
        }

        private Defense GetDefense(Dictionary<int, List<int>> playerCombination, Modifiers modifier)
        {
            return new Defense
            {
                Value = this.GetDefenseValue(playerCombination),
                Modifiers = this.GetModifiers(modifier)
            };
        }

        private double GetAttackValue(Dictionary<int, List<int>> playerCombination)
        {
                double result = 0;

                return result;
        }

        private double GetDefenseValue(Dictionary<int, List<int>> playerCombination)
        {
            double result = 0;

            return result;
        }

        private double GetModifiers(Modifiers modifier)
        {
            double result;

            if (modifier == Modifiers.Minor)
                result = 1.2;
            else if (modifier == Modifiers.Major)
                result = 1.5;
            else 
                result = 1.0;

            return result;
        }
    }

    public enum State
    {
        Attack,
        Defense
    }
}