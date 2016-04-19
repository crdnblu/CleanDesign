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
using Windows.UI.Xaml.Navigation;


namespace _08_Yahtzee
{

    public sealed partial class MainPage : Page
    {
        // Member variables
        Dice diceOne = new Dice();
        Dice diceTwo = new Dice();
        Dice diceThree = new Dice();
        Dice diceFour = new Dice();
        Dice diceFive = new Dice();

        public MainPage()
        {
            this.InitializeComponent();
            disableHolds();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            enableHolds();
            if (hold1.IsEnabled == true)
            {
                diceOne.RollDice();
            }
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
    }
}
