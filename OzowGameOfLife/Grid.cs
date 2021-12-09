using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzowGameOfLife
{
    public class Grid
    {
        public Grid(List<Cell> cells)
        {
            Cells = cells;
        }

        public Grid(int width, int height, bool randomlySeeded)
        {
            Cells = new List<Cell>();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (randomlySeeded)
                        Cells.Add(new Cell(x, y));
                    else
                        Cells.Add(new Cell(x, y, false));
                }
            }
        }

        public List<Cell> Cells { get; set; }

        public Cell GetCell(int x, int y)
        {
            Cell result = new Cell();

            result = Cells.FirstOrDefault(t => t.X == x && t.Y == y);

            return result;
        }

        public bool LifeExists()
        {
            return Cells.Where(t => t.IsAlive).Count() > 0;
        }

        public List<Cell> GetNeighborCells(Cell currentCell)
        {
            List<Cell> result = new List<Cell>();

            result = Cells.Where(t => t.X >= currentCell.X - 1 &&
                              t.X <= currentCell.X + 1 &&
                              t.Y >= currentCell.Y - 1 &&
                              t.Y <= currentCell.Y + 1 &&
                              t != currentCell).ToList();

            return result;
        }

        public string GenerateCurrentGridOutput()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < Cells.Max(t => t.Y) + 1; y++)
            {
                string row = string.Empty;

                for (int x = 0; x < Cells.Max(t => t.X) + 1; x++)
                {
                    var alive = Cells.FirstOrDefault(t => t.X == x && t.Y == y).IsAlive;
                    row += alive == true ? "█" : "░";
                }
                sb.AppendLine(row);
            }

            return sb.ToString();
        }

        public void UpdateGrid()
        {
            List<Cell> newCells = new List<Cell>();

            //Seed newCells with current Cell information
            Cells.ForEach(t => newCells.Add(new Cell(t.X, t.Y, t.IsAlive)));

            foreach(var cell in Cells)
            {
                var neighbors = GetNeighborCells(cell);
                var aliveNeighbors = neighbors.Where(t => t.IsAlive).Count();

                var newCell = newCells.FirstOrDefault(t => t.X == cell.X && t.Y == cell.Y);

                if (cell.IsAlive && (aliveNeighbors < 2 || aliveNeighbors > 3))
                {
                    newCell.IsAlive = false;
                }
                else if(!cell.IsAlive && aliveNeighbors == 3)
                {
                    newCell.IsAlive = true;
                }
            }

            //Map newCells to the Cells list
            Cells = newCells;
        }
    }
}
