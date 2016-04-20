/****************************************************************/
/* Name:     Alfin Rahardja, Yohan Hartono, Jason Keating       */
/* Class:    CS 364 - .NET Programming                          */
/* Due-date: April 26, 2016                                     */
/****************************************************************/

/****************************************************************/
/*                                                              */
/****************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace _08_Yahtzee
{

    public sealed partial class MainPage : Page
    {
        // Member variables
        private Dice diceOne = new Dice();
        private Dice diceTwo = new Dice();
        private Dice diceThree = new Dice();
        private Dice diceFour = new Dice();
        private Dice diceFive = new Dice();
        private string dicePicPath;
        private int rollDiceCounter = 0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        // Disable all hold buttons
        private void disableHolds()
        {
            hold1.IsEnabled = false;
            hold2.IsEnabled = false;
            hold3.IsEnabled = false;
            hold4.IsEnabled = false;
            hold5.IsEnabled = false;
        }

        // Enable all hold buttons
        private void enableHolds()
        {
            hold1.IsEnabled = true;
            hold2.IsEnabled = true;
            hold3.IsEnabled = true;
            hold4.IsEnabled = true;
            hold5.IsEnabled = true;
        }

        // Roll the unhold dices and shows the number of the dices on the screen
        private void btnPlay_Click_1(object sender, RoutedEventArgs e)
        {
            if (rollDiceCounter == 0)
            {
                enableHolds();
            }
            rollDiceCounter++;
            if (rollDiceCounter < 3)
            {
                if (!diceOne.HoldState)
                {
                    diceOne.rollDice();
                    dicePicPath = diceOne.diceImagePath(diceOne.DiceNumber);
                    dice1.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!diceTwo.HoldState)
                {
                    diceTwo.rollDice();
                    dicePicPath = diceTwo.diceImagePath(diceTwo.DiceNumber);
                    dice2.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!diceThree.HoldState)
                {
                    diceThree.rollDice();
                    dicePicPath = diceThree.diceImagePath(diceThree.DiceNumber);
                    dice3.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!diceFour.HoldState)
                {
                    diceFour.rollDice();
                    dicePicPath = diceFour.diceImagePath(diceFour.DiceNumber);
                    dice4.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!diceFive.HoldState)
                {
                    diceFive.rollDice();
                    dicePicPath = diceFive.diceImagePath(diceFive.DiceNumber);
                    dice5.Source = new BitmapImage(new Uri(dicePicPath));
                }
            }
            else
            {
                rollDiceCounter = 0;
            }
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold1_Click(object sender, RoutedEventArgs e)
        {
            diceOne.HoldState = true;
            hold1.IsEnabled = false;
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold2_Click(object sender, RoutedEventArgs e)
        {
            diceTwo.HoldState = true;
            hold2.IsEnabled = false;
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold3_Click(object sender, RoutedEventArgs e)
        {
            diceThree.HoldState = true;
            hold3.IsEnabled = false;
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold4_Click(object sender, RoutedEventArgs e)
        {
            diceFour.HoldState = true;
            hold4.IsEnabled = false;
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold5_Click(object sender, RoutedEventArgs e)
        {
            diceFive.HoldState = true;
            hold5.IsEnabled = false;
        }
    }
}
