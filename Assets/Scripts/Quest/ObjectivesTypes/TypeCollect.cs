using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest.ObjectivesTypes
{
    /// <summary>
    /// Implement the objective types collect.
    /// </summary>
    public class TypeCollect
    {
        private int _amount;
        private int _goalAmount;

        public TypeCollect(int amount, int goalAmount)
        {
            Amount = amount;
            GoalAmount = goalAmount;
        }

        public int Amount
        {
            get { return _amount; }

            set { _amount = value; }
        }

        public int GoalAmount
        {
            get { return _goalAmount; }

            set { _goalAmount = value; }
        }

        public bool IsComplete()
        {
            if(Amount == GoalAmount)
            {
                return true;
            }

            return false;
        }
    }
}
