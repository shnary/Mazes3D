using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes3D;

public class Grid {

    public int Rows { get; private set; }
    public int Columns { get; private set; }

    private readonly Cell[,] _cells;

    public int Size => Rows * Columns;

    public Cell this[int row, int column] {
        get {
            if (row < 0 || column < 0) { return null; }
            if (row >= Rows || column >= Columns) { return null; }
            return _cells[row, column]; 
        }
        set { _cells[row, column] = value; }
    }

    public Grid(int rows, int columns) {
        Rows = rows;
        Columns = columns;
        _cells = new Cell[Rows, Columns];
        ConfigureCells();
    }

    public void ConfigureCells() {
        for (int i = 0; i < Rows; i++) {
            for (int j = 0; j < Columns; j++) {
                _cells[i, j] = new Cell(i, j);
            }
        }

        for (int i = 0; i < Rows; i++) {
            for (int j = 0; j < Columns; j++) {
                var cell = _cells[i, j];
                cell.North = this[i - 1, j];
                cell.South = this[i + 1, j];
                cell.West = this[i, j - 1];
                cell.East = this[i, j + 1];
            }
        }
    }

    public Cell GetRandomCell() {
        var random = new Random();
        int row = random.Next(0, Rows);
        int column = random.Next(0, Columns);
        return _cells[row, column];
    }

    public string Print() {
        string walls = string.Concat(Enumerable.Repeat("---+", Columns));
        string output = "+" + walls + "\n";


        for (int i = 0; i < Rows; i++) {
            string top = "|";
            string bottom = "+";

            for (int j = 0; j < Columns; j++) {
                var cell = _cells[i, j];
                if (cell == null) {
                    cell = new Cell(-1, -1);
                }

                string body = "   ";
                string eastBoundary = cell.IsLinked(cell.East) ? " " : "|";

                top += body;
                top += eastBoundary;

                string southBoundary = cell.IsLinked(cell.South) ? "   " : "---";
                string corner = "+";
                bottom += southBoundary;
                bottom += corner; 
            }

            output += top;
            output += "\n";
            output += bottom;
            output += "\n";
        }

        return output;
    }

    public string ToPNG(int cellSize=10) {

        int imgWidth = cellSize * Columns;
        int imgHeight = cellSize * Rows;

        var backgroundColo = Color.White;
        var wallColor = Color.Black;

        using var img = new Image<Rgba32>(imgWidth + 1, imgHeight + 1);


        for (int i = 0; i < Rows; i++) {
            for (int j = 0; j < Columns; j++) {

                var cell = _cells[i, j];
                if (cell == null) {
                    cell = new Cell(-1, -1);
                }

                int x1 = cell.Column * cellSize;
                int y1 = cell.Row * cellSize;
                int x2 = (cell.Column + 1) * cellSize;
                int y2 = (cell.Row + 1) * cellSize;

                img.Mutate(ctx => {
                    // TODO: Implement here
                });
            }
        }

            return "";
    }

    public override string ToString() {
        return Print();
    }
}
