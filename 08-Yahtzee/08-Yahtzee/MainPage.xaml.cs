/****************************************************************/
/* Name:     Alfin Rahardja, Yohan Hartono, Jason Keating       */
/* Class:    CS 364 - .NET Programming                          */
/* Due-date: April 26, 2016                                     */
/****************************************************************/

/****************************************************************/
/*                                                              */
/****************************************************************/

using System;
using Windows.UI.Popups;
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
using Windows.UI;

namespace _08_Yahtzee
{
    public sealed partial class MainPage : Page
    {
        // Member variables
        public const int BLANK = 0;
        public calculateScore Score = new calculateScore();
        public Dice[] dice = new Dice[5] { new Dice(), new Dice(), new Dice(), new Dice(), new Dice() };
        private string dicePicPath;
        private int rollDiceCounter = 0;
        

        public MainPage()
        {
            this.InitializeComponent();

            // Set all textboxes to Read Only
            // Left Score Board Textboxes
            tbAces.IsReadOnly   = true;
            tbDeuces.IsReadOnly = true;
            tbThrees.IsReadOnly = true;
            tbFours.IsReadOnly  = true;
            tbFives.IsReadOnly  = true;
            tbSixes.IsReadOnly  = true;

            // Right Score Board Textboxes
            tbTrips.IsReadOnly    = true;
            tbQuads.IsReadOnly    = true;
            tbFullBoat.IsReadOnly = true;
            tbAces.IsReadOnly     = true;
            tbStretch.IsReadOnly  = true;
            tbStraight.IsReadOnly = true;
            tbYachty.IsReadOnly   = true;
            tbChance.IsReadOnly   = true;

            // Total Textboxes
            tbLeftTotal.IsReadOnly  = true;
            tbRightTotal.IsReadOnly = true;
            tbTotalScore.IsReadOnly = true;
        }

        // Unholds all the dice
        private void Holds()
        {
            // Red color for the button on unhold state
            SolidColorBrush red = new SolidColorBrush();
            red.Color = Color.FromArgb(255, 128, 0, 32);

            hold1.Content = "Hold";
            hold2.Content = "Hold";
            hold3.Content = "Hold";
            hold4.Content = "Hold";
            hold5.Content = "Hold";

            hold1.Background = red;
            hold2.Background = red;
            hold3.Background = red;
            hold4.Background = red;
            hold5.Background = red;
        }

        // Reset all dice values
        private void resetAllDice()
        {
            for(int index = 0; index < 5; index++)
            {
                dice[index].DiceNumber = 0;
                dicePicPath = dice[index].diceImagePath(0);
                dice[index].HoldState = false;
            }
           
            dice1.Source = new BitmapImage(new Uri(dicePicPath));
            dice2.Source = new BitmapImage(new Uri(dicePicPath));
            dice3.Source = new BitmapImage(new Uri(dicePicPath));
            dice4.Source = new BitmapImage(new Uri(dicePicPath));
            dice5.Source = new BitmapImage(new Uri(dicePicPath));
            Holds();
            btnPlay.IsEnabled = true;
        }

        // Check if the game has been over
        private void isGameOver()
        {
            if(tbAces.Text != String.Empty &&
            tbDeuces.Text != String.Empty &&
            tbThrees.Text != String.Empty &&
            tbFours.Text != String.Empty &&
            tbFives.Text != String.Empty &&
            tbSixes.Text != String.Empty &&
            tbTrips.Text != String.Empty &&
            tbQuads.Text != String.Empty &&
            tbFullBoat.Text != String.Empty &&
            tbStretch.Text != String.Empty &&
            tbStraight.Text != String.Empty &&
            tbYachty.Text != String.Empty &&
            tbChance.Text != String.Empty &&
            tbLeftTotal.Text != String.Empty &&
            tbRightTotal.Text != String.Empty &&
            tbTotalScore.Text != String.Empty)
            {
                ShowMessageDialog("The game is over! Your total score is " + Score.totalScore.ToString() + "." +
                                    "\nStart a new game. :)");
                btnPlay.Content = "Roll for Dayz!";
            }
        }

        // Clear all text boxes
        private void resetTextBoxes()
        {
            tbAces.Text       = String.Empty;
            tbDeuces.Text     = String.Empty;
            tbThrees.Text     = String.Empty;
            tbFours.Text      = String.Empty;
            tbFives.Text      = String.Empty;
            tbSixes.Text      = String.Empty;
            tbTrips.Text      = String.Empty;
            tbQuads.Text      = String.Empty;
            tbFullBoat.Text   = String.Empty;
            tbStretch.Text    = String.Empty;
            tbStraight.Text   = String.Empty;
            tbYachty.Text     = String.Empty;
            tbChance.Text     = String.Empty;
            tbLeftTotal.Text  = String.Empty;
            tbRightTotal.Text = String.Empty;
            tbTotalScore.Text   = String.Empty;
            Score.resetTotals();
        }

