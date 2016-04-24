﻿/****************************************************************/
/* Name:     Alfin Rahardja, Yohan Hartono, Jason Keating       */
/* Class:    CS 364 - .NET Programming                          */
/* Due-date: April 26, 2016                                     */
/****************************************************************/

/****************************************************************/
/* Dice class generates a random number to get a number for the */
/* dice.                                                        */
/****************************************************************/

using System;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Yahtzee
{
    
    public class Dice
    {
        // Member variables
        public const int BLANK = 0;

        private bool _holdState;
        private static Random diceRoll;
        private int _diceNumber;
        private string imagePath;

        // Default constructor
        public Dice()
        {
            _holdState = false;
            diceRoll = new Random();
            _diceNumber = BLANK;
        }

        // Get a random number after rolling a dice
        public void rollDice()
        {
            _diceNumber = diceRoll.Next(1, 7);
        }

        // Dice Number read-only property
        public int DiceNumber
        {
            get { return _diceNumber; }
            set { _diceNumber = value; }
        }

        // Get the image for the dice
        public string diceImagePath(int DiceNumber)
        {
            switch (DiceNumber)
            {
                case 1:
                    imagePath = "ms-appx:///Assets/one.png";
                    break;
                case 2:
                    imagePath = "ms-appx:///Assets/two.png";
                    break;
                case 3:
                    imagePath = "ms-appx:///Assets/three.png";
                    break;
                case 4:
                    imagePath = "ms-appx:///Assets/four.png";
                    break;
                case 5:
                    imagePath = "ms-appx:///Assets/five.png";
                    break;
                case 6:
                    imagePath = "ms-appx:///Assets/six.png";
                    break;
                default:
                    imagePath = "ms-appx:///Assets/blank.png";
                    break;
            }

            return imagePath;
        }

        // Hold the dice so that it does not roll when the roll button is clicked
        public bool HoldState
        {
            get { return _holdState; }
            set { _holdState = value; }
        }
    }
}
