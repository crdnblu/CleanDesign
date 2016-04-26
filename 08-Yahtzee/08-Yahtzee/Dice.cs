/****************************************************************/
/* Name:     Alfin Rahardja, Yohan Hartono, Jason Keating       */
/* Class:    CS 364 - .NET Programming                          */
/* Due-date: April 26, 2016                                     */
/****************************************************************/

/****************************************************************/
/* Dice class generates a random number to get a number for     */
/* each die, stores the hold state for each die, and stores the */
/* location of the die's image.                                 */
/****************************************************************/

using System;

namespace _08_Yahtzee
{
    public class Dice
    {
        // Constant variables
        public const int BLANK = 0;

        // Member variables
        private bool _holdState;
        private static Random _diceRoll;
        private int _diceNumber;
        private string _imagePath;

        // Default constructor
        public Dice()
        {
            _holdState = false;
            _diceRoll = new Random();
            _diceNumber = BLANK;
        }

        // Generate a random number for the die
        public void rollDice()
        {
            _diceNumber = _diceRoll.Next(1, 7);
        }

        // Property that stores the die's number
        public int DiceNumber
        {
            get { return _diceNumber; }
            set { _diceNumber = value; }
        }

        // Get the location of die's image
        public string diceImagePath(int DiceNumber)
        {
            switch (DiceNumber)
            {
                case 1:
                    _imagePath = "ms-appx:///Assets/one.png";
                    break;
                case 2:
                    _imagePath = "ms-appx:///Assets/two.png";
                    break;
                case 3:
                    _imagePath = "ms-appx:///Assets/three.png";
                    break;
                case 4:
                    _imagePath = "ms-appx:///Assets/four.png";
                    break;
                case 5:
                    _imagePath = "ms-appx:///Assets/five.png";
                    break;
                case 6:
                    _imagePath = "ms-appx:///Assets/six.png";
                    break;
                default:
                    _imagePath = "ms-appx:///Assets/blank.png";
                    break;
            }

            return _imagePath;
        }

        // Hold the die so that it does not roll when the roll button is clicked
        public bool HoldState
        {
            get { return _holdState; }
            set { _holdState = value; }
        }
    }
}