        // Roll the unhold dices and shows the number of the dices on the screen
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (rollDiceCounter == 0)
            {
                Holds();
            }
            rollDiceCounter++;
            if (rollDiceCounter <= 3)
            {
                if(rollDiceCounter == 3)
                {
                    btnPlay.IsEnabled = false;
                }
                if (!dice[0].HoldState)
                {
                    dice[0].rollDice();
                    dicePicPath = dice[0].diceImagePath(dice[0].DiceNumber);
                    dice1.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!dice[1].HoldState)
                {
                    dice[1].rollDice();
                    dicePicPath = dice[1].diceImagePath(dice[1].DiceNumber);
                    dice2.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!dice[2].HoldState)
                {
                    dice[2].rollDice();
                    dicePicPath = dice[2].diceImagePath(dice[2].DiceNumber);
                    dice3.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!dice[3].HoldState)
                {
                    dice[3].rollDice();
                    dicePicPath = dice[3].diceImagePath(dice[3].DiceNumber);
                    dice4.Source = new BitmapImage(new Uri(dicePicPath));
                }
                if (!dice[4].HoldState)
                {
                    dice[4].rollDice();
                    dicePicPath = dice[4].diceImagePath(dice[4].DiceNumber);
                    dice5.Source = new BitmapImage(new Uri(dicePicPath));
                }
            }
            else
            {
                newTerm();
            }
        }

