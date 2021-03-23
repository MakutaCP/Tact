using System;
using MapModel;

namespace Tact
{
    class Program
    {
        static Map myMap = new Map(10);
        static void Main(string[] args)
        {
            Start:
            Console.WriteLine("Welcome to the Game. Type C to begin.");
            
            ConsoleKey continueKey = ConsoleKey.C;
            Console.Write($"Press [{continueKey}] to continue...");
            while (Console.ReadKey(true).Key != continueKey)
            {
                Console.Write($"Please press [{continueKey}] to continue...");
            } 
            
            Console.ReadLine();

            Cell targetCell = toTargetCell();

            myMap.SetBaseSpawn(targetCell, "Unit1");
            targetCell.BaseSpawn = true;

            printMap(myMap);


            for ( int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Turn " + i);
                Cell currentCell = moveCurrentCell(); 
                
                myMap.MarkPossibleNextMoves(currentCell, "Heavy");
                currentCell.CurrentlyOccupied = true;

                printMap(myMap);

                Console.ReadLine();
            }

            ConsoleKey exitKey = ConsoleKey.Q;
            ConsoleKey restartKey = ConsoleKey.E;
            Console.Write($"Press [{exitKey}] to leave or press [{restartKey}] to play again.");
            if(Console.ReadKey(true).Key == exitKey)
            {
                Environment.Exit(0);
            } else if (Console.ReadKey(true).Key == restartKey){
                goto Start;
            } else
            {
                Console.Write($"Press [{exitKey}] to leave or press [{restartKey}] to play again.");
            }

            

        }

        private static Cell moveCurrentCell()
        {
            //logic for check of possible move
            Console.WriteLine("Enter the row number to move to");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the column number to move to");
            int currentColumn = int.Parse(Console.ReadLine());

            return myMap.Grid[currentRow, currentColumn];
        }

        private static Cell toTargetCell()
        {
            Console.WriteLine("Here are your targets. You have five turns to destroy them.");
            return myMap.Grid[5,7];
        }

        private static void printMap(Map myMap)
        {
            for (int i = 1; i < myMap.Size; i++)
                {
                    for (int j = 1; j < myMap.Size; j++)
                    {
                        Cell c = myMap.Grid[i, j];

                        if(c.CurrentlyOccupied == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("|-O-|");
                            Console.ResetColor();
                            
                        } else if (c.PossibleNextMoves == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("|-X-|");
                            Console.ResetColor();
                        } else if (c.BaseSpawn == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("|-T-|");
                            Console.ResetColor();
                        } else 
                        {
                            Console.Write("|---|");
                        }
                    }
                    Console.WriteLine();
                }
                
                Console.Write("____________         ");
        }
    }
}
