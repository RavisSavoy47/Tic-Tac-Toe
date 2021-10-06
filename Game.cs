﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Game
    {
        private static bool _gameOver = false;
        private Board _gameBoard;

        /// <summary>
        /// Begins the game.
        /// </summary>
        public void Run()
        {
            Start();

            while(!_gameOver)
            {
                Draw();
                Update();
            }

            End();
        }

        /// <summary>
        /// Called when the game starts.
        /// </summary>
        private void Start()
        {
            _gameBoard = new Board();
            _gameBoard.Start();
        }

        /// <summary>
        /// Called every time the game loops.
        /// </summary>
        private void Update()
        {
            _gameBoard.Update();
        }

        /// <summary>
        /// Updates the display to reflect any changes made while running.
        /// </summary>
        private void Draw()
        {
            Console.Clear();
            _gameBoard.Draw();
        }

        /// <summary>
        /// Called when the game ends.
        /// </summary>
        private void End()
        {
            _gameBoard.End();
        }

        public static void CloseGame()
        {
            _gameOver = true;
        }
        /// <summary>
        /// Gets the input from the player
        /// </summary>
        /// <returns></returns>
        public static int GetInput()
        {
            int choice = -1;
            while (choice == -1)
            {
                if (!int.TryParse(Console.ReadLine(), out choice))
                    choice = -1;

                Console.WriteLine("Invaild Input");
            }
            return choice;
        }
    }
}