        // Set the roll dice counter becomes 0 and enables the roll button
        private void newTerm()
        {
            rollDiceCounter = 0;
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold1_Click(object sender, RoutedEventArgs e)
        {
            // Gray color for the button on hold state
            SolidColorBrush gray = new SolidColorBrush();
            gray.Color = Color.FromArgb(255, 136, 136, 136);

            // Red color for the button on unhold state
            SolidColorBrush red = new SolidColorBrush();
            red.Color = Color.FromArgb(255, 128, 0, 32);

            if (dice[0].DiceNumber != BLANK)
            {
                if (hold1.Content.ToString() == "Hold")
                {
                    dice[0].HoldState = true;
                    hold1.Content = "Unhold";
                    hold1.Background = gray;
                }
                else
                {
                    dice[0].HoldState = false;
                    hold1.Content = "Hold";
                    hold1.Background = red;
                }
            }

        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold2_Click(object sender, RoutedEventArgs e)
        {
            // Gray color for the button on hold state
            SolidColorBrush gray = new SolidColorBrush();
            gray.Color = Color.FromArgb(255, 136, 136, 136);

            // Red color for the button on unhold state
            SolidColorBrush red = new SolidColorBrush();
            red.Color = Color.FromArgb(255, 128, 0, 32);

            if (dice[1].DiceNumber != BLANK)
            {
                if (hold2.Content.ToString() == "Hold")
                {
                    dice[1].HoldState = true;
                    hold2.Content = "Unhold";
                    hold2.Background = gray;
                }
                else
                {
                    dice[1].HoldState = false;
                    hold2.Content = "Hold";
                    hold2.Background = red;
                }
            }
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold3_Click(object sender, RoutedEventArgs e)
        {
            // Gray color for the button on hold state
            SolidColorBrush gray = new SolidColorBrush();
            gray.Color = Color.FromArgb(255, 136, 136, 136);

            // Red color for the button on unhold state
            SolidColorBrush red = new SolidColorBrush();
            red.Color = Color.FromArgb(255, 128, 0, 32);

            if (dice[2].DiceNumber != BLANK)
            {
                if (hold3.Content.ToString() == "Hold")
                {
                    dice[2].HoldState = true;
                    hold3.Content = "Unhold";
                    hold3.Background = gray;
                }
                else
                {
                    dice[2].HoldState = false;
                    hold3.Content = "Hold";
                    hold3.Background = red;
                }
            }
            
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold4_Click(object sender, RoutedEventArgs e)
        {
            // Gray color for the button on hold state
            SolidColorBrush gray = new SolidColorBrush();
            gray.Color = Color.FromArgb(255, 136, 136, 136);

            // Red color for the button on unhold state
            SolidColorBrush red = new SolidColorBrush();
            red.Color = Color.FromArgb(255, 128, 0, 32);

            if (dice[3].DiceNumber != BLANK)
            {
                if (hold4.Content.ToString() == "Hold")
                {
                    dice[3].HoldState = true;
                    hold4.Content = "Unhold";
                    hold4.Background = gray;
                }
                else
                {
                    dice[3].HoldState = false;
                    hold4.Content = "Hold";
                    hold4.Background = red;
                }
            }
        }

        // Disable the hold button and change the dice state to be HoldState
        private void hold5_Click(object sender, RoutedEventArgs e)
        {
            // Gray color for the button on hold state
            SolidColorBrush gray = new SolidColorBrush();
            gray.Color = Color.FromArgb(255, 136, 136, 136);

            // Red color for the button on unhold state
            SolidColorBrush red = new SolidColorBrush();
            red.Color = Color.FromArgb(255, 128, 0, 32);

            if (dice[4].DiceNumber != BLANK)
            {
                if (hold5.Content.ToString() == "Hold")
                {
                    dice[4].HoldState = true;
                    hold5.Content = "Unhold";
                    hold5.Background = gray;
                }
                else
                {
                    dice[4].HoldState = false;
                    hold5.Content = "Hold";
                    hold5.Background = red;
                }
            }
        }

        // Check for aces and score
        private void btnAces_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbAces.Text == String.Empty))
            {
                int score = Score.addSameDice(1, dice);

                tbAces.Text = score.ToString();
                Score.getTotals(score, true);

                // Update the upper total and grand total
                tbLeftTotal.Text  = Score.upperTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for twos and score
        private void btnDeuces_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbDeuces.Text == String.Empty))
            {
                int score = Score.addSameDice(2, dice);

                tbDeuces.Text = score.ToString();
                Score.getTotals(score, true);

                // Update the upper total and grand total
                tbLeftTotal.Text = Score.upperTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for three and score
        private void btnThrees_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbThrees.Text == String.Empty))
            {
                int score = Score.addSameDice(3, dice);

                tbThrees.Text = score.ToString();
                Score.getTotals(score, true);

                // Update the upper total and grand total
                tbLeftTotal.Text = Score.upperTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for four and score
        private void btnFours_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbFours.Text == String.Empty))
            {
                int score = Score.addSameDice(4, dice);

                tbFours.Text = score.ToString();
                Score.getTotals(score, true);

                // Update the upper total and grand total
                tbLeftTotal.Text = Score.upperTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for fives and score
        private void btnFives_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbFives.Text == String.Empty))
            {
                int score = Score.addSameDice(5, dice);

                tbFives.Text = score.ToString();
                Score.getTotals(score, true);

                // Update the upper total and grand total
                tbLeftTotal.Text = Score.upperTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for sixes and score
        private void btnSixes_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbSixes.Text == String.Empty))
            {
                int score = Score.addSameDice(6, dice);

                tbSixes.Text = score.ToString();
                Score.getTotals(score, true);

                // Update the upper total and grand total
                tbLeftTotal.Text = Score.upperTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for three of a kind and score
        private void btnTrips_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbTrips.Text == String.Empty))
            {
                int score = Score.calcThreeOfAKind(dice);

                tbTrips.Text = score.ToString();
                Score.getTotals(score, false);

                // Update the lower total and grand total
                tbRightTotal.Text = Score.lowerTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for four of a kind and score
        private void btnQuads_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbQuads.Text == String.Empty))
            {
                int score = Score.calcFourOfAKind(dice);

                tbQuads.Text = score.ToString();
                Score.getTotals(score, false);

                // Update the lower total and grand total
                tbRightTotal.Text = Score.lowerTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for full house and score
        private void btnFullBoat_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbFullBoat.Text == String.Empty))
            {
                int score = Score.calcFullHouse(dice);

                tbFullBoat.Text = score.ToString();
                Score.getTotals(score, false);

                // Update the lower total and grand total
                tbRightTotal.Text = Score.lowerTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for small straight and score
        private void btnStretch_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbStretch.Text == String.Empty))
            {
                int score = Score.calcSmallStraight(dice);

                tbStretch.Text = score.ToString();
                Score.getTotals(score, false);

                // Update the lower total and grand total
                tbRightTotal.Text = Score.lowerTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for large straight and score   
        private void btnStraight_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbStraight.Text == String.Empty))
            {
                int score = Score.calcLargeStraight(dice);

                tbStraight.Text = score.ToString();
                Score.getTotals(score, false);

                // Update the lower total and grand total
                tbRightTotal.Text = Score.lowerTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for yahtzee and score
        private void btnYahtzee_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbYachty.Text == String.Empty))
            {
                int score = Score.calcYahtzee(dice);

                tbYachty.Text = score.ToString();
                Score.getTotals(score, false);

                // Update the lower total and grand total
                tbRightTotal.Text = Score.lowerTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Check for chance and score
        private void btnChance_Click(object sender, RoutedEventArgs e)
        {
            if ((rollDiceCounter > 0) && (tbChance.Text == String.Empty))
            {
                int score = Score.addUpChance(dice);

                tbChance.Text = score.ToString();
                Score.getTotals(score, false);

                // Update the lower total and grand total
                tbRightTotal.Text = Score.lowerTotalScore.ToString();
                tbTotalScore.Text = Score.totalScore.ToString();

                // Reset all dice and their holds
                newTerm();
                resetAllDice();
                isGameOver();
            }
        }

        // Reset everything for a new game
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            btnPlay.Content = "Roll";
            newTerm();
            resetAllDice();
            resetTextBoxes();
        }

        // Pop up the dialog box
        private async void ShowMessageDialog(string errorMessage)
        {
            MessageDialog messagebox = new MessageDialog(errorMessage);
            await messagebox.ShowAsync();
        }
    }
}
