using System;
using terrain_gen;

Console.WriteLine("Welcome to a prototype of terrain generation!\n");

int matXSize = 50;
int matYSize = 25;

Matrix templateMat = new Matrix(matXSize, matYSize, 0, 70);

Console.WriteLine("Template Matrix: \n\n" + templateMat.GenerateTerrain());

templateMat.Smooth(2);

Console.WriteLine("Template Matrix: \n\n" + templateMat.GenerateTerrain());
