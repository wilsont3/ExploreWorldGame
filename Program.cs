using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreWorldGame
{
    public class Program
    {

        const int rowSize = 4;
        const int colSize = 4;
        static int currRow = 0;
        static int currCol = 0;

        public static void Main()
        {
            Character player = new Character(100, "Tim", false, true, true, 0, 1);

            Tile waterTile = new Tile("Water", 0.5f, 10, 0, true);
            Tile grassTile = new Tile("Grass", 1, 0, 0, true);
            Tile treeTile = new Tile("Tree", 1, 0, 0, false);
            Tile mountainTile = new Tile("Mountain", 1, 0, 0, false);
            Tile lavaTile = new Tile("Lava", 1, -10, 0, true);
            Tile treasureTile = new Tile("Treasure", 1, 0, 0, true);

            Tile[,] mapGrid = new Tile[rowSize, colSize]
                               {{grassTile,     grassTile,  mountainTile,   waterTile},
                                {mountainTile,  grassTile,  lavaTile,       waterTile},
                                {grassTile,     grassTile,  mountainTile,   mountainTile},
                                {waterTile,     treeTile,   mountainTile,   treasureTile}};

            Console.WriteLine("Welcome to the Explore the World game! You are tasked with exploring the map, " +
                "finding the axe and cutting down the tree.\nUse w, s, a and d to move around and x to exit the game.  Enjoy!\n");

            // loop for continual movement
            while (true)
            {
                Console.WriteLine("Where do you want to go traveler? The X represents where you are now.\n");
                // printing out game board
                PrintGameBoard(mapGrid, currRow, currCol);

                // reading direction from user input
                string direction = Console.ReadLine();

                // check if user wants to exit the game
                if (direction.ToLower() == "x")
                {
                    Console.WriteLine("Thank you for joining the journey!\n");
                    break;
                }

                Move(mapGrid, direction, player);

            }
        }

        public static void PrintGameBoard(Tile[,] mapGrid, int currRow, int currCol)
        {
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    if (i == currRow && j == currCol)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        if (mapGrid[i, j].terrain == "Water")
                        {
                            Console.Write("W");
                        }
                        else if (mapGrid[i, j].terrain == "Grass")
                        {
                            Console.Write("G");
                        }
                        else if (mapGrid[i, j].terrain == "Mountain")
                        {
                            Console.Write("M");
                        }
                        else if (mapGrid[i, j].terrain == "Lava")
                        {
                            Console.Write("L");
                        }
                        else if (mapGrid[i, j].terrain == "Tree")
                        {
                            Console.Write("F");
                        }
                        else if (mapGrid[i, j].terrain == "Treasure")
                        {
                            Console.Write("T");
                        }
                        else
                        {
                            Console.Write("#");
                        }
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }

        public static void Move(Tile[,] gameGrid, string direction, Character player)
        {
            int row = currRow;
            int col = currCol;

            // figure out the direction we want to move in
            if (direction.ToLower().Equals("w"))
            {
                row--;
            }
            else if (direction.ToLower().Equals("a"))
            {
                col--;
            }
            else if (direction.ToLower().Equals("s"))
            {
                row++;
            }
            else if (direction.ToLower().Equals("d"))
            {
                col++;
            }
            else
            {
                Console.WriteLine("Use w, s, a or d to move or x to exit noob!\n");
            }

            // complete the move
            if (row < rowSize && row >= 0 && col < colSize && col >= 0)
            {
                if (IsObstacleInWay(gameGrid, row, col))
                {
                    Console.WriteLine("There is something in your way so you cannot move there.\n");
                }
                else
                {
                    currRow = row;
                    currCol = col;

                    EvaluateGameTile(gameGrid[currRow, currCol], player);
                }
            }
            else
            {
                Console.WriteLine("We don't want you to leave our beautiful world, so you cannot go that way.\n");
            }
        }

        private static void EvaluateGameTile(Tile tile, Character player)
        {
            player.applyDamage(tile.healthModifier);
        }

        private static bool IsObstacleInWay(Tile[,] mapGrid, int row, int col)
        {
            return !mapGrid[row, col].isPassable;
        }
    }
}
