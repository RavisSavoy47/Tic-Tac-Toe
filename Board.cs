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
        private int _currentTurn;

        /// <summary>
        /// Initialize player tokens and the game board
        /// </summary>
        public void Start()
        {
            _currentTurn = 0;
            _player1Token = 'x';
            _player2Token = 'o';
            _currentToken = _player1Token;
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

        }

        int GetInput(string description, params string[] options)
        {
            string input = "";
            int inputReceived = -1;

            while (inputReceived == -1)
            {
                //Print options
                Console.WriteLine(description);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + " " + options[i]);
                }
                Console.Write("> ");

                //Get input from player
                input = Console.ReadLine();

                //If the player typed an int...
                if (int.TryParse(input, out inputReceived))
                {
                    //...decrement the input and check if it's within the bounds of the array
                    inputReceived--;
                    if (inputReceived < 0 || inputReceived >= options.Length)
                    {
                        //Set input received to be the default value
                        inputReceived = -1;
                        //Display error message
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey(true);
                    }
                    Console.Clear();
                }
                //If the player didn't type an int
                else
                {
                    //set inpurt recieved to be default value
                    inputReceived = -1;
                    Console.WriteLine("Invalid Input Bro!");
                    Console.ReadKey(true);
                    Console.Clear();
                }


            }
            return inputReceived;
        }

        /// <summary>
        /// Gets the input from the player.
        /// Sets the player token at the desired spot in the 2D array.
        /// Checks if there is a winner.
        /// Chanages the current token in play.
        /// </summary>
        public void Update()
        {
            //Gets the input for the player from game class
            int input = Game.GetInput() -1;

            if (!SetToken(_currentToken, (input) / 3, (input) % 3))
            {
                Console.WriteLine("You cannot place in that spot.");
                Console.ReadKey(true);
                return;
            }

            //checks the current turn 
            if (_currentTurn == 9)
            {
                //If they are on turn 9 and nobody has won then 
                Console.WriteLine("It's a tie!");
                Console.ReadKey(true);
                RestartMenu();
            }

            //checks if anyone has won
            if (CheckWinner(_currentToken))
            {
                RestartMenu();
            }

            //Changes the current player
            if (_currentToken == _player1Token)
            {
                _currentToken = _player2Token;
            }
            else
            {
                _currentToken = _player1Token;
            } 
            //updates the turn after each player has made a turn
            _currentTurn++;
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

            Console.WriteLine("It's " + _currentToken + " turn!");
        }

        /// <summary>
        /// Called when the game ends
        /// </summary>
        public void End()
        {
            Console.WriteLine("Goodbye lad");
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
            if (posX >= _board.GetLength(0))
                return false;
            if (posY >= _board.GetLength(1))
                return false;

            if (_board[posX,posY] == 'x' || _board[posX,posY] == 'o' )
            {
                return false;
            }

            _board[posX, posY] = token;
            return true;
        }

        /// <summary>
        /// Check to see if the token appears three time consecutively, vertically, horizontally, or diagonally.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool CheckWinner(char token)
        {
            if (_board[0, 0] == token && _board[0, 1] == token && _board[0, 2] == token)
            {
                Console.WriteLine(token + " Wins!!!");
                Console.ReadKey(true);
                return true;
            }
            if (_board[1, 0] == token && _board[1, 1] == token && _board[1, 2] == token)
            {
                Console.WriteLine(token + " Wins!!!");
                Console.ReadKey(true);
                return true;
            }
            if (_board[2, 0] == token && _board[2, 1] == token && _board[2, 2] == token)
            {
                Console.WriteLine(token + " Wins!!!");
                Console.ReadKey(true);
                return true;
            }
            if (_board[0, 0] == token && _board[1, 0] == token && _board[2, 0] == token)
            {
                Console.WriteLine(token + " Wins!!!");
                Console.ReadKey(true);
                return true;
            }
            if (_board[0, 1] == token && _board[1, 1] == token && _board[2, 1] == token)
            {
                Console.WriteLine(token + " Wins!!!");
                Console.ReadKey(true);
                return true;
            }
            if (_board[0, 2] == token && _board[1, 2] == token && _board[2, 2] == token)
            {
                Console.WriteLine(token + " Wins!!!");
                Console.ReadKey(true);
                return true;
            }
            if (_board[0, 0] == token && _board[1, 1] == token && _board[2, 2] == token)
            {
                Console.WriteLine(token + " Wins!!!");
                Console.ReadKey(true);
                return true;
            }
            if (_board[0, 2] == token && _board[1, 1] == token && _board[2, 0] == token)
            {
                Console.WriteLine(token + " Wins!!!");
                Console.ReadKey(true);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Resets the board to it's defualt state.
        /// </summary>
        public void ClearBoard()
        {
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }

        public void RestartMenu()
        {
            int choice = GetInput("Would you like to play agin?", "Yes", "No");
            switch(choice)
            {
                case 0:
                    _currentTurn = 0;
                    ClearBoard();
                    break;

                case 1:
                    Game.CloseGame();
                    break;
            }
        }

    }
}
