using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.Models
{
    public class TicTacToeGame
    {
        public string GameStatus { get; set; }
        // Game Status values
        // Player X Turn
        // Player O Turn
        // Player X Wins
        // Player O Won
        // CAT Game

        public bool PlayerXTurn { get; set; }
        public bool PlayerOTurn { get; set; }

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

        // increment each time tile clicked - max value is 9
        public int MoveNumber { get; set; }

        // Method that checks if one of 8 winning combinations on each button click
        // if no match and GameOver - then CAT game
        // returns gameStatus
        public string IsAWinner(string gameStatus, int moveNumber)
        {
            bool isAWinner = false;
            if(!String.IsNullOrEmpty(Square00) || !String.IsNullOrEmpty(Square01) || !String.IsNullOrEmpty(Square02))
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

            // No winner yet
            if (!isAWinner && gameStatus == "Player X Turn" && !GameOver(moveNumber))
                return "Player O Turn";
            else if (!isAWinner && gameStatus == "Player O Turn" && !GameOver(moveNumber))
                return "Player X Turn";

            return "CAT Game";
        }

        //check if game is over - MoveNumber = 9
        public bool GameOver(int moveNumber)
        {
            return (moveNumber >= 9);
        }

    }
}
