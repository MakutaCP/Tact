using System;

namespace MapModel
{
        public class Cell
        { 
            public int RowNumber { get; set;}
            public int ColumnNumber { get; set; }
            public bool CurrentlyOccupied { get; set; }
            public bool PossibleNextMoves { get; set; }

            public Cell(int x, int y)
            {
                RowNumber = x;
                ColumnNumber = y;
            }
        }

        public class Map 
        {
            public int Size { get; set; }

            public Cell[,] Grid { get; set;}

            public Map (int s)
            {
                // Size of board is s. Only makes squares for now.
                Size = s;

                Grid = new Cell[Size, Size];

                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        Grid[i,j] = new Cell(i, j);
                    }
                }
            }    
                
            public void MarkPossibleNextMoves( Cell currentCell, string unitType )
                {
                     //clear old possible moves
                    for (int i = 0; i < Size; i++)
                    {
                        for (int j = 0; j < Size; j++)
                        {
                            Grid[i,j].PossibleNextMoves = false;
                        }
                    }
            
                    switch (unitType)
                    {
                        case "Heavy" :
                            Grid[currentCell.RowNumber + 1, currentCell.ColumnNumber].PossibleNextMoves = true;
                            Grid[currentCell.RowNumber - 1, currentCell.ColumnNumber].PossibleNextMoves = true;
                            Grid[currentCell.RowNumber, currentCell.ColumnNumber - 1].PossibleNextMoves = true;
                            Grid[currentCell.RowNumber, currentCell.ColumnNumber + 1].PossibleNextMoves = true;

                            break;

                        case "Scout" :
                            break;

                        case "Normal" :
                            break;
                
                        default:
                             break;
                    }
                }
                
        }
}