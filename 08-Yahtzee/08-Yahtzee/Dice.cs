/****************************************************************/
/* Name:     Alfin Rahardja, Yohan Hartono, Jason Keating       */
/* Class:    CS 364 - .NET Programming                          */
/* Due-date: April 26, 2016                                     */
/****************************************************************/

/****************************************************************/
/* Dice class generates a random number to get a number for the */
/* dice.                                                        */
/****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Yahtzee
{
    class Dice
    {
        private bool _holdState = false;
        private static Random diceNumber = new Random();

        // Default constructor
        public Dice() { }

        // Get a random number between 1 and 6
        public int RollDice()
        {
            return diceNumber.Next(1, 7);
        }

        // Hold the dice so that it does not roll when the roll button is clicked
        public bool HoldState
        {
            get { return _holdState; }
            set { _holdState = value; }
        }

        /*       public void Roll()
               {
                   // If the dice is not held, roll it
                   if (!HoldState)
                   {
                       RollNumber = random.Next(1, 7);
                       this.Invalidate();
                   }
               } */

    }
}
