using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Board
    {
        private char _player1Token;
        private char _player2Token;
        private char _currentToken;
        private char[,] _board;

        /// <summary>
        /// Initialize player tokens and the game board
        /// </summary>
        public void Start()
        {
            _player1Token = 'x';
            _player2Token = 'o';
            _currentToken = _player1Token;
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

        }

        /// <summary>
        /// Gets the input from the player.
        /// Sets the player token at the desired spot in the 2D array.
        /// Checks if there is a winner.
        /// Chanages the current token in play.
        /// </summary>
        public void Update()
        {
            int choice = Game.GetInput("Pick a space.", "1", "2", "3", "4", "5", "6", "7", "8", "9");

            if (choice == 0)
                _board[0, 0] = _currentToken;

            if (choice == 1)
                _board[0, 1] = _currentToken;

            if (choice == 2)
                _board[0, 2] = _currentToken;

            if (choice == 3)
                _board[1, 0] = _currentToken;
            
            if (choice == 4)
                _board[1, 1] = _currentToken;
            
            if (choice == 5)
                _board[1, 2] = _currentToken;
            
            if (choice == 6)
                _board[2, 0] = _currentToken;
            
            if (choice == 7)
                _board[2, 1] = _currentToken;
            
            if (choice == 8)
                _board[2, 2] = _currentToken;
            
            //Changes the current player
            if (_currentToken == _player1Token)
                _currentToken = _player2Token;
            else
                _currentToken = _player1Token;
        }

        /// <summary>
        /// Draws the board and let's the player know whose turn it is.
        /// </summary>
        public void Draw()
        {
            Console.WriteLine(_board[0, 0] + " | " + _board[0, 1] + " | " + _board[0, 2] + "\n" +
                                                 "___________\n" +
                              _board[1, 0] + " | " + _board[1, 1] + " | " + _board[1, 2] + "\n" +
                                                 "___________\n" +
                              _board[2, 0] + " | " + _board[2, 1] + " | " + _board[2, 2]);
                              
        }

        /// <summary>
        /// Called when the game ends
        /// </summary>
        public void End()
        {
            
        }

        /// <summary>
        /// Assigns the spot the given index in the board array to be the given token.
        /// </summary>
        /// <param name="token">The token to set the array index to.</param>
        /// <param name="posX">The x position of the token.</param>
        /// <param name="posY">The y position of the token.</param>
        /// <returns>Return false if the indices are out of range.</returns>
        public bool SetToken(char token, int posX, int posY)
        {
            
            return false;
        }

        /// <summary>
        /// Check to see if the token appears three time consecutively, vertically, horizontally, or diagonally.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool CheckWinner(char token)
        {

            return false;
        }

        /// <summary>
        /// Resets the board to it's defualt state.
        /// </summary>
        public void ClearBoard()
        {

        }
    }
}
