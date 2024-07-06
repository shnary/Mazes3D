

using Mazes3D;

var grid = new Grid(4, 4);

BinaryTree.Run(grid);

Console.WriteLine("Binary Tree");
Console.WriteLine(grid);

Console.WriteLine("Sidewinder");
grid = new Grid(4, 4);
Sidewinder.Run(grid);
Console.WriteLine(grid);
