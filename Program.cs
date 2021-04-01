﻿using System;
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
            Cell startCell = toStartCell();

            myMap.SetBaseSpawn(targetCell, "Unit1");
            targetCell.BaseSpawn = true;

            myMap.SetPlayerSpawn(startCell, "Heavy");
            myMap.MarkPossibleNextMoves(startCell, "Heavy");
            startCell.PlayerSpawn = true;

            printMap(myMap);

            Cell currentCell = startCell;
            for ( int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Turn " + i);
                currentCell = moveCurrentCell(currentCell);
                
                myMap.MarkPossibleNextMoves(currentCell, "Heavy");
                currentCell.CurrentlyOccupied = true;

                if (currentCell == targetCell){
                    targetCell.BaseSpawn = false;
                }
                

                printMap(myMap);

                if (targetCell.BaseSpawn == false){
                    ConsoleKey exitKeyV = ConsoleKey.Q;
                    ConsoleKey restartKeyV = ConsoleKey.E;
                    Console.Write("All targets down. Good job commander.");
                    Console.Write($"Press [{exitKeyV}] to leave or press [{restartKeyV}] to play again.");
                    if(Console.ReadKey(true).Key == exitKeyV)
                    {
                        Environment.Exit(0);
                    } else if (Console.ReadKey(true).Key == restartKeyV){
                        goto Start;
                    } else
                    {
                        Console.Write($"Press [{exitKeyV}] to leave or press [{restartKeyV}] to play again.");
                    }
                    
                }

            Console.ReadLine();
            }

        ConsoleKey exitKey = ConsoleKey.Q;
        ConsoleKey restartKey = ConsoleKey.E;
        Console.Write("We ran out of time. We lost.");
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


        private static Cell moveCurrentCell(Cell currentCell)
        {
            //logic for check of possible move
            Moves:
            Console.WriteLine("Enter the row number to move to");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the column number to move to");
            int currentColumn = int.Parse(Console.ReadLine());
            if(myMap.MarkPossibleNextMoves(currentCell, "Heavy").Contains(myMap.Grid[currentRow, currentColumn]) == false)
            {
                Console.WriteLine("Location out of range. Please make a move in range.");
                goto Moves;
            }

            return myMap.Grid[currentRow, currentColumn];
        }

        private static Cell toTargetCell()
        {
            Console.WriteLine("Here are your targets. You have five turns to destroy them.");
            return myMap.Grid[5,7];
        }

        private static Cell toStartCell()
        {
            Console.WriteLine("Here are your units. Move them to destroy your targets");
            return myMap.Grid[5,9];
        }

        private static void printMap(Map myMap)
        {
            for (int i = 1; i < myMap.Size; i++)
                {
                    for (int j = 1; j < myMap.Size; j++)
                    {
                        Cell c = myMap.Grid[i, j];

                        if (c.PlayerSpawn == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("|-O-|");
                            Console.ResetColor();
                        } else if (c.CurrentlyOccupied == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("|-O-|");
                            Console.ResetColor();
                        } else if (c.BaseSpawn == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("|-T-|");
                            Console.ResetColor();
                        } else if (c.PossibleNextMoves == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("|-X-|");
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
