using System;
using MapModel;

namespace Tact
{
    class Program
    {
        static Map myMap = new Map(10);
        static void Main(string[] args)
        {

            printMap(myMap);

            Cell currentCell = setCurrentCell();
            currentCell.CurrentlyOccupied = true;

            myMap.MarkPossibleNextMoves(currentCell, "Heavy");

            printMap(myMap);


            Console.ReadLine();
            
        }

        private static Cell setCurrentCell()
        {
            Console.WriteLine("Enter the starting row number");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the staring column number");
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
                            Console.Write("O");
                        }
                        else if (c.PossibleNextMoves == true)
                        {
                            Console.Write("X");
                        }
                        else 
                        {
                            Console.Write(".");
                        }
                    }
                    Console.WriteLine();
                }
                //forground color
                Console.Write("@@@@@@@@@@@@@@@@@@@@          ");
        }
    }
}
