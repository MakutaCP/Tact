using System;
using MapModel;

namespace Tact
{
    class Program
    {
        static Map myMap = new Map(10);
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Game. Press enter to start.");
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
            

        }

        private static Cell moveCurrentCell()
        {
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
            for (int i = 0; i < myMap.Size; i++)
                {
                    for (int j = 0; j < myMap.Size; j++)
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
