using System;
using System.Collections.Generic;

namespace MapModel
{
        public class Cell
        { 
            // All references
            public int RowNumber { get; set;}
            public int ColumnNumber { get; set; }
            public bool CurrentlyOccupiedH { get; set; }
            public bool CurrentlyOccupiedS { get; set; }
            public bool PossibleNextMovesH { get; set; }
            public bool PossibleNextMovesS { get; set; }
            public bool BaseSpawn { get; set; }
            public bool PlayerSpawnS { get; set; }
            public bool PlayerSpawnH {get; set; }

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
                // Set size of board and fill with cells
                Size = s;

                Grid = new Cell[Size, Size];

                for (int i = 1; i < Size; i++)
                {
                    for (int j = 1; j < Size; j++)
                    {
                        Grid[i,j] = new Cell(i, j);
                    }
                }
            }  

            public void SetBaseSpawn( Cell targetCell, string unitNum)
            {
                // Old target interface 
                switch (unitNum)
                {
                    case "Unit1":
                        Grid[targetCell.RowNumber, targetCell.ColumnNumber].BaseSpawn = true;
                    break;

                    case "Unit2":
                        Grid[targetCell.RowNumber, targetCell.ColumnNumber].BaseSpawn = true;
                    break;

                    case "Unit3":
                        Grid[targetCell.RowNumber, targetCell.ColumnNumber].BaseSpawn = true;
                    break;

                    case "Unit4":
                        Grid[targetCell.RowNumber, targetCell.ColumnNumber].BaseSpawn = true;
                    break;

                    case "Unit5":
                        Grid[targetCell.RowNumber, targetCell.ColumnNumber].BaseSpawn = true;
                    break;
                }
            }

            public void SetPlayerSpawn( Cell startCell, string UnitType)
            {
                // Unit spawn interface
                switch (UnitType)
                {
                    case "Heavy":
                        Grid[startCell.RowNumber, startCell.ColumnNumber].PlayerSpawnH = true;
                    break;

                    case "Scout":
                        Grid[startCell.RowNumber, startCell.ColumnNumber].PlayerSpawnS = true;
                    break;
                }
            }
                
            public List<Cell> MarkPossibleNextMoves( Cell currentCell, string unitType )
            {
                switch (unitType)
                {
                    case "Heavy" :// Check for possible next move. Send those to list for return to move entry

                        for (int i = 1; i < Size; i++)
                        {
                            for (int j = 1; j < Size; j++)
                            {       
                                Grid[i,j].PlayerSpawnH = false;
                                Grid[i,j].CurrentlyOccupiedH = false;
                                Grid[i,j].PossibleNextMovesH = false;
                            }
                        }


                        if(currentCell.RowNumber != 9){
                            Grid[currentCell.RowNumber + 1, currentCell.ColumnNumber].PossibleNextMovesH = true;
                        }
                        if(currentCell.RowNumber != 1){
                            Grid[currentCell.RowNumber - 1, currentCell.ColumnNumber].PossibleNextMovesH = true;
                        }
                        if(currentCell.ColumnNumber != 1){
                            Grid[currentCell.RowNumber, currentCell.ColumnNumber - 1].PossibleNextMovesH = true;
                        }
                        if(currentCell.ColumnNumber != 9){
                            Grid[currentCell.RowNumber, currentCell.ColumnNumber + 1].PossibleNextMovesH = true;
                        }

                        var possibleMovesH = new List<Cell>();
                        for (int i = 1; i < Size; i++)
                        {
                            for (int j = 1; j < Size; j++)
                            {
                                if (Grid[i,j].PossibleNextMovesH)
                                {
                                    possibleMovesH.Add(Grid[i,j]);
                                }
                            }
                        }
                        return possibleMovesH;

                    case "Scout" :

                        for (int i = 1; i < Size; i++)
                        {
                            for (int j = 1; j < Size; j++)
                            {       
                                Grid[i,j].PlayerSpawnS = false;
                                Grid[i,j].CurrentlyOccupiedS = false;
                                Grid[i,j].PossibleNextMovesS = false;
                            }
                        }

                        if(currentCell.RowNumber != 9 && currentCell.RowNumber != 8){
                            Grid[currentCell.RowNumber + 2, currentCell.ColumnNumber].PossibleNextMovesS = true;
                        }
                        if(currentCell.RowNumber != 1 && currentCell.RowNumber != 2){
                            Grid[currentCell.RowNumber - 2, currentCell.ColumnNumber].PossibleNextMovesS = true;
                        }
                        if(currentCell.ColumnNumber != 8 && currentCell.ColumnNumber != 9){
                            Grid[currentCell.RowNumber, currentCell.ColumnNumber + 2].PossibleNextMovesS = true;
                        }
                        if(currentCell.ColumnNumber != 2 && currentCell.ColumnNumber != 1){
                            Grid[currentCell.RowNumber, currentCell.ColumnNumber - 2].PossibleNextMovesS = true;
                        }
                        if(currentCell.RowNumber !=1 && currentCell.ColumnNumber != 1){
                            Grid[currentCell.RowNumber - 1, currentCell.ColumnNumber -1].PossibleNextMovesS = true;
                        }
                        if(currentCell.RowNumber !=9 && currentCell.ColumnNumber != 9){
                            Grid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].PossibleNextMovesS = true;
                        }
                        if(currentCell.RowNumber !=9 && currentCell.ColumnNumber != 1){
                            Grid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].PossibleNextMovesS = true;
                        }
                        if(currentCell.RowNumber !=1 && currentCell.ColumnNumber != 9){
                        Grid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].PossibleNextMovesS = true;
                        }

                        var possibleMovesS = new List<Cell>();
                        for (int i = 1; i < Size; i++)
                        {
                            for (int j = 1; j < Size; j++)
                            {
                                if (Grid[i,j].PossibleNextMovesS)
                                {
                                    possibleMovesS.Add(Grid[i,j]);
                                }
                            }
                        }
                        return possibleMovesS;
                }
            // empty return to stop error
            var empty = new List<Cell>();
            return empty;
           
            }
                
        }
}