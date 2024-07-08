using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes3D; 
public class AldousBroder {

    public static void Run(Grid grid) {
        var cell = grid.GetRandomCell();
        int unvisitedCount = grid.Size - 1;

        var random = new Random();

        while (unvisitedCount > 0) {

            var neighbors = cell.GetNeighbors().ToList();
            int index = random.Next(0, neighbors.Count);
            var randomNeighbor = neighbors[index];

            if (randomNeighbor.Links.Count() == 0) {
                cell.Link(randomNeighbor);
                unvisitedCount -= 1;
            }

            cell = randomNeighbor;
        }
    }
}
