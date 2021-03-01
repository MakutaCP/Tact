using System;

namespace Tact
{
        class Cell
        { 
            public int RowNumber { get; set;}
            public int ColumnNumber { get; set; }
            public bool CurrentlyOccupied { get; set; }
            public bool PossiblrNextMoves { get; set; }
        }

        class Map 
        {
            public int Size { get; set; }

            public Cell[,] Grid { get; set;}

            public Map (int s)
        }
}