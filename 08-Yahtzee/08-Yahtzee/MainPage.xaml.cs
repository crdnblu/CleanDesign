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
        public calculateScore Score = new calculateScore();
        public Dice[] Dice = new Dice[5] { null, null, null, null, null };
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

        // Reset all dice values
        private void resetAllDice()
        {
            Dice[0].DiceNumber = 0;
            Dice[1].DiceNumber = 0;
            Dice[2].DiceNumber = 0;
            Dice[3].DiceNumber = 0;
            Dice[4].DiceNumber = 0;
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
                    dicePicPath = Dice[0].diceImagePath(Dice[0].DiceNumber);
                    dice1.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!Dice[1].HoldState)
                {
                    Dice[1].rollDice();
                    dicePicPath = Dice[1].diceImagePath(Dice[1].DiceNumber);
                    dice2.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!Dice[2].HoldState)
                {
                    Dice[2].rollDice();
                    dicePicPath = Dice[2].diceImagePath(Dice[2].DiceNumber);
                    dice3.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!Dice[3].HoldState)
                {
                    Dice[3].rollDice();
                    dicePicPath = Dice[3].diceImagePath(Dice[3].DiceNumber);
                    dice4.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!Dice[4].HoldState)
                {
                    Dice[4].rollDice();
                    dicePicPath = Dice[4].diceImagePath(Dice[4].DiceNumber);
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
                
                // Reset all dice and their holds
                disableHolds();
                resetAllDice();
            }
        }
    }
}
