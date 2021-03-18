using System;


namespace Cardgame
{
    partial class Program
    {
        class UserHandler
        {
            private string _userInput;
            private string _userEndInput;
            private bool _endGame = false;
            private readonly Game _newGame;
            public UserHandler()
            {
                _newGame = new Game();
                UsersChoices();
            }

            private bool CheckIfValidInput()
            {
                if(_userInput != "f" && _userInput != "s" && _userInput != "sf" && _userInput != "rsf")
                {
                    return false;
                }
                return true;
            }

            private bool CheckIfValidEndInput()
            {
                if (_userEndInput == "y" || _userEndInput == "n")
                {
                    return true;
                }
                return false;
            }

            private void UsersChoices()
            {
                while (_endGame == false)
                {
                    Console.WriteLine("Hello, what do you want to search for? Flush (f), Straight(s), Straight Flush(sf) or Royal Straight Flush(rsf)?");
                    _userInput = Console.ReadLine();
                    while (CheckIfValidInput() == false)
                    {
                        Console.WriteLine("Please, choose f, s, sf or rsf to start the search.");
                        _userInput = Console.ReadLine();
                    }
                    _newGame.HandleTry(_userInput);
                    Console.WriteLine("Do you want do another search? (y/n)");
                    _userEndInput = Console.ReadLine();
                    while (CheckIfValidEndInput() == false)
                    {
                        Console.WriteLine("Please, choose y for a new search or n for ending the game.");
                        _userEndInput = Console.ReadLine();
                    }
                    EndTheGame();
                }
            }

            private void EndTheGame()
            {
                if (_userEndInput == "n")
                {
                    _endGame = true;
                }
                else
                {
                    _endGame = false;
                }
            }
        }
    }
}
