using battleships.core.Services;
using System;

namespace battleships.consoleui
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to battleships game!");

            var game = new GameService();

            Console.WriteLine("Game initiaded let's start playing");

            game.PrintBoard(); // for debug and testing purposes

            while(!game.GameFinished())
            {
                Console.WriteLine("Please provide coordinates");
                var cords = Console.ReadLine().ToUpper();

                Console.WriteLine(game.Hit(cords)); 
            }

            Console.WriteLine("Game Finished! Thank you for playing");
        }
    }
}
