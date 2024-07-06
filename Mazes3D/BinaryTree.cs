using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes3D;

public class BinaryTree {

    public static void Run(Grid grid) {

        var random = new Random();
        for (int i = 0; i < grid.Rows; i++) {
            for (int j = 0; j < grid.Columns; j++) {
                var neighbors = new List<Cell>();
                var cell = grid[i, j];

                if (cell.North != null) neighbors.Add(cell.North);
                if (cell.East != null) neighbors.Add(cell.East);

                if (neighbors.Count == 0) continue;

                int index = random.Next(0, neighbors.Count);
                var neighbor = neighbors[index];

                if (neighbor != null) {
                    cell.Link(neighbor);
                }
            }
        }

    }
}
