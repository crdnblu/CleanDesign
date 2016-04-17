using System;

public class calcScore
{
    private int total;
    private int upperTotal;
    private int lowerTotal;
    public bool upperBonus = false;

    public int totalScore
    {
        get { return total; }
    }

    public int upperTotalScore
    {
        get { return upperTotal; }
    }

    public int lowerTotalScore
    {
        get { return lowerTotal; }
    }

    // Add scores to upper and lower totals adding in a bonus if th upper score is 63 or more
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

    // Add up and return the number of dice that are the same number
    public int addSameDice(int dieNumber, dice[] myDice)
    {
        int sum = 0;

        for (int i = 0; i < 5; i++)
        {
            if (myDice[i].rollNumber == dieNumber)
            {
                sum += dieNumber;
            }
        }

        return sum;
    }

    // Calculate if three of the dice are the same
    public int calcThreeOfAKind(Dice[] myDice)
    {
        int sum = 0;

        bool threeOfAKind = false;

        for (int i = 1; i <= 6; i++)
        {
            int count = 0;
            for (int j = 0; j < 5; j++)
            {
                if (myDice[j].rollNumber == i)
                    count++;

                if (count == 3)
                    threeOfAKind = true;
            }
        }

        if (threeOfAKind)
        {
            for (int k = 0; k <= 4; k++)
            {
                sum += myDice[k].rollNumber;
            }
        }

        return sum;
    }

    // Calculate if four of the dice are the same
    public int calcFourOfAKind(Dice[] myDice)
    {
        int sum = 0;

        bool fourOfAKind = false;

        for (int i = 1; i <= 6; i++)
        {
            int count = 0;
            for (int j = 0; j < 5; j++)
            {
                if (myDice[j].rollNumber == i)
                    count++;

                if (count == 4)
                    fourOfAKind = true;
            }
        }

        if (fourOfAKind)
        {
            for (int k = 0; k <= 4; k++)
            {
                sum += myDice[k].rollNumber;
            }
        }

        return sum;
    }

    // Calculate a Full House, returning the fixed score 25.
    public int calcFullHouse(Dice[] myDice)
    {
        int sum = 0;

        int[] die = new int[5];

        die[0] = myDice[0].rollNumber;
        die[1] = myDice[1].rollNumber;
        die[2] = myDice[2].rollNumber;
        die[3] = myDice[3].rollNumber;
        die[4] = myDice[4].rollNumber;

        Array.Sort(die);

        if ((((die[0] == die[1]) && (die[1] == die[2])) && // Three of a Kind
             (die[3] == die[4]) && // Two of a Kind
             (die[2] != die[3])) ||
            ((die[0] == die[1]) && // Two of a Kind
             ((die[2] == die[3]) && (die[3] == die[4])) && // Three of a Kind
             (die[1] != die[2])))
        {
            sum = 25;
        }

        return sum;
    }

    // Calculate the Large Straight, returning a fixed score of 40
    public int calcLargeStraight(Dice[] myDice)
    {
        int sum = 0;

        int[] die = new int[5];

        die[0] = myDice[0].rollNumber;
        die[1] = myDice[1].rollNumber;
        die[2] = myDice[2].rollNumber;
        die[3] = myDice[3].rollNumber;
        die[4] = myDice[4].rollNumber;

        Array.Sort(die);

        if (((die[0] == 1) &&
             (die[1] == 2) &&
             (die[2] == 3) &&
             (die[3] == 4) &&
             (die[4] == 5)) ||
            ((die[0] == 2) &&
             (die[1] == 3) &&
             (die[2] == 4) &&
             (die[3] == 5) &&
             (die[4] == 6)))
        {
            sum = 40;
        }

        return sum;
    }

    // Calculate the Small Straight, returning a fixed score of 30
    public int calcSmallStraight(Dice[] myDice)
    {
        int sum = 0;

        int[] die = new int[5];

        die[0] = myDice[0].rollNumber;
        die[1] = myDice[1].rollNumber;
        die[2] = myDice[2].rollNumber;
        die[3] = myDice[3].rollNumber;
        die[4] = myDice[4].rollNumber;

        Array.Sort(die);

        // Move any dice doubles to the end
        for (int j = 0; j < 4; j++)
        {
            int temp = 0;
            if (die[j] == die[j + 1])
            {
                temp = die[j];

                for (int k = j; k < 4; k++)
                {
                    die[k] = die[k + 1];
                }

                die[4] = temp;
            }
        }

        if (((die[0] == 1) && (die[1] == 2) && (die[2] == 3) && (die[3] == 4)) ||
            ((die[0] == 2) && (die[1] == 3) && (die[2] == 4) && (die[3] == 5)) ||
            ((die[0] == 3) && (die[1] == 4) && (die[2] == 5) && (die[3] == 6)) ||
            ((die[1] == 1) && (die[2] == 2) && (die[3] == 3) && (die[4] == 4)) ||
            ((die[1] == 2) && (die[2] == 3) && (die[3] == 4) && (die[4] == 5)) ||
            ((die[1] == 3) && (die[2] == 4) && (die[3] == 5) && (die[4] == 6)))
        {
            sum = 30;
        }

        return sum;
    }

    // Calculate a Yahtzee, returning a fixed score of 50 (only one Yahtzee is allowed)
    public int calcYahtzee(Dice[] myDice)
    {
        int sum = 0;

        for (int i = 1; i <= 6; i++)
        {
            int count = 0;
            for (int j = 0; j < 5; j++)
            {
                if (myDice[j].rollNumber == i)
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
            sum += myDice[i].rollNumber;
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
