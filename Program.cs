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

            printMap(myMap);

            Cell currentCell = setCurrentCell();
            currentCell.CurrentlyOccupied = true;

            myMap.MarkPossibleNextMoves(currentCell, "Heavy");

            printMap(myMap);

            Console.ReadLine();

            //if (finish = false) 
            //{
                 //Cell nextCell = moveCurrentCell();
            //} else
            //{
                //Console.WriteLine("The End!");
            //}
           
            //Cell currentCell = moveCurrentCell();
            
            //printMap(myMap);

            //Console.ReadLine();
        }

        private static Cell setCurrentCell()
        {
            Console.WriteLine("Enter the starting row number");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the staring column number");
            int currentColumn = int.Parse(Console.ReadLine());

            return myMap.Grid[currentRow, currentColumn];
        }

        private static Cell moveCurrentCell()
        {
            Console.WriteLine("Enter the row number to move to");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the column number to move to");
            int currentColumn = int.Parse(Console.ReadLine());

            return myMap.Grid[currentRow, currentColumn];
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
                        } else 
                        {
                            Console.Write("|---|");
                        }
                    }
                    Console.WriteLine();
                }
                //forground color
                Console.Write("@@@@@@@@@@@@@@@@@@@@          ");
        }
    }
}
