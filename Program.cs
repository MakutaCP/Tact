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

            Cell targetCell1 = toTargetCell1();
            Cell targetCell2 = toTargetCell2();
            Cell targetCell3 = toTargetCell3();
            Cell targetCell4 = toTargetCell4();
            Cell targetCell5 = toTargetCell5();

            Cell startCellH = toStartCellH();
            Cell startCellS = toStartCellS();

            myMap.SetBaseSpawn(targetCell1, "Unit1");
            myMap.SetBaseSpawn(targetCell2, "Unit2");
            myMap.SetBaseSpawn(targetCell3, "Unit3");
            myMap.SetBaseSpawn(targetCell4, "Unit4");
            myMap.SetBaseSpawn(targetCell5, "Unit5");
            targetCell1.BaseSpawn = true;
            targetCell2.BaseSpawn = true;
            targetCell3.BaseSpawn = true;
            targetCell4.BaseSpawn = true;
            targetCell5.BaseSpawn = true;

            myMap.SetPlayerSpawn(startCellH, "Heavy");
            myMap.SetPlayerSpawn(startCellS, "Scout");
            myMap.MarkPossibleNextMoves(startCellH, "Heavy");
            myMap.MarkPossibleNextMoves(startCellS, "Scout");
            startCellH.PlayerSpawnH = true;
            startCellS.PlayerSpawnS = true;

            printMap(myMap);

            Cell currentCellH = startCellH;
            Cell currentCellS = startCellS;
            for ( int i = 1; i <= 5; i++)
            {   

                Console.WriteLine("Turn " + i);
                currentCellS = moveCurrentCellS(currentCellS);
                currentCellH = moveCurrentCellH(currentCellH);

                myMap.MarkPossibleNextMoves(currentCellS, "Scout");
                currentCellS.CurrentlyOccupiedS = true;
                myMap.MarkPossibleNextMoves(currentCellH, "Heavy");
                currentCellH.CurrentlyOccupiedH = true;
                
                if (currentCellH == targetCell1 || currentCellS == targetCell1){
                    targetCell1.BaseSpawn = false;
                }
                if (currentCellH == targetCell2 || currentCellS == targetCell2){
                    targetCell2.BaseSpawn = false;
                }
                if (currentCellH == targetCell3 || currentCellS == targetCell3){
                    targetCell3.BaseSpawn = false;
                }
                 if (currentCellH == targetCell4 || currentCellS == targetCell4){
                    targetCell4.BaseSpawn = false;
                }
                 if (currentCellH == targetCell5 || currentCellS == targetCell5){
                    targetCell5.BaseSpawn = false;
                }
                

                printMap(myMap);

                if (targetCell1.BaseSpawn == false && targetCell2.BaseSpawn == false && targetCell3.BaseSpawn == false && targetCell4.BaseSpawn == false && targetCell5.BaseSpawn == false){
                    ConsoleKey exitKeyV = ConsoleKey.Q;
                    ConsoleKey restartKeyV = ConsoleKey.E;
                    Console.Write("All targets down. Good job commander.      ");
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
        Console.Write("We ran out of time. We lost.     ");
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


        private static Cell moveCurrentCellH(Cell currentCellH)
        {
            //logic for check of possible move
            MovesH:
            Console.WriteLine("Time to move the heavy unit.");
            Console.WriteLine("Enter the row number to move to");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the column number to move to");
            int currentColumn = int.Parse(Console.ReadLine());
            if(myMap.MarkPossibleNextMoves(currentCellH, "Heavy").Contains(myMap.Grid[currentRow, currentColumn]) == false)
            {
                Console.WriteLine("Location out of range. Please make a move in range.");
                goto MovesH;
            }

            return myMap.Grid[currentRow, currentColumn];
        }

        private static Cell moveCurrentCellS(Cell currentCellS)
        {
            //logic for check of possible move
            MovesS:
            Console.WriteLine("Time to move the Scout.");
            Console.WriteLine("Enter the row number to move to");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the column number to move to");
            int currentColumn = int.Parse(Console.ReadLine());
            if(myMap.MarkPossibleNextMoves(currentCellS, "Scout").Contains(myMap.Grid[currentRow, currentColumn]) == false)
            {
                Console.WriteLine("Location out of range. Please make a move in range.");
                goto MovesS;
            }

            return myMap.Grid[currentRow, currentColumn];
        }

        private static Cell toTargetCell1()
        {
            return myMap.Grid[4,2];
        }
        
        private static Cell toTargetCell2()
        {
            return myMap.Grid[4,5];
        }

        private static Cell toTargetCell3()
        {
            return myMap.Grid[3,5];
        }

        private static Cell toTargetCell4()
        {
            return myMap.Grid[5,7];
        }

        private static Cell toTargetCell5()
        {
            return myMap.Grid[7,7];
        }

        private static Cell toStartCellH()
        {
            return myMap.Grid[2,2];
        }

        private static Cell toStartCellS()
        {
            return myMap.Grid[9,9];
        }


        private static void printMap(Map myMap)
        {
            for (int i = 1; i < myMap.Size; i++)
                {
                    for (int j = 1; j < myMap.Size; j++)
                    {
                        Cell c = myMap.Grid[i, j];

                        if (c.PlayerSpawnH == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("|-H-|");
                            Console.ResetColor();
                        } else if (c.PlayerSpawnS == true) 
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("|-S-|");
                            Console.ResetColor();
                        } else if (c.CurrentlyOccupiedH == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("|-H-|");
                            Console.ResetColor();
                        } else if (c.CurrentlyOccupiedS == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("|-S-|");
                            Console.ResetColor();
                        } else if (c.BaseSpawn == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("|-T-|");
                            Console.ResetColor();
                        } else if (c.PossibleNextMovesH == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("|-H-|");
                            Console.ResetColor();
                        } else if (c.PossibleNextMovesS== true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("|-S-|");
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
