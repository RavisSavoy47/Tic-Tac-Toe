using System;
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


        public static int GetInput(string description, params string[] options)
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
    }

}
