using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes3D;  

public class Distances {

    public Dictionary<Cell, int> DistanceLookup;

    public Cell Root { get; set; }

    public int? this[Cell cell] {
        get {
            if (cell == null) {
                return null;
            }
            if (DistanceLookup.ContainsKey(cell) == false) {
                return null;
            }
            return DistanceLookup[cell]; 
        }
        set {
            if (value == null) {
                return;
            }
            DistanceLookup[cell] = value.Value; 
        }
    }

    public Distances(Cell cell) {
        Root = cell;
        DistanceLookup = new Dictionary<Cell, int>();
        DistanceLookup.Add(cell, 0);
    }

    public Distances PathTo(Cell goal) {
        var current = goal;

        var breadcrumbs = new Distances(Root);
        breadcrumbs[current] = DistanceLookup[current];

        while (current != Root) {
            foreach (var neighbor in current.Links) {
                if (DistanceLookup[neighbor] < DistanceLookup[current]) {
                    breadcrumbs[neighbor] = DistanceLookup[neighbor];
                    current = neighbor;
                }
            }
        }

        return breadcrumbs;
    }
}
