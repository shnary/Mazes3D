using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes3D;

public class Cell {

    public Cell North;
    public Cell South;
    public Cell West;
    public Cell East;

    public int Row { get; private set; }
    public int Column { get; private set; }

    private readonly Dictionary<Cell, bool> _links;

    private readonly List<Cell> _neighbors;

    public IEnumerable<Cell> Links => _links.Keys;

    public Cell(int row, int column) {
        _neighbors = new List<Cell>();
        _links = new Dictionary<Cell, bool>();
        Row = row;
        Column = column;
    }

    public IEnumerable<Cell> GetNeighbors() {
        if (North != null) yield return North;
        if (South != null) yield return South;
        if (West != null) yield return West;
        if (East != null) yield return East;
    }

    public void Link(Cell cell, bool bidirectional=true) {
        _links[cell] = true;
        if (bidirectional) {
            cell.Link(this, false);
        }
    }

    public void UnLink(Cell cell, bool bidirectional=true) {
        _links.Remove(cell);
        if (bidirectional) {
            cell.UnLink(this, false);
        }
    }

    public bool IsLinked(Cell cell) {
        if (cell == null) return false;
        if(_links.ContainsKey(cell) == false) return false;

        return _links[cell];
    }

    public Distances GetDistances() {
        var distances = new Distances(this);
        var frontier = new List<Cell> { this };

        while (frontier.Count > 0) {

            var newFrontier = new List<Cell>();

            foreach (var cell in frontier) {
                foreach (var link in cell._links.Keys) {
                    if (distances[link] != null) {
                        // Already visited.
                        continue;
                    }

                    distances[link] = distances[cell] + 1;
                    newFrontier.Add(link);
                }
            }

            frontier = newFrontier;
        }

        return distances;
    }
}
