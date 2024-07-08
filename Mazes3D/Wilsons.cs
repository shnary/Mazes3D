using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes3D; 
public class Wilsons {

    // BUG: Enters into infinite loop.
    public static void Run(Grid grid) {
        var unvisitedList = new List<Cell>();

        for (int i = 0; i < grid.Rows; i++) {
            for (int j = 0; j < grid.Columns; j++) {
                var cell = grid[i, j];
                unvisitedList.Add(cell);
            }
        }

        var random = new Random();

        var index = random.Next(0, unvisitedList.Count);
        var firstRandom = unvisitedList[index];
        unvisitedList.Remove(firstRandom);

        while (unvisitedList.Count > 0) {
            index = random.Next(0, unvisitedList.Count);
            var randomUnvisited = unvisitedList[index];
            var path = new List<Cell> { randomUnvisited };

            while (unvisitedList.Contains(randomUnvisited)) {
                var neighbors = randomUnvisited.GetNeighbors().ToList();
                int randNeighborIndex = random.Next(0, neighbors.Count);
                randomUnvisited = neighbors[randNeighborIndex];

                var position = path.IndexOf(randomUnvisited);
                if (position == -1) {
                    // Doesn't exist.
                    path.Add(randomUnvisited);
                }
                else {
                    // Truncate the path. Eliminate the loop.
                    path = path[0..position];
                }
            }

            for (int i = 0; i < path.Count - 2; i++) {
                path[i].Link(path[i + 1]);
                unvisitedList.Remove(path[i]);
            }
        }
    }
}
