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
        private calculateScore Score = new calculateScore();
        private Dice[] Dice = new Dice[5] { null, null, null, null, null };
        private string dicePicPath;
        private int rollDiceCounter = 0;

        public object MessageBoxIcon { get; private set; }
        public object MessageBox { get; private set; }
        public object MessageBoxButtons { get; private set; }

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
                if (!Dice[0].HoldState)
                {
                    Dice[0].rollDice();
                    dicePicPath = diceOne.diceImagePath(diceOne.DiceNumber);
                    dice1.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!Dice[1].HoldState)
                {
                    Dice[1].rollDice();
                    dicePicPath = diceTwo.diceImagePath(diceTwo.DiceNumber);
                    dice2.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!Dice[2].HoldState)
                {
                    Dice[2].rollDice();
                    dicePicPath = diceThree.diceImagePath(diceThree.DiceNumber);
                    dice3.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!Dice[3].HoldState)
                {
                    Dice[3].rollDice();
                    dicePicPath = diceFour.diceImagePath(diceFour.DiceNumber);
                    dice4.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!Dice[4].HoldState)
                {
                    Dice[4].rollDice();
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
            Dice[0].HoldState = true;
            hold1.IsEnabled = false;
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold2_Click(object sender, RoutedEventArgs e)
        {
            Dice[1].HoldState = true;
            hold2.IsEnabled = false;
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold3_Click(object sender, RoutedEventArgs e)
        {
            Dice[2].HoldState = true;
            hold3.IsEnabled = false;
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold4_Click(object sender, RoutedEventArgs e)
        {
            Dice[3].HoldState = true;
            hold4.IsEnabled = false;
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold5_Click(object sender, RoutedEventArgs e)
        {
            Dice[4].HoldState = true;
            hold5.IsEnabled = false;
        }

        // Disable the hold button and change the dice state to be HoldState
        private void btnAces_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbAces.Text == ""))
            {
                int score = Score.addSameDice(1, Dice);

                tbAces.Text = Score.ToString();
                Score.getTotals(score, true);
                // reset dice and holds here
            }
        }
    }
}
