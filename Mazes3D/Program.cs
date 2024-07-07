

using Mazes3D;

var grid = new Grid(5, 5);

BinaryTree.Run(grid);

var start = grid[0, 0];
var distances = start.GetDistances();

grid.Distances = distances;

Console.WriteLine("Binary Tree");
Console.WriteLine(grid);

/*
Console.WriteLine("Sidewinder");
grid = new Grid(4, 4);
Sidewinder.Run(grid);
Console.WriteLine(grid);
*/
