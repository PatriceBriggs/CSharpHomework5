using Homework5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TicTacToeGame ttt = new TicTacToeGame();
        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = "Player X Turn";
            ttt.GameStatus = "Player X Turn";
            ttt.PlayerXTurn = true;
            ttt.PlayerOTurn = false;
            ttt.MoveNumber = 1;

            SetExitGame();

        }

        private void SetExitGame()
        {
            MenuItem mi = new MenuItem();
            mi.Click += new RoutedEventHandler(ExitGame);
        }

        private void ExitGame(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //string thisTag = ((Button)sender).Tag.ToString();
            string thisTag = (sender as Button).Tag.ToString();
            SetSquareValue(thisTag, ttt.PlayerXTurn);
            (sender as Button).IsEnabled = false;

            if (ttt.PlayerXTurn)
            { 
                (sender as Button).Content = "X";
                ttt.PlayerXTurn = false;
                ttt.PlayerOTurn = true;
                ttt.GameStatus = ttt.CheckForWinner(ttt.GameStatus,ttt.MoveNumber);
                uxTurn.Text = ttt.GameStatus;
            }
            else { 
                (sender as Button).Content = "O";
                ttt.PlayerXTurn = true;
                ttt.PlayerOTurn = false;
                ttt.GameStatus = ttt.CheckForWinner(ttt.GameStatus, ttt.MoveNumber);
                uxTurn.Text = ttt.GameStatus;
            }

            if(ttt.GameStatus.Contains("Wins"))
            {               
                DisableAllTiles();
                return;
            }

            //No winner yet - increment movenumber
            ttt.MoveNumber = ttt.MoveNumber + 1;         
            return;
           
        }

        private void SetSquareValue(string thisTag, bool PlayerXTurn)
        {
            string row = thisTag.Substring(0, 1);
            string column = thisTag.Substring(2, 1);
            string varName = "Square" + row.ToString() + column.ToString();
            if (varName == "Square00")
            {
                if (PlayerXTurn)
                    ttt.Square00 = "X";
                else
                    ttt.Square00 = "O";
                return;
            }
            if (varName == "Square01")
            {
                if (PlayerXTurn)
                    ttt.Square01 = "X";
                else
                    ttt.Square01 = "O";
                return;
            }
            if (varName == "Square02")
            {
                if (PlayerXTurn)
                    ttt.Square02 = "X";
                else
                    ttt.Square02 = "O";
                return;
            }
            if (varName == "Square10")
            {
                if (PlayerXTurn)
                    ttt.Square10 = "X";
                else
                    ttt.Square10 = "O";
                return;
            }
            if (varName == "Square11")
            {
                if (PlayerXTurn)
                    ttt.Square11 = "X";
                else
                    ttt.Square11 = "O";
                return;
            }
            if (varName == "Square12")
            {
                if (PlayerXTurn)
                    ttt.Square12 = "X";
                else
                    ttt.Square12 = "O";
                return;
            }
            if (varName == "Square20")
            {
                if (PlayerXTurn)
                    ttt.Square20 = "X";
                else
                    ttt.Square20 = "O";
                return;
            }
            if (varName == "Square21")
            {
                if (PlayerXTurn)
                    ttt.Square21 = "X";
                else
                    ttt.Square21 = "O";
                return;
            }
            if (varName == "Square22")
            {
                if (PlayerXTurn)
                    ttt.Square22 = "X";
                else
                    ttt.Square22 = "O";
                return;
            }
        }


        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {

            uxTurn.Text = "Player X Turn";
            ttt.GameStatus = "Player X Turn";
            ttt.PlayerXTurn = true;
            ttt.PlayerOTurn = false;
            ttt.MoveNumber = 1;

            // Set all Squares in model to null
            ttt.Square00 = "";         
            ttt.Square01 = "";
            ttt.Square02 = "";
            ttt.Square10 = "";
            ttt.Square11 = "";
            ttt.Square12 = "";
            ttt.Square20 = "";
            ttt.Square21 = "";
            ttt.Square22 = "";

            //Clear board
            ClearBoard();

            return;
        }

        private void ClearBoard()
        {
            UIElementCollection element = uxGrid.Children;
            List<FrameworkElement> elements = element.Cast<FrameworkElement>().ToList();
            List<Button> buttons = elements.OfType<Button>().ToList();

            foreach (Button b in buttons)
            {
                b.Content = "";
                b.IsEnabled = true;
            }
        }

        public void DisableAllTiles()
        {
            UIElementCollection element = uxGrid.Children;
            List<FrameworkElement> elements = element.Cast<FrameworkElement>().ToList();
            List<Button> buttons = elements.OfType<Button>().ToList();

            foreach (Button b in buttons)
            {
                b.IsEnabled = false;
            }
        }
    }
}
