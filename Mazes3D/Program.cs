

using Mazes3D;

var grid = new Grid(5, 5);

BinaryTree.Run(grid);

var start = grid[0, 0];
var distances = start.GetDistances();

grid.Distances = distances;

Console.WriteLine("Binary Tree");
Console.WriteLine(grid);

grid.Distances = distances.PathTo(grid[grid.Rows - 1, 0]);
Console.WriteLine(grid);

grid = new Grid(5, 5);
RecursiveBacktracker.Run(grid);
Console.WriteLine("Aldous-Broder");
Console.WriteLine(grid);
Console.WriteLine(grid.GetDeadends().Count);


/*
Console.WriteLine("Sidewinder");
grid = new Grid(4, 4);
Sidewinder.Run(grid);
Console.WriteLine(grid);
*/
