using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes3D;

public class Sidewinder {

    public static void Run(Grid grid) {
        var random = new Random();
        for (int i = 0; i < grid.Rows; i++) {
            var run = new List<Cell>();
            for (int j = 0; j < grid.Columns; j++) {
                var cell = grid[i, j];
                if (cell == null) {
                    cell = new Cell(-1, -1);
                }
                run.Add(cell);

                bool isAtEasternBoundary = cell.East == null;
                bool isAtNorthernBoundary = cell.North == null;

                bool shouldCloseOut = isAtEasternBoundary || (!isAtNorthernBoundary && random.Next(2) == 0);

                if (shouldCloseOut) {
                    int index = random.Next(0, run.Count);
                    var member = run[index];
                    if (member.North != null) {
                        member.Link(member.North);
                    }
                    run.Clear();
                }
                else {
                    if (cell.East != null) cell.Link(cell.East);
                }

            }
        }
    }
}
