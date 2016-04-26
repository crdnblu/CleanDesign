/****************************************************************/
/* Name:     Alfin Rahardja, Yohan Hartono, Jason Keating       */
/* Class:    CS 364 - .NET Programming                          */
/* Due-date: April 26, 2016                                     */
/****************************************************************/

/****************************************************************/
/* calculateScore class keeps track of a player's score         */
/* throughout the game.                                         */
/****************************************************************/

using System;

namespace _08_Yahtzee
{
    public class calculateScore
    {
        // Member variables
        private int total;
        private int upperTotal;
        private int lowerTotal;
        public bool upperBonus = false;

        // Get the grand total score
        public int totalScore
        {
            get { return total; }
        }

        // Get the upper total score
        public int upperTotalScore
        {
            get { return upperTotal; }
        }

        // Get the lower total score
        public int lowerTotalScore
        {
            get { return lowerTotal; }
        }

        // Add scores to upper and lower totals adding in a bonus if the upper score is 63 or more
        public void getTotals(int score, bool upperScore)
        {
            if (upperScore == true)
            {
                upperTotal += score;

                if (upperTotal >= 63)
                    upperBonus = true;
            }

            else
                lowerTotal += score;

            total = 0;
            total += upperTotal;

            if (upperBonus == true)
                total += 35;

            total += lowerTotal;
        }

        // Add up and return the sum of the dice that are the same number
        public int addSameDice(int dieNumber, Dice[] myDice)
        {
            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                if (myDice[i].DiceNumber == dieNumber)
                {
                    sum += dieNumber;
                }
            }

            return sum;
        }

        // Check if three of the dice are the same, returning the score if true, 0 if false
        public int calcThreeOfAKind(Dice[] myDice)
        {
            int sum = 0;

            bool threeOfAKind = false;

            for (int i = 1; i <= 6; i++)
            {
                int count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (myDice[j].DiceNumber == i)
                        count++;

                    if (count == 3)
                        threeOfAKind = true;
                }
            }

            if (threeOfAKind)
            {
                for (int k = 0; k <= 4; k++)
                {
                    sum += myDice[k].DiceNumber;
                }
            }

            return sum;
        }

        // Check if four of the dice are the same, returning the score if true, 0 if false
        public int calcFourOfAKind(Dice[] myDice)
        {
            int sum = 0;

            bool fourOfAKind = false;

            for (int i = 1; i <= 6; i++)
            {
                int count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (myDice[j].DiceNumber == i)
                        count++;

                    if (count == 4)
                        fourOfAKind = true;
                }
            }

            if (fourOfAKind)
            {
                for (int k = 0; k <= 4; k++)
                {
                    sum += myDice[k].DiceNumber;
                }
            }

            return sum;
        }

        // Check for a Full House, returning the fixed score 25 if true, 0 if false
        public int calcFullHouse(Dice[] myDice)
        {
            int sum = 0;

            int[] dice = new int[5];

            dice[0] = myDice[0].DiceNumber;
            dice[1] = myDice[1].DiceNumber;
            dice[2] = myDice[2].DiceNumber;
            dice[3] = myDice[3].DiceNumber;
            dice[4] = myDice[4].DiceNumber;

            Array.Sort(dice);

            if ((((dice[0] == dice[1]) && (dice[1] == dice[2])) && // Three of a Kind
                 (dice[3] == dice[4]) && // Two of a Kind
                 (dice[2] != dice[3])) ||
                ((dice[0] == dice[1]) && // Two of a Kind
                 ((dice[2] == dice[3]) && (dice[3] == dice[4])) && // Three of a Kind
                 (dice[1] != dice[2])))
            {
                sum = 25;
            }

            return sum;
        }

        // Check for a Large Straight, returning a fixed score of 40 if true, 0 if false
        public int calcLargeStraight(Dice[] myDice)
        {
            int sum = 0;

            int[] dice = new int[5];

            dice[0] = myDice[0].DiceNumber;
            dice[1] = myDice[1].DiceNumber;
            dice[2] = myDice[2].DiceNumber;
            dice[3] = myDice[3].DiceNumber;
            dice[4] = myDice[4].DiceNumber;

            Array.Sort(dice);

            if (((dice[0] == 1) &&
                 (dice[1] == 2) &&
                 (dice[2] == 3) &&
                 (dice[3] == 4) &&
                 (dice[4] == 5)) ||
                ((dice[0] == 2) &&
                 (dice[1] == 3) &&
                 (dice[2] == 4) &&
                 (dice[3] == 5) &&
                 (dice[4] == 6)))
            {
                sum = 40;
            }

            return sum;
        }

        // check for a Small Straight, returning a fixed score of 30 if true, 0 if false
        public int calcSmallStraight(Dice[] myDice)
        {
            int sum = 0;

            int[] dice = new int[5];

            dice[0] = myDice[0].DiceNumber;
            dice[1] = myDice[1].DiceNumber;
            dice[2] = myDice[2].DiceNumber;
            dice[3] = myDice[3].DiceNumber;
            dice[4] = myDice[4].DiceNumber;

            Array.Sort(dice);

            // Move any dice doubles to the end
            for (int j = 0; j < 4; j++)
            {
                int temp = 0;
                if (dice[j] == dice[j + 1])
                {
                    temp = dice[j];

                    for (int k = j; k < 4; k++)
                    {
                        dice[k] = dice[k + 1];
                    }

                    dice[4] = temp;
                }
            }

            if (((dice[0] == 1) && (dice[1] == 2) && (dice[2] == 3) && (dice[3] == 4)) ||
                ((dice[0] == 2) && (dice[1] == 3) && (dice[2] == 4) && (dice[3] == 5)) ||
                ((dice[0] == 3) && (dice[1] == 4) && (dice[2] == 5) && (dice[3] == 6)) ||
                ((dice[1] == 1) && (dice[2] == 2) && (dice[3] == 3) && (dice[4] == 4)) ||
                ((dice[1] == 2) && (dice[2] == 3) && (dice[3] == 4) && (dice[4] == 5)) ||
                ((dice[1] == 3) && (dice[2] == 4) && (dice[3] == 5) && (dice[4] == 6)))
            {
                sum = 30;
            }

            return sum;
        }

        // Check for a Yahtzee, returning a fixed score of 50 (only one Yahtzee is allowed) if true, 0 if false
        public int calcYahtzee(Dice[] myDice)
        {
            int sum = 0;

            for (int i = 1; i <= 6; i++)
            {
                int count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (myDice[j].DiceNumber == i)
                        count++;

                    if (count > 4)
                        sum = 50;
                }
            }

            return sum;
        }

        // Calculate the chance score
        public int addUpChance(Dice[] myDice)
        {
            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                sum += myDice[i].DiceNumber;
            }

            return sum;
        }

        // Reset the score totals for a new game
        public void resetTotals()
        {
            total = 0;
            upperTotal = 0;
            lowerTotal = 0;
            upperBonus = false;
        }
    }
}