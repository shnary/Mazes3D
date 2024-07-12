using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes3D; 
public class HuntAndKill {

    public static void Run(Grid grid) {
        var current = grid.GetRandomCell();

        while (current != null) {
            var unvisitedNeighbors = current.GetNeighbors().Where(t => !t.Links.Any()).ToList();

            if (unvisitedNeighbors.Any()) {
                var random = new Random();
                int index = random.Next(0, unvisitedNeighbors.Count);
                var neighbor = unvisitedNeighbors[index];
                current.Link(neighbor);
                current = neighbor;
            }
            else {
                current = null;

                for (int i = 0; i < grid.Rows; i++) {
                    for (int j = 0; j < grid.Columns; j++) {
                        var cell = grid[i, j];
                        var visitedNeighbors = cell.GetNeighbors().Where(t => t.Links.Any()).ToList();
                        if (cell.Links.Any() == false && visitedNeighbors.Any()) {
                            current = cell;
                            
                            var random = new Random();
                            int index = random.Next(0, visitedNeighbors.Count);
                            var neighbor = visitedNeighbors[index];

                            current.Link(neighbor);

                            break;
                        }
                    } 
                }
            }
        }
    }
}
