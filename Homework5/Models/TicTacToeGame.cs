﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Homework5.Models
{
    public class TicTacToeGame
    {
        public string GameStatus { get; set; } //Could set up an enum here
        // Game Status values
        // Player X Turn
        // Player O Turn
        // Player X Wins
        // Player O Wins
        // CAT Game

        public bool PlayerXTurn { get; set; }
        public bool PlayerOTurn { get; set; } // don't really need this

        //Value is either X or O
        public string Square00 { get; set; }
        public string Square01 { get; set; }
        public string Square02 { get; set; }
        public string Square10 { get; set; }
        public string Square11 { get; set; }
        public string Square12 { get; set; }
        public string Square20 { get; set; }
        public string Square21 { get; set; }
        public string Square22 { get; set; }

        // increment each time tile clicked
        public int MoveNumber { get; set; }

        public int MaxNumberMoves { get { return 9; } }

        // Method that checks if one of 8 winning combinations on each button click
        // if no match and GameOver - then CAT game
        // returns gameStatus
        public string CheckForWinner(string gameStatus, int moveNumber)
        {
            bool isAWinner = false;
            if (!String.IsNullOrEmpty(Square00) || !String.IsNullOrEmpty(Square01) || !String.IsNullOrEmpty(Square02))
                if ((Square00 == Square01) && (Square01 == Square02))
                    isAWinner = true;
            if (!String.IsNullOrEmpty(Square10) || !String.IsNullOrEmpty(Square11) || !String.IsNullOrEmpty(Square12))
                if ((Square10 == Square11) && (Square11 == Square12))
                    isAWinner = true;
            if (!String.IsNullOrEmpty(Square20) || !String.IsNullOrEmpty(Square21) || !String.IsNullOrEmpty(Square22))
                if ((Square20 == Square21) && (Square21 == Square22))
                    isAWinner = true;
            if (!String.IsNullOrEmpty(Square00) || !String.IsNullOrEmpty(Square10) || !String.IsNullOrEmpty(Square20))
                if ((Square00 == Square10) && (Square10 == Square20))
                    isAWinner = true;
            if (!String.IsNullOrEmpty(Square01) || !String.IsNullOrEmpty(Square11) || !String.IsNullOrEmpty(Square21))
                if ((Square01 == Square11) && (Square11 == Square21))
                    isAWinner = true;
            if (!String.IsNullOrEmpty(Square02) || !String.IsNullOrEmpty(Square12) || !String.IsNullOrEmpty(Square22))
                if ((Square02 == Square12) && (Square12 == Square22))
                    isAWinner = true;
            if (!String.IsNullOrEmpty(Square00) || !String.IsNullOrEmpty(Square11) || !String.IsNullOrEmpty(Square22))
                if ((Square00 == Square11) && (Square11 == Square22))
                    isAWinner = true;
            if (!String.IsNullOrEmpty(Square20) || !String.IsNullOrEmpty(Square11) || !String.IsNullOrEmpty(Square02))
                if ((Square20 == Square11) && (Square11 == Square02))
                    isAWinner = true;

            // We have a winner
            if (isAWinner && gameStatus == "Player X Turn")
                return "Player X Wins";
            else if (isAWinner && gameStatus == "Player O Turn")
                return "Player O Wins";

            // No winner yet - check if game is over
            if (!isAWinner && gameStatus == "Player X Turn" && !CheckForGameOver(moveNumber))
                return "Player O Turn";
            else if (!isAWinner && gameStatus == "Player O Turn" && !CheckForGameOver(moveNumber))
                return "Player X Turn";

            // No winner - no more moves
            return "CAT Game";
        }

        //check if game is over - MoveNumber = 9
        public bool CheckForGameOver(int moveNumber)
        {
            return (moveNumber >= MaxNumberMoves);
        }

    }
}
