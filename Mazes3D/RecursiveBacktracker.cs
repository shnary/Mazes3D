using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes3D; 
public class RecursiveBacktracker {
    public static void Run(Grid grid) {
        var stack = new Stack<Cell>();

        stack.Push(grid.GetRandomCell());

        while (stack.Count > 0) {
            var current = stack.Peek();
            var neighbors = current.GetNeighbors().Where(t => t.Links.Any() == false).ToList();

            if (neighbors.Any() == false) {
                stack.Pop();
            }
            else {
                var random = new Random();
                int index = random.Next(0, neighbors.Count);
                var neighbor = neighbors[index];
                current.Link(neighbor);
                stack.Push(neighbor);
            }
        }
    }
}
